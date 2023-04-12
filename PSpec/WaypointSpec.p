// requirements for the waypoints mode

// spec machine implementation: abstract the drone into a 3 step sequential transition
// 1. Init (Mission Start)
// 2. ProcessMission
// 3. MissionComplete

// safety property: when the MissionComplete event is sent, all waypoints must be visited
// liveness property: the intermediate state should be temporary and the drone should not terminate in them
//                    eventually all waypoints are visited

spec WaypointCorrect observes eMissionStart, eMissionComplete, eProceedToWaypoint, eHoverAtWaypoint, eAdvanceWaypoint {
  start state Init {
    on eMissionStart goto ExecutingMission;
  }

  // the drone cannot terminate on executing mission
  hot state ExecutingMission {
    on eProceedToWaypoint, eHoverAtWaypoint, eAdvanceWaypoint do {
      // do nothing, stay in the same state
    }

    on eMissionComplete do (missionCompleteResponse: tMissionComplete){
      // FIXME: this is here to trigger an example bug.
      assert missionCompleteResponse.number_of_waypoints == missionCompleteResponse.current_waypoint_index, format ("Drone did not visit all the waypoints. Current waypoint index = {0}, Number of waypoints = {1}", missionCompleteResponse.current_waypoint_index, missionCompleteResponse.number_of_waypoints);

      // correct assertion
      assert missionCompleteResponse.number_of_waypoints == missionCompleteResponse.current_waypoint_index + 1, format ("Drone did not visit all the waypoints. Current waypoint index = {0}, Number of waypoints = {1}", missionCompleteResponse.current_waypoint_index, missionCompleteResponse.number_of_waypoints);

      goto MissionComplete;
    }
  }

  cold state MissionComplete {
    entry {
      // do nothing, allow the spec to terminate on this state
      print format ("[Waypoint Spec] Model Check Complete!");
    }
  }
}
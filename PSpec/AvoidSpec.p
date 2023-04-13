// safety/liveness: every intrusion detected should accompanied by a manuveur complete even 
// liveness: the system should never terminate on Avoidance Manevuring state (hot)

spec AvoidCorrect observes eAvoidStart, eIntrusionDetected, eAvoidManeuverComplete, eAvoidModeless {
  var detection_counter : int;
  var avoidance_counter : int;

  start state Init {
    on eAvoidStart do {
      detection_counter = 0;
      avoidance_counter = 0;

      goto DetectingIntrusion;
    }
  }

  state DetectingIntrusion {
    on eIntrusionDetected do {
      detection_counter = detection_counter + 1;

      goto AvoidManeuver;
    }
  }

  // should not terminate on 
  hot state AvoidManeuver {
    on eAvoidManeuverComplete do {
      avoidance_counter = avoidance_counter + 1;

      // this assertion states that each intruding aircraft should be accompanied by an avoidance maneuver
      // FIXME: this assertion is not working
      assert (detection_counter != avoidance_counter), format ("Detection Avoidance Counter Mismatch! detection_counter = {0}, avoidance_counter = {1}", detection_counter, avoidance_counter);

      // this is the correct assertion
      // assert (detection_counter == avoidance_counter), format ("Detection Avoidance Counter Mismatch! detection_counter = {0}, avoidance_counter = {1}", detection_counter, avoidance_counter);

      goto DetectingIntrusion;
    }

    on eAvoidModeless do {
      goto Modeless;
    }
  }

  state Modeless {
    // do nothing
  }
}
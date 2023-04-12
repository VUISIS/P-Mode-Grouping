// safety/liveness: every intrusion detected should accompanied by a manuveur complete even 
// liveness: the system should never terminate on Avoidance Manevuring state (hot)

spec AvoidCorrect observes eMissionStart {
  start state Init {
    // on eMissionStart goto ExecutingMission;
  }
}
// only on modeless state drone allows mode switching
// it should achieve both objectives
spec GlobalCorrect observes eMissionStart {
  start state Init {
    // on eMissionStart goto ExecutingMission;
  }
}
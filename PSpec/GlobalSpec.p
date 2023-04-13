// only on modeless state drone allows mode switching
// it should achieve both objectives

// specification, all the eIntrusionDetected events must be handled immediately 
// without the waypoint-related manuveurs

spec GlobalCorrect observes eMissionStart {
  start state Init {
  }
}
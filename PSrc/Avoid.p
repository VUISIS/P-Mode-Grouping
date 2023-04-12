// 
// type tPongResponse = (source : Pong);

// the avoidance mode is meant to be enabled always
event eAvoidStart;
event eIntrusionDetected;
event eAvoidManeuverComplete;

machine Avoid
{
  var number_of_intruding_aircraft : int;

  start state Init {
    entry (number_of_intruding_aircraft: int) {
      number_of_intruding_aircraft = number_of_intruding_aircraft;
    }
  }

  state DetectingIntrusion {

  }

  state AvoidManeuver {

  }
}
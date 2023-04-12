// 
// type tPongResponse = (source : Pong);

machine Avoid
{
  start state Init {
    entry  {
    }
  }

  // state Pong {
  //   // wait for ePing event 
  //   // note that ping machine will call pong machine first
  //   on ePing do (pingResponse: tPingResponse) {
  //     counter = counter + 1;
  //     print format ("Pong called, counter = {0}", counter);

  //     // send event ePong to ping machine
  //     send pingResponse.source, ePong, (source = this,); 
  //   }
  // }
}
// test driver
// the main entry point of the P program
machine Test {
  start state Init {
    entry {
      new Waypoint(10);
      // assert false, "hello";
      // new Avoid();
    }
  }
}

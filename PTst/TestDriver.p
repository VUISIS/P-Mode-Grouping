// test driver
// the main entry point of the P program
machine Test_Waypoint {
  start state Init {
    entry {
      new Waypoint(10);
    }
  }
}


machine Test_Avoid {
  start state Init {
    entry {
      new Avoid(10);
    }
  }
}


machine Test_Global {
  start state Init {
    entry {
      // new Avoid(10);
    }
  }
}


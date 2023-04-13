# Usage
```
p compile # compile the PSrc, PSpec and PTst
p check   # model check the P model against the PSpec.
          # the specific spec/property must be declared via assert in PTst

# Compile a Minimal P Model
- setup a source state machine (files: Ping.p, Pong.p)
- setup module systems (files: PingModules.p) (i.e. module <module name> = { <state machine
  name>}
- setup test script and test driver (files: TestDriver.p, TestScript.p)


# FAQ
- Error: Failed to get test method '' from assembly 'Hello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'
    - reinstall or update the p programming language

- global variable initialized to 0 or -1
    - use different variable names for the variable that is passed in and the global variable.

# Waypoint mode
given a set of waypoints, the drone should follow the waypoint
- safety property: the drone should visit all the waypoints upon mission completion (using index == number_of_waypoints - 1)
- liveness property: the mission should not terminate during execution of the mission (hot keyword)


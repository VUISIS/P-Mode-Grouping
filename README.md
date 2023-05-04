# Mode Grouping Challenge - VSPELLS Project Engagement 3
# Introduction
This P model is a state machine based model that models the auto mode (follow a set of mission waypoints) and the ADS-B mode (avoiding other aircrafts).

For each of the models, it checks a safety and liveness property
- auto mode (waypoint mode): 
  - safety: when the MissionComplete event is sent, all waypoints must be visited
  - liveness: the intermediate state should be temporary and the drone should not terminate in them / eventually all waypoints are visited
- ADS-B mode (avoidance mode):
  - safety: every intrusion detected must be accompanied by a manuveuring action.
  - liveness: the mode should not terminate on a manuveuring state (while trying to avoid a collision)
# Installation
## P programming language
Follow the tutorial on `https://p-org.github.io/P/getstarted/install/` to download .NET framework and P tool. In the model grouping project, we use P `version 2.0.6.0` and .NET `version 7.0.203`. Any later versions should be backward compatible.

## Mode Grouping P model
Clone the GitHub repository by executing the following command.
```
git clone git@github.com:VUISIS/P-Mode-Grouping.git
cd P-Mode-Grouping/
```

# Usage
```
p compile # compile the PSrc, PSpec and PTst
p check   # model check the P model against the PSpec.
          # the specific spec/property must be declared via assert in PTst
```

For invoking specific test cases, use the following command
```
p check -tc <test cases> 
```
There are 3 possible actions for the test cases, namely, waypoint, avoid and global.

# FAQ
## How to Compile a Minimal P Model
- setup a source state machine (files: Ping.p, Pong.p)
- setup module systems (files: PingModules.p) (i.e. module <module name> = { <state machine
  name>}
- setup test script and test driver (files: TestDriver.p, TestScript.p)

## Error: Failed to get test method ""
- Error: Failed to get test method '' from assembly 'Hello, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'
    - reinstall or update the p programming language

- global variable initialized to 0 or -1
    - use different variable names for the variable that is passed in and the global variable.

<!-- # Waypoint mode
given a set of waypoints, the drone should follow the waypoint
- safety property: the drone should visit all the waypoints upon mission completion (using index == number_of_waypoints - 1)
- liveness property: the mission should not terminate during execution of the mission (hot keyword) -->


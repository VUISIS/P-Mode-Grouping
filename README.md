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
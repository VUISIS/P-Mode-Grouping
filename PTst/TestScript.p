test waypoint [main=Test_Waypoint]:
  assert WaypointCorrect in
  (union Waypoint, Avoid, { Test_Waypoint });

test avoid [main=Test_Avoid]:
  assert AvoidCorrect in
  (union Waypoint, Avoid, { Test_Avoid });

test global [main=Test_Global]:
  assert GlobalCorrect in
  (union Waypoint, Avoid, { Test_Global });
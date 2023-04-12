using PChecker;
using PChecker.Actors;
using PChecker.Actors.Events;
using PChecker.Runtime;
using PChecker.Specifications;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Plang.CSharpRuntime;
using Plang.CSharpRuntime.Values;
using Plang.CSharpRuntime.Exceptions;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable 162, 219, 414, 1998
namespace PImplementation
{
}
namespace PImplementation
{
    internal partial class eAvoidStart : PEvent
    {
        public eAvoidStart() : base() {}
        public eAvoidStart (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eAvoidStart();}
    }
}
namespace PImplementation
{
    internal partial class eIntrusionDetected : PEvent
    {
        public eIntrusionDetected() : base() {}
        public eIntrusionDetected (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eIntrusionDetected();}
    }
}
namespace PImplementation
{
    internal partial class eAvoidManeuverComplete : PEvent
    {
        public eAvoidManeuverComplete() : base() {}
        public eAvoidManeuverComplete (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eAvoidManeuverComplete();}
    }
}
namespace PImplementation
{
    internal partial class eMissionStart : PEvent
    {
        public eMissionStart() : base() {}
        public eMissionStart (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eMissionStart();}
    }
}
namespace PImplementation
{
    internal partial class eMissionComplete : PEvent
    {
        public eMissionComplete() : base() {}
        public eMissionComplete (PrtNamedTuple payload): base(payload){ }
        public override IPrtValue Clone() { return new eMissionComplete();}
    }
}
namespace PImplementation
{
    internal partial class eProceedToWaypoint : PEvent
    {
        public eProceedToWaypoint() : base() {}
        public eProceedToWaypoint (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eProceedToWaypoint();}
    }
}
namespace PImplementation
{
    internal partial class eHoverAtWaypoint : PEvent
    {
        public eHoverAtWaypoint() : base() {}
        public eHoverAtWaypoint (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eHoverAtWaypoint();}
    }
}
namespace PImplementation
{
    internal partial class eAdvanceWaypoint : PEvent
    {
        public eAdvanceWaypoint() : base() {}
        public eAdvanceWaypoint (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eAdvanceWaypoint();}
    }
}
namespace PImplementation
{
    internal partial class eModeless : PEvent
    {
        public eModeless() : base() {}
        public eModeless (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eModeless();}
    }
}
namespace PImplementation
{
    internal partial class Avoid : PMachine
    {
        private PrtInt number_of_intruding_aircraft = ((PrtInt)0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(PrtInt val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PrtInt)value); }
        public Avoid() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eAvoidManeuverComplete));
            this.sends.Add(nameof(eAvoidStart));
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eIntrusionDetected));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eAvoidManeuverComplete));
            this.receives.Add(nameof(eAvoidStart));
            this.receives.Add(nameof(eHoverAtWaypoint));
            this.receives.Add(nameof(eIntrusionDetected));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eModeless));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon(Event currentMachine_dequeuedEvent)
        {
            Avoid currentMachine = this;
            PrtInt number_of_intruding_aircraft_1 = (PrtInt)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            number_of_intruding_aircraft_1 = (PrtInt)(((PrtInt)((IPrtValue)number_of_intruding_aircraft_1)?.Clone()));
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon))]
        class Init : State
        {
        }
        class DetectingIntrusion : State
        {
        }
        class AvoidManeuver : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Waypoint : PMachine
    {
        private PrtInt number_of_waypoints = ((PrtInt)0);
        private PrtInt current_waypoint_index = ((PrtInt)0);
        public class ConstructorEvent : PEvent{public ConstructorEvent(PrtInt val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((PrtInt)value); }
        public Waypoint() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eAvoidManeuverComplete));
            this.sends.Add(nameof(eAvoidStart));
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eIntrusionDetected));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eAvoidManeuverComplete));
            this.receives.Add(nameof(eAvoidStart));
            this.receives.Add(nameof(eHoverAtWaypoint));
            this.receives.Add(nameof(eIntrusionDetected));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eModeless));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_1(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PrtInt number_of_way_points = (PrtInt)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0 = ((PrtInt)0);
            PrtString TMP_tmp1 = ((PrtString)"");
            PMachineValue TMP_tmp2 = null;
            PEvent TMP_tmp3 = null;
            TMP_tmp0 = (PrtInt)(-(((PrtInt)1)));
            current_waypoint_index = TMP_tmp0;
            number_of_waypoints = (PrtInt)(((PrtInt)((IPrtValue)number_of_way_points)?.Clone()));
            TMP_tmp1 = (PrtString)(((PrtString) String.Format("[Waypoint] Waypoint Mode Initialized")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp1);
            TMP_tmp2 = (PMachineValue)(currentMachine.self);
            TMP_tmp3 = (PEvent)(new eMissionStart(null));
            currentMachine.TrySendEvent(TMP_tmp2, (Event)TMP_tmp3);
            currentMachine.TryGotoState<AdvanceWaypoint>();
            return;
        }
        public void Anon_2(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PrtInt TMP_tmp0_1 = ((PrtInt)0);
            PrtInt TMP_tmp1_1 = ((PrtInt)0);
            PrtString TMP_tmp2_1 = ((PrtString)"");
            PMachineValue TMP_tmp3_1 = null;
            PEvent TMP_tmp4 = null;
            TMP_tmp0_1 = (PrtInt)((current_waypoint_index) + (((PrtInt)1)));
            current_waypoint_index = TMP_tmp0_1;
            TMP_tmp1_1 = (PrtInt)(((PrtInt)((IPrtValue)current_waypoint_index)?.Clone()));
            TMP_tmp2_1 = (PrtString)(((PrtString) String.Format("[Waypoint] Current Waypoint Index = {0}",TMP_tmp1_1)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_1);
            TMP_tmp3_1 = (PMachineValue)(currentMachine.self);
            TMP_tmp4 = (PEvent)(new eProceedToWaypoint(null));
            currentMachine.TrySendEvent(TMP_tmp3_1, (Event)TMP_tmp4);
            currentMachine.TryGotoState<ProceedToWaypoint>();
            return;
        }
        public void Anon_3(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PMachineValue TMP_tmp0_2 = null;
            PEvent TMP_tmp1_2 = null;
            TMP_tmp0_2 = (PMachineValue)(currentMachine.self);
            TMP_tmp1_2 = (PEvent)(new eHoverAtWaypoint(null));
            currentMachine.TrySendEvent(TMP_tmp0_2, (Event)TMP_tmp1_2);
            currentMachine.TryGotoState<HoverAtWaypoint>();
            return;
        }
        public void Anon_4(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PrtInt TMP_tmp0_3 = ((PrtInt)0);
            PrtBool TMP_tmp1_3 = ((PrtBool)false);
            PMachineValue TMP_tmp2_2 = null;
            PEvent TMP_tmp3_2 = null;
            PrtInt TMP_tmp4_1 = ((PrtInt)0);
            PrtInt TMP_tmp5 = ((PrtInt)0);
            PrtNamedTuple TMP_tmp6 = (new PrtNamedTuple(new string[]{"current_waypoint_index","number_of_waypoints"},((PrtInt)0), ((PrtInt)0)));
            PMachineValue TMP_tmp7 = null;
            PEvent TMP_tmp8 = null;
            TMP_tmp0_3 = (PrtInt)((number_of_waypoints) - (((PrtInt)1)));
            TMP_tmp1_3 = (PrtBool)((PrtValues.SafeEquals(current_waypoint_index,TMP_tmp0_3)));
            if (TMP_tmp1_3)
            {
                TMP_tmp2_2 = (PMachineValue)(currentMachine.self);
                TMP_tmp3_2 = (PEvent)(new eMissionComplete((new PrtNamedTuple(new string[]{"current_waypoint_index","number_of_waypoints"},((PrtInt)0), ((PrtInt)0)))));
                TMP_tmp4_1 = (PrtInt)(((PrtInt)((IPrtValue)current_waypoint_index)?.Clone()));
                TMP_tmp5 = (PrtInt)(((PrtInt)((IPrtValue)number_of_waypoints)?.Clone()));
                TMP_tmp6 = (PrtNamedTuple)((new PrtNamedTuple(new string[]{"current_waypoint_index","number_of_waypoints"}, TMP_tmp4_1, TMP_tmp5)));
                currentMachine.TrySendEvent(TMP_tmp2_2, (Event)TMP_tmp3_2, TMP_tmp6);
                currentMachine.TryGotoState<MissionComplete>();
                return;
            }
            else
            {
                TMP_tmp7 = (PMachineValue)(currentMachine.self);
                TMP_tmp8 = (PEvent)(new eAdvanceWaypoint(null));
                currentMachine.TrySendEvent(TMP_tmp7, (Event)TMP_tmp8);
                currentMachine.TryGotoState<AdvanceWaypoint>();
                return;
            }
        }
        public void Anon_5(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PrtInt TMP_tmp0_4 = ((PrtInt)0);
            PrtInt TMP_tmp1_4 = ((PrtInt)0);
            PrtString TMP_tmp2_3 = ((PrtString)"");
            PMachineValue TMP_tmp3_3 = null;
            PEvent TMP_tmp4_2 = null;
            TMP_tmp0_4 = (PrtInt)(((PrtInt)((IPrtValue)current_waypoint_index)?.Clone()));
            TMP_tmp1_4 = (PrtInt)(((PrtInt)((IPrtValue)number_of_waypoints)?.Clone()));
            TMP_tmp2_3 = (PrtString)(((PrtString) String.Format("[Waypoint] Mission completed. Current Waypoint Index = {0}, Number of Waypoints = {1}",TMP_tmp0_4,TMP_tmp1_4)));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp2_3);
            TMP_tmp3_3 = (PMachineValue)(currentMachine.self);
            TMP_tmp4_2 = (PEvent)(new eModeless(null));
            currentMachine.TrySendEvent(TMP_tmp3_3, (Event)TMP_tmp4_2);
            currentMachine.TryGotoState<Modeless>();
            return;
        }
        public void Anon_6(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_1))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_1))]
        class Init_1 : State
        {
        }
        [OnEventDoAction(typeof(eMissionStart), nameof(Anon_2))]
        [OnEventDoAction(typeof(eAdvanceWaypoint), nameof(Anon_2))]
        class AdvanceWaypoint : State
        {
        }
        [OnEventDoAction(typeof(eProceedToWaypoint), nameof(Anon_3))]
        class ProceedToWaypoint : State
        {
        }
        [OnEventDoAction(typeof(eHoverAtWaypoint), nameof(Anon_4))]
        class HoverAtWaypoint : State
        {
        }
        [OnEventDoAction(typeof(eMissionComplete), nameof(Anon_5))]
        class MissionComplete : State
        {
        }
        [OnEventDoAction(typeof(eModeless), nameof(Anon_6))]
        class Modeless : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class WaypointCorrect : PMonitor
    {
        static WaypointCorrect() {
            observes.Add(nameof(eAdvanceWaypoint));
            observes.Add(nameof(eHoverAtWaypoint));
            observes.Add(nameof(eMissionComplete));
            observes.Add(nameof(eMissionStart));
            observes.Add(nameof(eProceedToWaypoint));
        }
        
        public void Anon_7(Event currentMachine_dequeuedEvent)
        {
            WaypointCorrect currentMachine = this;
        }
        public void Anon_8(Event currentMachine_dequeuedEvent)
        {
            WaypointCorrect currentMachine = this;
            PrtNamedTuple missionCompleteResponse = (PrtNamedTuple)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            PrtInt TMP_tmp0_5 = ((PrtInt)0);
            PrtInt TMP_tmp1_5 = ((PrtInt)0);
            PrtBool TMP_tmp2_4 = ((PrtBool)false);
            PrtInt TMP_tmp3_4 = ((PrtInt)0);
            PrtInt TMP_tmp4_3 = ((PrtInt)0);
            PrtString TMP_tmp5_1 = ((PrtString)"");
            PrtInt TMP_tmp6_1 = ((PrtInt)0);
            PrtInt TMP_tmp7_1 = ((PrtInt)0);
            PrtInt TMP_tmp8_1 = ((PrtInt)0);
            PrtBool TMP_tmp9 = ((PrtBool)false);
            PrtInt TMP_tmp10 = ((PrtInt)0);
            PrtInt TMP_tmp11 = ((PrtInt)0);
            PrtString TMP_tmp12 = ((PrtString)"");
            TMP_tmp0_5 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["number_of_waypoints"]);
            TMP_tmp1_5 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["current_waypoint_index"]);
            TMP_tmp2_4 = (PrtBool)((PrtValues.SafeEquals(TMP_tmp0_5,TMP_tmp1_5)));
            TMP_tmp3_4 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["current_waypoint_index"]);
            TMP_tmp4_3 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["number_of_waypoints"]);
            TMP_tmp5_1 = (PrtString)(((PrtString) String.Format("Drone did not visit all the waypoints. Current waypoint index = {0}, Number of waypoints = {1}",TMP_tmp3_4,TMP_tmp4_3)));
            currentMachine.TryAssert(TMP_tmp2_4,"Assertion Failed: " + TMP_tmp5_1);
            TMP_tmp6_1 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["number_of_waypoints"]);
            TMP_tmp7_1 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["current_waypoint_index"]);
            TMP_tmp8_1 = (PrtInt)((TMP_tmp7_1) + (((PrtInt)1)));
            TMP_tmp9 = (PrtBool)((PrtValues.SafeEquals(TMP_tmp6_1,TMP_tmp8_1)));
            TMP_tmp10 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["current_waypoint_index"]);
            TMP_tmp11 = (PrtInt)(((PrtNamedTuple)missionCompleteResponse)["number_of_waypoints"]);
            TMP_tmp12 = (PrtString)(((PrtString) String.Format("Drone did not visit all the waypoints. Current waypoint index = {0}, Number of waypoints = {1}",TMP_tmp10,TMP_tmp11)));
            currentMachine.TryAssert(TMP_tmp9,"Assertion Failed: " + TMP_tmp12);
            currentMachine.TryGotoState<MissionComplete_1>();
            return;
        }
        public void Anon_9(Event currentMachine_dequeuedEvent)
        {
            WaypointCorrect currentMachine = this;
            PrtString TMP_tmp0_6 = ((PrtString)"");
            TMP_tmp0_6 = (PrtString)(((PrtString) String.Format("[Waypoint Spec] Model Check Complete!")));
            PModule.runtime.Logger.WriteLine("<PrintLog> " + TMP_tmp0_6);
        }
        [Start]
        [OnEventGotoState(typeof(eMissionStart), typeof(ExecutingMission))]
        class Init_2 : State
        {
        }
        [Hot]
        [OnEventDoAction(typeof(eProceedToWaypoint), nameof(Anon_7))]
        [OnEventDoAction(typeof(eHoverAtWaypoint), nameof(Anon_7))]
        [OnEventDoAction(typeof(eAdvanceWaypoint), nameof(Anon_7))]
        [OnEventDoAction(typeof(eMissionComplete), nameof(Anon_8))]
        class ExecutingMission : State
        {
        }
        [Cold]
        [OnEntry(nameof(Anon_9))]
        class MissionComplete_1 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class GlobalCorrect : PMonitor
    {
        static GlobalCorrect() {
            observes.Add(nameof(eMissionStart));
        }
        
        [Start]
        class Init_3 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class AvoidCorrect : PMonitor
    {
        static AvoidCorrect() {
            observes.Add(nameof(eMissionStart));
        }
        
        [Start]
        class Init_4 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Test_Waypoint : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test_Waypoint() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eAvoidManeuverComplete));
            this.sends.Add(nameof(eAvoidStart));
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eIntrusionDetected));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eAvoidManeuverComplete));
            this.receives.Add(nameof(eAvoidStart));
            this.receives.Add(nameof(eHoverAtWaypoint));
            this.receives.Add(nameof(eIntrusionDetected));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eModeless));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_Waypoint));
        }
        
        public void Anon_10(Event currentMachine_dequeuedEvent)
        {
            Test_Waypoint currentMachine = this;
            PrtInt TMP_tmp0_7 = ((PrtInt)0);
            TMP_tmp0_7 = (PrtInt)(((PrtInt)10));
            currentMachine.CreateInterface<I_Waypoint>(currentMachine, TMP_tmp0_7);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_5))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_10))]
        class Init_5 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Test_Avoid : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test_Avoid() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eAvoidManeuverComplete));
            this.sends.Add(nameof(eAvoidStart));
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eIntrusionDetected));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eAvoidManeuverComplete));
            this.receives.Add(nameof(eAvoidStart));
            this.receives.Add(nameof(eHoverAtWaypoint));
            this.receives.Add(nameof(eIntrusionDetected));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eModeless));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_Avoid));
        }
        
        public void Anon_11(Event currentMachine_dequeuedEvent)
        {
            Test_Avoid currentMachine = this;
            PrtInt TMP_tmp0_8 = ((PrtInt)0);
            TMP_tmp0_8 = (PrtInt)(((PrtInt)10));
            currentMachine.CreateInterface<I_Avoid>(currentMachine, TMP_tmp0_8);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_6))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_11))]
        class Init_6 : State
        {
        }
    }
}
namespace PImplementation
{
    internal partial class Test_Global : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test_Global() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eAvoidManeuverComplete));
            this.sends.Add(nameof(eAvoidStart));
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eIntrusionDetected));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eAvoidManeuverComplete));
            this.receives.Add(nameof(eAvoidStart));
            this.receives.Add(nameof(eHoverAtWaypoint));
            this.receives.Add(nameof(eIntrusionDetected));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eModeless));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_12(Event currentMachine_dequeuedEvent)
        {
            Test_Global currentMachine = this;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_7))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_12))]
        class Init_7 : State
        {
        }
    }
}
namespace PImplementation
{
    public class waypoint {
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_Waypoint)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Avoid)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test_Waypoint)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test_Waypoint)].Add(nameof(I_Waypoint), nameof(I_Waypoint));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_Waypoint), typeof(Waypoint));
            PModule.interfaceDefinitionMap.Add(nameof(I_Avoid), typeof(Avoid));
            PModule.interfaceDefinitionMap.Add(nameof(I_Test_Waypoint), typeof(Test_Waypoint));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(WaypointCorrect)] = new List<string>();
            PModule.monitorObserves[nameof(WaypointCorrect)].Add(nameof(eAdvanceWaypoint));
            PModule.monitorObserves[nameof(WaypointCorrect)].Add(nameof(eHoverAtWaypoint));
            PModule.monitorObserves[nameof(WaypointCorrect)].Add(nameof(eMissionComplete));
            PModule.monitorObserves[nameof(WaypointCorrect)].Add(nameof(eMissionStart));
            PModule.monitorObserves[nameof(WaypointCorrect)].Add(nameof(eProceedToWaypoint));
        }
        
        public static void InitializeMonitorMap(IActorRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_Waypoint)] = new List<Type>();
            PModule.monitorMap[nameof(I_Waypoint)].Add(typeof(WaypointCorrect));
            PModule.monitorMap[nameof(I_Avoid)] = new List<Type>();
            PModule.monitorMap[nameof(I_Avoid)].Add(typeof(WaypointCorrect));
            PModule.monitorMap[nameof(I_Test_Waypoint)] = new List<Type>();
            PModule.monitorMap[nameof(I_Test_Waypoint)].Add(typeof(WaypointCorrect));
            runtime.RegisterMonitor<WaypointCorrect>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(IActorRuntime runtime) {
            runtime.RegisterLog(new PLogFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateActor(typeof(_GodMachine), new _GodMachine.Config(typeof(Test_Waypoint)));
        }
    }
}
namespace PImplementation
{
    public class avoid {
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_Waypoint)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Avoid)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test_Avoid)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test_Avoid)].Add(nameof(I_Avoid), nameof(I_Avoid));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_Waypoint), typeof(Waypoint));
            PModule.interfaceDefinitionMap.Add(nameof(I_Avoid), typeof(Avoid));
            PModule.interfaceDefinitionMap.Add(nameof(I_Test_Avoid), typeof(Test_Avoid));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(AvoidCorrect)] = new List<string>();
            PModule.monitorObserves[nameof(AvoidCorrect)].Add(nameof(eMissionStart));
        }
        
        public static void InitializeMonitorMap(IActorRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_Waypoint)] = new List<Type>();
            PModule.monitorMap[nameof(I_Waypoint)].Add(typeof(AvoidCorrect));
            PModule.monitorMap[nameof(I_Avoid)] = new List<Type>();
            PModule.monitorMap[nameof(I_Avoid)].Add(typeof(AvoidCorrect));
            PModule.monitorMap[nameof(I_Test_Avoid)] = new List<Type>();
            PModule.monitorMap[nameof(I_Test_Avoid)].Add(typeof(AvoidCorrect));
            runtime.RegisterMonitor<AvoidCorrect>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(IActorRuntime runtime) {
            runtime.RegisterLog(new PLogFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateActor(typeof(_GodMachine), new _GodMachine.Config(typeof(Test_Avoid)));
        }
    }
}
namespace PImplementation
{
    public class global {
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_Waypoint)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Avoid)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test_Global)] = new Dictionary<string, string>();
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_Waypoint), typeof(Waypoint));
            PModule.interfaceDefinitionMap.Add(nameof(I_Avoid), typeof(Avoid));
            PModule.interfaceDefinitionMap.Add(nameof(I_Test_Global), typeof(Test_Global));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
            PModule.monitorObserves[nameof(GlobalCorrect)] = new List<string>();
            PModule.monitorObserves[nameof(GlobalCorrect)].Add(nameof(eMissionStart));
        }
        
        public static void InitializeMonitorMap(IActorRuntime runtime) {
            PModule.monitorMap.Clear();
            PModule.monitorMap[nameof(I_Waypoint)] = new List<Type>();
            PModule.monitorMap[nameof(I_Waypoint)].Add(typeof(GlobalCorrect));
            PModule.monitorMap[nameof(I_Avoid)] = new List<Type>();
            PModule.monitorMap[nameof(I_Avoid)].Add(typeof(GlobalCorrect));
            PModule.monitorMap[nameof(I_Test_Global)] = new List<Type>();
            PModule.monitorMap[nameof(I_Test_Global)].Add(typeof(GlobalCorrect));
            runtime.RegisterMonitor<GlobalCorrect>();
        }
        
        
        [PChecker.SystematicTesting.Test]
        public static void Execute(IActorRuntime runtime) {
            runtime.RegisterLog(new PLogFormatter());
            PModule.runtime = runtime;
            PHelper.InitializeInterfaces();
            PHelper.InitializeEnums();
            InitializeLinkMap();
            InitializeInterfaceDefMap();
            InitializeMonitorMap(runtime);
            InitializeMonitorObserves();
            runtime.CreateActor(typeof(_GodMachine), new _GodMachine.Config(typeof(Test_Global)));
        }
    }
}
// TODO: NamedModule Waypoint_1
// TODO: NamedModule Avoid_1
namespace PImplementation
{
    public class I_Avoid : PMachineValue {
        public I_Avoid (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Waypoint : PMachineValue {
        public I_Waypoint (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Test_Waypoint : PMachineValue {
        public I_Test_Waypoint (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Test_Avoid : PMachineValue {
        public I_Test_Avoid (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public class I_Test_Global : PMachineValue {
        public I_Test_Global (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public partial class PHelper {
        public static void InitializeInterfaces() {
            PInterfaces.Clear();
            PInterfaces.AddInterface(nameof(I_Avoid), nameof(eAdvanceWaypoint), nameof(eAvoidManeuverComplete), nameof(eAvoidStart), nameof(eHoverAtWaypoint), nameof(eIntrusionDetected), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Waypoint), nameof(eAdvanceWaypoint), nameof(eAvoidManeuverComplete), nameof(eAvoidStart), nameof(eHoverAtWaypoint), nameof(eIntrusionDetected), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test_Waypoint), nameof(eAdvanceWaypoint), nameof(eAvoidManeuverComplete), nameof(eAvoidStart), nameof(eHoverAtWaypoint), nameof(eIntrusionDetected), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test_Avoid), nameof(eAdvanceWaypoint), nameof(eAvoidManeuverComplete), nameof(eAvoidStart), nameof(eHoverAtWaypoint), nameof(eIntrusionDetected), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test_Global), nameof(eAdvanceWaypoint), nameof(eAvoidManeuverComplete), nameof(eAvoidStart), nameof(eHoverAtWaypoint), nameof(eIntrusionDetected), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
        }
    }
    
}
namespace PImplementation
{
    public partial class PHelper {
        public static void InitializeEnums() {
            PrtEnum.Clear();
        }
    }
    
}
#pragma warning restore 162, 219, 414

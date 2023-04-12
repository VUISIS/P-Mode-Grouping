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
        public eMissionComplete (IPrtValue payload): base(payload){ }
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
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Avoid() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eHoverAtWaypoint));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eModeless));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon(Event currentMachine_dequeuedEvent)
        {
            Avoid currentMachine = this;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon))]
        class Init : State
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
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eHoverAtWaypoint));
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
            PMachineValue TMP_tmp4_1 = null;
            PEvent TMP_tmp5 = null;
            TMP_tmp0_3 = (PrtInt)((number_of_waypoints) - (((PrtInt)1)));
            TMP_tmp1_3 = (PrtBool)((PrtValues.SafeEquals(current_waypoint_index,TMP_tmp0_3)));
            if (TMP_tmp1_3)
            {
                TMP_tmp2_2 = (PMachineValue)(currentMachine.self);
                TMP_tmp3_2 = (PEvent)(new eMissionComplete(null));
                currentMachine.TrySendEvent(TMP_tmp2_2, (Event)TMP_tmp3_2);
                currentMachine.TryGotoState<MissionComplete>();
                return;
            }
            else
            {
                TMP_tmp4_1 = (PMachineValue)(currentMachine.self);
                TMP_tmp5 = (PEvent)(new eAdvanceWaypoint(null));
                currentMachine.TrySendEvent(TMP_tmp4_1, (Event)TMP_tmp5);
                currentMachine.TryGotoState<AdvanceWaypoint>();
                return;
            }
        }
        public void Anon_5(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PMachineValue TMP_tmp0_4 = null;
            PEvent TMP_tmp1_4 = null;
            TMP_tmp0_4 = (PMachineValue)(currentMachine.self);
            TMP_tmp1_4 = (PEvent)(new eModeless(null));
            currentMachine.TrySendEvent(TMP_tmp0_4, (Event)TMP_tmp1_4);
            currentMachine.TryGotoState<Modeless>();
            return;
        }
        public void Anon_6(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PrtString TMP_tmp0_5 = ((PrtString)"");
            TMP_tmp0_5 = (PrtString)(((PrtString) String.Format("modeless")));
            currentMachine.TryAssert(((PrtBool)false),"Assertion Failed: " + TMP_tmp0_5);
            throw new PUnreachableCodeException();
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
    internal partial class Test : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Test() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eHoverAtWaypoint));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eModeless));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eHoverAtWaypoint));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eModeless));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
            this.creates.Add(nameof(I_Waypoint));
        }
        
        public void Anon_7(Event currentMachine_dequeuedEvent)
        {
            Test currentMachine = this;
            PrtInt TMP_tmp0_6 = ((PrtInt)0);
            TMP_tmp0_6 = (PrtInt)(((PrtInt)10));
            currentMachine.CreateInterface<I_Waypoint>(currentMachine, TMP_tmp0_6);
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_2))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_7))]
        class Init_2 : State
        {
        }
    }
}
namespace PImplementation
{
    public class tc {
        public static void InitializeLinkMap() {
            PModule.linkMap.Clear();
            PModule.linkMap[nameof(I_Waypoint)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Avoid)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test)] = new Dictionary<string, string>();
            PModule.linkMap[nameof(I_Test)].Add(nameof(I_Waypoint), nameof(I_Waypoint));
        }
        
        public static void InitializeInterfaceDefMap() {
            PModule.interfaceDefinitionMap.Clear();
            PModule.interfaceDefinitionMap.Add(nameof(I_Waypoint), typeof(Waypoint));
            PModule.interfaceDefinitionMap.Add(nameof(I_Avoid), typeof(Avoid));
            PModule.interfaceDefinitionMap.Add(nameof(I_Test), typeof(Test));
        }
        
        public static void InitializeMonitorObserves() {
            PModule.monitorObserves.Clear();
        }
        
        public static void InitializeMonitorMap(IActorRuntime runtime) {
            PModule.monitorMap.Clear();
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
            runtime.CreateActor(typeof(_GodMachine), new _GodMachine.Config(typeof(Test)));
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
    
    public class I_Test : PMachineValue {
        public I_Test (ActorId machine, List<string> permissions) : base(machine, permissions) { }
    }
    
    public partial class PHelper {
        public static void InitializeInterfaces() {
            PInterfaces.Clear();
            PInterfaces.AddInterface(nameof(I_Avoid), nameof(eAdvanceWaypoint), nameof(eHoverAtWaypoint), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Waypoint), nameof(eAdvanceWaypoint), nameof(eHoverAtWaypoint), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test), nameof(eAdvanceWaypoint), nameof(eHoverAtWaypoint), nameof(eMissionComplete), nameof(eMissionStart), nameof(eModeless), nameof(eProceedToWaypoint), nameof(PHalt));
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
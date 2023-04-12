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
    internal partial class eHoeverAtWaypoint : PEvent
    {
        public eHoeverAtWaypoint() : base() {}
        public eHoeverAtWaypoint (IPrtValue payload): base(payload){ }
        public override IPrtValue Clone() { return new eHoeverAtWaypoint();}
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
    internal partial class Avoid : PMachine
    {
        public class ConstructorEvent : PEvent{public ConstructorEvent(IPrtValue val) : base(val) { }}
        
        protected override Event GetConstructorEvent(IPrtValue value) { return new ConstructorEvent((IPrtValue)value); }
        public Avoid() {
            this.sends.Add(nameof(eAdvanceWaypoint));
            this.sends.Add(nameof(eHoeverAtWaypoint));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eHoeverAtWaypoint));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
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
            this.sends.Add(nameof(eHoeverAtWaypoint));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eHoeverAtWaypoint));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_1(Event currentMachine_dequeuedEvent)
        {
            Waypoint currentMachine = this;
            PrtInt number_of_way_points = (PrtInt)(gotoPayload ?? ((PEvent)currentMachine_dequeuedEvent).Payload);
            this.gotoPayload = null;
            current_waypoint_index = (PrtInt)(((PrtInt)0));
            number_of_waypoints = (PrtInt)(((PrtInt)((IPrtValue)number_of_way_points)?.Clone()));
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_1))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_1))]
        class Init_1 : State
        {
        }
        class AdvanceWaypoint : State
        {
        }
        class ProceedToWaypoint : State
        {
        }
        class HoverAtWaypoint : State
        {
        }
        class Complete : State
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
            this.sends.Add(nameof(eHoeverAtWaypoint));
            this.sends.Add(nameof(eMissionComplete));
            this.sends.Add(nameof(eMissionStart));
            this.sends.Add(nameof(eProceedToWaypoint));
            this.sends.Add(nameof(PHalt));
            this.receives.Add(nameof(eAdvanceWaypoint));
            this.receives.Add(nameof(eHoeverAtWaypoint));
            this.receives.Add(nameof(eMissionComplete));
            this.receives.Add(nameof(eMissionStart));
            this.receives.Add(nameof(eProceedToWaypoint));
            this.receives.Add(nameof(PHalt));
        }
        
        public void Anon_2(Event currentMachine_dequeuedEvent)
        {
            Test currentMachine = this;
        }
        [Start]
        [OnEntry(nameof(InitializeParametersFunction))]
        [OnEventGotoState(typeof(ConstructorEvent), typeof(Init_2))]
        class __InitState__ : State { }
        
        [OnEntry(nameof(Anon_2))]
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
            PInterfaces.AddInterface(nameof(I_Avoid), nameof(eAdvanceWaypoint), nameof(eHoeverAtWaypoint), nameof(eMissionComplete), nameof(eMissionStart), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Waypoint), nameof(eAdvanceWaypoint), nameof(eHoeverAtWaypoint), nameof(eMissionComplete), nameof(eMissionStart), nameof(eProceedToWaypoint), nameof(PHalt));
            PInterfaces.AddInterface(nameof(I_Test), nameof(eAdvanceWaypoint), nameof(eHoeverAtWaypoint), nameof(eMissionComplete), nameof(eMissionStart), nameof(eProceedToWaypoint), nameof(PHalt));
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

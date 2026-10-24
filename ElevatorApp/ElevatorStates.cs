namespace ElevatorApp
{
    // STATE PATTERN
    // The contract every mode must follow. The elevator calls these;
    // each mode decides what actually happens.
    public interface IElevatorState
    {
        string Name { get; }   // "Idle" or "Moving" (handy for the display)
        bool IsBusy { get; }   // used later to pick the most available elevator

        void RequestFloor(Elevator e, int floor);  // what to do when asked to move
        void Step(Elevator e);                      // what to do on each timer tick
    }

    // Mode 1: standing still, free to take a new trip.
    public class IdleState : IElevatorState
    {
        public string Name => "Idle";
        public bool IsBusy => false;

        public void RequestFloor(Elevator e, int floor)
        {
            e.TargetFloor = floor;
            if (e.Position != floor)
                e.ChangeState(new MovingState());  // start moving
        }

        public void Step(Elevator e)
        {
            // idle: nothing to do
        }
    }

    // Mode 2: travelling to a floor, busy.
    public class MovingState : IElevatorState
    {
        public string Name => "Moving";
        public bool IsBusy => true;

        public void RequestFloor(Elevator e, int floor)
        {
            // busy: ignore new requests until it arrives (so its trip isn't disrupted)
        }

        public void Step(Elevator e)
        {
            if (e.Position < e.TargetFloor)
                e.Position = Math.Min(e.Position + Elevator.Speed, e.TargetFloor);   // going up
            else if (e.Position > e.TargetFloor)
                e.Position = Math.Max(e.Position - Elevator.Speed, e.TargetFloor);   // going down

            if (e.Position == e.TargetFloor)   // arrived
            {
                e.CurrentFloor = e.TargetFloor;
                e.ChangeState(new IdleState());  // back to idle
            }
        }
    }
}

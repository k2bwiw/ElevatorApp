namespace ElevatorApp
{
    // The logic for ONE elevator, with no knowledge of the screen.
    // Position runs from 0.0 (ground floor) to 1.0 (first floor).
    //
    // STATE PATTERN: the elevator does not decide how to behave itself.
    // It holds a "State" object (IdleState or MovingState) and hands the
    // work to it. Changing behaviour = swapping the State object.
    public class Elevator
    {
        public const double Speed = 0.004;  // how far it travels each step (~3.7s a trip)

        public string Name { get; }                  // "A" or "B"
        public int CurrentFloor { get; set; } = 0;   // 0 = ground, 1 = first
        public int TargetFloor { get; set; } = 0;    // where it is heading
        public double Position { get; set; } = 0.0;  // where the car actually is

        // the elevator's current mode (starts Idle)
        public IElevatorState State { get; private set; } = new IdleState();

        // the elevator is "moving" whenever its current state says it is busy
        public bool IsMoving => State.IsBusy;

        public Elevator(string name)
        {
            Name = name;
        }

        // swap to a different mode (called by the state objects)
        public void ChangeState(IElevatorState newState)
        {
            State = newState;
        }

        // these just pass the work to whatever mode we are in
        public void RequestFloor(int floor) => State.RequestFloor(this, floor);
        public void Step() => State.Step(this);
    }
}

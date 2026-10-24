namespace ElevatorApp
{
    // The logic for ONE elevator, with no knowledge of the screen.
    // Position runs from 0.0 (ground floor) to 1.0 (first floor).
    //
    // STATE PATTERN: the elevator holds a "State" object (IdleState or
    //   MovingState) and hands the work to it. Behaviour changes by swapping state.
    // OBSERVER PATTERN: the elevator is the "subject". Whenever it changes it
    //   calls Notify(), and every attached observer (e.g. the screen) updates itself.
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

        // everyone who wants to be told when this elevator changes (Observer pattern)
        private readonly List<IElevatorObserver> observers = new List<IElevatorObserver>();

        public Elevator(string name)
        {
            Name = name;
        }

        // an observer signs up to be notified
        public void Attach(IElevatorObserver observer)
        {
            observers.Add(observer);
            observer.Update(this);   // show its starting state at once
        }

        // tell every observer that something changed
        private void Notify()
        {
            foreach (IElevatorObserver observer in observers)
                observer.Update(this);
        }

        // swap to a different mode (called by the state objects)
        public void ChangeState(IElevatorState newState)
        {
            State = newState;
            Notify();
        }

        // these pass the work to whatever mode we are in, then tell observers
        public void RequestFloor(int floor)
        {
            State.RequestFloor(this, floor);
            Notify();
        }

        public void Step()
        {
            State.Step(this);
            Notify();
        }
    }
}

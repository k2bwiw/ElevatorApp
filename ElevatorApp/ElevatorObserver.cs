namespace ElevatorApp
{
    // OBSERVER PATTERN
    // The contract for anything that wants to react when an elevator changes.
    public interface IElevatorObserver
    {
        void Update(Elevator e);
    }

    // One observer that keeps an elevator's on-screen parts in sync:
    // the car panel, the floor display, and the status label.
    // The elevator knows nothing about these controls - it just calls Update().
    public class ElevatorView : IElevatorObserver
    {
        private readonly Panel car;       // the coloured box that slides in the shaft
        private readonly Label display;   // the big "G"/"1" number
        private readonly Label status;    // the "Idle at G" / "Moving to 1" text

        public ElevatorView(Panel car, Label display, Label status)
        {
            this.car = car;
            this.display = display;
            this.status = status;
        }

        // Called by the elevator every time it changes.
        public void Update(Elevator e)
        {
            // turn the 0.0..1.0 position into a pixel height inside whatever
            // size the shaft is (so the shaft can be resized freely)
            int margin = 10;
            int shaftHeight = (car.Parent != null) ? car.Parent.Height : 450;
            double groundTop = shaftHeight - car.Height - margin; // car resting on ground
            double firstTop = margin;                             // car at the top
            car.Top = (int)(groundTop - e.Position * (groundTop - firstTop));

            // while moving, show where it is heading; when idle, show where it is
            int shownFloor = e.IsMoving ? e.TargetFloor : e.CurrentFloor;
            string floorName = (shownFloor == 1) ? "1" : "G";

            display.Text = floorName;
            status.Text = e.IsMoving ? ("Moving to " + floorName) : ("Idle at " + floorName);
        }
    }
}

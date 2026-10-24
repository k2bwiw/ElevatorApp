namespace ElevatorApp
{
    // Decides which elevator should answer an OUTSIDE call (a floor Call button).
    // Inside-panel buttons skip the controller and talk to their own elevator.
    public class ElevatorController
    {
        private readonly List<Elevator> elevators;

        public ElevatorController(params Elevator[] elevators)
        {
            this.elevators = elevators.ToList();
        }

        // Send the nearest, most available elevator to a floor. Returns the one chosen.
        public Elevator CallToFloor(int floor)
        {
            Elevator best = null;
            double bestCost = double.MaxValue;

            foreach (Elevator e in elevators)
            {
                // cost = how far it must travel, plus a penalty if it is already busy
                // (so a free elevator is preferred and busy ones are not disrupted)
                double cost = Math.Abs(e.Position - floor) + (e.IsMoving ? 2.0 : 0.0);

                if (cost < bestCost)
                {
                    bestCost = cost;
                    best = e;
                }
            }

            best?.RequestFloor(floor);   // tell the winner to go
            return best;
        }
    }
}

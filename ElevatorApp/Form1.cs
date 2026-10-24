using System.Data;
using Microsoft.Data.SqlClient;

namespace ElevatorApp
{
    public partial class Form1 : Form
    {
        // two elevators, and the controller that dispatches outside calls
        private readonly Elevator elevatorA = new Elevator("A");
        private readonly Elevator elevatorB = new Elevator("B");
        private ElevatorController controller;

        public Form1()
        {
            InitializeComponent();

            // OBSERVER PATTERN: give each elevator a view that updates its on-screen
            // car, display and status whenever the elevator changes.
            elevatorA.Attach(new ElevatorView(pnlCarA, lblDisplayA, lblStatusA));
            elevatorB.Attach(new ElevatorView(pnlCarB, lblDisplayB, lblStatusB));

            controller = new ElevatorController(elevatorA, elevatorB);

            LoadLog();   // show today's log on startup
        }

        // ---------- Requests ----------

        // An OUTSIDE call (a floor Call button): the controller picks the elevator.
        private void OutsideCall(int floor)
        {
            Elevator chosen = controller.CallToFloor(floor);
            animationTimer.Start();
            if (chosen != null && chosen.IsMoving)   // only log a real move
            {
                SaveLog(chosen.Name, floor == 0 ? "G" : "1");
                LoadLog();
            }
        }

        // An INSIDE request (a control-panel button): handled only by that elevator.
        private void InsideRequest(Elevator e, int floor)
        {
            e.RequestFloor(floor);
            animationTimer.Start();
            if (e.IsMoving)   // only log if it actually set off
            {
                SaveLog(e.Name, floor == 0 ? "G" : "1");
                LoadLog();
            }
        }

        // outside Call buttons
        private void btnCall1_Click(object sender, EventArgs e) => OutsideCall(1);
        private void btnCall0_Click(object sender, EventArgs e) => OutsideCall(0);

        // inside panel buttons for elevator A
        private void btnA1_Click(object sender, EventArgs e) => InsideRequest(elevatorA, 1);
        private void btnA0_Click(object sender, EventArgs e) => InsideRequest(elevatorA, 0);

        // inside panel buttons for elevator B
        private void btnB1_Click(object sender, EventArgs e) => InsideRequest(elevatorB, 1);
        private void btnB0_Click(object sender, EventArgs e) => InsideRequest(elevatorB, 0);

        // the timer drives BOTH elevators; it stops once both have arrived
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            elevatorA.Step();
            elevatorB.Step();
            if (!elevatorA.IsMoving && !elevatorB.IsMoving)
                animationTimer.Stop();
        }

        // ---------- Database section ----------

        // Saves one elevator move (which lift, which floor, and the time).
        // Uses the DISCONNECTED model: fill a DataSet, add a row, then DataAdapter.Update().
        private void SaveLog(string elevatorName, string floorName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Db.ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Log", conn);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);  // writes the INSERT for us

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Log");

                    DataRow row = ds.Tables["Log"].NewRow();
                    row["Elevator"] = elevatorName;
                    row["FloorName"] = floorName;
                    row["MoveTime"] = DateTime.Now;
                    ds.Tables["Log"].Rows.Add(row);

                    adapter.Update(ds, "Log");   // push the change back (disconnected update)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving log: " + ex.Message);
            }
        }

        // Loads today's log records into the grid.
        private void LoadLog()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Db.ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(
                        "SELECT Id, Elevator, FloorName, MoveTime FROM Log " +
                        "WHERE CONVERT(date, MoveTime) = CONVERT(date, GETDATE()) " +
                        "ORDER BY MoveTime DESC", conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Log");
                    dgvLog.DataSource = ds.Tables["Log"];

                    // make the grid read-only and easier to read
                    dgvLog.ReadOnly = true;
                    dgvLog.AllowUserToAddRows = false;
                    dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    if (dgvLog.Columns.Contains("Id")) dgvLog.Columns["Id"].HeaderText = "ID";
                    if (dgvLog.Columns.Contains("Elevator")) dgvLog.Columns["Elevator"].HeaderText = "Lift";
                    if (dgvLog.Columns.Contains("FloorName")) dgvLog.Columns["FloorName"].HeaderText = "Floor";
                    if (dgvLog.Columns.Contains("MoveTime"))
                    {
                        dgvLog.Columns["MoveTime"].HeaderText = "Time";
                        dgvLog.Columns["MoveTime"].DefaultCellStyle.Format = "dd MMM yyyy  HH:mm:ss";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading log: " + ex.Message);
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            // toggle the log grid on or off
            dgvLog.Visible = !dgvLog.Visible;
            btnLog.Text = dgvLog.Visible ? "Hide Log" : "Show Log";
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            // open the history window (ShowDialog = must close it before using the main window)
            HistoryForm history = new HistoryForm();
            history.ShowDialog();
        }
    }
}

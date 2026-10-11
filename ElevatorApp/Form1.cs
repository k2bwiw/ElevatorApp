using System.Data;
using Microsoft.Data.SqlClient;


namespace ElevatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Which floor the elevator is on: 0 = Ground, 1 = First
        private int currentFloor = 0;
        private int targetTop;      // where the car should end up
        private int stepSize = 10;  // pixels the car moves each tick

        // Moves the elevator to a floor and updates every display
        private void MoveTo(int floor)
        {
            currentFloor = floor;

            string floorName = (floor == 0) ? "G" : "1";

            // set the destination and start the animation (the timer moves the car)
            targetTop = (floor == 1) ? 10 : 260;
            animationTimer.Start();

            // Update all the displays
            lblDisplay.Text = floorName;
            lblStatusFloor0.Text = "Elevator at: " + floorName;
            lblStatusFloor1.Text = "Elevator at: " + floorName;
            // record this move in the database
            SaveLog(floorName);
            // show the updated log straight away
            LoadLog();
        }

        // ---------- Database section ----------

        // One place that builds the connection. |DataDirectory| = the app's own folder,
        // so this is a RELATIVE path (the database travels with the program).
        private string GetConnectionString()
        {
            return Db.ConnectionString;
        }

        // Saves one elevator move to the database, with the time it happened.
        // Uses the DISCONNECTED model: fill a DataSet, add a row, then DataAdapter.Update().
        private void SaveLog(string floorName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Log", conn);
                    // CommandBuilder writes the INSERT command for us
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Log");

                    // add the new record to the in-memory table
                    DataRow row = ds.Tables["Log"].NewRow();
                    row["FloorName"] = floorName;
                    row["MoveTime"] = DateTime.Now;
                    ds.Tables["Log"].Rows.Add(row);

                    // push the change back to the database (disconnected update)
                    adapter.Update(ds, "Log");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving log: " + ex.Message);
            }
        }

        // Loads all log records from the database into the grid.
        private void LoadLog()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Log WHERE CONVERT(date, MoveTime) = CONVERT(date, GETDATE()) ORDER BY MoveTime DESC", conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Log");
                    dgvLog.DataSource = ds.Tables["Log"];
                    // make the grid read-only and easier to read
                    dgvLog.ReadOnly = true;
                    dgvLog.AllowUserToAddRows = false;
                    dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLog.Columns["Id"].HeaderText = "ID";
                    dgvLog.Columns["FloorName"].HeaderText = "Floor";
                    dgvLog.Columns["MoveTime"].HeaderText = "Time";
                    dgvLog.Columns["MoveTime"].DefaultCellStyle.Format = "dd MMM yyyy  HH:mm:ss";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading log: " + ex.Message);
            }
        }

        private void btnRequestFloor1_Click(object sender, EventArgs e)
        {
            MoveTo(1);
        }

        private void btnRequestFloor0_Click(object sender, EventArgs e)
        {
            MoveTo(0);
        }

        private void btnFloor1_Click(object sender, EventArgs e)
        {
            MoveTo(1);
        }

        private void btnFloor0_Click(object sender, EventArgs e)
        {
            MoveTo(0);
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

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            // called ~every 15ms: nudge the car toward the target floor
            if (pnlCar.Top < targetTop)
            {
                // need to go down; don't overshoot past the target
                pnlCar.Top = Math.Min(pnlCar.Top + stepSize, targetTop);
            }
            else if (pnlCar.Top > targetTop)
            {
                // need to go up; don't overshoot past the target
                pnlCar.Top = Math.Max(pnlCar.Top - stepSize, targetTop);
            }
            else
            {
                // arrived at the floor, stop animating
                animationTimer.Stop();
            }
        }
    }
}

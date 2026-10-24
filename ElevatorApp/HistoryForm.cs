using System.Data;
using Microsoft.Data.SqlClient;

namespace ElevatorApp
{
    // A separate window that shows ALL log records,
    // with filters for a single day and for a floor.
    // The whole window is built here in code (no designer file),
    // so everything it does is visible in this one file.
    public class HistoryForm : Form
    {
        private DateTimePicker dtpDay;
        private CheckBox chkAllDates;
        private ComboBox cmbFloor;
        private Button btnApply;
        private DataGridView dgv;

        public HistoryForm()
        {
            // --- the window itself ---
            Text = "History Logs";
            Width = 700;
            Height = 500;
            StartPosition = FormStartPosition.CenterParent;

            // --- day filter ---
            Label lblDay = new Label { Text = "Day:", Left = 15, Top = 20, Width = 35 };
            dtpDay = new DateTimePicker { Left = 55, Top = 16, Width = 150, Format = DateTimePickerFormat.Short };
            chkAllDates = new CheckBox { Text = "All dates", Left = 215, Top = 18, Width = 90 };

            // --- floor filter ---
            Label lblFloor = new Label { Text = "Floor:", Left = 320, Top = 20, Width = 45 };
            cmbFloor = new ComboBox { Left = 365, Top = 16, Width = 90, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFloor.Items.AddRange(new string[] { "All", "G", "1" });
            cmbFloor.SelectedIndex = 0;

            // --- apply button ---
            btnApply = new Button { Text = "Apply filter", Left = 475, Top = 15, Width = 100, Height = 24 };
            btnApply.Click += (s, e) => LoadHistory();

            // --- the results grid ---
            dgv = new DataGridView
            {
                Left = 15,
                Top = 55,
                Width = 650,
                Height = 390,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // put every control on the window
            Controls.Add(lblDay);
            Controls.Add(dtpDay);
            Controls.Add(chkAllDates);
            Controls.Add(lblFloor);
            Controls.Add(cmbFloor);
            Controls.Add(btnApply);
            Controls.Add(dgv);

            // make the Apply button line up exactly with the floor dropdown
            btnApply.Height = cmbFloor.Height;
            btnApply.Top = cmbFloor.Top;

            LoadHistory(); // show everything when the window opens
        }

        // Builds a filtered query from the chosen day/floor and loads it into the grid.
        private void LoadHistory()
        {
            try
            {
                // start with a query that matches everything, then add the filters
                string sql = "SELECT Id, Elevator, FloorName, MoveTime FROM Log WHERE 1=1";
                if (!chkAllDates.Checked)
                    sql += " AND CONVERT(date, MoveTime) = @day";
                if (cmbFloor.SelectedItem.ToString() != "All")
                    sql += " AND FloorName = @floor";
                sql += " ORDER BY MoveTime DESC";

                using (SqlConnection conn = new SqlConnection(Db.ConnectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    // parameters keep the query safe from SQL injection
                    if (!chkAllDates.Checked)
                        adapter.SelectCommand.Parameters.AddWithValue("@day", dtpDay.Value.Date);
                    if (cmbFloor.SelectedItem.ToString() != "All")
                        adapter.SelectCommand.Parameters.AddWithValue("@floor", cmbFloor.SelectedItem.ToString());

                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Log");
                    dgv.DataSource = ds.Tables["Log"];

                    // friendly column headers and date format
                    if (dgv.Columns.Contains("Id")) dgv.Columns["Id"].HeaderText = "ID";
                    if (dgv.Columns.Contains("Elevator")) dgv.Columns["Elevator"].HeaderText = "Lift";
                    if (dgv.Columns.Contains("FloorName")) dgv.Columns["FloorName"].HeaderText = "Floor";
                    if (dgv.Columns.Contains("MoveTime"))
                    {
                        dgv.Columns["MoveTime"].HeaderText = "Time";
                        dgv.Columns["MoveTime"].DefaultCellStyle.Format = "dd MMM yyyy  HH:mm:ss";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }
    }
}

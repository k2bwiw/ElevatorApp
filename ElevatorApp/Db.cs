namespace ElevatorApp
{
    // One shared place for the database connection details,
    // so the connection string is never duplicated across the app.
    // |DataDirectory| = the app's own folder, so this is a RELATIVE path.
    public static class Db
    {
        public static string ConnectionString =>
            @"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=|DataDirectory|\ElevatorLog.mdf;" +
            @"Integrated Security=True;";
    }
}

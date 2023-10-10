namespace CRUD_ADO.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=STPL-INT-ANUS;Initial Catalog=CRUD_ADO;User ID=sa;Password=P@ssw0rd";
        public static string CName
        {
            get => cName;
        }
    }
}
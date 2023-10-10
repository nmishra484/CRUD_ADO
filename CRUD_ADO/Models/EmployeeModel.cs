namespace CRUD_ADO.Models
{
    public class EmployeeModel
    {
        public int Employee_Id { get; set; }
        public int Employee_id { get; internal set; }
        public string Employee_Name{ get; set; } = string.Empty;
        public String Employee_Salary{ get; set;} = string .Empty;
    }
}
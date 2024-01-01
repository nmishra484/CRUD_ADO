using System.ComponentModel.DataAnnotations;

namespace CRUD_ADO.Models
{
    public class EmployeeModel
    {
        public int Employee_id { get; set; }
        public string  Employee_Name{ get; set; }
        public string  Salary{ get; set;}

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Phone { get; set;} 
        public string Address {  get; set; }    
    }
}
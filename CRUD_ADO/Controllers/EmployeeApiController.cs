using CRUD_ADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ADO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private EmployeeDataAccessLayer empDataAccessLayer;

        //EmployeeDataAccessLayer empDataAccessLayer = null;
        public EmployeeApiController()
        {
            empDataAccessLayer = new EmployeeDataAccessLayer();
        }
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> students = empDataAccessLayer.GetAllEmployeeModel();
            return Ok(students);
        }
        public ActionResult Details(int id)
        {
            EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
            return Ok(empMod);
        }
        public ActionResult Create()
        {
            return Ok();
        }
        public ActionResult Edit(int id)
        {
            EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
            return Ok(empMod);
        }
        public ActionResult Edit(int id, EmployeeModel employeeModel)
        {
            try
            {
                empDataAccessLayer.UpdateEmployeeModel(employeeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            try
            {
                empDataAccessLayer.AddEmployeeModel(employeeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
        public ActionResult Delete(int id)
        {
            EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
            return Ok(empMod);
        }
        public ActionResult Delete(int id, EmployeeModel employeeModel)
        {
            try
            {
                empDataAccessLayer.DeleteEmployeeModel(employeeModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
    }
}
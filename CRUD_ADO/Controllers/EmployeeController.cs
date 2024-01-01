using CRUD_ADO.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ADO.Controllers
{

    public class EmployeeController : Controller
    {
        private EmployeeDataAccessLayer empDataAccessLayer;

        //EmployeeDataAccessLayer empDataAccessLayer = null;
        public EmployeeController()
        {
            empDataAccessLayer = new EmployeeDataAccessLayer();
        }
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel>students = empDataAccessLayer.GetAllEmployeeModel();
            return View(students);
        }
        //public ActionResult Details(int id)
        //{
        //    EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
        //    return View(empMod);
        //}
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //public ActionResult Edit(int id)
        //{
        //    EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
        //    return View(empMod);
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
            return View(id);
        }

        [HttpPost]
        public ActionResult Edit(int id ,  EmployeeModel employeeModel)
        {
           try
            {
                empDataAccessLayer.UpdateEmployeeModel(employeeModel);
                return RedirectToAction("Index");
            }
            catch 
            { 
                return View();
            }
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            try
            {
                empDataAccessLayer.AddEmployeeModel(employeeModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        
        public ActionResult Delete(int id)
        {
            EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
            empMod.Employee_id = id;

            return View(empMod);
        }

        [HttpPost]
        public ActionResult Delete( EmployeeModel employeeModel)
        {
            try
            {
                empDataAccessLayer.DeleteEmployeeModel(employeeModel);

                return RedirectToAction("Index");
            }
            catch 
            {
                return View();  
            }
        }
    }
}
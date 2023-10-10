﻿using CRUD_ADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ADO.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer empDataAccessLayer = null;
        public EmployeeController()
        {
            empDataAccessLayer = new EmployeeDataAccessLayer();
        }
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> students = empDataAccessLayer.GetAllEmployeeModel();
            return View(students);
        }
        public ActionResult Details(int id)
        {
            EmployeeModel empMod = empDataAccessLayer.GetEmployeeModelData(id);
            return View(empMod);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            try
            {
                empDataAccessLayer.AddEmployeeModel(employeeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
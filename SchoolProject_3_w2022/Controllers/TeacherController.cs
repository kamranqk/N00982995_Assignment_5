using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolProject_1_w2022.Models;
using System.Diagnostics;

namespace SchoolProject_1_w2022.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher

        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List 
        // showing the page of all the Teacher in the system
        [Route("Teacher/List/{SearchKey}")]
        public ActionResult List(string SearchKey)
        {
            Debug.WriteLine("The key is " + SearchKey);
            // connects to out data access layer
            // get our teachers
            // pass the Teacher to the veiw Teacher/list cshtml

            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);

            return View(Teachers);
        }

        // GET: Teacher/Show/{id} 
        // showing the page of teachers in the system by id  
        // [Route("/Teacher/Show/{Teacherid}")]
        public ActionResult Show(int id)
        {
            // how do we get the selected Teacher
            // get our Teachers
            // pass the Teacher to the veiw Teacher/list cshtml

            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            //routes the single Teacher info to show.cshtml
            return View(SelectedTeacher);
        }


        // GET: Teacher/DeleteConfirm/{id} 
        // showing the page of teachers in the system by id  
        // [Route("/Teacher/DeleteConfirm/{Teacherid}")]
        public ActionResult DeleteConfirm(int id)
        {
            // how do we get the selected Teacher
            // get our Teachers
            // pass the Teacher to the veiw Teacher/list cshtml

            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            //routes the single Teacher info to show.cshtml
            return View(SelectedTeacher);
        }
        //POST: Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }
        // GET: Teacher/New/
        public ActionResult New()
        {

            return View();

        }
        // [HtppPost]
        public ActionResult Create(string teacherfname, string teacherlname, string employeenumber)
        {
            Debug.WriteLine("The teacher info is:" + teacherfname + " " + teacherlname + " " + employeenumber );

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFName = teacherfname;
            NewTeacher.TeacherLName = teacherlname;
            NewTeacher.EmployeeNumber = employeenumber;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            //we want to do the following:
            //connect to a database
            //inserts into teachers
            //with provided values


            // redirects immediately to list view
            return RedirectToAction("List");

        }

        //GET : /Teacher/Edit/{id}
        /// <summary>
        /// returns a webpage of the Teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Edit(int id)
        {
            // I need to pass Teacher info to the view to show that to the user
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            
            return View(SelectedTeacher);

        }

        //POST : /Teacher/Update/{id}
        /// <summary>
        /// This method actually updates the Teacher
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpPost]

        public ActionResult Update(int id, string TeacherFName, string TeacherLName, string EmployeeNumber)
        {
            Debug.WriteLine("The Teacher name is "+TeacherFName);
            Debug.WriteLine("The ID is " + id);

            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFName = TeacherFName;
            TeacherInfo.TeacherLName = TeacherLName;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.TeacherId = id;

            //update the Teacher information
            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);
            //return to the Teacher that I just changed
            return RedirectToAction("Show/" + id);
        }



    }
}
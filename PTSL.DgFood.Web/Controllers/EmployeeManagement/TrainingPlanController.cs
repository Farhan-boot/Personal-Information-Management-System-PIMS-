using EnglishAndBanglaFeildValidation.Implementation;
using EnglishAndBanglaFeildValidation.Interface;
using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.CustomModal;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web.Mvc;

namespace PTSL.DgFood.Web.Controllers.EmployeeManagement
{
    [SessionAuthorize]
    public class TrainingPlanController : Controller
    {
        private readonly ITrainingPlanService _TrainingPlanService;
        public readonly IModelStateValidation _ModelStateValidation;
        public TrainingPlanController()
        {
            _TrainingPlanService = new TrainingPlanService();
            _ModelStateValidation = new ModelStateValidation();
        }
        // GET: Category
        public ActionResult Index()
        {
            var returnResponse = _TrainingPlanService.List();
            foreach (var item in returnResponse.entity)
            {
                item.GradeName = item.GradeId.GetEnumDisplayName();
            }
            return View(returnResponse.entity);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, TrainingPlanVM entity, string message) returnResponse = _TrainingPlanService.GetById(id);
            returnResponse.entity.GradeName = returnResponse.entity.GradeId.GetEnumDisplayName();

            return View(returnResponse.entity);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            TrainingPlanVM entity = new TrainingPlanVM();
            ViewBag.GradeId = new SelectList(EnumHelper.GetEnumDropdowns<Grade>(), "Id", "Name");
            return View(entity);
        }
        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(TrainingPlanVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entity.IsActive = true;
                    entity.CreatedAt = DateTime.Now;
                    // TODO: Add insert logic here
                    (ExecutionState executionState, TrainingPlanVM entity, string message) returnResponse = _TrainingPlanService.Create(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;

        
                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }
        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            DropdownController dc = new DropdownController();
            (ExecutionState executionState, TrainingPlanVM entity, string message) returnResponse = _TrainingPlanService.GetById(id);

            ViewBag.GradeId = new SelectList(EnumHelper.GetEnumDropdowns<Grade>(), "Id", "Name", (int)returnResponse.entity.GradeId);

            return View(returnResponse.entity);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TrainingPlanVM entity)
        {
            try
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    if (id != entity.Id)
                    {
                        return RedirectToAction(nameof(TrainingPlanController.Index), "Category");
                    }
                    entity.UpdatedAt = DateTime.Now;
                    (ExecutionState executionState, TrainingPlanVM entity, string message) returnResponse = _TrainingPlanService.Update(entity);
                    Session["Message"] = returnResponse.message;
                    Session["executionState"] = returnResponse.executionState;
                    if (returnResponse.executionState.ToString() != "Updated")
                    {
                        return View(entity);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }

                Session["Message"] = _ModelStateValidation.ModelStateErrorMessage(ModelState);
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
            catch
            {
                Session["Message"] = "Form Data Not Valid.";
                Session["executionState"] = ExecutionState.Failure;
                return View(entity);
            }
        }

        // GET: Category/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, string message) CheckDataExistOrNot = _TrainingPlanService.DoesExist(id);
            string message = "Faild, You can't delete this item.";
            //if (CheckDataExistOrNot.executionState.ToString() == "Success")
            //{
            //    return Json(new { Message = message, executionState = CheckDataExistOrNot.executionState }, JsonRequestBehavior.AllowGet);

            //}
            (ExecutionState executionState, TrainingPlanVM entity, string message) returnResponse = _TrainingPlanService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Category deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TrainingPlanVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(TrainingPlanController.Index), "Category");
                }
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, TrainingPlanVM entity, string message) returnResponse = _TrainingPlanService.Update(entity);
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult TrainingMonthlyDetailsReport()
        {
            var returnResponse = _TrainingPlanService.List();
            foreach (var item in returnResponse.entity)
            {
                item.GradeName = item.GradeId.GetEnumDisplayName();
            }
            var trainingMonthlyDetailsReport = new List<TrainingMonthlyDetailsReportVM>();
            var monthDestance =0;
            foreach (var item in returnResponse.entity)
            {
                var obj = new TrainingMonthlyDetailsReportVM();
                monthDestance =  (item.ProbableEndDate.Value.Month - item.ProbableStartDate.Value.Month) + 1;
                var totalPerMonth = item.TotalTrainingHours / monthDestance;

                obj.Grade = item.GradeId.GetEnumDisplayName();
                obj.EmployeesNumber = item.NumberOfParticipants;
                obj.EmployeesWiseTrainingHours = 0;
                obj.TotalTrainingHours = item.TotalTrainingHours;

                for (int i = 1; i < monthDestance + 1; i++)
                {
                   var monthName = item.ProbableStartDate?.AddMonths(-1).AddMonths(i).ToString("MMMM");
                    //Start Date start
                        if (monthName == "January"){ obj.January = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "February") { obj.February = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "March") { obj.March = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "April") { obj.April = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "May") { obj.May = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "June") { obj.June = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "July") { obj.July = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "August") { obj.August = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "September") { obj.September = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "October") { obj.October = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "November") { obj.November = Convert.ToDouble(totalPerMonth.ToString()); }
                        if (monthName == "December") { obj.December = Convert.ToDouble(totalPerMonth.ToString()); }
                    //Start Date End
                }
                trainingMonthlyDetailsReport.Add(obj);
            }
            return View(trainingMonthlyDetailsReport.ToList());
        }


        public ActionResult TrainingImplementationReport(string getMonthName)
        {
            var returnResponse = _TrainingPlanService.List();
            foreach (var item in returnResponse.entity)
            {
                item.GradeName = item.GradeId.GetEnumDisplayName();
            }
            var trainingMonthlyDetailsReport = new List<TrainingMonthlyDetailsReportVM>();
            var monthDestance = 0;
            foreach (var item in returnResponse.entity)
            {
                var obj = new TrainingMonthlyDetailsReportVM();
                monthDestance = (item.ProbableEndDate.Value.Month - item.ProbableStartDate.Value.Month) + 1;
                var totalPerMonth = item.TotalTrainingHours / monthDestance;

                obj.Grade = item.GradeId.GetEnumDisplayName();
                obj.EmployeesNumber = item.NumberOfParticipants;
                obj.EmployeesWiseTrainingHours = 0;
                obj.TotalTrainingHours = item.TotalTrainingHours;

                for (int i = 1; i < monthDestance + 1; i++)
                {
                    var monthName = item.ProbableStartDate?.AddMonths(-1).AddMonths(i).ToString("MMMM");
                    //Start Date start
                    if (monthName == "January") { obj.January = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "February") { obj.February = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "March") { obj.March = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "April") { obj.April = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "May") { obj.May = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "June") { obj.June = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "July") { obj.July = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "August") { obj.August = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "September") { obj.September = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "October") { obj.October = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "November") { obj.November = Convert.ToDouble(totalPerMonth.ToString()); }
                    if (monthName == "December") { obj.December = Convert.ToDouble(totalPerMonth.ToString()); }
                    //Start Date End
                }
                trainingMonthlyDetailsReport.Add(obj);
            }


            var dataList = new List<TrainingImplementationReportVM>();
            foreach (var item in trainingMonthlyDetailsReport.ToList())
            {
                var data = new TrainingImplementationReportVM();
                if (nameof(item.January) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.January;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);
                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.January > 0 && nameof(item.January) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100); ;
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }
                    
                    dataList.Add(data);
                }

                if (nameof(item.February) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.February;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.February > 0 && nameof(item.February) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }

                    dataList.Add(data);
                }

                if (nameof(item.March) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.March;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.March > 0 && nameof(item.March) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }
                    dataList.Add(data);
                }

                if (nameof(item.April) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.April;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);


                    if (item.April > 0 && nameof(item.April) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }
                   
                    dataList.Add(data);
                }

                if (nameof(item.May) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.May;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.May > 0 && nameof(item.May) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }

                    dataList.Add(data);
                }

                if (nameof(item.June) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.June;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.June > 0 && nameof(item.June) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }

                    dataList.Add(data);
                }

                if (nameof(item.July) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.July;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);


                    if (item.July > 0 && nameof(item.July) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }

                    dataList.Add(data);
                }

                if (nameof(item.August) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.August;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.August > 0 && nameof(item.August) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }

                    dataList.Add(data);
                }

                if (nameof(item.September) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.September;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.September > 0 && nameof(item.September) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }
                   
                    dataList.Add(data);
                }

                if (nameof(item.October) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.October;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.October > 0 && nameof(item.October) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }
                   
                    dataList.Add(data);
                }

                if (nameof(item.November) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.November;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.November > 0 && nameof(item.November) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }

                    dataList.Add(data);
                }

                if (nameof(item.December) == getMonthName)
                {
                    data.Grade = item.Grade;
                    data.EmployeesNumber = item.EmployeesNumber;
                    data.TotalTrainingHours = item.TotalTrainingHours;
                    data.RunningMonthWiseValue = item.December;
                    data.RunningAchievementHours = (data.TotalTrainingHours / data.EmployeesNumber);

                    //Formula 
                    data.RunningAchievementPercentage = (data.RunningAchievementHours / 100);

                    if (item.December > 0 && nameof(item.December) == DateTime.Now.ToString("MMMM"))
                    {
                        data.CurrentMonthWiseValue = data.TotalTrainingHours;
                        data.CurrentAchievementHours = data.RunningMonthWiseValue;
                        data.CurrentAchievementPercentage = (data.CurrentAchievementHours / 100);
                    }
                    else
                    {
                        data.CurrentMonthWiseValue = 0;
                        data.CurrentAchievementHours = 0;
                        data.CurrentAchievementPercentage = 0;
                    }

                    dataList.Add(data);
                }
            }


            ViewBag.monthNameText = getMonthName;

            return View(dataList.ToList());
        }





    }
}
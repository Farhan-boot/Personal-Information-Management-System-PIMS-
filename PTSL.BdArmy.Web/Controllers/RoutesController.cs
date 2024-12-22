using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PTSL.BdArmy.Common.Entity.BdArmy;
using PTSL.BdArmy.Web.Helper;
using PTSL.BdArmy.Web.Helper.Enum;
using PTSL.BdArmy.Web.Model;
using PTSL.BdArmy.Web.Model.EntityViewModels;
using PTSL.BdArmy.Web.Services.Implementation.GeneralSetup;
using PTSL.BdArmy.Web.Services.Interface;
using PTSL.BdArmy.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.BdArmy.Web.Controllers.GeneralSetup
{
    [SessionAuthorize]
    public class RoutesController : Controller
    {
        private readonly IRoutesService _RoutesService;
        private readonly IRoutesDetailsService _RoutesDetailsService;
        private readonly IUserService _UserService;
        //public RoutesController(): this(new RoutesService())
        //{
        //}
        public RoutesController()
        {
            _RoutesService = new RoutesService();
            _RoutesDetailsService = new RoutesDetailsService();
            _UserService = new UserService();
        }
        // GET: Routes
        public ActionResult Index()
        {
            (ExecutionState executionState, List<RoutesVM> entity, string message) returnResponse = _RoutesService.List();
            var users = _UserService.List();

            var data = new List<RoutesListsVM>();
            if (returnResponse.entity != null)
            {
                data = (from routes in returnResponse.entity
                        join user in users.entity
                        on routes.UserId equals user.Id
                        select new RoutesListsVM
                        {
                            Id = routes.Id,
                            CreatedAt = routes.CreatedAt,
                            UserName = user.UserName,
                            UserEmail = user.UserEmail,
                            IsArrived = routes.IsArrived,
                            SessionName = routes.SessionName,
                            PlaceName = string.Join(", ", routes.RoutesDetails.Select(x=>x.PlaceName))
                        }).ToList();
            }
            return View(data);
        }

        // GET: Routes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.GetById(id);
            return View(returnResponse.entity);
        }

        // GET: Routes/Create
        public ActionResult Create()
        {
            (ExecutionState executionState, List<UserVM> entity, string message) returnResponse = _UserService.List();
            if(returnResponse.entity != null)
            {
                ViewBag.UserId = new SelectList(returnResponse.entity, "Id", "UserName");
            }
            else
            {
                ViewBag.UserId = new SelectList("");
            }
            

            RoutesDataVM entity = new RoutesDataVM();
            entity.RoutesDetailsVM = new RoutesDetailsVM();
            entity.RoutesVM = new RoutesVM();
            return View(entity);
        }

        // POST: Routes/Create

        [HttpPost]
        public JsonResult Create(RoutesVM entity)
        {
            try
            {
                (ExecutionState executionState, List<UserVM> entity, string message) userResponse = _UserService.List();
                ViewBag.UserId = new SelectList(userResponse.entity, "Id", "UserName", entity.UserId);
                if (ModelState.IsValid)
                {
                    //RoutesVM data = entity.RoutesVM;
                   // RoutesDetailsVM detailsData = entity.RoutesDetailsVM;
                    entity.IsActive = true;
                    entity.CreatedAt = entity.RoutesDetails.FirstOrDefault().StartDate;
                    entity.SessionId = "";
                    //RoutesVM filterData = new RoutesVM();
                    //filterData.CreatedAt = entity.RoutesDetails.FirstOrDefault().StartDate;
                    //filterData.UserId = entity.UserId;
                    //var isExistsSameDate = false;
                    //(ExecutionState executionState, List<RoutesVM> entity, string message) returnRoutesResponse = _RoutesService.GetFilterData(filterData);
                    //if(returnRoutesResponse.entity != null)
                    //{
                    //    isExistsSameDate = true;
                    //    return Json(new { Status = false, Message = "Faild, Data Already Exists in This Day, Please Edit It." }, JsonRequestBehavior.AllowGet);
                    //}


                    foreach (var childItem in entity.RoutesDetails)
                    {
                        childItem.IsActive = true;
                        childItem.CreatedAt = DateTime.Now;
                    }
                    // TODO: Add insert logic here
                    (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.Create(entity);
                    
                    if (returnResponse.executionState.ToString() != "Created")
                    {
                        return Json(new { Status = false, Message = "Data Saved Faild." }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        (ExecutionState executionState, RoutesVM entity, string message) returnExistingResponse = _RoutesService.GetById(returnResponse.entity.Id);
                        (ExecutionState executionState, UserVM entity, string message) returnExistingUserResponse = _UserService.GetById(returnResponse.entity.UserId);
                        string userThreeDigitName = returnExistingUserResponse.entity.UserName.Substring(0, 3);
                        returnExistingResponse.entity.SessionId = returnExistingResponse.entity.Id + "_" + userThreeDigitName + "_" + DateTime.Now.ToString("dd-MM-yyyy");
                        (ExecutionState executionState, RoutesVM entity, string message) returnRoutesResponse = _RoutesService.Update(returnExistingResponse.entity);
                        return Json(new { Status = true, Message = "Data Saved Successfully." }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { Status = false, Message = "Data Saved Faild." }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Status = false, Message = "Data Saved Faild." }, JsonRequestBehavior.AllowGet);
            }
        }




        //[HttpPost]
        //public ActionResult Create(RoutesDataVM entity)
        //{
        //    try
        //    {
        //        (ExecutionState executionState, List<UserVM> entity, string message) userResponse = _UserService.List();
        //        ViewBag.UserId = new SelectList(userResponse.entity, "Id", "UserName",entity.RoutesVM.UserId);
        //        if (ModelState.IsValid)
        //        {
        //            RoutesVM data = entity.RoutesVM;
        //            RoutesDetailsVM detailsData = entity.RoutesDetailsVM;
        //            entity.RoutesVM.IsActive = true;
        //            entity.RoutesVM.CreatedAt = DateTime.Now;
        //            entity.RoutesDetailsVM.IsActive = true;
        //            entity.RoutesDetailsVM.CreatedAt = DateTime.Now;
        //            // TODO: Add insert logic here
        //            (ExecutionState executionState, RoutesVM entity, string message) returnResponse  = _RoutesService.Create(data);
        //             detailsData.RoutesId = returnResponse.entity.Id;

        //            //Session["Message"] = returnResponse.message;
        //            //Session["executionState"] = returnResponse.executionState;


        //                if (detailsData.RoutesId > 0)
        //                {
        //                    entity.RoutesVM.Id = returnResponse.entity.Id;

        //                    (ExecutionState executionState, RoutesDetailsVM entity, string message) returnRoutesDetailsResponse = _RoutesDetailsService.Create(detailsData);
        //                    if (returnRoutesDetailsResponse.entity != null)
        //                    {
        //                        if (returnRoutesDetailsResponse.entity.Id > 0)
        //                        {
        //                            entity.RoutesDetailsVM.Id = returnRoutesDetailsResponse.entity.Id;
        //                        }
        //                    }
        //                    Session["Message"] = returnRoutesDetailsResponse.message;
        //                    Session["executionState"] = returnRoutesDetailsResponse.executionState;

        //                }



        //            if (returnResponse.executionState.ToString() != "Created")
        //            {
        //                return View(entity);
        //            }
        //            else
        //            {
        //                //return RedirectToAction("Index");
        //                //return View(entity);
        //                return RedirectToAction("Edit", new { id = returnResponse.entity.Id, sdid = 0 });
        //            }
        //        }
        //        return View(entity);
        //    }
        //    catch
        //    {
        //        return View(entity);
        //    }
        //}


        // GET: Routes/Edit/5
        public ActionResult Edit(int? id,int? sdid)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.GetById(id);
            (ExecutionState executionState, List<UserVM> entity, string message) userResponse = _UserService.List();
            ViewBag.UserId = new SelectList(userResponse.entity, "Id", "UserName", returnResponse.entity.UserId);
            RoutesDataVM RoutesDataVM = new RoutesDataVM();
            RoutesDataVM.RoutesVM = returnResponse.entity;
            RoutesDataVM.RoutesDetailsVM = new RoutesDetailsVM();
            if(sdid > 0)
            {
                RoutesDataVM.RoutesDetailsVM = returnResponse.entity.RoutesDetails.Where(x => x.Id == sdid).FirstOrDefault();
            }
            RoutesDataVM.RoutesDetails = returnResponse.entity.RoutesDetails;
            ViewBag.PostId = id;
            return View(RoutesDataVM);
        }

        [HttpPost]
        public JsonResult Edit(RoutesVM entity)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //RoutesVM data = entity.RoutesVM;
                    // RoutesDetailsVM detailsData = entity.RoutesDetailsVM;
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    entity.UpdatedAt = DateTime.Now;
                    entity.IsActive = true;
                    entity.CreatedAt = entity.RoutesDetails.FirstOrDefault().StartDate;

                    RoutesVM filterData = new RoutesVM();
                    filterData.CreatedAt = entity.RoutesDetails.FirstOrDefault().StartDate;
                    filterData.UserId = entity.UserId;
                    //var isExistsSameDate = false;
                    //(ExecutionState executionState, List<RoutesVM> entity, string message) returnRoutesResponse = _RoutesService.GetFilterData(filterData);
                    //if (returnRoutesResponse.entity != null)
                    //{
                    //    var data = returnRoutesResponse.entity.Where(x => x.Id != entity.Id);
                    //    if(data.Count() > 0)
                    //    {
                    //        isExistsSameDate = true;
                    //        return Json(new { Status = false, Message = "Faild, Data Already Exists in This Day, Please Edit It." }, JsonRequestBehavior.AllowGet);
                    //    }

                    //}


                    (ExecutionState executionState, RoutesVM entity, string message) returnExistingResponse = _RoutesService.GetById(entity.Id);
                    foreach (var childData in returnExistingResponse.entity.RoutesDetails)
                    {
                        bool alreadyExists = entity.RoutesDetails.Any(x => x.Id == childData.Id);
                        if (alreadyExists == false)
                        {
                            (ExecutionState executionState, RoutesDetailsVM entity, string message) returnDetailsResponse = _RoutesDetailsService.Delete(childData.Id);
                        }
                    }
                    foreach (var childItem in entity.RoutesDetails)
                    {
                        childItem.IsActive = true;
                        childItem.IsDeleted = false;
                        childItem.UpdatedAt = DateTime.Now;
                    }
                    // TODO: Add insert logic here
                    (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.Update(entity);
                    
                    if (returnResponse.executionState.ToString() == "Updated")
                    {
                        return Json(new { Status = true, Message = "Data Updated Successfully." }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Status = false, Message = "Data Updated Faild." }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { Status = false, Message = "Data Updated Faild." }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Status = false, Message = "Data Updated Faild." }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Routes/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, RoutesDataVM entity)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            RoutesVM data = entity.RoutesVM;
        //            RoutesDetailsVM detailsData = entity.RoutesDetailsVM;
        //            // TODO: Add update logic here
        //            if (id != entity.Id)
        //            {
        //                return RedirectToAction(nameof(RoutesController.Index), "Routes");
        //            }
        //            entity.RoutesVM.IsActive = true;
        //            entity.RoutesVM.IsDeleted = false;
        //            entity.RoutesVM.UpdatedAt = DateTime.Now;
        //            entity.RoutesDetailsVM.IsActive = true;
        //            entity.RoutesDetailsVM.IsDeleted = false;
        //            entity.RoutesDetailsVM.UpdatedAt = DateTime.Now;
        //            (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.Update(data);
        //            Session["Message"] = returnResponse.message;
        //            Session["executionState"] = returnResponse.executionState;
        //            if (returnResponse.executionState.ToString() != "Updated")
        //            {
        //                (ExecutionState executionState, RoutesVM entity, string message) returnRoutesResponse = _RoutesService.GetById(id);
        //                if (returnRoutesResponse.entity != null)
        //                {
        //                    entity.RoutesDetails = returnRoutesResponse.entity.RoutesDetails;
        //                }
        //                return View(entity);
        //            }
        //            else
        //            {
        //                (ExecutionState executionState, RoutesDetailsVM entity, string message) returnRoutesDetailsResponse;
        //                detailsData.RoutesId = id;
        //                if (detailsData.Id > 0)
        //                {
        //                     returnRoutesDetailsResponse = _RoutesDetailsService.Update(detailsData);

        //                }
        //                else
        //                {
        //                     returnRoutesDetailsResponse = _RoutesDetailsService.Create(detailsData);

        //                }
        //                //return RedirectToAction("Index");
        //                Session["Message"] = returnRoutesDetailsResponse.message;
        //                Session["executionState"] = returnRoutesDetailsResponse.executionState;
        //                (ExecutionState executionState, RoutesVM entity, string message) returnRoutesResponse = _RoutesService.GetById(id);
        //                if (returnRoutesResponse.entity != null)
        //                {
        //                    entity.RoutesDetails = returnRoutesResponse.entity.RoutesDetails;
        //                }
        //                return RedirectToAction("Edit", new { id = id, sdid = 0 });
        //            }
        //        }

        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Routes/Delete/5
        public JsonResult Delete(int id)
        {
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.Delete(id);
            if (returnResponse.executionState.ToString() == "Updated")
            {
                returnResponse.message = "Routes deleted successfully.";
            }
            return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
            //return View();
        }

        // POST: Routes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RoutesVM entity)
        {
            try
            {
                // TODO: Add update logic here
                if (id != entity.Id)
                {
                    return RedirectToAction(nameof(RoutesController.Index), "Routes");
                }
                //entity.IsActive = true;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.Update(entity);
                Session["Message"] = returnResponse.message;
                Session["executionState"] = returnResponse.executionState;
                //return View(returnResponse.entity);
                // return RedirectToAction("Edit?id="+id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult RoutesMapView(long RoutesId)
        {
            RoutesVM master = new RoutesVM();
            (ExecutionState executionState, RoutesVM entity, string message) returnResponse = _RoutesService.GetById(RoutesId);
             master = returnResponse.entity;
            if (master != null)
            {
                (ExecutionState executionState, UserVM entity, string message) returnExistingUserResponse = _UserService.GetById(master.UserId);
                ViewBag.UserName = returnExistingUserResponse.entity.UserName;
                ViewBag.SessionName = master.SessionName;

                if (returnResponse.entity.RoutesDetails.Count() > 0)
                {
                    var filterData = returnResponse.entity.RoutesDetails.OrderByDescending(x => x.StartDate);//.ThenByDescending(x => x.EndDate);
                    ViewBag.DetailsData = filterData;
                    ViewBag.RowCount = filterData.Count();
                }
                if (master.JsonFileName == "" || master.JsonFileName == null)
                {
                    ViewBag.DamageMapJson = null;
                    return View();
                }
                List<RoutesRequest> mapGeoJson = GetRoutesJson(master.JsonFileName);
                GeojsonlintResponseModel geojsonlintResponseModel = new GeojsonlintResponseModel();
                geojsonlintResponseModel.type = "FeatureCollection";
                foreach (var item in mapGeoJson)
                {
                    geojsonlintResponseModel.features.Add(item);
                }

                var responseData = JsonConvert.SerializeObject(geojsonlintResponseModel);
                JToken mapJson = responseData.ToString();
                ViewBag.DamageMapJson = mapJson.ToString();
                
                //List<DamageImagesViewModel> images = new List<DamageImagesViewModel>();
                //List<DamageImages> imagesList = repo.DamageImageRepository.FindByDamageMasterId(Convert.ToInt64(damageMasterId));
                //ViewBag.DamageImages = null;
                //ViewBag.RoadName = master.Road.RoadName;
                //if (imagesList.Count() > 0)
                //{
                //    master = repo.DamageSurveyMasterRepository.Find(imagesList.FirstOrDefault().DamageSurveyMasterID);
                //    images = GetImageList(imagesList, master);
                //    ViewBag.DamageImages = images;
                //    ViewBag.RoadName = master.Road.RoadName;
                //}
            }
            return View();
        }

        private List<RoutesRequest> GetRoutesJson(string FileName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            string[] lines = System.IO.File.ReadAllLines(path + "Urls.txt");
            List<RoutesRequest> jsonResponse = new List<RoutesRequest>();
            //string fileLocation = string.Format(AppDomain.CurrentDomain.BaseDirectory + "jsons\\DamageJsons\\RoadWiseDamageLineString\\{0}.json", FileName);
            //string fileLocation = @"D:\Office Work\DgFood\pims_dgfood\DgFood\jsons\RoutesMasterfilesLineString\"+FileName+ ".json";
            string fileLocation = @""+ lines[0] + FileName + ".json";

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string jsonR = r.ReadToEnd();
                var output = JsonConvert.DeserializeObject<List<RoutesRequest>>(jsonR);
                jsonResponse = output;
                //jsonResponse.features.Add(output);
            }
            return jsonResponse;
        }


    }
}

using PTSL.BdArmy.Common.Entity.BdArmy;
using PTSL.BdArmy.Web.Helper;
using PTSL.BdArmy.Web.Helper.Enum;
using PTSL.BdArmy.Web.Model;
using PTSL.BdArmy.Web.Model.EntityViewModels;
using PTSL.BdArmy.Web.Services.Implementation.GeneralSetup;
using PTSL.BdArmy.Web.Services.Interface.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTSL.BdArmy.Web.Controllers
{
    [SessionAuthorize]
    public class HomeController : Controller
    {
        private readonly IPmsGroupService _PmsGroupService;
        private readonly IAccessMapperService _AccessMapperService;
        private readonly IAccesslistService _AccesslistService;
        private readonly IModuleService _ModuleService;
        private readonly IUserService _UserService;
        private readonly IRoutesService _RoutesService;
        public HomeController()
        {
            _PmsGroupService = new PmsGroupService();
            _AccessMapperService = new AccessMapperService();
            _AccesslistService = new AccesslistService();
            _ModuleService = new ModuleService();
            _UserService = new UserService();
            _RoutesService = new RoutesService();
        }
        public ActionResult Index()
        {
            (ExecutionState executionState, List<RoutesVM> entity, string message) returnRoutesResponse = _RoutesService.List();
            var totalRoutesCreated = 0;
            var totalCompleted = 0;
            var totalIncompleted = 0;
            string completedPercent = "0";
            string inCompletedPercent = "0";
            ViewBag.data = null;
            if (returnRoutesResponse.entity != null)
            {
                var atotalRoutesCreated = returnRoutesResponse.entity.Select(x => x.RoutesDetails.Count());
                //totalRoutesCreated = returnRoutesResponse.entity.Count(x=>x.RoutesDetails.ToList()).Count();
                totalRoutesCreated = returnRoutesResponse.entity
                             .Select(x => x.RoutesDetails.Count(y => y.IsDeleted == false))
                             .Sum();
                totalCompleted = returnRoutesResponse.entity.Where(x => x.IsArrived == true)
                             .Select(x => x.RoutesDetails.Count(y => y.IsDeleted == false))
                             .Sum();
                totalIncompleted = returnRoutesResponse.entity.Where(x => x.IsArrived == false)
                             .Select(x => x.RoutesDetails.Count(y => y.IsDeleted == false))
                             .Sum();
                //totalCompleted = returnRoutesResponse.entity.Where(x=>x.IsArrived == true).Select(x => x.RoutesDetails.Count()).Count();
                //totalIncompleted = returnRoutesResponse.entity.Where(x => x.IsArrived == false).Select(x => x.RoutesDetails.Count()).Count();
                decimal routesDevided = (100m / totalRoutesCreated);
                //completedPercent = routesDevided * totalCompleted;
                //inCompletedPercent = 100 - completedPercent;//(100 / totalRoutesCreated) * totalIncompleted;
                completedPercent = String.Format("{0:0}", routesDevided * totalCompleted);
                inCompletedPercent = String.Format("{0:0}", 100 - (routesDevided * totalCompleted));

                //chart data
                var users = _UserService.List();
                DateTime lastSixDaysDate= DateTime.Now.AddDays(-4);

               // var data = new List<RoutesListsVM>();
               var data = (from routes in returnRoutesResponse.entity//.Where(x=>x.CreatedAt >= lastSixMonthDate)
                            join user in users.entity
                            on routes.UserId equals user.Id
                            select new
                            {
                                //Id = routes.Id,
                                //CreatedAt = routes.CreatedAt,
                                UserName = user.UserName,
                                UserEmail = user.UserEmail,
                                Total = routes.RoutesDetails.Count(),
                                Completed = routes.RoutesDetails.Where(x => x.IsArrived == true).Count(),
                                NotCompleted = routes.RoutesDetails.Where(x => x.IsArrived == false).Count(),
                                //IsArrived = routes.IsArrived
                            }).GroupBy(x=>x.UserName).Select(y=> new {
                                UserName = y.FirstOrDefault().UserName,
                                UserEmail = y.FirstOrDefault().UserEmail,
                                Total = y.Sum(z=>z.Total),
                                Completed = y.Sum(z => z.Completed),
                                NotCompleted = y.Sum(z => z.NotCompleted),
                            } ).ToList();
                ViewBag.data = data;

                var dayWisedata = (from routes in returnRoutesResponse.entity.Where(x=> Convert.ToDateTime(x.CreatedAt.Date) >= Convert.ToDateTime(lastSixDaysDate.Date))
                            join user in users.entity
                            on routes.UserId equals user.Id
                            select new
                            {
                                //Id = routes.Id,
                                CreatedAt = routes.CreatedAt,
                               // UserName = user.UserName,
                               // UserEmail = user.UserEmail,
                                Total = routes.RoutesDetails.Count(),
                                Completed = routes.RoutesDetails.Where(x => x.IsArrived == true).Count(),
                                NotCompleted = routes.RoutesDetails.Where(x => x.IsArrived == false).Count(),
                                //IsArrived = routes.IsArrived
                            }).GroupBy(x => x.CreatedAt.Date).Select(y => new {
                                CreatedAt = y.FirstOrDefault().CreatedAt.Date.ToString(),
                                //UserName = y.FirstOrDefault().UserName,
                                //UserEmail = y.FirstOrDefault().UserEmail,
                                Total = y.Sum(z => z.Total),
                                Completed = y.Sum(z => z.Completed),
                                NotCompleted = y.Sum(z => z.NotCompleted),
                            }).ToList();
                ViewBag.dayWisedata = dayWisedata;

            }
            ViewBag.totalRoutesCreated = totalRoutesCreated;
            ViewBag.totalCompleted = totalCompleted;
            ViewBag.totalIncompleted = totalIncompleted;
            ViewBag.completedPercent = completedPercent;
            ViewBag.inCompletedPercent = inCompletedPercent;
            ViewBag.PrlCount = "";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult RootMenue()
        {
            //IGXMenu menu = new IGXMenu();
            Menu menu = new Menu();

            List<Model.EntityViewModels.MenueViewModel> menueList = new List<Model.EntityViewModels.MenueViewModel>();

            try
            {
                menu = PmsRootMenueList();
                menueList = menu.MenuList;
                return Json(menu, JsonRequestBehavior.AllowGet); //ViewBag.GroupList = GroupList.ToList();

            }
            catch (Exception ex)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }

        }

        public Menu PmsRootMenueList()
        {
            Menu menu = new Menu();
            try
            {

                List<CustomerAccessList> AllAccesslist = new List<CustomerAccessList>();

                List<Model.EntityViewModels.MenueViewModel> menueList = new List<Model.EntityViewModels.MenueViewModel>();

                List<int> AccesList = new List<int>();
                //var aspNetUser = UserManager.Users.ToList().Where(x => !x.IsRemoved && x.Id == User.Identity.GetUserId()).FirstOrDefault();
                long GroupID = 1;// Convert.ToInt32(aspNetUser.PmsGroupID);


                long LoggedInUser = MySession.Current.UserId; // User.Identity.GetUserId();
                var loginUser = _UserService.GetById(LoggedInUser);
                var UserName = MySession.Current.UserEmail;// User.Identity.GetUserName();
                // var PmsGroupId = _PmsGroupService.GetById(GroupID);
                if(loginUser.entity != null)
                {
                    GroupID = loginUser.entity.PmsGroupID;
                }
                (ExecutionState executionState, PmsGroupVM entity, string message) returnPmsGroupResponse = _PmsGroupService.GetById(GroupID);

                string GroupName = returnPmsGroupResponse.entity.GroupName;


                if (GroupID != 0)
                {
                    (ExecutionState executionState, AccessMapperVM entity, string message) returnAccessMapperVMResponse = _AccessMapperService.GetById(GroupID);

                    //var accessMapper = _AccessMapperService.GetById(GroupID);
                    string s = returnAccessMapperVMResponse.entity.AccessList;
                    string[] values = s.Split(',');
                    foreach (var value in values)
                    {
                        AccesList.Add(Convert.ToInt32(value));
                    }
                    foreach (var item in AccesList)
                    {
                        try
                        {
                            //var access = _AccesslistService.GetById(item);
                            (ExecutionState executionState, AccesslistVM entity, string message) returnAccesslistResponse = _AccesslistService.GetById(item);

                            CustomerAccessList custom = new CustomerAccessList();
                            custom.AccessID = returnAccesslistResponse.entity.Id;
                            custom.AccessStatus = returnAccesslistResponse.entity.AccessStatus;
                            custom.ActionName = returnAccesslistResponse.entity.ActionName;
                            custom.BaseModule = returnAccesslistResponse.entity.BaseModule;
                            custom.ControllerName = returnAccesslistResponse.entity.ControllerName;
                            custom.IconClass = returnAccesslistResponse.entity.IconClass;
                            custom.Mask = returnAccesslistResponse.entity.Mask;
                            custom.BaseModuleIndex = returnAccesslistResponse.entity.BaseModuleIndex;

                            if (returnAccesslistResponse.entity != null && returnAccesslistResponse.entity.IsVisible == 0)
                            {
                                AllAccesslist.Add(custom);
                            }
                        }
                        catch (Exception ex)
                        {


                        }

                    }
                    (ExecutionState executionState, List<ModuleVM> entity, string message) returnModuleVMResponse = _ModuleService.List();

                    var ModuleList = returnModuleVMResponse.entity.OrderBy(a => a.MenueOrder).ToList();
                    foreach (var item in ModuleList)
                    {
                        Model.EntityViewModels.MenueViewModel menue = new Model.EntityViewModels.MenueViewModel();
                        menue.ModuleID = item.Id;
                        menue.ModuleName = item.ModuleName;
                        menue.ModuleIcon = item.ModuleIcon;
                        var module = _ModuleService.GetById(item.Id);

                        if (module.entity.IsVisible == 0)
                        {
                            var menulist = AllAccesslist.Where(a => a.BaseModule == item.Id).OrderBy(a => a.BaseModuleIndex).ToList();
                            if (menulist.Count > 0)
                            {
                                menue.AccessList = menulist;
                                menueList.Add(menue);
                            }
                        }
                    }
                }
                menu.MenuList = menueList;
                menu.UserName = UserName;
                menu.GroupName = GroupName;

                return menu;

            }
            catch (Exception ex)
            {
                //var formatter = RequestFormat.JsonFormaterString();
                //return Request.CreateResponse(HttpStatusCode.OK, new PayloadResponse { Success = false, Message = "200", Payload = null }, formatter);
                return menu;
            }
        }

    }
}
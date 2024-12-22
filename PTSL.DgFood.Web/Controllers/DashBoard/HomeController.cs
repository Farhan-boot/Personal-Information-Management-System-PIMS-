using PTSL.DgFood.Web.Controllers.GeneralSetup;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Model.EntityViewModels;
using PTSL.DgFood.Web.Services.Implementation;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;
using PTSL.eCommerce.Web.Services.Interface.GeneralSetup;
using PTSL.GENERIC.Web.Core.Services.Implementation.EmployeeManagementEntity;
using PTSL.GENERIC.Web.Core.Services.Interface.EmployeeManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace PTSL.DgFood.Web.Controllers
{
	[SessionAuthorize]
	public class HomeController : Controller
	{
		private readonly IPmsGroupService _PmsGroupService;
		private readonly IAccessMapperService _AccessMapperService;
		private readonly IAccesslistService _AccesslistService;
		private readonly IModuleService _ModuleService;
		private readonly IUserService _UserService;
		private readonly IEmployeeInformationService _EmployeeInformationService;
		public readonly IPRLService _prlService;
		private readonly IDashboardService _dashboardService;
		private readonly ITrainingManagementTypeService _trainingManagementTypeService;
        private readonly IEmployeePostingDetailsService _EmployeePostingDetailsService;

        public HomeController()
		{
			_PmsGroupService = new PmsGroupService();
			_AccessMapperService = new AccessMapperService();
			_AccesslistService = new AccesslistService();
			_ModuleService = new ModuleService();
			_UserService = new UserService();
			_EmployeeInformationService = new EmployeeInformationService();
			_prlService = new PRLService();
			_dashboardService = new DashboardService();
			_trainingManagementTypeService = new TrainingManagementTypeService();
            _EmployeePostingDetailsService = new EmployeePostingDetailsService();
        }

		public ActionResult Index()
		{
			var RoleName = Session["RoleName"].ToString();

			if (RoleName == "Employee Group")
			{
				return RedirectToAction(nameof(AccountController.LogOff), "Account");
			}

			var prlList = _prlService.List();
			IList<OfficialInformationVM> empList = prlList.Result.entity.Take(5).ToList();

			ViewBag.PrlList = empList;
			ViewBag.PrlCount = prlList.Result.entity.Count;
			ViewBag.Dashboard = _dashboardService.GetData().entity ?? new DashboardVM();
			ViewBag.TrainingManagementTypes = _trainingManagementTypeService.ListLatest(10).entity ?? new List<TrainingManagementTypeVM>();


            //Show Dept Name by LogIn user
            var employeeInformationId = (long)Session["EmployeeInformationId"];

			var empLogInfo = _EmployeePostingDetailsService.List().entity.Where(x => x.EmployeeInformationId == employeeInformationId).LastOrDefault();
            ViewBag.DeptName = empLogInfo?.Posting?.PostingName;


            return View();
		}

		public ActionResult EmployeeIndex()
		{
			EmployeeInformationVM entity = new EmployeeInformationVM();
			var RoleName = Session["RoleName"].ToString();
			//entity.Email = Session["UserEmail"].ToString();
			entity.Id = (long)Session["EmployeeInformationId"];


			EmployeeInformationVM filterData = new EmployeeInformationVM();
			filterData.Id = entity.Id;

			(ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.GetById(entity.Id);
			entity = returnResponse.entity;

			DropdownController dc = new DropdownController();

			List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
			ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName", returnResponse.entity.DivisionId);

			List<DistrictVM> returnDistrictResponse = dc.GetDistrictByDivisionId(entity.DivisionId); //_DistrictService.List();
			ViewBag.DistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName", returnResponse.entity.DistrictId);

			var returnPoliceStationResponse = dc.GetPoliceStationByDistrictId(entity.DistrictId);
			ViewBag.PoliceStationId = new SelectList(returnPoliceStationResponse, "Id", "PoliceStationName", returnResponse.entity.PoliceStationId);

			ICollection<EmployeeStatusVM> returnOfficialInformationEmployeeStatusResponse = dc.GetEmployeeStatus();
			ViewBag.OfficialInformationEmployeeStatusId = new SelectList(returnOfficialInformationEmployeeStatusResponse, "Id", "EmployeeStatusName", returnResponse.entity.OfficialInformation);

			List<Dropdown2VM> returnBloodGroupResponse = dc.GetBloodGroups();
			ViewBag.BloodGroup = new SelectList(returnBloodGroupResponse, "Id", "Name", (int)entity?.BloodGroup);

			var GenderList = dc.GetGenders();
			ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", (int)entity.GenderId);

			var MaritalStatusList = dc.GetMaritalStatus();
			ViewBag.MaritalStatusId = new SelectList(MaritalStatusList, "Id", "Name", (int)entity.MaritalStatusId);

			var ReligionList = dc.GetReligions();
			ViewBag.ReligionId = new SelectList(ReligionList, "Id", "Name", (int)entity.ReligionId);

			return View(entity);
		}


        public ActionResult IndividualEmployeeIndex()
        {
            EmployeeInformationVM entity = new EmployeeInformationVM();
            var RoleName = Session["RoleName"].ToString();
            //entity.Email = Session["UserEmail"].ToString();
            entity.Id = (long)Session["EmployeeInformationId"];


            EmployeeInformationVM filterData = new EmployeeInformationVM();
            filterData.Id = entity.Id;

            (ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _EmployeeInformationService.GetById(entity.Id);
            entity = returnResponse.entity;

            DropdownController dc = new DropdownController();

            List<DivisionVM> returnDivisionResponse = dc.GetDivisions();
            ViewBag.DivisionId = new SelectList(returnDivisionResponse, "Id", "DivisionName", returnResponse.entity.DivisionId);

            List<DistrictVM> returnDistrictResponse = dc.GetDistrictByDivisionId(entity.DivisionId); //_DistrictService.List();
            ViewBag.DistrictId = new SelectList(returnDistrictResponse, "Id", "DistrictName", returnResponse.entity.DistrictId);

            var returnPoliceStationResponse = dc.GetPoliceStationByDistrictId(entity.DistrictId);
            ViewBag.PoliceStationId = new SelectList(returnPoliceStationResponse, "Id", "PoliceStationName", returnResponse.entity.PoliceStationId);

            ICollection<EmployeeStatusVM> returnOfficialInformationEmployeeStatusResponse = dc.GetEmployeeStatus();
            ViewBag.OfficialInformationEmployeeStatusId = new SelectList(returnOfficialInformationEmployeeStatusResponse, "Id", "EmployeeStatusName", returnResponse.entity.OfficialInformation);

            List<Dropdown2VM> returnBloodGroupResponse = dc.GetBloodGroups();
            ViewBag.BloodGroup = new SelectList(returnBloodGroupResponse, "Id", "Name", (int)entity?.BloodGroup);

            var GenderList = dc.GetGenders();
            ViewBag.GenderId = new SelectList(GenderList, "Id", "Name", (int)entity.GenderId);

            var MaritalStatusList = dc.GetMaritalStatus();
            ViewBag.MaritalStatusId = new SelectList(MaritalStatusList, "Id", "Name", (int)entity.MaritalStatusId);

            var ReligionList = dc.GetReligions();
            ViewBag.ReligionId = new SelectList(ReligionList, "Id", "Name", (int)entity.ReligionId);

            return View(entity);
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
				if (loginUser.entity != null)
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

							if (returnAccesslistResponse.entity != null && returnAccesslistResponse.entity.IsVisible == 0)
							{
								custom.AccessID = returnAccesslistResponse.entity.Id;
								custom.AccessStatus = returnAccesslistResponse.entity.AccessStatus;
								custom.ActionName = returnAccesslistResponse.entity.ActionName;
								custom.BaseModule = returnAccesslistResponse.entity.BaseModule;
								custom.ControllerName = returnAccesslistResponse.entity.ControllerName;
								custom.IconClass = returnAccesslistResponse.entity.IconClass;
								custom.Mask = returnAccesslistResponse.entity.Mask;
								custom.BaseModuleIndex = returnAccesslistResponse.entity.BaseModuleIndex;
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
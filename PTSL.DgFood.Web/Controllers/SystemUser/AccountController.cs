using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PTSL.DgFood.Web.Controllers.EmployeeManagement;
using PTSL.DgFood.Web.Helper;
using PTSL.DgFood.Web.Helper.Enum;
using PTSL.DgFood.Web.Model;
using PTSL.DgFood.Web.Models;
using PTSL.DgFood.Web.Services.Implementation.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Implementation.GeneralSetup;
using PTSL.DgFood.Web.Services.Interface.EmployeeManagementEntity;
using PTSL.DgFood.Web.Services.Interface.GeneralSetup;

namespace PTSL.DgFood.Web.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;
		private readonly IPmsGroupService _PmsGroupService;
		private readonly IUserService _UserService;
		private readonly IEmployeeInformationService _employeeInformationService;
		public AccountController()
		{
			_PmsGroupService = new PmsGroupService();
			_UserService = new UserService();
			_employeeInformationService = new EmployeeInformationService();
		}

		public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			UserManager = userManager;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}

			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		//
		// GET: /Account/Login
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			LoginVM model = new LoginVM();
			return View(model);
		}

		//
		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginVM model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			(ExecutionState executionState, LoginResultVM entity, string message) returnResponse = _UserService.UserLogin(model);

			if (returnResponse.executionState == ExecutionState.Retrieved)
			{
				Session["Token"] = returnResponse.entity.Token;
				Session["UserEmail"] = returnResponse.entity.UserEmail;
				Session["EmployeeInformationId"] = returnResponse.entity.EmployeeInformationId;
				Session["RoleName"] = returnResponse.entity.RoleName;
				MySession.Current.Token = returnResponse.entity.Token;
				MySession.Current.UserId = returnResponse.entity.UserId;
				MySession.Current.UserEmail = returnResponse.entity.UserEmail;

                

            }

			if (returnResponse.entity != null && returnResponse.entity.RoleName == "Employee Group" && returnResponse.entity.EmployeeInformationId != 0)
			{
                return RedirectToAction(nameof(HomeController.EmployeeIndex), "Home");
			}

            if (returnResponse.entity != null && returnResponse.entity.RoleName == "Individual Employee Group" && returnResponse.entity.EmployeeInformationId != 0)
            {
                Session["IndividualEmployeeGroup"] = "Individual Employee Group";
                return RedirectToAction(nameof(HomeController.IndividualEmployeeIndex), "Home");
            }


            if (returnResponse.entity != null)
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
			else
			{
				ViewBag.ErrorMsg = "Username or Password Invalid !";
				return View(model);
			}

			//// This doesn't count login failures towards account lockout
			//// To enable password failures to trigger account lockout, change to shouldLockout: true
			//var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
			//switch (result)
			//{
			//    case SignInStatus.Success:
			//        return RedirectToLocal(returnUrl);
			//    case SignInStatus.LockedOut:
			//        return View("Lockout");
			//    case SignInStatus.RequiresVerification:
			//        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
			//    case SignInStatus.Failure:
			//    default:
			//        ModelState.AddModelError("", "Invalid login attempt.");
			//        return View(model);
			//}
		}

		//
		// GET: /Account/VerifyCode
		[AllowAnonymous]
		public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
		{
			// Require that the user has already logged in via username/password or external login
			if (!await SignInManager.HasBeenVerifiedAsync())
			{
				return View("Error");
			}
			return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
		}

		//
		// POST: /Account/VerifyCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			// The following code protects for brute force attacks against the two factor codes. 
			// If a user enters incorrect codes for a specified amount of time then the user account 
			// will be locked out for a specified amount of time. 
			// You can configure the account lockout settings in IdentityConfig
			var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(model.ReturnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.Failure:
				default:
					ModelState.AddModelError("", "Invalid code.");
					return View(model);
			}
		}

		// GET: UrerList
		[AllowAnonymous]
		public ActionResult UserLists()
		{
			(ExecutionState executionState, List<UserVM> entity, string message) returnResponse = _UserService.List();
			return View(returnResponse.entity);
		}

		[AllowAnonymous]
		public ActionResult EmployeeUserLists()
		{
			(ExecutionState executionState, List<UserVM> entity, string message) returnResponse = _UserService.EmployeeUserLists();
			return View(returnResponse.entity);
		}

		//
		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register()
		{

			ViewBag.GroupList = new SelectList(GroupList(), "Id", "GroupName");
			UserVM rvm = new UserVM();
			return View(rvm);
		}

		//
		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(UserVM model)
		{
			try
			{
				List<PmsGroupViewModel> group = new List<PmsGroupViewModel>();
				group = GroupList();
				//ViewBag.GroupList = group;
				ViewBag.GroupList = new SelectList(GroupList(), "Id", "GroupName", model.PmsGroupID);
				if (ModelState.IsValid)
				{

					var nameOfGroup = group.Where(a => a.Id == model.PmsGroupID).FirstOrDefault();
					model.IsActive = true;
					model.CreatedAt = DateTime.Now;
					model.RoleName = nameOfGroup.GroupName;
					// TODO: Add insert logic here
					(ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Create(model);
					Session["Message"] = returnResponse.message;
					Session["executionState"] = returnResponse.executionState;

					if (returnResponse.executionState.ToString() != "Created")
					{
						return View(model);
					}
					else
					{
						return RedirectToAction("UserLists");
					}
				}
				return View(model);
			}
			catch
			{
				return View(model);
			}



			//if (ModelState.IsValid)
			//{

			//    //var user = new ApplicationUser { UserName = model.UserEmail, Email = model.UserEmail };
			//    //var result = await UserManager.CreateAsync(user, model.UserPassword);
			//    //if (result.Succeeded)
			//    //{
			//    //    await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

			//    //    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
			//    //    // Send an email with this link
			//    //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
			//    //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
			//    //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

			//    //    return RedirectToAction("Index", "Home");
			//    //}
			//    //AddErrors(result);

			//}

			//// If we got this far, something failed, redisplay form
			//return View(model);
		}


		// GET: /Account/RegisterEmployeeUser
		[AllowAnonymous]
		public ActionResult RegisterEmployeeUser(long id)
		{
			UserVM userVM = new UserVM();

			(ExecutionState executionState, EmployeeInformationVM entity, string message) returnResponse = _employeeInformationService.GetById(id);

			if (returnResponse.executionState != ExecutionState.Retrieved)
			{
				return RedirectToAction("Index", "EmployeeInformation");
			}

			ViewBag.EmployeeInformationId = id;

			userVM.UserName = returnResponse.entity.NameEnglish;
			userVM.UserEmail = returnResponse.entity.EmployeeCode;

			return View(userVM);
		}

		// POST: /Account/RegisterEmployeeUser
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> RegisterEmployeeUser(UserVM model)
		{
			try
			{
				List<PmsGroupViewModel> groups = GroupList();
				ViewBag.EmployeeInformationId = model.EmployeeInformationId;

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				(ExecutionState executionState, EmployeeInformationVM entity, string message) empInfoResponse = _employeeInformationService.GetById(model.EmployeeInformationId);

				if (empInfoResponse.executionState != ExecutionState.Retrieved)
				{
					Session["Message"] = "Invalid Employee";
					Session["executionState"] = empInfoResponse.executionState;
					return RedirectToAction("RegisterEmployeeUser", "Account", new { id = model.EmployeeInformationId });
				}

				

				// Email Validation
				(ExecutionState executionState, long entity, string message) countEmailResult = _UserService.CountByEmail(model.UserEmail);
				long userEmailCount = 0;
				if (countEmailResult.executionState == ExecutionState.Success)
					userEmailCount = countEmailResult.entity;

				if (userEmailCount != 0)
				{
					Session["Message"] = "Email already exists";
					Session["executionState"] = countEmailResult.executionState;
					return RedirectToAction("RegisterEmployeeUser", "Account", new { id = model.EmployeeInformationId });
				}

				model.IsActive = true;
				model.IsDeleted = false;
				model.CreatedAt = DateTime.Now;
				model.RoleName = "Employee Group";
				model.PmsGroupID = groups.FirstOrDefault(x => x.GroupName == "Employee Group").Id;
				model.UserName = empInfoResponse.entity.NameEnglish;
				model.UserEmail = empInfoResponse.entity.EmployeeCode;

				(ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Create(model);

				Session["Message"] = returnResponse.message;
				Session["executionState"] = returnResponse.executionState;

				if (returnResponse.executionState != ExecutionState.Created)
				{
					return RedirectToAction("RegisterEmployeeUser", "Account", new { id = model.EmployeeInformationId });
				}
				else
				{
					return RedirectToAction("Index", "EmployeeInformation");
				}
			}
			catch (Exception ex)
			{
				return View(model);
			}
		}


		[AllowAnonymous]
		public ActionResult UserEdit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}

			(ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.GetById(id);

			ViewBag.GroupList = new SelectList(GroupList(), "Id", "GroupName", returnResponse.entity.PmsGroupID);
			return View(returnResponse.entity);
		}

		// POST: Account/UserEdit/5
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult UserEdit(int id, UserVM entity)
		{
			try
			{
				List<PmsGroupViewModel> group = new List<PmsGroupViewModel>();
				group = GroupList();
				ViewBag.GroupList = new SelectList(GroupList(), "Id", "GroupName", entity.PmsGroupID);

				if (ModelState.IsValid)
				{
					// TODO: Add update logic here
					if (id != entity.Id)
					{
						return RedirectToAction(nameof(AccountController.UserLists), "Account");
					}
					entity.IsActive = true;
					entity.IsDeleted = false;
					entity.UpdatedAt = DateTime.Now;

					ViewBag.GroupList = group;
					var nameOfGroup = group.Where(a => a.Id == entity.PmsGroupID).FirstOrDefault();
					entity.RoleName = nameOfGroup.GroupName;

					(ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Update(entity);
					Session["Message"] = returnResponse.message;
					Session["executionState"] = returnResponse.executionState;
					if (returnResponse.executionState.ToString() != "Updated")
					{
						return View(entity);
					}
					else
					{
						return RedirectToAction("UserLists");
					}
				}

				return View();
			}
			catch
			{
				return View();
			}
		}

		[AllowAnonymous]
		public ActionResult EmployeeUserEdit(long? EmployeeInformationId)
		{
			if (EmployeeInformationId == null)
			{
				return HttpNotFound();
			}

			(ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.GetByEmployeeInformationId(EmployeeInformationId);

			if (returnResponse.entity == null || returnResponse.entity.EmployeeInformationId == 0)
			{
				return HttpNotFound();
			}

			ViewBag.EmployeeInformationId = EmployeeInformationId;

			return View(returnResponse.entity);
		}

		// POST: Account/EmployeeUserEdit/5
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult EmployeeUserEdit(long EmployeeInformationId, UserVM entity)
		{
			try
			{
				List<PmsGroupViewModel> groups = GroupList();

				if (ModelState.IsValid)
				{
					// TODO: Add update logic here
					if (EmployeeInformationId != entity.EmployeeInformationId)
					{
						return RedirectToAction(nameof(AccountController.UserLists), "Account");
					}

					(ExecutionState executionState, EmployeeInformationVM entity, string message) empInfoResponse = _employeeInformationService.GetById(EmployeeInformationId);
					if (empInfoResponse.executionState != ExecutionState.Retrieved)
					{
						Session["Message"] = "Invalid Employee";
						Session["executionState"] = empInfoResponse.executionState;
						return RedirectToAction("EmployeeUserEdit", "Account", new { id = EmployeeInformationId });
					}

					entity.IsActive = true;
					entity.IsDeleted = false;
					entity.UpdatedAt = DateTime.Now;
					entity.RoleName = "Employee Group";
					entity.PmsGroupID = groups.FirstOrDefault(x => x.GroupName == "Employee Group").Id;
					entity.UserName = empInfoResponse.entity.NameEnglish;
					entity.UserEmail = empInfoResponse.entity.EmployeeCode;

					(ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Update(entity);
					Session["Message"] = returnResponse.message;
					Session["executionState"] = returnResponse.executionState;
					if (returnResponse.executionState != ExecutionState.Updated)
					{
						return RedirectToAction(nameof(AccountController.EmployeeUserEdit), "Account", new { id = entity.EmployeeInformationId });
					}
					else
					{
						return RedirectToAction(nameof(EmployeeInformationController.Index), "EmployeeInformation");
					}
				}

				return RedirectToAction("EmployeeUserEdit", "Account", new { id = EmployeeInformationId });
			}
			catch
			{
				return RedirectToAction("EmployeeUserEdit", "Account", new { id = EmployeeInformationId });
			}
		}


		// GET: Account/UserDelete/5
		[AllowAnonymous]
		public JsonResult UserDelete(int id)
		{
			(ExecutionState executionState, UserVM entity, string message) returnResponse = _UserService.Delete(id);
			if (returnResponse.executionState.ToString() == "Updated")
			{
				returnResponse.message = "User deleted successfully.";
			}
			return Json(new { Message = returnResponse.message, executionState = returnResponse.executionState }, JsonRequestBehavior.AllowGet);
			//return View();
		}



		public List<PmsGroupViewModel> GroupList()
		{


			(ExecutionState executionState, List<PmsGroupVM> entity, string message) returnPmsGroupResponse = _PmsGroupService.List();

			List<PmsGroupViewModel> result = returnPmsGroupResponse.entity.Where(c => c.IsActive == true && c.IsVisible != 1).Select(c => new PmsGroupViewModel
			{
				Id = c.Id,
				GroupName = c.GroupName
			}).ToList();
			//var accessList = _PmsGroupService.GetAll()
			//.Select(g => new PmsGroupViewModel
			//{
			//    GroupID = g.GroupID,
			//    GroupName = g.GroupName

			//}).ToList();

			return result;
		}

		//
		// GET: /Account/ConfirmEmail
		[AllowAnonymous]
		public async Task<ActionResult> ConfirmEmail(string userId, string code)
		{
			if (userId == null || code == null)
			{
				return View("Error");
			}
			var result = await UserManager.ConfirmEmailAsync(userId, code);
			return View(result.Succeeded ? "ConfirmEmail" : "Error");
		}

		//
		// GET: /Account/ForgotPassword
		[AllowAnonymous]
		public ActionResult ForgotPassword()
		{
			return View();
		}

		//
		// POST: /Account/ForgotPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await UserManager.FindByNameAsync(model.Email);
				if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
				{
					// Don't reveal that the user does not exist or is not confirmed
					return View("ForgotPasswordConfirmation");
				}

				// For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
				// Send an email with this link
				// string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
				// var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
				// await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
				// return RedirectToAction("ForgotPasswordConfirmation", "Account");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		//
		// GET: /Account/ForgotPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ForgotPasswordConfirmation()
		{
			return View();
		}

		//
		// GET: /Account/ResetPassword
		[AllowAnonymous]
		public ActionResult ResetPassword(string code)
		{
			return code == null ? View("Error") : View();
		}

		//
		// POST: /Account/ResetPassword
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await UserManager.FindByNameAsync(model.Email);
			if (user == null)
			{
				// Don't reveal that the user does not exist
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("ResetPasswordConfirmation", "Account");
			}
			AddErrors(result);
			return View();
		}

		//
		// GET: /Account/ResetPasswordConfirmation
		[AllowAnonymous]
		public ActionResult ResetPasswordConfirmation()
		{
			return View();
		}

		//
		// POST: /Account/ExternalLogin
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult ExternalLogin(string provider, string returnUrl)
		{
			// Request a redirect to the external login provider
			return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
		}

		//
		// GET: /Account/SendCode
		[AllowAnonymous]
		public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
		{
			var userId = await SignInManager.GetVerifiedUserIdAsync();
			if (userId == null)
			{
				return View("Error");
			}
			var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
			var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
			return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
		}

		//
		// POST: /Account/SendCode
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> SendCode(SendCodeViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			// Generate the token and send it
			if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
			{
				return View("Error");
			}
			return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
		}

		//
		// GET: /Account/ExternalLoginCallback
		[AllowAnonymous]
		public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
		{
			var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
			if (loginInfo == null)
			{
				return RedirectToAction("Login");
			}

			// Sign in the user with this external login provider if the user already has a login
			var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
			switch (result)
			{
				case SignInStatus.Success:
					return RedirectToLocal(returnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				case SignInStatus.RequiresVerification:
					return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
				case SignInStatus.Failure:
				default:
					// If the user does not have an account, then prompt the user to create an account
					ViewBag.ReturnUrl = returnUrl;
					ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
					return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
			}
		}

		//
		// POST: /Account/ExternalLoginConfirmation
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Manage");
			}

			if (ModelState.IsValid)
			{
				// Get the information about the user from the external login provider
				var info = await AuthenticationManager.GetExternalLoginInfoAsync();
				if (info == null)
				{
					return View("ExternalLoginFailure");
				}
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await UserManager.CreateAsync(user);
				if (result.Succeeded)
				{
					result = await UserManager.AddLoginAsync(user.Id, info.Login);
					if (result.Succeeded)
					{
						await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
						return RedirectToLocal(returnUrl);
					}
				}
				AddErrors(result);
			}

			ViewBag.ReturnUrl = returnUrl;
			return View(model);
		}
		[AllowAnonymous]
		public ActionResult LogOff()
		{
			Session["UserEmail"] = string.Empty;
			MySession.Current.Token = string.Empty;
			Session.Abandon();
			Session.Clear();
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			//return Json(true,JsonRequestBehavior.AllowGet);
			return RedirectToAction("Login", "Account");
		}
		////
		//// POST: /Account/LogOff
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult LogOff()
		//{
		//    Session["UserEmail"] = string.Empty;
		//    MySession.Current.Token = string.Empty;
		//    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
		//    return RedirectToAction("Login", "Account");
		//}

		//
		// GET: /Account/ExternalLoginFailure
		[AllowAnonymous]
		public ActionResult ExternalLoginFailure()
		{
			return View();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_userManager != null)
				{
					_userManager.Dispose();
					_userManager = null;
				}

				if (_signInManager != null)
				{
					_signInManager.Dispose();
					_signInManager = null;
				}
			}

			base.Dispose(disposing);
		}

		#region Helpers
		// Used for XSRF protection when adding external logins
		private const string XsrfKey = "XsrfId";

		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			return RedirectToAction("Index", "Home");
		}

		internal class ChallengeResult : HttpUnauthorizedResult
		{
			public ChallengeResult(string provider, string redirectUri)
				: this(provider, redirectUri, null)
			{
			}

			public ChallengeResult(string provider, string redirectUri, string userId)
			{
				LoginProvider = provider;
				RedirectUri = redirectUri;
				UserId = userId;
			}

			public string LoginProvider { get; set; }
			public string RedirectUri { get; set; }
			public string UserId { get; set; }

			public override void ExecuteResult(ControllerContext context)
			{
				var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
				if (UserId != null)
				{
					properties.Dictionary[XsrfKey] = UserId;
				}
				context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
			}
		}
		#endregion
	}
}
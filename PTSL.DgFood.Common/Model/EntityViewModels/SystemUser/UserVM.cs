using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model.BaseModels;
using PTSL.DgFood.Common.Model.EntityViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model
{
    public class UserVM : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string ImageUrl { get; set; }
        public string UserPhone { get; set; }
        public string UserGroup { get; set; }
        public bool UserStatus { get; set; }
        public long PmsGroupID { get; set; }
        public long? GroupID { get; set; }
        public virtual UserGroupVM Group { get; set; }
        public virtual PmsGroupVM PmsGroup { get; set; }
        public long EmployeeInformationId { get; set; }
    }
    public class LoginVM
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
    public class LoginResultVM
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public string RoleName { get; set; }
		public long EmployeeInformationId { get; set; }
	}
}

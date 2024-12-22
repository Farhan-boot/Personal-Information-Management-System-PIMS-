using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity
{
    public class User : BaseEntity
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
        public virtual UserGroup Group { get; set; }
        public virtual PmsGroup PmsGroup { get; set; }
		//public long UserRolesId { get; set; }
		//public virtual UserRoles UserRoles { get; set; }

		public long? EmployeeInformationId { get; set; }
		public virtual EmployeeInformation EmployeeInformation { get; set; }
	}

    public class UserDropdownVM
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

    }
}

using PTSL.DgFood.Common.Entity.CommonEntity;
using PTSL.DgFood.Common.Entity.EmployeeManagementEntity;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity
{
    public class UserRoles : BaseEntity
    {
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

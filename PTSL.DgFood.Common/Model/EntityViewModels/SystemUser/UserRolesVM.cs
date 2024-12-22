using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels
{
    public class UserRolesVM : BaseModel
    {
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

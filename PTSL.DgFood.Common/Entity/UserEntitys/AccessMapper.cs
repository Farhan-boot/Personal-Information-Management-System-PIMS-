using PTSL.DgFood.Common.Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Entity
{
    public class AccessMapper : BaseEntity
    {
        public string AccessList { get; set; }
        public byte RoleStatus { get; set; }
        public byte IsVisible { get; set; }
    }
}

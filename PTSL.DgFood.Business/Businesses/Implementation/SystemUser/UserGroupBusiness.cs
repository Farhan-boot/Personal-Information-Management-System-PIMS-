using PTSL.DgFood.Business.BaseBusinesses;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Business.Businesses.Implementation
{
    public class UserGroupBusiness : BaseBusiness<UserGroup>, IUserGroupBusiness
    {
        public UserGroupBusiness(DgFoodUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //Implement System Busniess Logic here
    }
}

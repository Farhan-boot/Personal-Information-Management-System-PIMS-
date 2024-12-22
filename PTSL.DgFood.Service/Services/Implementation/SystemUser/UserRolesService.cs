using AutoMapper;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Service.BaseServices;
using PTSL.DgFood.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTSL.DgFood.Service.Services.Implementation
{
    public class UserRolesService : BaseService<UserRolesVM, UserRoles>, IUserRolesService
    {
        public readonly IUserRolesBusiness _userRolesBusiness;
        public IMapper _mapper;
        public UserRolesService(IUserRolesBusiness userRolesBusiness, IMapper mapper) : base(userRolesBusiness)
        {
            _userRolesBusiness = userRolesBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override UserRoles CastModelToEntity(UserRolesVM model)
        {
            try
            {
                return _mapper.Map<UserRoles>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override UserRolesVM CastEntityToModel(UserRoles entity)
        {
            try
            {
                UserRolesVM model = _mapper.Map<UserRolesVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<UserRolesVM> CastEntityToModel(IQueryable<UserRoles> entity)
        {
            try
            {
                IList<UserRolesVM> userRolesList = _mapper.Map<IList<UserRolesVM>>(entity).ToList();
                return userRolesList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

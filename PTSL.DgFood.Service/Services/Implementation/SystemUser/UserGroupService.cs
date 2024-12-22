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
    public class UserGroupService : BaseService<UserGroupVM, UserGroup>, IUserGroupService
    {
        public readonly IUserGroupBusiness _userGroupBusiness;
        public IMapper _mapper;
        public UserGroupService(IUserGroupBusiness userGroupBusiness, IMapper mapper) : base(userGroupBusiness)
        {
            _userGroupBusiness = userGroupBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override UserGroup CastModelToEntity(UserGroupVM model)
        {
            try
            {
                return _mapper.Map<UserGroup>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override UserGroupVM CastEntityToModel(UserGroup entity)
        {
            try
            {
                UserGroupVM model = _mapper.Map<UserGroupVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<UserGroupVM> CastEntityToModel(IQueryable<UserGroup> entity)
        {
            try
            {
                IList<UserGroupVM> userGroupList = _mapper.Map<IList<UserGroupVM>>(entity).ToList();
                return userGroupList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

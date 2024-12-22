using AutoMapper;
using PTSL.DgFood.Common.Entity;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Business;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSL.DgFood.Business.Businesses;
using PTSL.DgFood.Service.Services.Interface;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.QuerySerialize.Implementation;

namespace PTSL.DgFood.Service.Services.Implementation
{
    public class UserService : BaseService<UserVM, User>, IUserService
    {
        public readonly IUserBusiness _userBusiness;
        public IMapper _mapper;
        public UserService(IUserBusiness userBusiness, IMapper mapper) : base(userBusiness)
        {
            _userBusiness = userBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public async Task<(ExecutionState executionState, UserVM entity, string message)> UserLogin(LoginVM model)
        {
            (ExecutionState executionState, UserVM entity, string message) returnResponse;
            try
            {
                (ExecutionState executionState, User entity, string message) recieveEntity = await _userBusiness.UserLogin(model);

                if (recieveEntity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: CastEntityToModel(recieveEntity.entity), message: recieveEntity.message);
                }
                else
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: null, message: recieveEntity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        
        public async Task<(ExecutionState executionState, UserVM entity, string message)> GetByEmployeeInformationId(long employeeInformationid)
		{
            (ExecutionState executionState, UserVM entity, string message) returnResponse;
            try
            {
                var filterOptions = new FilterOptions<User>()
                {
                    FilterExpression = x => x.EmployeeInformationId == employeeInformationid
                };

                (ExecutionState executionState, User entity, string message) recieveEntity = await _userBusiness.GetAsync(filterOptions);

                if (recieveEntity.executionState == ExecutionState.Retrieved)
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: CastEntityToModel(recieveEntity.entity), message: recieveEntity.message);
                }
                else
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: null, message: recieveEntity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
            }

            return returnResponse;
        }
        
        public async Task<(ExecutionState executionState, long entity, string message)> CountByEmail(string userEmail)
		{
            (ExecutionState executionState, long entity, string message) returnResponse;
            try
            {
                var filterOptions = new CountOptions<User>()
                {
                    FilterExpression = x => x.UserEmail == userEmail
				};

                (ExecutionState executionState, long entity, string message) recieveEntity = await _userBusiness.CountAsync(filterOptions);

                if (recieveEntity.executionState == ExecutionState.Success)
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: recieveEntity.entity, message: recieveEntity.message);
                }
                else
                {
                    returnResponse = (executionState: recieveEntity.executionState, entity: 0, message: recieveEntity.message);
                }
            }
            catch (Exception ex)
            {
                returnResponse = (executionState: ExecutionState.Failure, entity: 0, message: ex.Message);
            }

            return returnResponse;
        }

        //public async Task<(ExecutionState executionState, List<UserVM> entity, string message)> UserLists()
        //{
        //    (ExecutionState executionState, IList<UserVM> entity, string message) returnResponse;
        //    try
        //    {
        //        (ExecutionState executionState, List<User> entity, string message) recieveEntity = await _userBusiness.UserLists();

        //        if (recieveEntity.executionState == ExecutionState.Retrieved)
        //        {
        //            returnResponse = (executionState: recieveEntity.executionState, entity: CastEntityToModel(IQueryable<recieveEntity.entity>), message: recieveEntity.message);
        //        }
        //        else
        //        {
        //            returnResponse = (executionState: recieveEntity.executionState, entity: null, message: recieveEntity.message);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        returnResponse = (executionState: ExecutionState.Failure, entity: null, message: ex.Message);
        //    }

        //    return returnResponse;
        //}

        public override User CastModelToEntity(UserVM model)
        {
            try
            {
                return _mapper.Map<User>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override UserVM CastEntityToModel(User entity)
        {
            try
            {
                UserVM model = _mapper.Map<UserVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<UserVM> CastEntityToModel(IQueryable<User> entity)
        {
            try
            {
                IList<UserVM> colorList = _mapper.Map<IList<UserVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

		public async Task<(ExecutionState executionState, IList<UserVM> entity, string message)> EmployeeUserLists()
		{
            var result = await _userBusiness.EmployeeUserLists();
            if (result.executionState == ExecutionState.Retrieved)
            {
                return (result.executionState, CastEntityToModel(result.entity), result.message);
            }

			return (result.executionState, null, result.message);
		}
	}
}

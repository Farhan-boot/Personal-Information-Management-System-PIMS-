using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services
{
    public class JobCategoryService : BaseService<JobCategoryVM, JobCategory>, IJobCategoryService
    {
        public readonly IJobCategoryBusiness _JobCategoryBusiness;
        public IMapper _mapper;
        public JobCategoryService(IJobCategoryBusiness JobCategoryBusiness, IMapper mapper) : base(JobCategoryBusiness)
        {
            _JobCategoryBusiness = JobCategoryBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override JobCategory CastModelToEntity(JobCategoryVM model)
        {
            try
            {
                return _mapper.Map<JobCategory>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override JobCategoryVM CastEntityToModel(JobCategory entity)
        {
            try
            {
                JobCategoryVM model = _mapper.Map<JobCategoryVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<JobCategoryVM> CastEntityToModel(IQueryable<JobCategory> entity)
        {
            try
            {
                IList<JobCategoryVM> colorList = _mapper.Map<IList<JobCategoryVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

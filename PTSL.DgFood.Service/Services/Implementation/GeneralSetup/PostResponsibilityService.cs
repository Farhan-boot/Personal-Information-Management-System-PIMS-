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
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Business.Businesses.Implementation;

namespace PTSL.DgFood.Service.Services
{
    public class PostResponsibilityService : BaseService<PostResponsibilityVM, PostResponsibility>, IPostResponsibilityService
    {
        public readonly IPostResponsibilityBusiness _PostResponsibilityBusiness;
        public IMapper _mapper;
        public PostResponsibilityService(IPostResponsibilityBusiness PostResponsibilityBusiness, IMapper mapper) : base(PostResponsibilityBusiness)
        {
            _PostResponsibilityBusiness = PostResponsibilityBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override PostResponsibility CastModelToEntity(PostResponsibilityVM model)
        {
            try
            {
                return _mapper.Map<PostResponsibility>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PostResponsibilityVM CastEntityToModel(PostResponsibility entity)
        {
            try
            {
                PostResponsibilityVM model = _mapper.Map<PostResponsibilityVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PostResponsibilityVM> CastEntityToModel(IQueryable<PostResponsibility> entity)
        {
            try
            {
                //IQueryable<PostResponsibilityVM> PostResponsibilityList = _mapper.Map<IQueryable<PostResponsibilityVM>>(entity).ToList();
                IList<PostResponsibilityVM> PostResponsibilityList = _mapper.Map<IList<PostResponsibilityVM>>(entity).ToList();
                return PostResponsibilityList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

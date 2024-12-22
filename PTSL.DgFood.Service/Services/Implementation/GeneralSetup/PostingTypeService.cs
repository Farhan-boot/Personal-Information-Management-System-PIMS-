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
    public class PostingTypeService : BaseService<PostingTypeVM, PostingType>, IPostingTypeService
    {
        public readonly IPostingTypeBusiness _PostingTypeBusiness;
        public IMapper _mapper;
        public PostingTypeService(IPostingTypeBusiness PostingTypeBusiness, IMapper mapper) : base(PostingTypeBusiness)
        {
            _PostingTypeBusiness = PostingTypeBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override PostingType CastModelToEntity(PostingTypeVM model)
        {
            try
            {
                return _mapper.Map<PostingType>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PostingTypeVM CastEntityToModel(PostingType entity)
        {
            try
            {
                PostingTypeVM model = _mapper.Map<PostingTypeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PostingTypeVM> CastEntityToModel(IQueryable<PostingType> entity)
        {
            try
            {
                //IQueryable<PostingTypeVM> PostingTypeList = _mapper.Map<IQueryable<PostingTypeVM>>(entity).ToList();
                IList<PostingTypeVM> PostingTypeList = _mapper.Map<IList<PostingTypeVM>>(entity).ToList();
                return PostingTypeList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

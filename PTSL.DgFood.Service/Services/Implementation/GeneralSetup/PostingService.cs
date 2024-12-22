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
    public class PostingService : BaseService<PostingVM, Posting>, IPostingService
    {
        public readonly IPostingBusiness _PostingBusiness;
        public IMapper _mapper;
        public PostingService(IPostingBusiness PostingBusiness, IMapper mapper) : base(PostingBusiness)
        {
            _PostingBusiness = PostingBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Posting CastModelToEntity(PostingVM model)
        {
            try
            {
                return _mapper.Map<Posting>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override PostingVM CastEntityToModel(Posting entity)
        {
            try
            {
                PostingVM model = _mapper.Map<PostingVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<PostingVM> CastEntityToModel(IQueryable<Posting> entity)
        {
            try
            {
                //IQueryable<PostingVM> PostingList = _mapper.Map<IQueryable<PostingVM>>(entity).ToList();
                IList<PostingVM> PostingList = _mapper.Map<IList<PostingVM>>(entity).ToList();
                return PostingList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

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
    public class DegreeService : BaseService<DegreeVM, Degree>, IDegreeService
    {
        public readonly IDegreeBusiness _DegreeBusiness;
        public IMapper _mapper;
        public DegreeService(IDegreeBusiness DegreeBusiness, IMapper mapper) : base(DegreeBusiness)
        {
            _DegreeBusiness = DegreeBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Degree CastModelToEntity(DegreeVM model)
        {
            try
            {
                return _mapper.Map<Degree>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override DegreeVM CastEntityToModel(Degree entity)
        {
            try
            {
                DegreeVM model = _mapper.Map<DegreeVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<DegreeVM> CastEntityToModel(IQueryable<Degree> entity)
        {
            try
            {
                //IQueryable<DegreeVM> DegreeList = _mapper.Map<IQueryable<DegreeVM>>(entity).ToList();
                IList<DegreeVM> DegreeList = _mapper.Map<IList<DegreeVM>>(entity).ToList();
                return DegreeList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using AutoMapper;
using Newtonsoft.Json;
using PTSL.DgFood.Business.Businesses.Interface;
using PTSL.DgFood.Common.Entity.BdArmy;
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
    public class RoutesLineStringJsonsService : BaseService<RoutesLineStringJsonsVM, RoutesLineStringJsons>, IRoutesLineStringJsonsService
    {
        public readonly IRoutesLineStringJsonsBusiness _RoutesLineStringJsonsBusiness;
        public IMapper _mapper;
        public RoutesLineStringJsonsService(IRoutesLineStringJsonsBusiness RoutesLineStringJsonsBusiness, IMapper mapper) : base(RoutesLineStringJsonsBusiness)
        {
            _RoutesLineStringJsonsBusiness = RoutesLineStringJsonsBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override RoutesLineStringJsons CastModelToEntity(RoutesLineStringJsonsVM model)
        {
            try
            {
                return _mapper.Map<RoutesLineStringJsons>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override RoutesLineStringJsonsVM CastEntityToModel(RoutesLineStringJsons entity)
        {
            try
            {
                RoutesLineStringJsonsVM model = _mapper.Map<RoutesLineStringJsonsVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<RoutesLineStringJsonsVM> CastEntityToModel(IQueryable<RoutesLineStringJsons> entity)
        {
            try
            {
                IList<RoutesLineStringJsonsVM> colorList = _mapper.Map<IList<RoutesLineStringJsonsVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

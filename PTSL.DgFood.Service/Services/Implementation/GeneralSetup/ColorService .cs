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
using PTSL.DgFood.Service.Services.Interface.GeneralSetup;

namespace PTSL.DgFood.Service.Services
{
    public class ColorService : BaseService<ColorVM, Color>, IColorService
    {
        public readonly IColorBusiness _ColorBusiness;
        public IMapper _mapper;
        public ColorService(IColorBusiness ColorBusiness, IMapper mapper) : base(ColorBusiness)
        {
            _ColorBusiness = ColorBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Color CastModelToEntity(ColorVM model)
        {
            try
            {
                return _mapper.Map<Color>(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override ColorVM CastEntityToModel(Color entity)
        {
            try
            {
                ColorVM model = _mapper.Map<ColorVM>(entity);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override IList<ColorVM> CastEntityToModel(IQueryable<Color> entity)
        {
            try
            {
                //IQueryable<CategoryVM> CategoryList = _mapper.Map<IQueryable<CategoryVM>>(entity).ToList();
                IList<ColorVM> ColorList = _mapper.Map<IList<ColorVM>>(entity).ToList();
                return ColorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

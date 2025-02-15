﻿using AutoMapper;
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
    public class CategoryService : BaseService<CategoryVM, Category>, ICategoryService
    {
        public readonly ICategoryBusiness _categoryBusiness;
        public IMapper _mapper;
        public CategoryService(ICategoryBusiness categoryBusiness, IMapper mapper) : base(categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
            _mapper = mapper;
        }

        //Implement System Busniess Logic here

        public override Category CastModelToEntity(CategoryVM model)
        {
            try
            {
                return _mapper.Map<Category>(model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public override CategoryVM CastEntityToModel(Category entity)
        {
            try
            {
                CategoryVM model = _mapper.Map<CategoryVM>(entity);
                return model;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public override IList<CategoryVM> CastEntityToModel(IQueryable<Category> entity)
        {
            try
            {
                IList<CategoryVM> colorList = _mapper.Map<IList<CategoryVM>>(entity).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

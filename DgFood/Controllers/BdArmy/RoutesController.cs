using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using PTSL.DgFood.Api.Helpers;
using PTSL.DgFood.Common.Entity.BdArmy;
using PTSL.DgFood.Common.Entity.GeneralSetup;
using PTSL.DgFood.Common.Enum;
using PTSL.DgFood.Common.Model;
using PTSL.DgFood.Common.Model.EntityViewModels.GeneralSetup;
using PTSL.DgFood.Service.Services;
using PTSL.DgFood.Service.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.DgFood.Api.Controllers.GeneralSetup
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : BaseController<IRoutesService, RoutesVM, Routes>
    {
        private readonly IRoutesService _routesService;
        //private IConfiguration _config;
        //public RoutesController(IRoutesService routesService, IConfiguration config) :
        //    base(routesService)
        //{
        //    _config = config;
        //    _routesService = routesService;
        //}
        public RoutesController(IRoutesService RoutesService) :
           base(RoutesService)
        {
            _routesService = RoutesService;
        }
        //Implement here new api, if we want.

        [HttpPost("RoutesByUserId")]
        //[AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<WebApiResponse<RoutesVM>>> RoutesByUserId([FromBody] Routes model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            RoutesVM filterData = new RoutesVM();
            filterData.UserId = model.UserId;
            filterData.CreatedAt = model.CreatedAt;
            (ExecutionState executionState, IList<RoutesVM> entity, string message) result = await _routesService.GetFilterData(null, filterData);

            (ExecutionState executionState, List<RoutesResultVM> entity, string message) responseResult;
            List<RoutesResultVM> routesResult = new List<RoutesResultVM>();
            //{
            //    UserId = result.entity.UserId,
            //    Id = result.entity.Id,
            //    CreatedAt = result.entity.CreatedAt,
            //    RoutesDetails = details
            //};
            if (result.executionState == ExecutionState.Retrieved)
            {
                foreach (var masterData in result.entity)
                {
                    RoutesResultVM tempRoutes = new RoutesResultVM();
                    List<RoutesDetailsDataVM> details = new List<RoutesDetailsDataVM>();

                    tempRoutes.Id = masterData.Id;
                    tempRoutes.UserId = masterData.UserId;
                    tempRoutes.CreatedAt = masterData.CreatedAt;
                    tempRoutes.SessionName = masterData.SessionName;
                    tempRoutes.IsArrived = masterData.IsArrived;

                    foreach (var data in masterData.RoutesDetails)
                    {
                        RoutesDetailsDataVM routesDetailsDataVM = new RoutesDetailsDataVM();
                        routesDetailsDataVM.Id = data.Id;
                        routesDetailsDataVM.StartDate = data.StartDate;
                        routesDetailsDataVM.EndDate = data.EndDate;
                        routesDetailsDataVM.Latitude = data.Latitude;
                        routesDetailsDataVM.Longitude = data.Longitude;
                        routesDetailsDataVM.Radius = data.Radius;
                        routesDetailsDataVM.PlaceName = data.PlaceName;
                        routesDetailsDataVM.RoutesId = data.RoutesId;
                        details.Add(routesDetailsDataVM);
                    }
                    tempRoutes.RoutesDetails = details.OrderBy(x => x.StartDate).ToList();//.ThenByDescending(x=>x.EndDate).ToList();
                    routesResult.Add(tempRoutes);
                }

                responseResult.entity = routesResult;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState; //30 means data retrived
                //responseResult.staus = 200;
                WebApiResponse<List<RoutesResultVM>> apiResponse = new WebApiResponse<List<RoutesResultVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = routesResult;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState; //0 means  no data found
                //responseResult. = 200;
                WebApiResponse<List<RoutesResultVM>> apiResponse = new WebApiResponse<List<RoutesResultVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }

        //public async Task<ActionResult<WebApiResponse<RoutesVM>>> RoutesByUserId([FromBody] Routes model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    (ExecutionState executionState, RoutesVM entity, string message) result = await _routesService.RoutesByUserId(model);

        //    (ExecutionState executionState, RoutesResultVM entity, string message) responseResult;

        //    if (result.executionState == ExecutionState.Retrieved)
        //    {
        //        List<RoutesDetailsDataVM> details = new List<RoutesDetailsDataVM>();
        //        foreach (var data in result.entity.RoutesDetails)
        //        {
        //            RoutesDetailsDataVM routesDetailsDataVM = new RoutesDetailsDataVM();
        //            routesDetailsDataVM.Id = data.Id;
        //            routesDetailsDataVM.StartDate = data.StartDate;
        //            routesDetailsDataVM.EndDate = data.EndDate;
        //            routesDetailsDataVM.Latitude = data.Latitude;
        //            routesDetailsDataVM.Longitude = data.Longitude;
        //            routesDetailsDataVM.Radius = data.Radius;
        //            routesDetailsDataVM.PlaceName = data.PlaceName;
        //            routesDetailsDataVM.RoutesId = data.RoutesId;
        //            details.Add(routesDetailsDataVM);
        //        }

        //        RoutesResultVM routesResult = new RoutesResultVM
        //        {
        //            UserId = result.entity.UserId,
        //            Id = result.entity.Id,
        //            CreatedAt = result.entity.CreatedAt,
        //            RoutesDetails = details
        //        };
        //        responseResult.entity = routesResult;
        //        responseResult.message = result.message;
        //        responseResult.executionState = result.executionState; //30 means data retrived
        //        //responseResult.staus = 200;
        //        WebApiResponse<RoutesResultVM> apiResponse = new WebApiResponse<RoutesResultVM>(responseResult);
        //        return Ok(apiResponse);
        //    }
        //    else
        //    {
        //        responseResult.entity = null;
        //        responseResult.message = result.message;
        //        responseResult.executionState = result.executionState; //0 means  no data found
        //        //responseResult. = 200;
        //        WebApiResponse<RoutesResultVM> apiResponse = new WebApiResponse<RoutesResultVM>(responseResult);
        //        return NotFound(apiResponse);
        //    }
        //}





        [HttpPost("SubmitRoutesLineStringJson")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<WebApiResponse<RoutesVM>>> SubmitRoutesLineStringJson(List<RoutesRequest> model)
        {
            ApiResponse _response = new ApiResponse();

            try
            {
                if (model.Count() > 0)
                {
                    RoutesRequest request = new RoutesRequest();
                    request = model.FirstOrDefault();
                     
                    string RoutesMasterfileName = Guid.NewGuid().ToString();
                    string RoutesMasterfileUrl = string.Format(Directory.GetCurrentDirectory() + "\\jsons\\RoutesMasterfilesLineString\\{0}.json", RoutesMasterfileName + "-" + request.properties.RoutesId);
                    //string RoutesMasterfileUrl = Server.MapPath("~/App_Data/somedata.xml");
                    string RoutesMasterjson = JsonConvert.SerializeObject(model);
                    //File.WriteAllText(RoutesMasterfileUrl, RoutesMasterjson);
                    System.IO.File.WriteAllText(RoutesMasterfileUrl, RoutesMasterjson);


                    (ExecutionState executionState, RoutesVM entity, string message)  master = await _routesService.GetAsync(request.properties.RoutesId);
                    master.entity.IsArrived = true;
                    master.entity.JsonFileName = RoutesMasterfileName + "-" + request.properties.RoutesId;

                    List<RoutesDetailsVM> routesDetailsListsVM = new List<RoutesDetailsVM>();
                    foreach (var detailsData in master.entity.RoutesDetails)
                    {
                        detailsData.IsArrived = true;
                    }


                    List<RoutesLineStringJsonsVM> routesLineStringJsonsLists = new List<RoutesLineStringJsonsVM>();
                    foreach (var detailsData in model)
                    {
                        string RoutesDetailsfileName = Guid.NewGuid().ToString();
                        string RoutesDetailsfileUrl = string.Format(Directory.GetCurrentDirectory() + "\\jsons\\RoutesDetailsLineStringJsonURL\\{0}.json", RoutesDetailsfileName+"-"+ detailsData.properties.RoutesDetailId);
                        string RoutesDetailsjson = JsonConvert.SerializeObject(detailsData);
                        System.IO.File.WriteAllText(RoutesDetailsfileUrl, RoutesDetailsjson);
                        RoutesLineStringJsonsVM routesLineStringJsons = new RoutesLineStringJsonsVM();
         
                        routesLineStringJsons.UserId = detailsData.properties.UserId;
                        routesLineStringJsons.RoutesId = detailsData.properties.RoutesId;
                        routesLineStringJsons.RoutesDetailsId = detailsData.properties.RoutesDetailId;
                        routesLineStringJsons.StartLatitude = detailsData.properties.StartLatitude;
                        routesLineStringJsons.EndLatitude = detailsData.properties.EndLatitude;
                        routesLineStringJsons.StartLongitude = detailsData.properties.StartLongitude;
                        routesLineStringJsons.EndLongitude = detailsData.properties.EndLongitude;
                        routesLineStringJsons.JsonFileName = RoutesDetailsfileName + "-" + detailsData.properties.RoutesDetailId;
                        routesLineStringJsons.IsActive = true;
                        routesLineStringJsons.CreatedAt = DateTime.Now;
                        routesLineStringJsonsLists.Add(routesLineStringJsons);

                    }
                    master.entity.LineStringJsons = routesLineStringJsonsLists;
                    (ExecutionState executionState, RoutesVM entity, string message) result = await _routesService.UpdateAsync(master.entity);

                     
                    _response.Success = true;
                    // _response.Data = response1;
                    _response.Data = new { ExecutionState = 10 }; //means success

                     
                    _response.Message = "Data successfully sync.";
                    return Ok(_response);
                }
                else
                {
                    _response.Success = false;
                    _response.Data = new { ExecutionState = 0 }; //means failed
                    _response.Message = "Data is not sync.";
                    //return _response;
                    return Ok(_response);
                }

            }
            catch (Exception ex)
            {

                _response.Success = false;
                _response.Data = new { ExecutionState = 0 }; //means failed
                _response.Message = "Data is not sync.";
                return Ok(_response);
            }
        }


        [HttpPost("GetFilterData")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WebApiResponse<RoutesVM>>> GetFilterData([FromBody] RoutesVM model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            (ExecutionState executionState, IList<RoutesVM> entity, string message) result = await _routesService.GetFilterData(null, model);

            (ExecutionState executionState, List<RoutesVM> entity, string message) responseResult;

            if (result.executionState == ExecutionState.Retrieved)
            {

                responseResult.entity = result.entity.ToList();
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;
                WebApiResponse<List<RoutesVM>> apiResponse = new WebApiResponse<List<RoutesVM>>(responseResult);
                return Ok(apiResponse);
            }
            else
            {
                responseResult.entity = null;
                responseResult.message = result.message;
                responseResult.executionState = result.executionState;

                WebApiResponse<List<RoutesVM>> apiResponse = new WebApiResponse<List<RoutesVM>>(responseResult);
                return NotFound(apiResponse);
            }
        }


        //Implement here new api, if we want.
    }
}

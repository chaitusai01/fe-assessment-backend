using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using FeAssignmentApp.Web.API.Models;
using FeAssignmentApp.Web.API.Repository;
using FeAssignmentApp.Web.API.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FeAssignmentApp.Web.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        protected readonly IFacilitiesRepository _facilitiesRepository;

        public FacilitiesController(IFacilitiesRepository facilitiesRepository)
        {
            _facilitiesRepository = facilitiesRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            FacilitiesResponse facilitiesResponse = new FacilitiesResponse();
            FacilitiesService faService = new FacilitiesService(_facilitiesRepository);
            HttpResponseMessage responseMsg = new HttpResponseMessage();

            try
            {
                var result = faService.GetAllFacilities();
                facilitiesResponse.facilitiesResultList = result;

                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                responseMsg.StatusCode = HttpStatusCode.OK;
                return Ok(facilitiesResponse);
            }
            catch(Exception e)
            {
                facilitiesResponse.ErrorMessage = e.Message;
                responseMsg.StatusCode = HttpStatusCode.BadRequest;
                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                return BadRequest(facilitiesResponse);
            }

        }

        [HttpPost]
        public IActionResult Save([FromBody] FacilitiesRequest faReq)
        {
            FacilitiesResponse facilitiesResponse = new FacilitiesResponse();
            FacilitiesService faService = new FacilitiesService(_facilitiesRepository);
            HttpResponseMessage responseMsg = new HttpResponseMessage();

            try
            {
                var result = faService.CreateFacilities(faReq);
                facilitiesResponse.actionResult = result;

                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                responseMsg.StatusCode = HttpStatusCode.OK;
                return Ok(facilitiesResponse);
            }
            catch (Exception e)
            {
                facilitiesResponse.ErrorMessage = e.Message;
                responseMsg.StatusCode = HttpStatusCode.BadRequest;
                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                return BadRequest(facilitiesResponse);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FacilitiesResponse facilitiesResponse = new FacilitiesResponse();
            FacilitiesService faService = new FacilitiesService(_facilitiesRepository);
            HttpResponseMessage responseMsg = new HttpResponseMessage();

            try
            {
                var result = faService.GetFacilitiesById(id);
                facilitiesResponse.facilitiesResult = result;

                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                responseMsg.StatusCode = HttpStatusCode.OK;
                return Ok(facilitiesResponse);
            }
            catch (Exception e)
            {
                facilitiesResponse.ErrorMessage = e.Message;
                responseMsg.StatusCode = HttpStatusCode.BadRequest;
                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                return BadRequest(facilitiesResponse);
            }

        }

        [HttpPut]
        public IActionResult Update([FromBody] FacilitiesRequest faReq)
        {
            FacilitiesResponse facilitiesResponse = new FacilitiesResponse();
            FacilitiesService faService = new FacilitiesService(_facilitiesRepository);
            HttpResponseMessage responseMsg = new HttpResponseMessage();

            try
            {
                var result = faService.UpdateByFacility(faReq);
                facilitiesResponse.actionResult = result;

                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                responseMsg.StatusCode = HttpStatusCode.OK;
                return Ok(facilitiesResponse);
            }
            catch (Exception e)
            {
                facilitiesResponse.ErrorMessage = e.Message;
                responseMsg.StatusCode = HttpStatusCode.BadRequest;
                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                return BadRequest(facilitiesResponse);
            }

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] FacilitiesRequest faReq)
        {
            FacilitiesResponse facilitiesResponse = new FacilitiesResponse();
            FacilitiesService faService = new FacilitiesService(_facilitiesRepository);
            HttpResponseMessage responseMsg = new HttpResponseMessage();

            try
            {
                var result = faService.DeleteByFacility(faReq);
                facilitiesResponse.actionResult = result;

                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                responseMsg.StatusCode = HttpStatusCode.OK;
                return Ok(facilitiesResponse);
            }
            catch (Exception e)
            {
                facilitiesResponse.ErrorMessage = e.Message;
                responseMsg.StatusCode = HttpStatusCode.BadRequest;
                faService.GetResponseMsg(ref responseMsg, facilitiesResponse);
                return BadRequest(facilitiesResponse);
            }

        }


    }
}

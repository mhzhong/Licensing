using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using DataAccessLayer.Interface;
using DataLayer.Entities;
using WebApi.Models;



namespace WebApi.Controllers
{
    public class AuthorizationController : BaseApiController
    {
        private AuthorizationModel _authorizationModel;

        public AuthorizationController(IAuthorizationRepository repo): base(repo)
        {
            
        }

        // GET api/Authorization
        public HttpResponseMessage Get()
        {
            var allAuthorizaion = _theAuthorizationRepo.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, allAuthorizaion);
        }

        // GET api/Authorization/5
        public HttpResponseMessage Get(int id)
        {
            var authorization = _theAuthorizationRepo.GetById(id);

            try
            {
                if (authorization == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, authorization);
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/Authorization
        public HttpResponseMessage Post([FromBody] DataLayer.Entities.Authorization autho)
        {
            try
            {
                _theAuthorizationRepo.Insert(autho);

                return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(autho));

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/Authorization/5
        public HttpResponseMessage Put(int id, [FromBody] DataLayer.Entities.Authorization autho)
        {
            try
            {
                var originalAutho = _theAuthorizationRepo.GetById(id);

                if (originalAutho != null && originalAutho.Id == id)
                {
                    originalAutho.Status = autho.Status;
                    originalAutho.Quantity = autho.Quantity;
                    originalAutho.DateCreated = autho.DateCreated;

                    _theAuthorizationRepo.Update(autho);

                    var authorizationModel = TheModelFactory.Create(autho);
                    authorizationModel.Id = id;

                    return Request.CreateResponse(HttpStatusCode.OK, authorizationModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "The authorization is not found.");
                }
            }
            catch (Exception ex)
            {
                
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        
    }
}
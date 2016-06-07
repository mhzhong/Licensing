using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using DataAccessLayer.Interface;
using DataLayer.Entities;

namespace WebApi.Controllers
{
    public class ProductFamilyController : BaseApiController
    {
        public ProductFamilyController(IProductFamilyRepository repo): base (repo)
        {
            
        } 
        
        // GET: api/ProductFamily
        public HttpResponseMessage Get()
        {
            var allProdFamily = _theProductFamilyRepo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allProdFamily);
        }

        // GET api/ProductFamily/2
        public HttpResponseMessage Get(int id)
        {
            var prodFamily = _theProductFamilyRepo.GetById(id);

            try
            {
                if (prodFamily == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, prodFamily);
                }

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        // POST api/ProductFamily
        public HttpResponseMessage Post([FromBody] ProductFamily prodFamily)
        {
            try
            {
                _theProductFamilyRepo.Insert(prodFamily);
                return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(prodFamily));
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        public HttpResponseMessage Put(int id, [FromBody] ProductFamily prodFamily)
        {
            try
            {
                var targetProdFamily = _theProductFamilyRepo.GetById(id);

                if (targetProdFamily != null && targetProdFamily.Id == id)
                {
                    targetProdFamily.Name = prodFamily.Name;
                    targetProdFamily.Description = prodFamily.Description;
                    targetProdFamily.DateCreated = prodFamily.DateCreated;
                    targetProdFamily.DateUpdated = prodFamily.DateUpdated;
                    targetProdFamily.Licenses = prodFamily.Licenses;
                   // targetProdFamily.Products = prodFamily.Products;

                    _theProductFamilyRepo.Update(prodFamily);

                    var productFamilyModel = TheModelFactory.Create(prodFamily);

                    productFamilyModel.Id = id;

                    return Request.CreateResponse(HttpStatusCode.OK, productFamilyModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Not found the product family");
                }
            }
            catch (Exception ex)
            {
                
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //No need to delete
    }
}

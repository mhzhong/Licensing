using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using DataAccessLayer;
using DataAccessLayer.Interface;
using DataLayer.Entities;
using Ninject.Infrastructure.Language;
using WebApi.Models;

namespace WebApi.Controllers
{
    
    public class LicenseController : BaseApiController 
    {
         
        public LicenseController(ILicenseRepository repo) : base(repo)
        {
            
        }

        //GET api/License
        public HttpResponseMessage Get()
        {
            var allLicenses = _theLicenseRepo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allLicenses);           
        }
        
        //public IEnumerable<License> Get()
        //{
        //    CurrentDbContext.Configuration.ProxyCreationEnabled = false;

        //    return _theLicenseRepo.GetAll();
        //}

        //GET api/License/2
        public HttpResponseMessage Get(int id)
        {
            var license = _theLicenseRepo.GetById(id);

            try
            {
                if (license == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, license);
                }
            }
            catch (Exception ex)
            {
                
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //GET api/ProductType/{productTypeId}/Licenses
        public IEnumerable<LicenseModel> GetLicensesFilteredByProductType(int productTypeId)
        {
            var license = _theLicenseRepo.GetLicensesByProductTypeId(productTypeId);

            var result = license.ToList().Select(l => TheModelFactory.Create(l));

            return result;
        }
        

        //POST api/License
        public HttpResponseMessage Post([FromBody] License license)
        {
            try
            {
                _theLicenseRepo.Insert(license);

                return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(license));
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //PUT api/License/26
        public HttpResponseMessage PUT(int id, [FromBody] License license)
        {
            try
            {
                var targetLicense = _theLicenseRepo.GetById(id);

                if (targetLicense != null && targetLicense.Id == id)
                {
                    targetLicense.Name = license.Name;
                    targetLicense.Description = license.Description;
                    targetLicense.TitleOfHardware = license.TitleOfHardware;
                    targetLicense.LicenseType = license.LicenseType;
                    targetLicense.Duration = license.Duration;
                    targetLicense.DateCreated = license.DateCreated;
                    targetLicense.DateUpdated = license.DateUpdated;
                    targetLicense.Status = license.Status;
                    targetLicense.ProdFamilyId = license.ProdFamilyId;
                    targetLicense.SubscriptionId = license.SubscriptionId;
                    targetLicense.VersionId = license.VersionId;
                    targetLicense.ApplicationId = license.ApplicationId;
                    targetLicense.ProductTypeId = license.ProductTypeId;

                    _theLicenseRepo.Update(license);

                    var licenseModel = TheModelFactory.Create(license);
                    licenseModel.Id = id;

                    return Request.CreateResponse(HttpStatusCode.OK, licenseModel);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Not found the license.");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //No need to delete license
       
    }
}

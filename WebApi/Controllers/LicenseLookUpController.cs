using DataAccessLayer.Interface;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class LicenseLookUpController : BaseApiController
    {
        //
        // GET: /LicenseLookUp/

        public LicenseLookUpController(ILicenseLookUp lookUp)
            : base(lookUp)
        {           
        }

        public HttpResponseMessage Get(string app)
        {
            var requiredLicenses = _theLicenseLookUp.GetLicensesByApplication(app);
            return Request.CreateResponse(HttpStatusCode.OK, requiredLicenses);

        }

    }
}

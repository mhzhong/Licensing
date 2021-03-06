﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using DataAccessLayer.Interface;

namespace WebApi.Controllers
{
    public class ApplicationController : BaseApiController
    {
        public ApplicationController(IApplicationRepository repo) : base(repo)
        {           
        } 
        
        // GET: api/Application
        public HttpResponseMessage Get()
        {
            var allApp = _theApplicationRepo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, allApp);
        }

    }
}

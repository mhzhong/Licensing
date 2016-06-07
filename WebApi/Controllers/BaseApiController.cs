using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer.Interface;
using DataLayer.Entities;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        public ILicenseRepository _theLicenseRepo;
        public IProductTypeRepository _theProductTypeRepo;
        public IAuthorizationRepository _theAuthorizationRepo;
        public IProductFamilyRepository _theProductFamilyRepo;
        public IActivationRepository _theActivationRepo;
        public IApplicationRepository _theApplicationRepo;
        public ILicenseLookUp _theLicenseLookUp;


        public ModelFactory _modelFactory;

              
        public BaseApiController(ILicenseRepository licenseRepo)
        {
            _theLicenseRepo = licenseRepo;
        }

        public BaseApiController(ILicenseLookUp lookUp)
        {
            _theLicenseLookUp = lookUp;
        }

        public BaseApiController(IProductTypeRepository productTypeRepo)
        {
            _theProductTypeRepo = productTypeRepo;
        }

        public BaseApiController(IAuthorizationRepository authorizationRepo)
        {
            _theAuthorizationRepo = authorizationRepo;
        }

        public BaseApiController(IProductFamilyRepository prodFamilyRepo)
        {
            _theProductFamilyRepo = prodFamilyRepo;
        }

        public BaseApiController(IActivationRepository activationRepo)
        {
            _theActivationRepo = activationRepo;
        }

        public BaseApiController(IApplicationRepository appRepo)
        {
            _theApplicationRepo = appRepo;
        }


        public ILicenseRepository TheLicenseRepo
        {
            get { return _theLicenseRepo; }
        }

        public ILicenseLookUp TheLicenseLookUp
        {
            get { return _theLicenseLookUp; }
        }

        public IProductTypeRepository TheProductTypeRepo
        {
            get { return _theProductTypeRepo; }
        }

        public IAuthorizationRepository TheAuthorizationRepo
        {
            get { return _theAuthorizationRepo; }

        }

        public IProductFamilyRepository TheProductFamilyRepo
        {
            get { return _theProductFamilyRepo; }
        }

        public IActivationRepository TheActivationRepo
        {
            get { return _theActivationRepo; }
        }

        public IApplicationRepository TheApplicationRepo
        {
            get { return _theApplicationRepo; }
        }

        public ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(Request, TheLicenseRepo);
                    _modelFactory = new ModelFactory(Request, TheLicenseLookUp);
                    _modelFactory = new ModelFactory(Request, TheProductTypeRepo);
                    _modelFactory = new ModelFactory(Request, TheAuthorizationRepo);
                    _modelFactory = new ModelFactory(Request, TheProductFamilyRepo);
                    _modelFactory = new ModelFactory(Request, TheActivationRepo);
                    _modelFactory = new ModelFactory(Request, TheApplicationRepo);

                }
                return _modelFactory;
            }
        }

    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using DataAccessLayer;
using DataAccessLayer.Interface;
using DataLayer.Entities;
using NUnit.Framework;
using WebApi.App_Start;
using WebApi.Controllers;

namespace WebAPIControllerTest
{
    /// <summary>
    /// Summary description for AuthorizationControllerTest
    /// </summary>
    [TestFixture]
    public class AuthorizationControllerTest
    {
        private IAuthorizationRepository _authorizationRepo;
        private AuthorizationController _authorizationController;

        
        //private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        public IAuthorizationRepository TheAuthorizationRepo
        {
            get { return _authorizationRepo; }
            //set
            //{
            //    testContextInstance = value;
            //}
        }

        public AuthorizationControllerTest(IAuthorizationRepository authorizationRepo)
        {
            _authorizationRepo = authorizationRepo;
        }

        [SetUp]
        public void SetUp()
        {
            _authorizationController = new AuthorizationController(_authorizationRepo);
        }


        [Test]
        public void Can_GetAllAuthorization_Test()
        {
            _authorizationController.Request = new HttpRequestMessage();
            _authorizationController.Configuration = new HttpConfiguration();

            var response = _authorizationController.Get(4);

            Authorization autho;
            Assert.IsTrue(response.TryGetContentValue<Authorization>(out autho));
            Assert.AreEqual(4, autho.Id);

        }

      
    }
}

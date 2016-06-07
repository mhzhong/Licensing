using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Interface;
using DataLayer;
using DataLayer.Entities;
using NUnit.Framework;
using Moq;

namespace WebAPIControllerTest
{
    /// <summary>
    /// Summary description for RepositoryTest
    /// </summary>
    //[TestFixture]
    //public class RepositoryTest: MockRepository<ProductType>
    //{
    //    private MockRepository<ProductType> _mockProductTypeRepo;
    //    private MockRepository<License> _mockLicenseRepo; 

    //    public RepositoryTest()
    //    {
    //        _mockProductTypeRepo = new MockRepository<ProductType>();
    //        _mockProductTypeRepo._context = new List<ProductType>(){new ProductType(){
    //                        Id = 1,
    //                        Type = "BVMS Test",
    //                    },
    //                     new ProductType
    //                    {
    //                       Id = 2,
    //                       Type = "CDR Test",
    //                    },
    //                    new ProductType
    //                    {
    //                        Id = 3,
    //                        Type = "VIR Test",
    //                    }
    //        };

    //        _mockLicenseRepo = new MockRepository<License>();
    //        _mockLicenseRepo._context = new List<License>(){new License()
    //        {
    //            Id = 5,
    //            Name = "VCI ALL - 2 Year",
    //            Description = "VCI ALL - 2 Year",
    //            TitleOfHardware = "M-VCI",
    //            LicenseType = DataLayer.Enums.LicenseType.Subscription,
    //            Duration = 2,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            Status = DataLayer.Enums.Status.Valid,
    //            ProdFamilyId = 6,
    //            SubscriptionId = 2,
    //            VersionId = 10,
    //            ApplicationId = 2,
    //            ProductTypeId = 7
    //        }};
    //    }

    //    [SetUp]
    //    public void SetUp()
    //    {
           
    //    }

    //    #region Additional test attributes
    //    //
    //    // You can use the following additional attributes as you write your tests:
    //    //
    //    // Use ClassInitialize to run code before running the first test in the class
    //    // [ClassInitialize()]
    //    // public static void MyClassInitialize(TestContext testContext) { }
    //    //
    //    // Use ClassCleanup to run code after all tests in a class have run
    //    // [ClassCleanup()]
    //    // public static void MyClassCleanup() { }
    //    //
    //    // Use TestInitialize to run code before running each test 
    //    // [TestInitialize()]
    //    // public void MyTestInitialize() { }
    //    //
    //    // Use TestCleanup to run code after each test has run
    //    // [TestCleanup()]
    //    // public void MyTestCleanup() { }
    //    //
    //    #endregion

    //    [Test]
    //    public void Can_GetAll_ProductType_Test()
    //    {
    //        var allTypes = _mockProductTypeRepo.GetAll();
    //        var actualResult = allTypes.Count();
    //        Assert.AreEqual(3,actualResult);
    //    }

    //    [Test]
    //    public void Can_Insert_ProductType_Test()
    //    {
    //        var newType = new ProductType()
    //        {
    //            Id = 3,
    //            Type = "Divor Test"
    //        };
    //        var result = _mockProductTypeRepo.Insert(newType);
    //        Assert.IsNotNull(result);
    //    }

    //    [Test]
    //    public void Can_Insert_License_Test()
    //    {
             
    //    }
    //}
}

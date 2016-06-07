﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Security.Claims;

using DataAccessLayer.Interface;
using DataLayer.Entities;
using DataAccessLayer;
using DataLayer;
using DataLayer.Enums;
using Moq;
using NUnit.Framework;


namespace BusinessLogicTest
{
    /// <summary>
    /// Test behaviors of ProductType repository by mocking ProductTypeRepository interface
    /// </summary>
    [TestFixture]
    public class ProductTypeRepositoryTest
    {
        public readonly IProductTypeRepository MockProductTypeRepo;
        public Mock<IProductTypeRepository> mockProductTypeRepo;

        public readonly ILicenseRepository MockLicenseRepo;
        public Mock<ILicenseRepository> mockLicenseRepo;

        public readonly IAuthorizationRepository MockAuthorizationRepo;
        public Mock<IAuthorizationRepository> mockAuthorizationRepo;

        public readonly IActivationRepository MockActivationRepo;
        public Mock<IActivationRepository> mockActivationRepo;

        [SetUp]
        public void Init()
        {
            
            
        }
        //Constructor
        public ProductTypeRepositoryTest()
        {           
            //mock data for productType entity
             IList<ProductType> types = new List<ProductType>()
            {
                new ProductType{ Id = 1, Type = "BVMS"},
                new ProductType{ Id = 2, Type = "CDR"}
            };

            
            //initial the mock product type repository using Moq
            mockProductTypeRepo = new Mock<IProductTypeRepository>();
            
            //access mock instance
            //this.MockProductTypeRepo = mockProductTypeRepo.Object;
            
            //set up GetAll method
            //mockProductTypeRepo.Setup(mp => mp.GetAll()).Returns(types.AsQueryable());
            //set up GetById method
            mockProductTypeRepo.Setup(mp => mp.GetById(It.IsAny<int>())).Returns((int i) => types.Where(x => x.Id == i).Single());
            //set up create method
            mockProductTypeRepo.Setup(mp => mp.Insert(It.IsAny<ProductType>())).Returns(true);
            

            //mock data for license entity
            IList<License> ListOfMatchinglicenses = new List<License>()
            {
                new License { Id = 1, Name = "BVMS Lite-64 edition v2.0", Description = "this is a test.", TitleOfHardware = "Computer Signature", 
                    LicenseType = LicenseType.Subscription, Duration = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Status = Status.Valid, ProdFamilyId = 1, SubscriptionId = 1, VersionId = 1, ApplicationId = 1, ProductTypeId = 1},
                new License { Id = 2, Name = "BVMS 2 Camera Extension", Description = "test test test.", TitleOfHardware = "Computer Signature", 
                    LicenseType = LicenseType.Subscription, Duration = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Status = Status.Invalid, ProdFamilyId = 1, SubscriptionId = 1, VersionId = 2, ApplicationId = 1, ProductTypeId = 1},
                new License { Id = 3, Name = "CDR V3.6, 1 Year Subscription", Description = "this is for VLMS.", TitleOfHardware = "CDR Vehicle Interface Module", 
                    LicenseType = LicenseType.Subscription, Duration = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Status = Status.Valid, ProdFamilyId = 10, SubscriptionId = 1, VersionId = 6, ApplicationId = 2, ProductTypeId = 2}
            };


            //initial the mock license repository
            mockLicenseRepo = new Mock<ILicenseRepository>();
            //access the mock instance
            this.MockLicenseRepo = mockLicenseRepo.Object;
            //set up GetLicensesByProductTypeId
            //mockLicenseRepo.Setup(m => m.GetLicensesByProductTypeId(It.IsAny<int>())).Returns(licenses);
            mockLicenseRepo.Setup(m => m.GetLicensesByProductTypeId(It.IsAny<int>()
                )).Returns((int i) => ListOfMatchinglicenses.Where(x => x.ProductTypeId == i) );



            mockActivationRepo = new Mock<IActivationRepository>();
            this.MockActivationRepo = mockActivationRepo.Object;

            //mock data for authorization

        }

        /// <summary>
        /// Test behavior of ProductType repository
        /// </summary>
        [Test]
        public void Can_CreateProductType()
        {
            
            var _mockProductTypeSet = new Mock<DbSet<ProductType>>();

            var mockContext = new Mock<LicensingContext>();
            mockContext.Setup(m => m.ProductTypes).Returns(_mockProductTypeSet.Object);
            mockContext.Setup(m => m.Set<ProductType>()).Returns(_mockProductTypeSet.Object);
            
            var type = new ProductType()
            {
                Type = "Divar Test",
                Licenses = new List<License>() { }
            };

            var productTypeRepo = new ProductTypeRepository(mockContext.Object);
            var result = productTypeRepo.Insert(type);
            Assert.IsNotNull(result);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }


        [Test]
        public void Can_GetAllProductType()
        {
            var data = new List<ProductType> 
            { 
                new ProductType { Type = "BBB" }, 
                new ProductType { Type = "ZZZ" }, 
                new ProductType { Type = "AAA" }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ProductType>>();
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ProductType>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<LicensingContext>();
            mockContext.Setup(c => c.ProductTypes).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<ProductType>()).Returns(mockSet.Object);


            var productTypeRepo = new ProductTypeRepository(mockContext.Object);
            var allTypes = productTypeRepo.GetAll().ToList();

            //Assert.AreEqual(3, allTypes.Count());
            //Assert.AreEqual("AAA", allTypes[2].Type);
            //Assert.AreEqual("BBB", allTypes[0].Type);
            //Assert.AreEqual("ZZZ", allTypes[1].Type);

        }
        
        /// <summary>
        /// Test behaviors of license repository
        /// </summary>
        [Test]
        public void Can_CreateLicense_Test()
        {

            var mockSet = new Mock<DbSet<License>>();

            var mockContext = new Mock<LicensingContext>();
            mockContext.Setup(m => m.Licenses).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<License>()).Returns(mockSet.Object);

            var license = new License()
            {
                Name = "VCI ALL - Test",
                Description = "VCI ALL - Test",
                TitleOfHardware = "M-VCI",
                LicenseType = LicenseType.Subscription,
                Duration = 2,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Status = Status.Valid,
                ProdFamilyId = 6,
                SubscriptionId = 2,
                VersionId = 10,
                ApplicationId = 2,
                ProductTypeId = 7
            };

            var licenseRepo = new LicenseRepository(mockContext.Object);
            var result = licenseRepo.Insert(license);
            Assert.IsNotNull(result);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void Can_GetLicensesByProductTypeId_Test()
        {
            var data = new List<License> 
            { 
                new License {
                                Name = "CDR V3.6 2years",
                                Description = "CDR V3.6 Test",
                                TitleOfHardware = "CDR Vehicle",
                                LicenseType = LicenseType.Subscription,
                                Duration = 2,
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now,
                                Status = Status.Valid,
                                ProdFamilyId = 6,
                                SubscriptionId = 2,
                                VersionId = 10,
                                ApplicationId = 2,
                                ProductTypeId = 7 
                            }, 
                new License { 
                                Name = "BVMS V5.0 1 years",
                                Description = "BVMS V5.0 1Test",
                                TitleOfHardware = "BVMS",
                                LicenseType = LicenseType.Subscription,
                                Duration = 1,
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now,
                                Status = Status.Valid,
                                ProdFamilyId = 6,
                                SubscriptionId = 2,
                                VersionId = 10,
                                ApplicationId = 2,
                                ProductTypeId = 5  
                            }, 
                new License { 
                                Name = "CDR V4.4.1 1years",
                                Description = "CDR V4.4.1 1Test",
                                TitleOfHardware = "CDR Vehicle",
                                LicenseType = LicenseType.Subscription,
                                Duration = 1,
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now,
                                Status = Status.Valid,
                                ProdFamilyId = 6,
                                SubscriptionId = 2,
                                VersionId = 10,
                                ApplicationId = 2,
                                ProductTypeId = 7   
                               }, 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<License>>();
            mockSet.As<IQueryable<License>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<License>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<License>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<License>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<LicensingContext>();
            mockContext.Setup(c => c.Licenses).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<License>()).Returns(mockSet.Object);

            var licenseRepo = new LicenseRepository(mockContext.Object);
            var result = licenseRepo.GetLicensesByProductTypeId(7);

            Assert.AreEqual(2, result.Count());
           
        }

        /// <summary>
        /// test behaviors of authorization repository
        /// </summary>
        [Test]
        public void Can_GetAuthorizationsByLicenseId_Test()
        {
            var data = new List<Authorization> 
            { 
                new Authorization { Key = "3334 6879 1616 5989", Status = Status.Authorized, Quantity = 1, DateCreated = DateTime.Now, LicenseId = 1}, 
                new Authorization { Key = "6339 0924 3636 2969", Status = Status.Activated, Quantity = 1, DateCreated = DateTime.Now, LicenseId = 7}, 
                new Authorization { Key = "32062 7182 9649 9435", Status = Status.Authorized, Quantity = 1, DateCreated = DateTime.Now, LicenseId = 3} 
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Authorization>>();
            mockSet.As<IQueryable<Authorization>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Authorization>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Authorization>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Authorization>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<LicensingContext>();
            mockContext.Setup(c => c.Authorizations).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<Authorization>()).Returns(mockSet.Object);


            var authorizationRepo = new AuthorizationRepository(mockContext.Object);
            var result = authorizationRepo.GetAuthorizationsByLicenseId(3);

            Assert.AreEqual(1, result.Count());
        }




        [Test]
        public void Can_Insert_Save_Activation_Test()
        {
            //var mockSet = new Mock<DbSet<Activation>>();
            //var mockContext = new Mock<LicensingContext>();
            //mockContext.Setup(m => m.Activations).Returns(mockSet.Object);
            IList<Activation> activations = new List<Activation>()
            {
                new Activation(){Key = "D41A91DB6285B0048F923C00C1F4754FFD42D257", Status = Status.Activated, MachineIdentifier = "0010000A4195CEC8", 
                                  BegEffDate = DateTime.Now, EndEffDate  = DateTime.Now.AddYears(1), 
                                 AuthorizationId = 1
                                
                                }             
            };

            Mock<IActivationRepository> mockActivationRepo = new Mock<IActivationRepository>();

            mockActivationRepo.Setup(m => m.Insert(It.IsAny<Activation>())).Returns(
                (Activation target) =>
                {
                    if (target.AuthorizationId.Equals(default(int)))
                    {
                        target.AuthorizationId = activations.Count() + 1;
                        target.DateCreated = DateTime.Now;
                        target.DateUpdated = DateTime.Now;
                        activations.Add(target);
                    }
                    else
                    {
                        var original = activations.Where(q => q.AuthorizationId == target.AuthorizationId).Single();

                        if (original == null)
                        {
                            return false;
                        }

                        original.Key = target.Key;
                        original.Status = target.Status;
                        original.MachineIdentifier = target.MachineIdentifier;
                        original.BegEffDate = DateTime.Now;
                        original.EndEffDate = DateTime.Now.AddYears(1);
                    }
                    return true;
                }
                    
                );

            
        }

        [Test]
        public void Can_GetProductTypeById_ReturnProductType()
        {
            ProductType testProductType = this.MockProductTypeRepo.GetById(2);

            Assert.IsNotNull(testProductType);
            Assert.AreEqual("CDR", testProductType.Type);
        }

        [Test]
        public void Check_Moq()
        {
            // Create Moq
            Mock<IProductTypeRepository> mockProductTypeRepo = new Mock<IProductTypeRepository>();

            // Setup
            mockProductTypeRepo.Setup(x => x.Insert(new ProductType())).Returns(true);

            mockProductTypeRepo.Verify();
        }

        [Test]
        public void Can_GetLicensesByProductTypeId()
        {

            IList<License> testLicenses = this.MockLicenseRepo.GetLicensesByProductTypeId(1).ToList();

            Assert.IsNotNull(testLicenses);
            Assert.AreEqual(2, testLicenses.Count);


        }

        //LicenseLookUp testing

        [Test]
        public void Can_LookUpLicenseByApplication_Test()
        {
            //var fakeApp = new List<Application>
            //{
            //    new Application {App = "SLMS"},
            //    new Application {App = "VLMS"}
                                
            //};

            Application fakeApp = new Application
            {
                App = "SLMS" 
            };

            var fakeLicense = new List<License>
            {
                new License{
                                Name = "CDR V3.6 2years",
                                Description = "CDR V3.6 Test",
                                TitleOfHardware = "CDR Vehicle",
                                LicenseType = LicenseType.Subscription,
                                Duration = 2,
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now,
                                Status = Status.Valid,
                                ProdFamilyId = 6,
                                SubscriptionId = 2,
                                VersionId = 10,
                                ApplicationId = 1,
                                ProductTypeId = 7 
                },
                new License {
                                Name = "BVMS V5.0 1 years",
                                Description = "BVMS V5.0 1Test",
                                TitleOfHardware = "BVMS",
                                LicenseType = LicenseType.Subscription,
                                Duration = 1,
                                DateCreated = DateTime.Now,
                                DateUpdated = DateTime.Now,
                                Status = Status.Valid,
                                ProdFamilyId = 6,
                                SubscriptionId = 2,
                                VersionId = 10,
                                ApplicationId = 1,
                                ProductTypeId = 5  


                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<License>>();
            mockSet.As<IQueryable<License>>().Setup(m => m.Provider).Returns(fakeLicense.Provider);
            mockSet.As<IQueryable<License>>().Setup(m => m.Expression).Returns(fakeLicense.Expression);
            mockSet.As<IQueryable<License>>().Setup(m => m.ElementType).Returns(fakeLicense.ElementType);
            mockSet.As<IQueryable<License>>().Setup(m => m.GetEnumerator()).Returns(fakeLicense.GetEnumerator());

            //var mockAppSet = new Mock<DbSet<Application>>();
            //mockAppSet.As<IQueryable<Application>>().Setup(m => m.Provider).Returns(fakeApp.Provider);
            //mockAppSet.As<IQueryable<Application>>().Setup(m => m.Expression).Returns(fakeApp.Expression);
            //mockAppSet.As<IQueryable<Application>>().Setup(m => m.ElementType).Returns(fakeApp.ElementType);
            //mockAppSet.As<IQueryable<Application>>().Setup(m => m.GetEnumerator()).Returns(fakeApp.GetEnumerator());

            var mockContext = new Mock<LicensingContext>();
            mockContext.Setup(c => c.Licenses).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<License>()).Returns(mockSet.Object);

            var licenseLookUp = new LicenseLookUp(mockContext.Object);
            
            var result = licenseLookUp.GetLicensesByApplication(fakeApp.App);

            Assert.AreEqual(2, result.Count());
        }



            
            //Mock<IGenericRepository<ProductType>> mockService = new Mock<IGenericRepository<ProductType>>();

            //mock licensing context
            //mockContext = new Mock<LicensingContext>();

            //mock DbSet ProductType
            //mockSet = new Mock<DbSet<ProductType>>();

            // var service = new mockService(mockContext.Object);

            //Set up
            //mockContext.Setup(m => m.ProductTypes).Returns(mockSet.Object);


            //var service = new IGenericRepository<mockContext.Object>();

            //return product type by id


            //mockProductTypeRepo.Setup(mp => mp.Insert(It.IsAny<ProductType>())).Returns(
            //    (ProductType target) =>
            //    {
            //        if (target.Id.Equals(default(int)))
            //        {
            //            target.Id = types.Count() + 1;
            //            target.Type = "VCI";
            //            types.Insert(target);
            //        }
            //        else
            //        {
            //            var original = types.Where(q => q.Id == target.Id).Single();

            //            if (original == null)
            //            {
            //                return false;
            //            }

            //            original.Type = target.Type;
            //        }
            //        return true;
            //    }

            //    );



        
    }
}

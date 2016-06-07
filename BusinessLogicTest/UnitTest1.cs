using System;
using Moq;
using System.Data.Entity;
using DataLayer.Entities;
using DataLayer;
using System.Collections.Generic;
using DataAccessLayer;
using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;

namespace BusinessLogicTest
{
    [TestFixture]
    public class UnitTest1
    {
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

        }
    
}

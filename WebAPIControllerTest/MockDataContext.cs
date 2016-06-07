using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace WebAPIControllerTest
{
    public class MockDataContext
    {
        public List<ProductType> Types
        {
            get
            {
                return new List<ProductType>
                    {
                        new ProductType
                        {
                            Id = 1,
                            Type = "BVMS Test",
                        },
                        new ProductType
                        {
                           Id = 2,
                           Type = "CDR Test",
                        },
                        new ProductType
                        {
                            Id = 3,
                            Type = "VIR Test",
                        }
                    };
            }
        }
    }
}

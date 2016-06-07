using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Enums
{
    public enum Status
    {
       //License Status
        Valid = 1,
        Invalid = 2,
        
        //Authorization Status
        Authorized = 3,
        Activated = 4,
        Expired = 5,
        
        //Activation Status
        //IsValid = 6,
        //IsExpired = 7,

        //Order Status
        Pending = 6,
        Completed = 7       
    }
}

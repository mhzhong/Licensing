﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface IAuthorizationRepository: IGenericRepository<Authorization>
    {
        //should return other things
        IEnumerable<Authorization> GetAuthorizationsByLicenseId(int id);
        Authorization GetAuthorizationByOrderId(int id);
        //bool Insert(Authorization authorization);


        //void Insert(System.Net.Authorization autho);
    }
}

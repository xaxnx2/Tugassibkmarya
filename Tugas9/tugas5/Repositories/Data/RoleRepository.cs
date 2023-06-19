﻿using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class RoleRepository : GenericRepo<Role,int,MyContext>,IRoleRepository
    {
        public RoleRepository(MyContext context) : base(context) { }

    }
}

﻿using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutRepository: Repositories.GenericRepository<About>,IAboutDal
    {

    }
}

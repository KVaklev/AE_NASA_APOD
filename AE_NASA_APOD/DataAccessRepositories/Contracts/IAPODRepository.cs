﻿using BusinessQueryParameters;
using DataAccessModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessRepositories.Contracts
{
    public interface IAPODRepository
    {
        List<APOD> GetAll();

        PaginatedList<APOD> FilterBy(APODQueryParameters queryParameters);

        APOD GetById(int id);

        APOD GetByName(string name);

        APOD GetByCopyright(string copyright);



    }
}
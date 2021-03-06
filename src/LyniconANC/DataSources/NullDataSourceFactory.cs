﻿using Lynicon.Extensibility;
using Lynicon.Repositories;
using Lynicon.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lynicon.DataSources
{
    public class NullDataSourceFactory : IDataSourceFactory
    {
        public string DataSourceSpecifier
        {
            get
            {
                return "";
            }
        }

        public LyniconSystem System { get; set; }

        public IDataSource Create(bool forSummaries)
        {
            return new NullDataSource();
        }
    }
}

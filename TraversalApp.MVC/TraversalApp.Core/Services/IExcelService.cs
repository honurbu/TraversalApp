﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalApp.Core.Services
{
    public interface IExcelService
    {
        byte[] ExcelList<T>(List<T> t) where T : class;

    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace VRA.BusinessLayer
{
    public interface IQueryProcess
    {
        DataTable Query(string query);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.ViewModels.Category
{
    public class GetAllCategoryViewModel
    {
        public int Id { get; set; }
        public int? Parent { get; set; }
        public string Name { get; set; }
    }
}

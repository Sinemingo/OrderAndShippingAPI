﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAndShippingAPI.Entities.Abstract.Enums;

namespace OrderAndShippingAPI.Entities.Concrete.Dtos
{
    public class CategoryListDto
    {
        public IList<Category> Categories { get; set; }
        public EResultStatu ResultStatus { get; set; }
    }
}

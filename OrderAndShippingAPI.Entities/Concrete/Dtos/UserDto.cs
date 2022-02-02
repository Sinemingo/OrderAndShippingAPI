﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAndShippingAPI.Entities.Abstract.Enums;

namespace OrderAndShippingAPI.Entities.Concrete.Dtos
{
    public class UserDto
    {
        public User User { get; set; }
        public EResultStatu ResultStatus { get; set; }
    }
}

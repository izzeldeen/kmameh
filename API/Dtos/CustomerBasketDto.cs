﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }

        public List<BasketItem>  Items { get; set; }
    }
}

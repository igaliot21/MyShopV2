﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public int BasketTotal { get; set; }
        public BasketSummaryViewModel() { }
        public BasketSummaryViewModel(int BasketCount, int BasketTotal) {
            this.BasketCount = BasketCount;
            this.BasketTotal = BasketTotal;
        }
    }
}

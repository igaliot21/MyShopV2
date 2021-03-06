﻿using MyShop.Core.Models;
using MyShop.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Intefaces
{
    public interface IOrderService
    {
        void CreateOrder(Order baseOrder, List<BasketItemViewModel> basketItem);
        List<Order> GetOrderList();
        Order GetOrder(string Id);
        void UpdateOrder(Order UpdatedOrder);
        void DeleteOrder(string Id);
    }
}

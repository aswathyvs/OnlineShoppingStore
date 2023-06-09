﻿using Microsoft.AspNetCore.Mvc;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Models.ViewModels;

namespace OnlineShoppingStore.Infrastructure.Components
{
    public class SmallCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            SmallCartViewModel smallCartViewModel;

            if (cart == null || cart.Count == 0)
            {
                smallCartViewModel = null;
            }
            else
            {
                smallCartViewModel = new()
                {
                    NumberOfItems = cart.Sum(x => x.Quantity),
                    TotalAmount = cart.Sum(x => x.Quantity * x.DiscountedPrice)
                };
            }

            return View(smallCartViewModel);
        }
    }
}

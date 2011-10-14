﻿using System;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize = 4;

        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(int page = 1)
        {
            return View(new ProductsListViewModel
                {
                    Products = repository.Products.OrderBy(p => p.ProductID)
                                                  .Skip(Math.Max(0, page - 1) * PageSize)
                                                  .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count(),
                    }
                });
        }
    }
}

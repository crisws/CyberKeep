using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CyberKeep.Data;
using CyberKeep.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using CyberKeep.Models.Request;
using CyberKeep.Models.Response;

namespace CyberKeep.Controllers.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CyberKeepContext _context;

        public ProductsController(CyberKeepContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Get")]
        public ActionResult GetProducts(SimpleProductRequest product)
        {
            var CheckProduct = _context.Products.FirstOrDefault(u => u.SKU == product.SKU);
            var checkHistories = _context.Histories.Where(u => u.Product == CheckProduct);

            List<HistoriesResponse> Histories = new List<HistoriesResponse>();

            foreach (var item in checkHistories)
            {
                Histories.Add(new HistoriesResponse
                {
                    Date = item.AddedDate,
                    Price = item.Price
                });
            }


            ProductResponse Product = new ProductResponse
            {
                SKU = CheckProduct.SKU,
                ActualPrice = CheckProduct.Price,
                InitialDate = CheckProduct.AddedDate,
                Histories = Histories
            };

            return  Ok(Product);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Products>> PostProducts(ProductRequest product)
        {
            var CheckProduct = _context.Products.FirstOrDefault(u => u.SKU == product.SKU);

            if (CheckProduct != null)
            {
                if (CheckProduct.Price == product.Price)
                {
                    Histories historie = new Histories
                    {
                        Product = CheckProduct,
                        AddedDate = DateTime.UtcNow,
                        Price = product.Price
                    };

                    _context.Histories.Add(historie);
                }
                else
                {
                    CheckProduct.Price = product.Price;
                    _context.Entry(CheckProduct).State = EntityState.Modified;
                    Histories historie = new Histories
                    {
                        Product = CheckProduct,
                        AddedDate = DateTime.UtcNow,
                        Price = product.Price
                    };

                    _context.Histories.Add(historie);
                }
            }
            else
            {
                Products Product = new Products
                {
                    Price = product.Price,
                    SKU = product.SKU,
                    AddedDate = DateTime.UtcNow
                };
                _context.Products.Add(Product);

                Histories historie = new Histories
                {
                    Product = Product,
                    AddedDate = DateTime.UtcNow,
                    Price = product.Price
                };

                _context.Histories.Add(historie);
            }
            await _context.SaveChangesAsync();

            return Ok(new BaseResponse { Message = "Product ready" });

        }



    }
}

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService; //dependency injection için field ekledim!

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] //tüm ürünleri getirmek için!
        public IActionResult GetList()
        {
            var result = _productService.GetList();

            if (result.Success) //burada result yönetimi yaptım!
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getlistbycategory")] //category ye göre ürünleri getirmek için!
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);

            if (result.Success) 
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getbyid")] //tek bir ürün döndüreceğim id 'ye göre çekebilirim!
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);

            if (result.Success) //burada result yönetimi yaptım!
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("add")] //ekleme benim için post methodu!
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success) //burada result yönetimi yaptım!
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("update")] //güncelleme benim için post methodu!
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);

            if (result.Success) 
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("delete")] //silme benim için post methodu!
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);

            if (result.Success) 
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}

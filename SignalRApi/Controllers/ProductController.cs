using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_ProductService.TGetAll());
            return Ok(value);
        }
		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_ProductService.TProductCount());
		}
		[HttpGet("ProductCountByCategoryNameHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			return Ok(_ProductService.TProductCountByCategoryNameHamburger());
		}
		[HttpGet("ProductCountByCategoryNameDrink")]
		public IActionResult ProductCountByCategoryNameDrink()
		{
			return Ok(_ProductService.TProductCountByCategoryNameDrink());
		}
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_ProductService.TProductPriceAvg()); 
		}
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_ProductService.TProductNameByMaxPrice());
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult TProductNameByMinPrice()
		{
			return Ok(_ProductService.TProductNameByMinPrice());
		}
		[HttpGet("ProductPriceByHmaburger")]
		public IActionResult TProductPriceByHmaburger()
		{
			return Ok(_ProductService.TProductPriceByHmaburger());
		}


		[HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory() 
        {
        var context=new SignalRContext();
        var values=context.Products.Include(x=>x.Category).Select(y=>new ResultProductWithCategory
        {
            Description=y.Description,
            ImageUrl=y.ImageUrl,
            price=y.price,
            ProductID=y.ProductID,
            ProductName=y.ProductName,
            ProductStatus=y.ProductStatus,
            CategoryName=y.Category.CategoryName,
            
        });
            return Ok(values.ToList());
        }



        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _ProductService.TAdd(new SignalR.EntityLayer.Entities.Product()
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductStatus = createProductDto.ProductStatus,
                price = createProductDto.price,
                CategoryID = createProductDto.CategoryID,



            }) ;
            return Ok("ürün bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            _ProductService.TDelete(value);
            return Ok("ürün Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _ProductService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _ProductService.TUpdate(new SignalR.EntityLayer.Entities.Product()
            {
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                ProductStatus = updateProductDto.ProductStatus,
                price = updateProductDto.price,
                ProductName = updateProductDto.ProductName,
                ProductID = updateProductDto.ProductID,
                CategoryID=updateProductDto.CategoryID

            });

            return Ok("ürün  güncellendi");
        }
    }
}


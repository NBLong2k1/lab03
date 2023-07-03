using AutoMapper;
using BusinessObjects.Models.Entities;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.DTO;
using ProjectManagementAPI;
using Repositories.Interface;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Web.Helpers;
using System.Web.Http.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementAPI.Controllers
{


     
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class ProductsControllers : ControllerBase
    {
        private readonly IMapper _mapper;
        public ProductsControllers(IMapper mapper)
        {
          
            _mapper = mapper;
        }

        
        private IProductRepository repository = new ProductRepository();
        // GET: api/<ProductsControllers>

       

        [HttpGet] 
        [EnableQuery]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return repository.GetProducts();
        }
             

        // GET: api/TodoItems/5
        //[HttpGet("{id}")]
        [HttpGet("get-product-by-id/{id}/detail")]
       
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Product>> GetProducts(int id)
            => repository.GetProductById(id);


        // POST api/<ProductsControllers>
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult PostProduct([FromBody]ProductDTO p)
        {

           var product=_mapper.Map<Product>(p);

             repository.SaveProduct(product);

            return NoContent();
        }



        //PUT api/<ProductsControllers>/5
        [HttpPut("{id}")]
        
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(int id,ProductDTO p)
        {
            var product= _mapper.Map<Product>(p);  
            
            var pTmp=repository.GetProductById(id);
            if (pTmp == null)
            
                return NotFound();
            pTmp = product;
            pTmp.ProductId = id;
                repository.UpdateProduct(pTmp);
               return NoContent();

            
        }

        // DELETE api/<ProductsControllers>/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
   
        public IActionResult DeleteProduct(int id)
        {

            Console.WriteLine("ok:::");

            //var p = repository.GetProductById(id);
            //if (p == null)
            //    return NotFound();
            //repository.DeleteProduct(p);
            
            
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

//This is a code of controller
//This edit is done from Dev-Branch
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository<Product> _ProductRepository;

        public ProductsController(IProductRepository<Product> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _ProductRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product pro = _ProductRepository.Get(id);
            if (pro != null)
            {
                return Ok(pro);
            }
            return NotFound("he Product record couldn't be found.");
        }


        [HttpPost]
        public IActionResult Post([FromBody] Product pro)
        {
            if (pro == null)
            {
                return BadRequest("Product is null.");
            }
            _ProductRepository.Add(pro);
            return CreatedAtAction("Get",new { Id = pro.ProductID },pro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product pro)
        {
            if (pro == null)
            {
                return BadRequest("Product is null.");
            }
            Product productToUpdate = _ProductRepository.Get(id);
            if (productToUpdate == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            _ProductRepository.Update(productToUpdate, pro);
            //return Ok(pro);
            return NoContent();
        }

        

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Product pro = _ProductRepository.Get(id);
            if (pro == null)
            {
                return NotFound("The Product record couldn't be found.");
            }
            _ProductRepository.Delete(pro);
            //return Ok(pro);
            return NoContent();
        }

    }
}

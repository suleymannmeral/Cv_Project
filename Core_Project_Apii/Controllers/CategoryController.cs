using Core_Project_Apii.DAL.ApiContext;
using Core_Project_Apii.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Core_Project_Apii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
           using var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
           using  var c = new Context();
            var value = c.Categories.Find(id);
            return (value == null ? NotFound() : Ok(value));
        }
        [HttpPost]
        public IActionResult GetCategoryAdd(Category p)
        {
            using var c = new Context();
           c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if(value == null) 
                {
                return NotFound();

                }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            using var c = new Context();
            var value = c.Find<Category>(p.CategoryID);
            if(value==null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName = p.CategoryName;
                c.Update(value);
                c.SaveChanges();
                return NoContent() ;
            }
        }
    }
}

using Exercise_1.ItemsManager;
using Exercise_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exercise_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemManager _manger = new ItemManager();
        // GET: api/<ItemsController>
        [HttpGet]

        public IEnumerable<Item> Get([FromQuery] String substing,int minQuality,int quantity)
        {
            return _manger.GetAll(substing,minQuality,quantity);
            //IEnumerable<Item> result = _manger.GetAll(substing, minQuality, quantity);
            //if (result.Count() == 0) return NoContent();
            //return Ok(result);
        }
        [HttpGet("quality")]
        public IEnumerable<Item> Get([FromQuery] int minQuality,[FromQuery] int maxQuality)
        {
           /* IEnumerable<Item > result =*/return _manger.getAllBetweenQaulity(minQuality, maxQuality);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _manger.GetById(id);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] Item newItem)
        {
            _manger.Add(newItem);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item newItem)
        {
            _manger.Update(id, newItem);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public Item Delete(int id)
        {
           return _manger.Delete(id);
        }
    }
}

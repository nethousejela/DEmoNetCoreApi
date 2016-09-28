using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DemoNetCoreApi.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoNetCoreApi.Controllers
{
    [Route("api/data")]
    public class DemoControler : Controller
    {
        public IDemoReposityry DemoItems { get; set; }
        public DemoControler(IDemoReposityry demoItems)
        {
            DemoItems = demoItems;
        }

        [HttpGet]
        public IEnumerable<DemoItem> GetAll()
        {
            return DemoItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetItem")]
        public IActionResult GetById(string id)
        {
            var item = DemoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] DemoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            DemoItems.Add(item);
            return CreatedAtRoute("GetItem", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] DemoItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var todo = DemoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            DemoItems.Update(item);
            return new NoContentResult();
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] DemoItem item, string id)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var todo = DemoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            item.Key = todo.Key;

            DemoItems.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = DemoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            DemoItems.Remove(id);
            return new NoContentResult();
        }
    }


}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinesApi.Models;
using WinesApi.Services;

namespace WinesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinesController : ControllerBase
    {
        private readonly WineService _wineService;

        public WinesController(WineService wineService)
        {
            _wineService = wineService;
        }

        [HttpGet]
        public ActionResult<List<Wine>> Get() =>
            _wineService.Get();

        [HttpGet("{id:length(24)}", Name = "GetWine")]
        public ActionResult<Wine> Get(string id)
        {
            var wine = _wineService.Get(id);

            if (wine == null)
            {
                return NotFound();
            }

            return wine;
        }

        [HttpPost]
        public ActionResult<Wine> Create(Wine wine)
        {
            _wineService.Create(wine);

            return CreatedAtRoute("GetWine", new { id = wine.Id.ToString() }, wine);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Wine wineIn)
        {
            var wine = _wineService.Get(id);

            if (wine == null)
            {
                return NotFound();
            }

            _wineService.Update(id, wineIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var wine = _wineService.Get(id);

            if (wine == null)
            {
                return NotFound();
            }

            _wineService.Remove(wine.Id);

            return NoContent();
        }
    }
}

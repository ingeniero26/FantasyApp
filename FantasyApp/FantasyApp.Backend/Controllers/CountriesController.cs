using FantasyApp.Backend.Data;
using FantasyApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FantasyApp.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;
        public CountriesController(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync( Country country)
        {
          var currentCountry = await _context.Countries.FirstOrDefaultAsync(c => c.Id == country.Id);
            if (currentCountry == null)
            {
                return NotFound();
            }
            currentCountry.Name = country.Name;
            currentCountry.Code = country.Code;
            currentCountry.IsActive = country.IsActive;
            _context.Update(currentCountry);
            await _context.SaveChangesAsync();
            return Ok(currentCountry);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //activar o desactivar un país
        [HttpPut("toggle/{id}")]
        public async Task<IActionResult> ToggleAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            country.IsActive = !country.IsActive;
            _context.Update(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _context.Countries.AnyAsync(e => e.Id == id);

        }
    }
}

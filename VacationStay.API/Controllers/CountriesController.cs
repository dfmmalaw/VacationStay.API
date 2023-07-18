using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationStay.API.Data;
using VacationStay.API.DTOs.Country;

namespace VacationStay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly VacationStayDbContext _context;
        private readonly IMapper _mapper;

        public CountriesController(VacationStayDbContext context, IMapper mapper)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            
            var countries = await _context.Countries.ToListAsync();
            var countryDtos = _mapper.Map<List<GetCountryDto>>(countries);
            return Ok(countryDtos);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            // I refactored this to include list of hotels for the country
            var country = await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            var countryDto = _mapper.Map<CountryDto>(country);

            return Ok(countryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            // this code actually sets EntityState to Modified while mapping the dto fields to the model
            _mapper.Map(updateCountryDto, country);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountryDto)
        {
            if (_context.Countries == null)
            {
                return Problem("Entity set 'VacationStayDbContext.Countries'  is null.");
            }
 
            var country = _mapper.Map<Country>(createCountryDto);
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

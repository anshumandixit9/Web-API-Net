using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly DataContext _context;
        public ClinicController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Clinics>>> Get()
        {    
            return Ok(await _context.Clinic.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Clinics>>> Post(Clinics clinic)
        {
            await _context.Clinic.AddAsync(clinic);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clinic.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Clinics>>> Update(Clinics clinic)
        {
            var clinic_single = await _context.Clinic.FindAsync(clinic.ClinicName);
            if (clinic_single == null)
                return BadRequest("Clinic Not Found!");
            clinic_single.id = clinic.id;
            clinic_single.ClinicName = clinic.ClinicName;
            clinic_single.Location = clinic.Location;
            await _context.SaveChangesAsync();
            return Ok(await _context.Clinic.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Clinics>>> RemoveClinic(string RemoveClinic)
        {
            var clinic_single = await _context.Clinic.FindAsync(RemoveClinic);
            if (clinic_single == null)
                return NotFound();
            _context.Clinic.Remove(clinic_single);
            await _context.SaveChangesAsync();
            return Ok(await _context.Clinic.ToListAsync());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly DataContext _context;
        public MedicineController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Medicines>>> Get()
        {
            return Ok(await _context.Medicine.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Medicines>>> AddMedicine(Medicines medicine)
        {
            await _context.Medicine.AddAsync(medicine);
            await _context.SaveChangesAsync();
            return Ok(await _context.Medicine.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Medicines>>> UpdateMedicine(Medicines medicine)
        {
            var medicine_single = await _context.Medicine.FindAsync(medicine.MedicineName);
            if (medicine_single == null)
                return NotFound();
            medicine_single.id = medicine.id;
            medicine_single.MedicineName = medicine.MedicineName;
            medicine_single.ClinicName = medicine.ClinicName;
            medicine_single.AvailableStock = medicine.AvailableStock;
            return Ok(_context.Medicine.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Medicines>>> DeleteMedicine(string RemoveMedicineName)
        {
            var medicine_single = await _context.Medicine.FindAsync(RemoveMedicineName);
            if (medicine_single == null)
                return NotFound();
            _context.Medicine.Remove(medicine_single);
            return Ok(await _context.Medicine.ToListAsync());
        }
    }
}

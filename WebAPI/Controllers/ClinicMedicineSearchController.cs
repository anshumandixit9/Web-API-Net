using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicMedicineSearchController : ControllerBase
    {
        private readonly DataContext _context;
        public ClinicMedicineSearchController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("{clinicName}")]
        public async Task<ActionResult<List<Medicines>>> Get(string clinicName)
        {
            List<Medicines> medicine_clinic_list = new List<Medicines>();
            List<Medicines> temp = new List<Medicines>(await _context.Medicine.ToListAsync());
            foreach (var obj in temp)
            {
                if ((obj.ClinicName).Equals(clinicName))
                    medicine_clinic_list.Add(obj);
            }
            return Ok(medicine_clinic_list);
        }
    }
}

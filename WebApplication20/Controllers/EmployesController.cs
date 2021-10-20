using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication20.models;
using static WebApplication20.Controllers.paginate;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApplication20.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    //public class DefaultController : ApiController
    //{
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly EmployeeAttendanceContext _context =new EmployeeAttendanceContext();

        //public EmployesController(EmployeeAttendanceContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Employes
        [HttpGet]
        public  IEnumerable<Employe> GetEmployes()
        {
            return  _context.Employes.ToList();
        }

        // GET: api/Employes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
            var employe = await _context.Employes.FindAsync(id);

            if (employe == null)
            {
                return NotFound();
            }

            return employe;
        }
        [HttpGet("{PageNumber}&{PageSize}")]

        public PagedData<Employe> GetEmployePage(int PageNumber, int PageSize)
        {
            var res = GetEmployes();
            var DATA = paginate.PagedResult(res, PageNumber, PageSize);
            return DATA;
        }


        // PUT: api/Employes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(int id, Employe employe )
        {

            if (id != employe.Id)
            {
                return BadRequest();
            }
            var emp = _context.Employes.Find(id);
            emp.Name = employe.Name;
            emp.PhoneNumber = employe.PhoneNumber;
            emp.Address = employe.Address;
            emp.Age = employe.Age;
            _context.Entry(emp).State = EntityState.Modified;
        
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
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

        
        // POST: api/Employes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employe>> PostEmploye(Employe employe)
        {

            _context.Employes.Add(employe);
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeExists(employe.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmploye", new { id = employe.Id }, employe);
        }


       

        // DELETE: api/Employes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploye(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }

            _context.Employes.Remove(employe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeExists(int id)
        {
            return _context.Employes.Any(e => e.Id == id);
        }
    }
}

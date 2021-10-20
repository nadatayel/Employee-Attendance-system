using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication20.models;

namespace WebApplication20.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendController : ControllerBase
    {

        private readonly EmployeeAttendanceContext _context = new EmployeeAttendanceContext();

        //put employeeAttendance
        //[HttpPut("{employeAttendance.EmpId}")]
        //public async Task<IActionResult> PutEmployeAttend(EmpAtt_VM empAtt)
        //{
        //    EmployeAttendance employeAttendance = new EmployeAttendance();
        //    var att = _context.EmployeAttendances.Where(x => x.EmpId == empAtt.EmpId).FirstOrDefault();
        //    employeAttendance.Attendance = TimeSpan.Parse(empAtt.Attendance);
        //    employeAttendance.Leaving = TimeSpan.Parse(empAtt.Leaving);




        //    await _context.SaveChangesAsync();
        //    return Ok();



        //}

        //post employee attendance 
        [HttpPost("employeAttendance")]
        public async Task<IActionResult> PostEmployeAttend(EmpAtt_VM empAtt)
        {
            Employe employe = new Employe();
            EmployeAttendance attendance = new EmployeAttendance();
            attendance.EmpId = empAtt.EmpId;
            attendance.Leaving = DateTime.Parse(empAtt.Leaving).TimeOfDay ;
            attendance.Attendance = DateTime.Parse(empAtt.Attendance).TimeOfDay;

            await _context.EmployeAttendances.AddAsync(attendance);

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

            return Ok();
        }


        // GET: api/EmployeAttend/5
        [HttpGet()]
        public  ActionResult<EmployeAttendance> GetEmployeAttend(int Emp_Id)
        {

            //var employeAttendance = _context.EmployeAttendances.Where(A => A.EmpId == Emp_Id).ToArray();
            var employeAttendance = _context.EmployeAttendances.Where(A => A.EmpId == Emp_Id).OrderByDescending(a=>a.Id).FirstOrDefault();

         
            if (employeAttendance ==null)
            {
                return NoContent();
            }
            //if (employeAttendance.Length < 1 || employeAttendance[employeAttendance.Length - 1] == null)
            //{
            //    return NotFound();
            //}
            //EmpAtt_VM res = new EmpAtt_VM();
            //res.Attendance = (employeAttendance[employeAttendance.Length - 1].Attendance.Hours).ToString();
            //res.Leaving = (employeAttendance[employeAttendance.Length - 1].Leaving.Hours).ToString();
            //res.EmpId= (employeAttendance[employeAttendance.Length - 1].EmpId);

            var attendance = string.Concat(employeAttendance.Attendance.Hours, ":", employeAttendance.Attendance.Minutes);
            var leaving = string.Concat(employeAttendance.Leaving.Hours, ":", employeAttendance.Leaving.Minutes);

            //return Ok(res);
            return Ok( new { attendance , leaving });
            //Return Ok(new { Result = true / false, Value = { attendance = "12:05", leaving = "18:01"}

        }

        private bool EmployeExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}

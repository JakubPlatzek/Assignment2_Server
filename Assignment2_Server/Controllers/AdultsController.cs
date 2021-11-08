using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Server.Data;
using Microsoft.AspNetCore.Mvc;
using Assignment2_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
       private readonly IAdultsData adultsData;

        public AdultsController(IAdultsData adultsData)
        {
            this.adultsData = adultsData;
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdult([FromRoute] int id)
        {
            Adult adult = await adultsData.Get(id);
            return adult;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdultsAsync([FromQuery] string jobTitle,
            [FromQuery] string salary, [FromQuery] int? age, [FromQuery] int? height, [FromQuery] int? id,
            [FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] string hairColor,
            [FromQuery] string eyeColor, [FromQuery] float? weight,
            [FromQuery] string sex)
        {
            IList<Adult> adultsToShow = new List<Adult>();
            try
            {
                IQueryable<Adult> adults = await adultsData.GetAdults();
                if (id != null)
                {
                    adultsToShow = await adults.Where(t => t.Id == id).ToListAsync();
                }
                else if (jobTitle != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.AdultJob.JobTitle.ToString().Equals(jobTitle)).ToListAsync();
                }
                else if (salary != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.AdultJob.Salary.ToString().Equals(salary)).ToListAsync();
                }
                else if (age != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.Age == age).ToListAsync();
                }
                else if (height != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.Height == height).ToListAsync();
                }
                else if (firstName != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.FirstName.ToString().Equals(firstName)).ToListAsync();
                }
                else if (lastName != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.LastName.ToString().Equals(lastName)).ToListAsync();
                }
                else if (hairColor != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.HairColor.ToString().Equals(hairColor)).ToListAsync();
                }
                else if (eyeColor != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.EyeColor.ToString().Equals(eyeColor)).ToListAsync();
                }
                else if (weight != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.Weight == weight).ToListAsync();
                }
                else if (sex != null)
                {
                    adultsToShow = await adults.Where(t =>
                        t.Sex.ToString().Equals(sex)).ToListAsync();
                }
                else
                {
                    adultsToShow = await adults.ToListAsync();
                }
                return Ok(adultsToShow);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdultAsync([FromBody]Adult adult)
        {
            try
            {
                Adult added = await adultsData.AddAdult(adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
               return StatusCode(500, e.Message);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> DeleteAdultAsync([FromRoute] int id)
        {
            try
            {
                Adult adult = await adultsData.Get(id);
                await adultsData.RemoveAdult(adult.FirstName, adult.LastName);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        public async Task<ActionResult<Adult>> EditAdultAsync([FromBody]Adult adult)
        {
            try
            {
                await adultsData.Update(adult);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
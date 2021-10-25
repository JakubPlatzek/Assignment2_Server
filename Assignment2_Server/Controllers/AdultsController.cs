using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2_Server.Data;
using Microsoft.AspNetCore.Mvc;
using Assignment2_Server.Models;

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
                IList<Adult> adults = await adultsData.GetAdults();
                Console.WriteLine(adults[1].FirstName);
                if (id != null)
                {
                    adultsToShow = adults.Where(t => t.Id == id).ToList();
                }
                else if (jobTitle != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.JobTitle.JobTitle.ToString().Equals(jobTitle)).ToList();
                }
                else if (salary != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.JobTitle.Salary.ToString().Equals(salary)).ToList();
                }
                else if (age != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.Age == age).ToList();
                }
                else if (height != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.Height == height).ToList();
                }
                else if (firstName != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.FirstName.ToString().Equals(firstName)).ToList();
                }
                else if (lastName != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.LastName.ToString().Equals(lastName)).ToList();
                }
                else if (hairColor != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.HairColor.ToString().Equals(hairColor)).ToList();
                }
                else if (eyeColor != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.EyeColor.ToString().Equals(eyeColor)).ToList();
                }
                else if (weight != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.Weight == weight).ToList();
                }
                else if (sex != null)
                {
                    adultsToShow = adults.Where(t =>
                        t.Sex.ToString().Equals(sex)).ToList();
                }
                else
                {
                    adultsToShow = adults;
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
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper_Demo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dapper_Demo.Controllers
{
    [Route("api/[controller]")]
    public class AircraftsController : Controller
    {
        private AircraftRepository repo = new AircraftRepository();

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<Aircraft>> Get()
        {
            IEnumerable<Aircraft> aircraft;

            using (var connection = new SqlConnection(""))
            {
                await connection.OpenAsync();
                var query = @"
SELECT 
       Id
      ,Manufacturer
      ,Model
      ,RegistrationNumber
      ,FirstClassCapacity
      ,RegularClassCapacity
      ,CrewCapacity
      ,ManufactureDate
      ,NumberOfEngines
      ,EmptyWeight
      ,MaxTakeoffWeight
  FROM Aircraft";
                aircraft = await connection.QueryAsync<Aircraft>(query);
            }
            return aircraft;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Aircraft> Get(int id)
        {
            Aircraft aircraft;
            using (var connection = new SqlConnection(""))
            {
                await connection.OpenAsync();
                var query = @"
SELECT 
       Id
      ,Manufacturer
      ,Model
      ,RegistrationNumber
      ,FirstClassCapacity
      ,RegularClassCapacity
      ,CrewCapacity
      ,ManufactureDate
      ,NumberOfEngines
      ,EmptyWeight
      ,MaxTakeoffWeight
  FROM Aircraft WHERE Id = @Id";

                aircraft = await connection.QuerySingleAsync<Aircraft>(query, new { Id = id });
            }
            return aircraft;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

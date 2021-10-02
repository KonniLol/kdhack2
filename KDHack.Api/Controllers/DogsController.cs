using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using KDHack.Api.DbModels;
using KDHack.Api.Models;
using KDHack.Api.Services;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

namespace KDHack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        public IMongoCollection<DogDbModel> DogMongoCollection { get; set; }
        public DogsController()
        {
            string connectionString =
  @"mongodb://kdhack-bd:GWA5Xqx6GxOJ4XYTz3nJgAOQcoQV7kFtqGlxfpsQUy7Y2kxzBCPcM5Nu1PxygbdQxsXLbur1mceTxA7X874BsA==@kdhack-bd.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@kdhack-bd@";
                        var client = new MongoClient(connectionString);
            var database = client.GetDatabase("KDHack");
            DogMongoCollection = database.GetCollection<DogDbModel>("Dogs");
        }
      
        [HttpPost]
        public async Task<ActionResult<DogResponse>> Post(DogHttpPostRequst requst)
        {
            var height = double.Parse(requst.Height);
            var weight = double.Parse(requst.Weight);
            var trainability = double.Parse(requst.Trainability);
            var interations = double.Parse(requst.Interations);

            List<Dog> nexts = NextGenerationService.NextGeneration(DogMongoCollection, height, weight,
                trainability).ToList();

            for (var i = 1; i < interations; i++)
            {
                nexts = NextGenerationService.NextGeneration(new List<Dog>(nexts), height, weight, trainability).ToList();
            }

            var dog = NextGenerationService.GetPol(nexts, height, weight, trainability);

            return Ok(new DogResponse
            {
                Height = dog.Height,
                Weight = dog.Weight,
                Trainability = dog.Trainability
            });
        }

        [HttpGet]
        public ActionResult<string> Get(double interations, double height, double weight, double trainability)
        {
            return Ok("hi");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using KDHack.Api.DbModels;
using KDHack.Api.Models;

using Microsoft.EntityFrameworkCore;

using MongoDB.Driver;

namespace KDHack.Api.Services
{
    public static class NextGenerationService
    {
        //public List<DogDbModel> DbList = new()
        //{
        //    new()
        //    {
        //        Name = 
        //         Height = 1,
        //         Weight = 1,
                 
        //    }
        //};
        public static IEnumerable<Dog> NextGeneration(IEnumerable<Dog> dogs, double serachSize, double searchMass, double searchTrainability)
        {
            var nextDogList = new List<Dog>();
            var dogList = dogs.OrderBy(i =>
            Math.Abs(i.Height - serachSize)*3 + Math.Abs(i.Weight - searchMass)*5 + Math.Abs(i.Trainability - searchTrainability)*20).Take(5).ToList();

            for (var i = 0; i < dogList.Count; i++)
                for (var j = i + 1; j < dogList.Count; j++)
                    nextDogList.Add(dogList[i] + dogList[j]);

            return nextDogList;
        }

        
        public static Dog GetPol(IEnumerable<Dog> dogs, double serachSize, double searchMass, double searchTrainability) =>
            dogs.OrderBy(i =>
            
                300 - (i.Weight * 100 / serachSize) + (i.Height * 100 / searchMass) + (i.Trainability * 100 / searchTrainability) < 0 ?
  -(300 - (i.Weight * 100 / serachSize) + (i.Height * 100 / searchMass) + (i.Trainability * 100 / searchTrainability)) :
  (300 - (i.Weight * 100 / serachSize) + (i.Height * 100 / searchMass) + (i.Trainability * 100 / searchTrainability))
            ).First();


    }
}

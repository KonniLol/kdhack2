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
            {
                double GetProc(double o, double g) => o * 100 / g;
                return Math.Abs(300 - GetProc(i.Height, serachSize) + GetProc(i.Weight, searchMass) + GetProc(i.Trainability, searchTrainability));
            }).Take(5).ToList();

            for (var i = 0; i < dogList.Count; i++)
                for (var j = i + 1; j < dogList.Count; j++)
                    nextDogList.Add(dogList[i] + dogList[j]);

            return nextDogList;
        }

        public static IEnumerable<Dog> NextGeneration(IMongoCollection<DogDbModel> collection, double serachSize, double searchMass, double searchTrainability)
        {
            var nextDogList = new List<Dog>();
            var bdList =  collection.AsQueryable().Where(i => i.Trainability == 2).ToList();
            var dogDbList = collection.AsQueryable().ToList().OrderBy(i =>
                  300 - (i.Weight*100/serachSize) + (i.Height * 100 / searchMass) + (i.Trainability * 100 / searchTrainability) < 0 ?
                  -(300 - (i.Weight * 100 / serachSize) + (i.Height * 100 / searchMass) + (i.Trainability * 100 / searchTrainability)):
                  (300 - (i.Weight * 100 / serachSize) + (i.Height * 100 / searchMass) + (i.Trainability * 100 / searchTrainability))
                 ).Take(5).ToList();

            var dogList = dogDbList.Select(i => new Dog()
            {
                Weight = i.Weight,
                Height = i.Height,
                Trainability = i.Trainability,
                MainRod1Name = i.Name,
                MainRod2Name = i.Name,
            }).ToList();

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

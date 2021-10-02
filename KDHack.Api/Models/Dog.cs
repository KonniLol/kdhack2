using System;

namespace KDHack.Api.Models
{
    public class Dog
    {
        public double Height { get; set; }

        public double Weight { get; set; }

        public double Trainability { get; set; }

        public string MainRod1Name { get; set; }
        public string MainRod2Name {  get; set; }

        public Dog Rod1 { get; set; }
        public Dog Rod2 {  get; set; }

        public static Dog operator +(Dog d1, Dog d2)
        {
            var t = Math.Round((d1.Trainability + d2.Trainability) / 2, mode: MidpointRounding.AwayFromZero);
           return new()
            {
                Height = (d1.Height + d2.Height) / 2,
                Weight = (d1.Weight + d2.Weight) / 2,
                Trainability = t,
                Rod1 = new() { Height = d1.Height, Weight = d1.Weight, Trainability = d1.Trainability, Rod1 = d1.Rod1, Rod2 = d1.Rod2 },
                Rod2 = new() { Height = d2.Height, Weight = d2.Weight, Trainability = d2.Trainability, Rod1 = d2.Rod1, Rod2 = d2.Rod2 },
            };
        }
    }
}

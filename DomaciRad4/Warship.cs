using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DomaciRad4
{
    public sealed class Warship : Vehicle, ISwimmable
    {
        public int Distance { get; set; }

        public Warship(Guid id, int weight, int averagespeed, int fuelconsumption, int capacity, int distance)
                : base(id, weight, averagespeed, fuelconsumption, capacity)
        {
            Id = id;
            Weight = 100000;
            AverageSpeed = 65;
            Capacity = 50;
            FuelConsumption = 200;
            Distance = distance;
        }

        public override string ToString()
        {
            return $" ID: {Id} \n Tezina vozila:{Weight} \n Prosjecna brzina vozila: {AverageSpeed} tona \n Prosjecna potrosnja: {FuelConsumption} l/100 km \n Max. kapacitet: {Capacity}";
        }

        public void Swim(int Distance)
        {
            int TripUntilFail;
            int NumberOfFails;
            Random rnd = new Random();

            TripUntilFail = (int)(AverageSpeed * 0.167);
            NumberOfFails = Distance / TripUntilFail;

            for (int i = 0; i < NumberOfFails; i++)
            {
                int Maybe = rnd.Next(0, 101);
                if (Maybe < 50)
                {
                    Distance = Distance + 3;
                }
            }
        }
    }
}

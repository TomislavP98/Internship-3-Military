using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DomaciRad4
{
    public sealed class Tank : Vehicle, IDriveable
    {
        public int Distance { get; set; }

        public Tank(Guid id, int weight, int averagespeed, int fuelconsumption, int capacity, int distance)
            :base(id, weight, averagespeed, fuelconsumption, capacity)
        {
            Id = id;
            Weight = weight;
            AverageSpeed = averagespeed;
            Capacity = capacity;
            FuelConsumption = fuelconsumption;
            Distance = distance;
        }

        public override string ToString()
        {
            return $" ID: {Id} \n Tezina vozila:{Weight} tona \n Prosjecna brzina vozila: {AverageSpeed} \n Prosjecna potrosnja: {FuelConsumption} l/100 km \n Max. kapacitet: {Capacity}";
        }

       public void Move(int Distance)
        {
            Random rnd = new Random();
            int NumberOfIterations;

            NumberOfIterations = Distance / 10;
            for (int i = 0; i < NumberOfIterations; i++)
            {
                int Maybe = rnd.Next(0, 101);
                if (Maybe < 30)
                {
                    Distance = Distance + 5;
                }
            }
        }
    }
}

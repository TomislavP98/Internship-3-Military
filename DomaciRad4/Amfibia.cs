using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DomaciRad4
{
    public sealed class Amfibia : Vehicle, ISwimmable, IDriveable
    {

        
            public int DistanceWater { get; set; } 
            public int DistanceLand { get; set; }

            public Amfibia(Guid id, int weight, int averagespeed, int fuelconsumption, int capacity, int distanceland, int distancewater)
                : base(id, weight, averagespeed, fuelconsumption, capacity)
            {
                Id = id;
                Weight = 30;
                AverageSpeed = 30;
                Capacity = 20;
                FuelConsumption = 70;
                DistanceLand = distanceland;
                DistanceWater = distancewater;
            }
        public override string ToString()
        {
            return $" ID: {Id} \n Tezina vozila:{Weight} tona \n Prosjecna brzina vozila: {AverageSpeed} km/h \n Prosjecna potrosnja: {FuelConsumption} l/100 km \n Max. kapacitet: {Capacity}";
        }

        

        public void  Move(int Distance)
        {   
            Random rnd = new Random();
            int NumberOfIterations;

            NumberOfIterations = Distance / 10;
            for (int i = 0; i < NumberOfIterations; i++)
            {
                int Maybe = rnd.Next(0, 101);
                if(Maybe < 30)
                {
                    Distance = Distance + 5;
                }
            }
        }

        public  void Swim(int Distance)
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




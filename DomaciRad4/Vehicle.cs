using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DomaciRad4
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public int AverageSpeed { get; set; }
        public int FuelConsumption { get; set; }
        public int Capacity { get; set; }

        public Vehicle(Guid id, int weight, int averagespeed, int fuelconsumption, int capacity)
        {
            Id = id;
            Weight = weight;
            AverageSpeed = averagespeed;
            FuelConsumption = fuelconsumption;
            Capacity = capacity;

        }

        public override string ToString()
        {
            return $" ID: {Id} \n Tezina vozila:{Weight} tona \n Prosjecna brzina vozila: {AverageSpeed} \n Prosjecna potrosnja: {FuelConsumption} l/100 km \n Max. kapacitet: {Capacity}";
        }

    }
}

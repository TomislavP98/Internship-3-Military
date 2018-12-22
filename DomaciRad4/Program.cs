using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DomaciRad4
{
    class Program
    {
        static void Main(string[] args)
        {
            int TankDistance;
            int WarshipDistance;
            int[] AmfibiaDistance = new int[2];
            int NumberOfSoliders;
            int Weight, AverageSpeed, Capacity, FuelConsumption, Distance, DistanceWater, DistanceLand;
            int NumWarship, NumTank, NumAmfibia, RestWarship, RestTank, RestAmfibia;
            int ConsumptionTank, ConsumptionAmfibia, ConsumptionWarship;
            Guid IdTank, IdWarship, IdAmfibia;


            Console.WriteLine("Unos udaljenosti od tocke A do B");

            Console.WriteLine("Udaljenost za ratni broj:");
            WarshipDistance = int.Parse(Console.ReadLine());

            Console.WriteLine("Udaljenost za tenk:");
            TankDistance = int.Parse(Console.ReadLine());

            Console.WriteLine("Udaljenost za amfibiju(kopnena):");
            AmfibiaDistance[0] = int.Parse(Console.ReadLine());

            Console.WriteLine("Udaljenost za amfibiju(morska):");
            AmfibiaDistance[1] = int.Parse(Console.ReadLine());

            if ((AmfibiaDistance[0] + AmfibiaDistance[1]) >= TankDistance || (AmfibiaDistance[0] + AmfibiaDistance[1]) >= WarshipDistance)
            {
                Console.WriteLine("Unesene udaljenosti us krive, udaljenost koju prelazi amfibia mora biti najmanja!");
                Environment.Exit(0);
            }

            Console.WriteLine("Unesite broj vojnika koji treba prevesti:");
            NumberOfSoliders = int.Parse(Console.ReadLine());

            var tank = new Tank(IdTank = Guid.NewGuid(), Weight = 67, AverageSpeed = 67, Capacity = 6, FuelConsumption = 30, Distance = TankDistance);
            var ship = new Warship(IdWarship = Guid.NewGuid(), Weight = 100000, AverageSpeed = 65, Capacity = 50, FuelConsumption = 200, Distance = WarshipDistance);
            var amfibia = new Amfibia(IdAmfibia = Guid.NewGuid(), Weight = 30, AverageSpeed = 30, Capacity = 20, FuelConsumption = 70, DistanceLand = AmfibiaDistance[0], DistanceWater = AmfibiaDistance[1]);

            IDriveable tnk = tank;
            IDriveable amfd = amfibia;
            ISwimmable wars = ship;
            ISwimmable amfs = amfibia;

            tnk.Move(TankDistance);
            wars.Swim(WarshipDistance);
            amfd.Move(AmfibiaDistance[0]);
            amfs.Swim(AmfibiaDistance[1]);

            NumWarship = NumberOfSoliders / ship.Capacity + 1;
            NumTank = NumberOfSoliders / tank.Capacity + 1;
            NumAmfibia = NumberOfSoliders / amfibia.Capacity + 1;

            RestWarship = NumberOfSoliders % ship.Capacity;
            RestTank = NumberOfSoliders % tank.Capacity;
            RestAmfibia = NumberOfSoliders % amfibia.Capacity;

            if(RestWarship == 0)
            {
                NumWarship--;
            }

            if(RestTank == 0)
            {
                NumTank--;
            }
            if (RestAmfibia == 0)
            {
                NumAmfibia--;
            }

            ConsumptionWarship = WarshipDistance * 2 * NumWarship;
            ConsumptionTank = (int)(TankDistance * 0.3 * NumTank);
            ConsumptionAmfibia = (int)((AmfibiaDistance[0] + AmfibiaDistance[1])* 0.7 * NumAmfibia);

            Console.WriteLine("\nGenerale, imate 3 opcije za prijevoz vojnika\n");
            Console.WriteLine("Amfibijsko vozilo:");
            Console.WriteLine(amfibia);
            Console.WriteLine($" Broj voznja:{NumAmfibia}\nBroj vojnika na zadnjoj voznji:{RestAmfibia}\n Potrebna kolicina goriva:{ConsumptionAmfibia} litara");
            Console.WriteLine("\n");
            Console.WriteLine("Ratni brod:");
            Console.WriteLine(ship);
            Console.WriteLine($" Broj voznja:{NumWarship}\nBroj vojnika na zadnjoj voznji:{RestWarship}\n Potrebna kolicina goriva:{ConsumptionWarship} litara");
            Console.WriteLine("\n");
            Console.WriteLine("Tenk:");
            Console.WriteLine(tank);
            Console.WriteLine($" Broj voznja:{NumTank}\nBroj vojnika na zadnjoj voznji:{RestTank}\n Potrebna kolicina goriva:{ConsumptionTank} litara");
            Console.WriteLine("\n");


            

            if ((TankDistance * 30) <= (WarshipDistance * 200) && (TankDistance * 30) < ((AmfibiaDistance[0] + AmfibiaDistance[1]) * 70))
            {
                Console.WriteLine("Tenk je najisplativija opcija!\n");
            }
            else if (((WarshipDistance * 200) < (TankDistance * 30)) && ((AmfibiaDistance[0] + AmfibiaDistance[1]) * 70) > (WarshipDistance * 200))
            {
                Console.WriteLine("Ratni brod je najisplativija opcija!\n");
            } 
            else
            {
                Console.WriteLine("Najbolja opcija je amfibijsko vozilo!\n");
            }
          
        }
    }
}
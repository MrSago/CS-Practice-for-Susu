
using System;
using System.Collections.Generic;

namespace lab3
{
    class AppMain
    {
        static void Main()
        {
            Airline airline = new();

            List<string> crew1 = new()
            {
                "Petya",
                "Vasya"
            };
            List<string> crew2 = new()
            {
                "Sashok",
                "Gorshok"
            };

            airline.Add(new AirPass(AirplaneType.AirbusA310, "RA-001", 120, crew1));
            airline.Add(new AirCargo(AirplaneType.Boeing737, "RA-002", 4000, crew2));
            airline.Add(new AirPass(AirplaneType.Boeing747, "RA-003", 50, crew1));

            airline.ToXml("res.xml");
            
            try
            {
                Airline airlineNew = Airline.FromXml("res.xml");

                foreach (Airplane plane in airlineNew.Airplanes)
                {
                    Console.WriteLine($"Plane: {plane.Type}, {plane.Number}, {plane.Weight} kg");
                    foreach (string member in plane.Crew)
                    {
                        Console.Write($"{member} ");
                    }
                    Console.Write('\n');
                }
                Console.WriteLine($"Total Price: {airlineNew.SumWeight}");
                Console.WriteLine($"Avarage Price: {airlineNew.AvarageWeight}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}


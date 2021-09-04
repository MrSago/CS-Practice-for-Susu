
using System;
using System.Collections.Generic;

namespace lab3
{
    class AppMain
    {
        static Airline airline = new();

        static void SortPrint()
        {
            airline.SortByWeight();
            foreach (Airplane plane in airline.Airplanes)
            {
                Console.WriteLine($"\n{plane.Type} | {plane.Number} | {plane.Weight}");
                Console.WriteLine("Crew list:");
                foreach (string member in plane.Crew)
                {
                    Console.WriteLine($"{member}");
                }
            }
        }

        static void FirstSixPlanes()
        {
            airline.SortByWeight();
            List<Airplane> planes = airline.Airplanes as List<Airplane>;
            for (int i = 0; i < 6 && i < planes.Count; ++i)
            {
                Console.WriteLine($"\n{planes[i].Type} | {planes[i].Number} | {planes[i].Weight}");
                Console.WriteLine("Crew list:");
                foreach (string member in planes[i].Crew)
                {
                    Console.WriteLine($"{member}");
                }
            }
        }

        static void LastTwoPlanesNum()
        {
            airline.SortByWeight();
            List<Airplane> planes = airline.Airplanes as List<Airplane>;
            for (int i = planes.Count - 1; i > planes.Count - 3 && i > 0; --i)
            {
                Console.WriteLine($"\nNumber: {planes[i].Number}");
            }
        }

        static void Main()
        {
            string fileNameXML = "result.xml";

            List<string> crew1 = new()
            {
                "Petya",
                "Vasya"
            };
            List<string> crew2 = new()
            {
                "Sashok",
                "Pashok"
            };
            List<string> crew3 = new()
            {
                "Artyom",
                "Anton"
            };

            airline.Add(new AirPass(AirplaneType.AirbusA310, "RA-001", 120, crew1));
            airline.Add(new AirCargo(AirplaneType.Boeing737, "RA-003", 4000, crew2));
            airline.Add(new AirCargo(AirplaneType.Boeing747, "RA-006", 4000, crew3));
            airline.Add(new AirCargo(AirplaneType.Boeing737, "RA-007", 9000, crew1));
            airline.Add(new AirPass(AirplaneType.AirbusA320, "RA-008", 500, crew3));
            airline.Add(new AirCargo(AirplaneType.Boeing747, "RA-009", 5555, crew2));
            airline.Add(new AirCargo(AirplaneType.Boeing737, "RA-010", 4444, crew1));
            airline.Add(new AirPass(AirplaneType.AirbusA320, "RA-005", 200, crew1));
            airline.Add(new AirPass(AirplaneType.Boeing747, "RA-002", 150, crew2));
            airline.Add(new AirPass(AirplaneType.Boeing737, "RA-004", 450, crew3));

            bool cont = true;
            while (cont)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1.Упорядочить и вывести данные авиалайнеров");
                Console.WriteLine("2.Вывести первые 6 бортов");
                Console.WriteLine("3.Последние 2 номера рейса");
                Console.WriteLine("4.Средний взлетный вес");
                Console.WriteLine("5.Запись в XML");
                Console.WriteLine("6.Чтение из XML");
                Console.WriteLine("0.Выход");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        SortPrint();
                    break;

                    case ConsoleKey.D2:
                        FirstSixPlanes();
                    break;

                    case ConsoleKey.D3:
                        LastTwoPlanesNum();
                    break;

                    case ConsoleKey.D4:
                        Console.WriteLine($"\nAvarage Weight: {airline.AvarageWeight}");
                    break;

                    case ConsoleKey.D5:
                        airline.ToXml(fileNameXML);
                    break;

                    case ConsoleKey.D6:
                        try
                        {
                            airline = Airline.FromXml(fileNameXML);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"\n{e.Message}");
                        }
                    break;

                    case ConsoleKey.D0:
                        cont = false;
                    break;

                    default:
                        Console.WriteLine("\nUnknown option!");
                    break;
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Menu
    {
        private readonly DictionaryMethods<ConsoleKey> _method;
        private bool _continueMenu = true;

        public DictionaryMethods<ConsoleKey> Method => _method;
        public bool ContinueMenu => _continueMenu;

        private Airline airline = new();
        private const string fileNameXML = "result.xml";

        public Menu()
        {
            _method = new(new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.D1, SortPrint },
                { ConsoleKey.D2, FirstSixPlanes },
                { ConsoleKey.D3, LastTwoPlanesNum },
                { ConsoleKey.D4, PrintAvarageWeight },
                { ConsoleKey.D5, SaveToXml },
                { ConsoleKey.D6, LoadFromXml },
                { ConsoleKey.D0, ExitMenu }
            });

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
        }

        // Key1
        private void SortPrint()
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

        // Key2
        private void FirstSixPlanes()
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

        // Key3
        private void LastTwoPlanesNum()
        {
            airline.SortByWeight();
            List<Airplane> planes = airline.Airplanes as List<Airplane>;
            for (int i = planes.Count - 1; i > planes.Count - 3 && i > 0; --i)
            {
                Console.WriteLine($"\nNumber: {planes[i].Number}");
            }
        }

        // Key4
        private void PrintAvarageWeight()
        {
            Console.WriteLine($"\nAvarage Weight: {airline.AvarageWeight}");
        }

        // Key5
        private void SaveToXml()
        {
            airline.ToXml(fileNameXML);
        }

        // Key6
        private void LoadFromXml()
        {
            try
            {
                airline = Airline.FromXml(fileNameXML);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}");
            }
        }

        // Key0
        private void ExitMenu()
        {
            _continueMenu = false;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace lab3
{
    class Airline
    {
        private readonly List<Airplane> _planes = new();

        public void Add(Airplane plane)
        {
            if (plane == null || plane.Type == AirplaneType.None || string.IsNullOrEmpty(plane.Number) || !plane.Crew.Any())
            {
                throw new ArgumentException(null, nameof(plane));
            }
            _planes.Add(plane);
        }

        public IEnumerable<Airplane> Airplanes
        {
            get
            {
                return _planes;
            }
        }
        public double SumWeight
        {
            get
            {
                double price = 0;
                foreach(var plane in _planes)
                {
                    price += plane.Weight;
                }
                return price;
            }
        }
        public double AvarageWeight
        {
            get
            {
                return SumWeight / _planes.Count;
            }
        }


        private class ByWeightComparer : IComparer<Airplane>
        {
            public int Compare(Airplane x, Airplane y)
            {
                int val = x.Weight.CompareTo(y.Weight);
                return val == 0 ? x.Number.CompareTo(y.Number) : val;
            }
        }
        public void SortByWeight()
        {
            _planes.Sort(new ByWeightComparer());
        }

        public void ToXml(string fileName)
        {
            XmlSerializer serializer = new(typeof(List<Airplane>));

            using FileStream stream = File.OpenWrite(fileName);
            serializer.Serialize(stream, _planes);
            stream.Flush();
        }

        public static Airline FromXml(string fileName)
        {
            Airline airline = new();
            XmlSerializer serializer = new(typeof(List<Airplane>));

            using FileStream stream = File.OpenRead(fileName);
            if (serializer.Deserialize(stream) is IEnumerable<Airplane> planes)
            {
                airline._planes.AddRange(planes);
            }

            return airline;
        }
    }
}


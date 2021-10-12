
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
        private double _sumWeight = 0.0;
        private double _avarageWeight = 0.0;

        private double _calcWieght()
        {
            double weights = 0;
            foreach (var plane in _planes)
            {
                weights += plane.Weight;
            }
            return weights;
        }

        public void Add(Airplane plane)
        {
            if (plane == null || plane.Type == AirplaneType.None || string.IsNullOrEmpty(plane.NumberRace) || !plane.Crew.Any())
            {
                throw new ArgumentException(null, nameof(plane));
            }
            _planes.Add(plane);
            _sumWeight = _calcWieght();
            _avarageWeight = _planes.Count > 0 ? _sumWeight / _planes.Count : 0.0;
        }

        public IEnumerable<Airplane> Airplanes => _planes;

        public double SumWeight => _sumWeight;
        public double AvarageWeight => _avarageWeight;

        private class ByWeightComparer : IComparer<Airplane>
        {
            public int Compare(Airplane x, Airplane y)
            {
                int val = x.Weight.CompareTo(y.Weight);
                return val == 0 ? x.NumberRace.CompareTo(y.NumberRace) : val;
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


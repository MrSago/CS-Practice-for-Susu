
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace lab3
{
    public enum AirplaneType
    {
        None,
        AirbusA310,
        AirbusA320,
        Boeing737,
        Boeing747
    }

    [XmlInclude(typeof(AirPass))]
    [XmlInclude(typeof(AirCargo))]
    public abstract class Airplane
    {
        private static readonly Dictionary<AirplaneType, double> _emptyWeights = new()
        {
            [AirplaneType.AirbusA310] = 82000,
            [AirplaneType.AirbusA320] = 36750,
            [AirplaneType.Boeing737] = 26400,
            [AirplaneType.Boeing747] = 186000
        };

        protected AirplaneType _airplaneType;
        protected double _emptyWeight;
        protected string _number;
        protected List<string> _crew = new();

        protected Airplane() { }

        public Airplane(AirplaneType type, string number, List<string> crew)
        {
            _airplaneType = type;
            _emptyWeight = _emptyWeights[type];
            _number = number;
            _crew = crew.ToList();
        }

        public AirplaneType Type
        {
            get
            {
                return _airplaneType;
            }
            set
            {
                _airplaneType = value;
                _emptyWeight = _emptyWeights[value];
            }
        }
        public string Number { get => _number; set => _number = value; }
        public List<string> Crew { get => _crew; set => _crew = value; }
        public abstract double Weight { get; }
    }

    public class AirPass : Airplane
    {
        private readonly double K = 62;
        private int _countSeats;

        public AirPass() {}

        public AirPass(AirplaneType type, string number, int countSeats, List<string> crew) :
            base(type, number, crew)
        {
            _countSeats = countSeats;
        }

        public int CountSeats { get => _countSeats; set => _countSeats = value; }
        public override double Weight
        {
            get
            {
                return _countSeats * K + _emptyWeight;
            }
        }
    }

    public class AirCargo : Airplane
    {
        private double _cargoWeight;

        public AirCargo() { }

        public AirCargo(AirplaneType type, string number, double weight, List<string> crew) :
            base(type, number, crew)
        {
            _cargoWeight = weight;
        }

        public double CargoWeight { get => _cargoWeight; set => _cargoWeight = value; }
        public override double Weight
        {   
            get
            {
                return _cargoWeight + _emptyWeight;
            }
        }
    }
}


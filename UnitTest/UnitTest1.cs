using BAL.Service;
using Core.Model;
using DAL.DataAccess;
using DAL.DBContext;
using DAL.IDataAccess;
using Newtonsoft.Json.Linq;

namespace UnitTest
{
    public class Tests
    {
        private IUnitConverstionService _unitConverstionService;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            if (_unitConverstionService == null)
            {
                _unitConverstionService = new UnitConverstionService(new I);
            }

            string fromUnit = "Celsius";
            string toUnit = "Fahrenheit";
            double value = 50;
            TempratureUnit tempratureUnit = new TempratureUnit();
            tempratureUnit.FromUnit = fromUnit;
            tempratureUnit.ToUnit = toUnit;
            tempratureUnit.Value = value;

            var result = _unitConverstionService.ConvertByUnit(tempratureUnit);

            Assert.Pass(result);
        }
    }
}
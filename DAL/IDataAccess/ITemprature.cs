using Core.Model;

namespace DAL.IDataAccess
{
    public interface ITemprature
    {
        IEnumerable<TempUnitConversion> GetAllRate();
        TempUnitConversion GetConvertionByRate(string Unit);
    }
}

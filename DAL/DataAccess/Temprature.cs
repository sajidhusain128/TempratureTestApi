using Core.Model;
using DAL.DBContext;
using DAL.IDataAccess;

namespace DAL.DataAccess
{
    public class Temprature : ITemprature
    {
        private readonly ApplicationDbContext _dbContext;

        public Temprature(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        /// <summary>
        /// Get All Temprature Converstion Rate
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TempUnitConversion> GetAllRate()
        {
            try
            {
                return _dbContext.TempUnitConversion.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Temprature Converstion Rate By Unit Name
        /// </summary>
        /// <param name="Unit"></param>
        /// <returns></returns>
        public TempUnitConversion GetConvertionByRate(string Unit)
        {
            try
            {
                return _dbContext.TempUnitConversion.Where(x => x.Unit == Unit).FirstOrDefault();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using BAL.CommonFunctions;
using Core.Model;
using DAL.IDataAccess;

namespace BAL.Service
{
    public class UnitConverstionService : IUnitConverstionService
    {
        private readonly ITemprature _temprature;

        public UnitConverstionService(ITemprature temprature)
        {
            _temprature = temprature;
        }

        /// <summary>
        /// Get All Temprature Converstion Rate 
        /// </summary>
        /// <param name="tempratureUnit"></param>
        /// <returns></returns>
        public string ConvertByUnit(TempratureUnit tempratureUnit)
        {
            try
            {
                string Result = "";

                TempUnitConversion tempUnitConversion = _temprature.GetConvertionByRate(tempratureUnit.FromUnit);

                if (tempUnitConversion != null)
                {
                    if (tempUnitConversion.Unit == "Celsius")
                    {
                        if (tempratureUnit.FromUnit == "Celsius" && tempratureUnit.ToUnit == "Fahrenheit")
                        {
                            string replacedValue = tempUnitConversion.ToFahrenheit.Replace("C", tempratureUnit.Value.ToString());

                            double F = Math.Round(StringToFormula.Eval(replacedValue), 2);

                            Result = String.Format("{0}°C = " + "{1}°F", tempratureUnit.Value, F);
                        }
                        else if (tempratureUnit.FromUnit == "Celsius" && tempratureUnit.ToUnit == "Kelvin")
                        {
                            string replacedValue = tempUnitConversion.ToKelvin.Replace("C", tempratureUnit.Value.ToString());

                            double K = Math.Round(StringToFormula.Eval(replacedValue), 2);

                            Result = String.Format("{0}°C = " + "{1} K", tempratureUnit.Value, K);
                        }
                    }
                    else if (tempUnitConversion.Unit == "Fahrenheit")
                    {
                        if (tempratureUnit.FromUnit == "Fahrenheit" && tempratureUnit.ToUnit == "Kelvin")
                        {
                            string replacedValue = tempUnitConversion.ToKelvin.Replace("F", tempratureUnit.Value.ToString());

                            double K = Math.Round(StringToFormula.Eval(replacedValue), 2);

                            Result = String.Format("{0}°F = " + "{1} K", tempratureUnit.Value, K);
                        }
                        else if (tempratureUnit.FromUnit == "Fahrenheit" && tempratureUnit.ToUnit == "Celsius")
                        {
                            string replacedValue = tempUnitConversion.ToCelsius.Replace("F", tempratureUnit.Value.ToString());

                            double C = Math.Round(StringToFormula.Eval(replacedValue), 2);

                            Result = String.Format("{0}°F = " + "{1}°C", tempratureUnit.Value, C);
                        }
                    }
                    else if (tempUnitConversion.Unit == "Kelvin")
                    {
                        if (tempratureUnit.FromUnit == "Kelvin" && tempratureUnit.ToUnit == "Celsius")
                        {
                            string replacedValue = tempUnitConversion.ToCelsius.Replace("K", tempratureUnit.Value.ToString());

                            double C = Math.Round(StringToFormula.Eval(replacedValue), 2);

                            Result = String.Format("{0} K = " + "{1}°C", tempratureUnit.Value, C);
                        }
                        else if (tempratureUnit.FromUnit == "Kelvin" && tempratureUnit.ToUnit == "Fahrenheit")
                        {
                            string replacedValue = tempUnitConversion.ToFahrenheit.Replace("K", tempratureUnit.Value.ToString());

                            double F = Math.Round(StringToFormula.Eval(replacedValue), 2);

                            Result = String.Format("{0} K = " + "{1}°F", tempratureUnit.Value, F);
                        }
                    }
                }

                return Result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        ////GET All Perso Details   
        //public IEnumerable<Person> GetAllPersons()
        //{
        //    try
        //    {
        //        return _person.GetAll().ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        ////Get Person by Person Name  
        //public Person GetPersonByUserName(string UserName)
        //{
        //    return _person.GetAll().Where(x => x.EmailID == UserName).FirstOrDefault();
        //}
        ////Add Person  
        //public async Task<Person> AddPerson(Person Person)
        //{
        //    return await _person.Create(Person);
        //}
        ////Delete Person   
        //public bool DeletePerson(string UserEmail)
        //{

        //    try
        //    {
        //        var DataList = _person.GetAll().Where(x => x.EmailID == UserEmail).ToList();
        //        foreach (var item in DataList)
        //        {
        //            _person.Delete(item);
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}
        ////Update Person Details  
        //public bool UpdatePerson(Person person)
        //{
        //    try
        //    {
        //        var personUpdate = _person.GetById(person.ID);

        //        personUpdate.FirstName = !string.IsNullOrEmpty(person.FirstName) ? person.FirstName : personUpdate.FirstName;
        //        personUpdate.LastName = !string.IsNullOrEmpty(person.LastName) ? person.LastName : personUpdate.LastName;
        //        personUpdate.EmailID = !string.IsNullOrEmpty(person.EmailID) ? person.EmailID : personUpdate.EmailID;
        //        personUpdate.Address = !string.IsNullOrEmpty(person.Address) ? person.Address : personUpdate.Address;
        //        personUpdate.Age = person.Age != 0 ? person.Age : personUpdate.Age;
        //        personUpdate.ModifiedOn = DateTime.Now;
        //        _person.Update(personUpdate);

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}

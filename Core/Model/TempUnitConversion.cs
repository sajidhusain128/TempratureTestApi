using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model
{
    [Table("TempUnitConversion", Schema = "dbo")]
    public class TempUnitConversion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Unit { get; set; }

        public string ToCelsius { get; set; }

        public string ToFahrenheit { get; set; }

        public string ToKelvin { get; set; }
    }
}

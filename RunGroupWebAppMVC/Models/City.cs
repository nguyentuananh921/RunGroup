using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroupWebAppMVC.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CityName { get; set; }
        public string StateCode { get; set; }
        public int Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Country { get; set; }
    }
}

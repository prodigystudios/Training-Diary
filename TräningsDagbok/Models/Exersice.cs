using System.ComponentModel.DataAnnotations;
namespace TräningsDagbok.Models
{
    public class Exersice
    {
        public int id { get; set; }
        [Display(Name = "Övning")]
        public string exersice { get; set; }
        [Display(Name = "Vikt/Distans")]
        public string weight { get; set; }
        [Display(Name = "Datum")]
        public string date { get; set; }
    }
}

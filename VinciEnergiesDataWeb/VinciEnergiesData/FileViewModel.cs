using System.ComponentModel.DataAnnotations;

namespace VinciEnergiesData
{
    public class FileViewModel
    {
        public List<string> Files { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a year.")]
        public string Year { get; set; } = "default";

    }
}

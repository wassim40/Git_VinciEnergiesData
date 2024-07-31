using System.ComponentModel.DataAnnotations;
using VinciEnergiesData.Enums;

namespace VinciEnergiesData.Models
{
    public class Dossier
    {
        [Key]
        public int Id { get; set; }
        public string codeSite { get; set; }
        [Display(Name = "Annee")]
        [RegularExpression(@"\d{4}", ErrorMessage = "Please enter a valid year (e.g., 2024).")]
        public string annee { get; set; }
        public string ville { get; set; }
        public FolderType folder { get; set; }
        public GenreFolder genre { get; set; }
            
    }
}

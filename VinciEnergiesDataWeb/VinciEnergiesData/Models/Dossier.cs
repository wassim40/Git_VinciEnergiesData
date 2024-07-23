using System.ComponentModel.DataAnnotations;
using VinciEnergiesData.Enums;

namespace VinciEnergiesData.Models
{
    public class Dossier
    {
        [Key]
        public int Id { get; set; }
        public string codeSite { get; set; }
        public GenreFolder genre { get; set; }
        public FolderType folder { get; set; }
    }
}

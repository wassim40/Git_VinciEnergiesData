using System.ComponentModel.DataAnnotations;

namespace VinciEnergiesData.Models
{
    public class Administrateur
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string AdminKey { get; set; }
        public string Admin0 { get; set; }
        public string AdminKey0 { get; set; }

    }
}

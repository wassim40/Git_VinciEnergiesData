using System.ComponentModel.DataAnnotations.Schema;

namespace VinciEnergiesData.Models
{
    public class Fichier
    {
        public int Id { get; set; }
        public string nom { get; set; }
        public string extension { get; set; }
        public string dossier { get; set; }
        public string annee { get; set; }
        public string ville { get; set; }
    }
}

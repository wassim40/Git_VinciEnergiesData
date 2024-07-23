using System.ComponentModel.DataAnnotations.Schema;

namespace VinciEnergiesData.Models
{
    public class Fichier
    {
        public int Id { get; set; }
        public int annee { get; set; }
        public string ville { get; set; }
        public int dossierId { get; set; }
        [ForeignKey("dossierId")]
        public virtual Dossier dossier { get; set; }


    }
}

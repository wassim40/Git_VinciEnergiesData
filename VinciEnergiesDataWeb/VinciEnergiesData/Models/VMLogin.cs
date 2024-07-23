namespace VinciEnergiesData.Models
{
    public class VMLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool KeepLoggedIn { get; set; }
        public string Administrateur { get; set; }
        public string AdminKey { get; set; }
    }
}

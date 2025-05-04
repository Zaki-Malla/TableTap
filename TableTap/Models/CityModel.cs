namespace TableTap.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual List<EstablishmentModel> Establishments { get; set; }
    }
}

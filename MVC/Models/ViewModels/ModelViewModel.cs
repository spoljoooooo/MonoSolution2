namespace MVC.Models.ViewModels
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMake VehicleMake { get; set; }
        public int VehicleMakeId { get; set; }
    }
}

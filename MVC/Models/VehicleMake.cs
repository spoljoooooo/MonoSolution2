﻿namespace MVC.Models
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
    }
}

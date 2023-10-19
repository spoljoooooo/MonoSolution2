using AutoMapper;
using MVC.Models.Requests;
using MVC.Models.ViewModels;

namespace MVC.Models
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<VehicleMake, CreateMake>();
            CreateMap<CreateMake, VehicleMake>();

            CreateMap<EditMake, VehicleMake>();
            CreateMap<VehicleMake, EditMake>();

            CreateMap<VehicleMake, MakeViewModel>();
            CreateMap<MakeViewModel, VehicleMake>();

            CreateMap<VehicleModel, CreateModel>();
            CreateMap<CreateModel, VehicleModel>();

            CreateMap<VehicleModel, EditModel>();
            CreateMap<EditModel, VehicleModel>();

            CreateMap<VehicleModel, ModelViewModel>();
            CreateMap<ModelViewModel, VehicleModel>();
        }
    }
}

using MVC.Models;

namespace MVC.Service
{
    public interface IServices
    {
        Task<List<VehicleMake>> AllMakes();
        Task<VehicleMake> MakeById(int? id);
        Task CreateMake(VehicleMake make);
        Task EditMake(VehicleMake make);
        Task DeleteMake(int id);
        Task<List<VehicleModel>> AllModels();
        Task<VehicleModel> ModelById(int? id);
        Task CreateModel(VehicleModel model);
        Task EditModel(VehicleModel model);
        Task DeleteModel(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Service
{
    public class Services : IServices
    {
        private readonly VehicleContext _context;
        public Services(VehicleContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleMake>> AllMakes()
        {
            return await _context.Makes.ToListAsync();
        }

        public async Task<VehicleMake> MakeById(int? id)
        {
            return await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateMake(VehicleMake make)
        {
            await _context.Makes.AddAsync(make);
            await _context.SaveChangesAsync();
        }

        public async Task EditMake(VehicleMake make)
        {
            _context.Makes.Update(make);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMake(int id)
        {
            var make = await MakeById(id);
            _context.Makes.Remove(make);
            await _context.SaveChangesAsync();
        }

        public async Task<List<VehicleModel>> AllModels()
        {
            var models = await _context.Models.Include(m => m.VehicleMake).ToListAsync();
            return models;
        }

        public async Task<VehicleModel> ModelById(int? id)
        {
            var model = await _context.Models.Include(v => v.VehicleMake).FirstOrDefaultAsync(m => m.Id == id);
            return model;
        }

        public async Task CreateModel(VehicleModel model)
        {
            await _context.Models.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task EditModel(VehicleModel model)
        {
            _context.Models.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteModel(int id)
        {
            var model = await ModelById(id);
            _context.Models.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}

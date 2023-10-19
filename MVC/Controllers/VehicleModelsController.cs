using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Models.Requests;
using MVC.Models.ViewModels;
using MVC.Service;

namespace MVC.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly IServices _services;
        private readonly IMapper _mapper;

        public VehicleModelsController(IServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index()
        {
            var models = await _services.AllModels();
            var modelsViewModel = _mapper.Map<IList<ModelViewModel>>(models);
            return View(modelsViewModel);
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _services.ModelById(id);

            if (model == null)
            {
                return NotFound();
            }

            var modelViewModel = _mapper.Map<ModelViewModel>(model);
            return View(modelViewModel);
        }

        // GET: VehicleModels/Create
        public async Task<IActionResult> Create()
        {
            var models = await _services.AllMakes();
            ViewData["VehicleMakeId"] = new SelectList(models, "Id", "Name");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Abrv,VehicleMakeId")] CreateModel model)
        {
            if (ModelState.IsValid)
            {
                _services.CreateModel(_mapper.Map<VehicleModel>(model));
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleMakeId"] = new SelectList(await _services.AllModels(), "Id", "Name", model.VehicleMakeId);
            var modelViewModel = _mapper.Map<ModelViewModel>(model);
            return View(modelViewModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _services.ModelById(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["VehicleMakeId"] = new SelectList(await _services.AllMakes(), "Id", "Name", model.VehicleMakeId);
            var modelViewModel = _mapper.Map<ModelViewModel>(model);
            return View(modelViewModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv,VehicleMakeId")] EditModel model)
        {
            if (ModelState.IsValid)
            {
                await _services.EditModel(_mapper.Map<VehicleModel>(model));
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleMakeId"] = new SelectList(await _services.AllMakes(), "Id", "Name", model.VehicleMakeId);
            var modelViewModel = _mapper.Map<ModelViewModel>(model);
            return View(modelViewModel);
        }
        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await _services.ModelById(id);
            if (model == null)
            {
                return NotFound();
            }

            var modelViewModel = _mapper.Map<ModelViewModel>(model);
            return View(modelViewModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteModel(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

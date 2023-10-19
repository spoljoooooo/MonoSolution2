using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Requests;
using MVC.Models.ViewModels;
using MVC.Service;

namespace MVC.Controllers
{
    public class VehicleMakesController : Controller
    {
        private readonly IServices _services;
        private readonly IMapper _mapper;

        public VehicleMakesController(IServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        // GET: VehicleMakes
        public async Task<IActionResult> Index()
        {
            var makes = await _services.AllMakes();
            var makesViewModel = _mapper.Map<IList<MakeViewModel>>(makes);
            return View(makesViewModel);
        }

        // GET: VehicleMakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var make = await _services.MakeById(id);
            if (make == null)
            {
                return NotFound();
            }

            var makeViewModel = _mapper.Map<MakeViewModel>(make);
            return View(makeViewModel);
        }

        // GET: VehicleMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Abrv")] CreateMake make)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateMake(_mapper.Map<VehicleMake>(make));
            }
            return RedirectToAction("Index");
        }

        // GET: VehicleMakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var make = await _services.MakeById(id);
            if (make == null)
            {
                return NotFound();
            }
            var makeViewModel = _mapper.Map<MakeViewModel>(make);
            return View(makeViewModel);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abrv")] EditMake make)
        {
            if (ModelState.IsValid)
            {
                await _services.EditMake(_mapper.Map<VehicleMake>(make));
            }
            else
            {
                var makeViewModel = _mapper.Map<MakeViewModel>(make);
                return View(makeViewModel);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: VehicleMakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _services.MakeById(id);

            if (make == null)
            {
                return NotFound();
            }

            var makeViewModel = _mapper.Map<MakeViewModel>(make);
            return View(makeViewModel);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteMake(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

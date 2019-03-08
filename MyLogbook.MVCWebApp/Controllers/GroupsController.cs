using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyLogbook.Repositories;
using Microsoft.EntityFrameworkCore;
using MyLogbook.AppContext;
using MyLogbook.Entities;

namespace MyLogbook.MVCWebApp.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupRepository _repository;

        public GroupsController(IGroupRepository context)
        {
            _repository = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return View(await _repository.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _repository.GetItemAsync(id.Value);

            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] Group group)
        {
            if (ModelState.IsValid)
            {
                group.Id = Guid.NewGuid();
				await _repository.AddItemAsync(group);

                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _repository.GetItemAsync(id.Value);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] Group group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				if (!await _repository.ChangeItemAsync(group))
				{
					return NotFound();
				}
				return RedirectToAction(nameof(Index));
			}
            return View(group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

			var group = await _repository.GetItemAsync(id.Value);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repository.DeleteItemAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

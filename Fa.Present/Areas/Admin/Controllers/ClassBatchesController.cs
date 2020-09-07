using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.Project.Model;

namespace Fa.Present.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassBatchesController : Controller
    {
        private readonly TMSContext _context;

        public ClassBatchesController(TMSContext context)
        {
            _context = context;
        }

        // GET: Admin/ClassBatches
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassBatches.ToListAsync());
        }

        // GET: Admin/ClassBatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classBatch = await _context.ClassBatches
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (classBatch == null)
            {
                return NotFound();
            }

            return View(classBatch);
        }

        // GET: Admin/ClassBatches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ClassBatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,ClassName,ClassCode,GroupMail,StartDate,EndDate,Location,DetailLocation,Status,Remarks,AuditTrail,isDeleted")] ClassBatch classBatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classBatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classBatch);
        }

        // GET: Admin/ClassBatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classBatch = await _context.ClassBatches.FindAsync(id);
            if (classBatch == null)
            {
                return NotFound();
            }
            return View(classBatch);
        }

        // POST: Admin/ClassBatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,ClassName,ClassCode,GroupMail,StartDate,EndDate,Location,DetailLocation,Status,Remarks,AuditTrail,isDeleted")] ClassBatch classBatch)
        {
            if (id != classBatch.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classBatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassBatchExists(classBatch.ClassId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classBatch);
        }

        // GET: Admin/ClassBatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classBatch = await _context.ClassBatches
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (classBatch == null)
            {
                return NotFound();
            }

            return View(classBatch);
        }

        // POST: Admin/ClassBatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classBatch = await _context.ClassBatches.FindAsync(id);
            _context.ClassBatches.Remove(classBatch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassBatchExists(int id)
        {
            return _context.ClassBatches.Any(e => e.ClassId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlePonto.Data;
using ControlePonto.Models;

namespace ControlePonto.Controllers
{
    public class HorarioController : Controller
    {
        private readonly Contexto _context;

        public HorarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Horario
        public async Task<IActionResult> Index()
        {
            var contexto = _context.HorarioModel.Include(h => h.Funcionario);
            return View(await contexto.ToListAsync());
        }

        // GET: Horario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioModel = await _context.HorarioModel
                .Include(h => h.Funcionario)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horarioModel == null)
            {
                return NotFound();
            }

            return View(horarioModel);
        }

        // GET: Horario/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioID"] = new SelectList(_context.funcionario, "id", "id");
            return View();
        }

        // POST: Horario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorarioID,DiadaSemana,HoraInicio,HoraFim,TempodeDescanso,CargaHoraria,CargaHorariaSEmanal,FuncionarioID")] HorarioModel horarioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioID"] = new SelectList(_context.funcionario, "id", "id", horarioModel.FuncionarioID);
            return View(horarioModel);
        }

        // GET: Horario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioModel = await _context.HorarioModel.FindAsync(id);
            if (horarioModel == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioID"] = new SelectList(_context.funcionario, "id", "id", horarioModel.FuncionarioID);
            return View(horarioModel);
        }

        // POST: Horario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorarioID,DiadaSemana,HoraInicio,HoraFim,TempodeDescanso,CargaHoraria,CargaHorariaSEmanal,FuncionarioID")] HorarioModel horarioModel)
        {
            if (id != horarioModel.HorarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioModelExists(horarioModel.HorarioID))
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
            ViewData["FuncionarioID"] = new SelectList(_context.funcionario, "id", "id", horarioModel.FuncionarioID);
            return View(horarioModel);
        }

        // GET: Horario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioModel = await _context.HorarioModel
                .Include(h => h.Funcionario)
                .FirstOrDefaultAsync(m => m.HorarioID == id);
            if (horarioModel == null)
            {
                return NotFound();
            }

            return View(horarioModel);
        }

        // POST: Horario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horarioModel = await _context.HorarioModel.FindAsync(id);
            _context.HorarioModel.Remove(horarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioModelExists(int id)
        {
            return _context.HorarioModel.Any(e => e.HorarioID == id);
        }
    }
}

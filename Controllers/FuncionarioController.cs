using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlePonto.Data;
using ControlePonto.Models;
using ControlePonto.Helpers;

namespace ControlePonto.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly Contexto _context;

        public FuncionarioController(Contexto context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {   
            
            return View(await _context.funcionario.ToListAsync());
        }


        public ActionResult BuscarCEP(string cep)
        {
           

            var result = new AjaxActionResult();

            try
            {

                var resultcep = Cep.BuscarCEP(cep);

                result.bag = resultcep;
                result.isOk = true;

            }
            catch (Exception ex)
            {
                result.isOk = false;
                result.message = ex.Message;
            }

            return Json(result);

        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.funcionario
                .FirstOrDefaultAsync(m => m.id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
           

            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nome,CPF,Email,Telefone,Habilitacao,Categoria,LinguaEstrangeira,Estado,Cidade,CEP,Logradouro,Numero,Complemento,Cargo,SalarioProposto")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,Nome,CPF,Email,Telefone,Habilitacao,Categoria,LinguaEstrangeira,Estado,Cidade,CEP,Logradouro,Numero,Complemento,Cargo,SalarioProposto")] Funcionario funcionario)
        {
            if (id != funcionario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.id))
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
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.funcionario
                .FirstOrDefaultAsync(m => m.id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var funcionario = await _context.funcionario.FindAsync(id);
            _context.funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int? id)
        {
            return _context.funcionario.Any(e => e.id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDIMDIM.Models;

namespace WebDIMDIM.Controllers
{
    public class ContaBancariaController : Controller
    {
        private readonly Contexto _context;

        public ContaBancariaController(Contexto context)
        {
            _context = context;
        }

        // GET: ContaBancaria
        public async Task<IActionResult> Index()
        {
              return _context.ContaBancaria != null ? 
                          View(await _context.ContaBancaria.ToListAsync()) :
                          Problem("Entity set 'Contexto.ContaBancaria'  is null.");
        }

        // GET: ContaBancaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContaBancaria == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContaBancaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // GET: ContaBancaria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaBancaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Agencia,Conta,Saldo")] ContaBancaria contaBancaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contaBancaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaBancaria);
        }

        // GET: ContaBancaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContaBancaria == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContaBancaria.FindAsync(id);
            if (contaBancaria == null)
            {
                return NotFound();
            }
            return View(contaBancaria);
        }

        // POST: ContaBancaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Agencia,Conta,Saldo")] ContaBancaria contaBancaria)
        {
            if (id != contaBancaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contaBancaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaBancariaExists(contaBancaria.Id))
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
            return View(contaBancaria);
        }

        // GET: ContaBancaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContaBancaria == null)
            {
                return NotFound();
            }

            var contaBancaria = await _context.ContaBancaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contaBancaria == null)
            {
                return NotFound();
            }

            return View(contaBancaria);
        }

        // POST: ContaBancaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContaBancaria == null)
            {
                return Problem("Entity set 'Contexto.ContaBancaria'  is null.");
            }
            var contaBancaria = await _context.ContaBancaria.FindAsync(id);
            if (contaBancaria != null)
            {
                _context.ContaBancaria.Remove(contaBancaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaBancariaExists(int id)
        {
          return (_context.ContaBancaria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

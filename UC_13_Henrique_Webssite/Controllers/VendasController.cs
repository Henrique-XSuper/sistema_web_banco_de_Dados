using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UC_13_Henrique_Webssite.Data;
using UC_13_Henrique_Webssite.Models;

namespace UC_13_Henrique_Webssite.Controllers
{
    public class VendasController : Controller
    {
        private readonly UC_13_Henrique_WebssiteContext _context;

        public VendasController(UC_13_Henrique_WebssiteContext context)
        {
            _context = context;
        }

        // LISTA TODAS AS VENDAS
        public async Task<IActionResult> Index()
        {
            var vendas = _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor);
            return View(await vendas.ToListAsync());
        }

        // DETALHES DE UMA VENDA
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            if (venda == null) return NotFound();

            return View(venda);
        }

        // EDIÇÃO
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null) return NotFound();

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", venda.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorId", venda.VendedorId);
            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaId,Data,Parcelas,ClienteId,VendedorId")] Venda venda)
        {
            if (id != venda.VendaId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.VendaId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "ClienteId", venda.ClienteId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedor, "VendedorId", "VendedorId", venda.VendedorId);
            return View(venda);
        }

        // EXCLUSÃO
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var venda = await _context.Venda
                .Include(v => v.Cliente)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(m => m.VendaId == id);

            if (venda == null) return NotFound();

            return View(venda);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.VendaId == id);
        }
    }
}

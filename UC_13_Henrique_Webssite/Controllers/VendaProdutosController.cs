using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UC_13_Henrique_Webssite.Data;
using UC_13_Henrique_Webssite.Models;

namespace UC_13_Henrique_Webssite.Controllers
{
    public class VendaProdutosController : Controller
    {
        private readonly UC_13_Henrique_WebssiteContext _context;

        public VendaProdutosController(UC_13_Henrique_WebssiteContext context)
        {
            _context = context;
        }

        // ✅ AÇÃO DE COMPRA FUNCIONAL COM REDIRECIONAMENTO PARA DETALHES DA VENDA
        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(int produtoId)
        {
            var produto = await _context.Produto.FindAsync(produtoId);
            if (produto == null)
                return NotFound("Produto não encontrado.");

            int clienteId = 1;
            int vendedorId = 1;

            var clienteExiste = await _context.Cliente.AnyAsync(c => c.ClienteId == clienteId);
            var vendedorExiste = await _context.Vendedor.AnyAsync(v => v.VendedorId == vendedorId);

            if (!clienteExiste || !vendedorExiste)
                return NotFound("Cliente ou Vendedor não encontrado.");

            var novaVenda = new Venda
            {
                Data = DateTime.Now,
                Parcelas = 1,
                ClienteId = clienteId,
                VendedorId = vendedorId
            };

            _context.Venda.Add(novaVenda);
            await _context.SaveChangesAsync();

            var itemVenda = new VendaProdutos
            {
                VendaId = novaVenda.VendaId,
                ProdutoId = produtoId
            };

            _context.VendaProdutos.Add(itemVenda);
            await _context.SaveChangesAsync();

            TempData["Mensagem"] = "Compra realizada com sucesso!";
            return RedirectToAction("Details", "Vendas", new { id = novaVenda.VendaId });
        }

        // LISTAGEM
        public async Task<IActionResult> Index()
        {
            var contexto = _context.VendaProdutos
                .Include(v => v.Produto)
                .Include(v => v.Venda);
            return View(await contexto.ToListAsync());
        }

        // DETALHES
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var vendaProdutos = await _context.VendaProdutos
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendaProdutosId == id);

            if (vendaProdutos == null) return NotFound();

            return View(vendaProdutos);
        }

        // EDIÇÃO
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var vendaProdutos = await _context.VendaProdutos.FindAsync(id);
            if (vendaProdutos == null) return NotFound();

            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", vendaProdutos.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Venda, "VendaId", "VendaId", vendaProdutos.VendaId);
            return View(vendaProdutos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VendaProdutosId,VendaId,ProdutoId")] VendaProdutos vendaProdutos)
        {
            if (id != vendaProdutos.VendaProdutosId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaProdutos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaProdutosExists(vendaProdutos.VendaProdutosId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ProdutoId"] = new SelectList(_context.Produto, "ProdutoId", "Nome", vendaProdutos.ProdutoId);
            ViewData["VendaId"] = new SelectList(_context.Venda, "VendaId", "VendaId", vendaProdutos.VendaId);
            return View(vendaProdutos);
        }

        // EXCLUSÃO
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var vendaProdutos = await _context.VendaProdutos
                .Include(v => v.Produto)
                .Include(v => v.Venda)
                .FirstOrDefaultAsync(m => m.VendaProdutosId == id);

            if (vendaProdutos == null) return NotFound();

            return View(vendaProdutos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendaProdutos = await _context.VendaProdutos.FindAsync(id);
            if (vendaProdutos != null)
            {
                _context.VendaProdutos.Remove(vendaProdutos);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VendaProdutosExists(int id)
        {
            return _context.VendaProdutos.Any(e => e.VendaProdutosId == id);
        }
    }
}

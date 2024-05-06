using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;

namespace Agenda.Pages.Categorias
{
    public class EliminarModel : PageModel
    {
        private readonly ApplicationDBContext _contexto;
        
        public EliminarModel(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Categoria categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            categoria = await _contexto.Categoria.FindAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            
            
                var CategoriaDesdeDB = await _contexto.Categoria.FindAsync(categoria.Id);
                
                if(CategoriaDesdeDB == null)
                {
                    return NotFound();
                }

                _contexto.Categoria.Remove(CategoriaDesdeDB);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
        }
    }
}

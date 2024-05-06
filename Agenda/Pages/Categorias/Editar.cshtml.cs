using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Immutable;

namespace Agenda.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDBContext _contexto;
        
        public EditarModel(ApplicationDBContext contexto)
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
            if (ModelState.IsValid)
            {
                var CategoriaDesdeDB = await _contexto.Categoria.FindAsync(categoria.Id);
                CategoriaDesdeDB.Nombre = categoria.Nombre;
                CategoriaDesdeDB.FechaCreacion = categoria.FechaCreacion;

                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else 
            {
                return RedirectToPage();
            }
        }
    }
}

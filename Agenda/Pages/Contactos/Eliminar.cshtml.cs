using Agenda.Datos;
using Agenda.Modelos;
using Agenda.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class EliminarModel : PageModel
    {
        public readonly ApplicationDBContext _contexto;

        public EliminarModel(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearContactoVM contactoVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            contactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = await _contexto.Contacto.FindAsync(id)
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var contacto = await _contexto.Contacto.FindAsync(contactoVM.Contacto.id);
            if (contacto == null) 
            {
                return NotFound();
            }

            _contexto.Contacto.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}

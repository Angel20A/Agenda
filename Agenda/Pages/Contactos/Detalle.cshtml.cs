using Agenda.Datos;
using Agenda.Modelos;
using Agenda.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDBContext _contexto;

        public DetalleModel(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Contacto Contacto { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Contacto = await _contexto.Contacto.
                                Where(c => c.id == id).
                                Include(c => c.Categoria).
                                FirstOrDefaultAsync();
            return Page();
        }
    }
}

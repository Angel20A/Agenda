using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Agenda.Pages.Categorias
{
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDBContext _contexto;

        public DetalleModel(ApplicationDBContext contexto)
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
    }
}

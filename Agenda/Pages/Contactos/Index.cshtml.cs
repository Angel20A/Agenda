using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _contexto;

        public IndexModel(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Contacto> Contactos { get; set; }

        public async Task OnGet()
        {
            Contactos = await _contexto.Contacto.Include(c => c.Categoria).ToListAsync();
        }
    }
}

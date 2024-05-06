using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _contexto;

        public IndexModel(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Categoria> categorias { get; set; }

        public async Task OnGet()
        {
            categorias = await _contexto.Categoria.ToListAsync();
        }
    }
}

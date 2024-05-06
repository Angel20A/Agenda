using Agenda.Datos;
using Agenda.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Agenda.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDBContext _contexto;

        public CrearModel(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public Categoria categoria { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _contexto.Categoria.AddAsync(categoria);
                await _contexto.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

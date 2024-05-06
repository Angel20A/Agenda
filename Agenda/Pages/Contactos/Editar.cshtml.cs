using Agenda.Datos;
using Agenda.Modelos;
using Agenda.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Pages.Contactos
{
    public class EditarModel : PageModel
    {
        public readonly ApplicationDBContext _contexto;

        public EditarModel(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [BindProperty]
        public CrearContactoVM ContactoVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = await _contexto.Contacto.FindAsync(id)
            };
            
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var contactoDesdeDB = await _contexto.Contacto.FindAsync(ContactoVM.Contacto.id);
                contactoDesdeDB.Nombre = ContactoVM.Contacto.Nombre;
                contactoDesdeDB.Email = ContactoVM.Contacto.Email;
                contactoDesdeDB.Telefono = ContactoVM.Contacto.Telefono;
                contactoDesdeDB.CategoriaId = ContactoVM.Contacto.CategoriaId;
                contactoDesdeDB.FechaCreacion = ContactoVM.Contacto.FechaCreacion;
                
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

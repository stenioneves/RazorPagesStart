using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Appsx.Data;
using Appsx.Models;
using System.Threading.Tasks;

namespace Appsx.Pages{


public class CriarModel: PageModel
{
    private readonly ContatoDbContext _contexto;

    public CriarModel(ContatoDbContext contexto)
    {
        _contexto = contexto;
    }
    public IActionResult OnGet()
    {
        return Page();
    }
    [BindProperty]
    public Contato Contato {get; set;}

    public async Task<IActionResult> OnPostAsync()
    {
        if(!ModelState.IsValid)
        {
            return Page();
        }
        _contexto.Contatos.Add(Contato);
        await _contexto.SaveChangesAsync();
        return RedirectToPage("./Listar");
    }
}



}
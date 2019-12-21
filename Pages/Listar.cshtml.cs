using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Appsx.Data;
using Appsx.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Appsx.Pages{

public class ListarModel: PageModel
{
    private readonly ContatoDbContext _contexto;
    public ListarModel(ContatoDbContext contexto)
    {
        _contexto=contexto;
    }
    public IList<Contato> Contato {get; set;} 
    public async Task OnGetAsync()
    {
        Contato= await _contexto.Contatos.ToListAsync();
    }
    public async Task<IActionResult>OnPostDeleteAsync(int id)
    {
        var contato = await _contexto.Contatos.FindAsync(id);
        if(contato != null)
        {
            _contexto.Contatos.Remove(contato);
            await _contexto.SaveChangesAsync();
        }
        return RedirectToPage();
    }   
}








}
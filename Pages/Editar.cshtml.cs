using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Appsx.Data;
using Appsx.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace Appsx.Pages
{
    public class EditarModel: PageModel
    {
        private readonly ContatoDbContext _contexto;
        public EditarModel(ContatoDbContext contexto)
        {
            _contexto=contexto;
        }
        [BindProperty]
        public Contato Contato{ set; get;}
        
        public async Task<IActionResult>OnGetAsync(int id)
        {
            Contato= await _contexto.Contatos.FindAsync(id);
            if(Contato==null)
            {
                return RedirectToPage("./Listar");
            }
            return Page();
        }
        public async Task<IActionResult>OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _contexto.Attach(Contato).State= EntityState.Modified;
            try{
                await _contexto.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw new Exception($"Contato {Contato.Id} Não encontrado!");
            }
            return RedirectToPage("./Listar");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Appsx.Models;

namespace Appsx.Data{
 
  public class ContatoDbContext: DbContext{
     
     public ContatoDbContext(DbContextOptions options)
              :base(options)
              {

              }
     public DbSet<Contato> Contatos{get; set;}      

  }




}
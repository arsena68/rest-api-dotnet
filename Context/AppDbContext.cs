using AlunosApiArnaldo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlunosApiArnaldo.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {        
        public AppDbContext(DbContextOptions<AppDbContext>  options): base(options)
        {            
        }
        public DbSet<Aluno> Alunos { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Aluno>().HasData(
        //        new Aluno
        //        {
        //            Id = 1,
        //            Name = "Maria da Penha",
        //            Email = "maria@teste.com",
        //            Idade = 42
        //        },
        //        new Aluno
        //        {
        //            Id = 2,
        //            Name = "Fulano de Tall",
        //            Email = "fulano@teste.com",
        //            Idade = 43
        //        }

        //   );

        //}
    }
}

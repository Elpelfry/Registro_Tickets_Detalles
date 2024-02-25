using Class_Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Tickets_Detalles.API.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }

    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Tickets> Tickets { get; set; }
}

using Microsoft.EntityFrameworkCore;
using gerenciador_de_estacionamento.Models;

namespace gerenciador_de_estacionamento.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<CarroModel> Carros { get; set; }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gerenciador_de_estacionamento.Models;
using gerenciador_de_estacionamento.Data;

namespace gerenciador_de_estacionamento.Controllers;
public class PrecoController : Controller
{
    private readonly gerenciador_de_estacionamento.Data.AppDbContext _context;

    public PrecoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var precos = _context.TabelaPrecos.ToList();
        return View(precos);
    }

    [HttpPost]
    public IActionResult Cadastrar(decimal valor_hora_inicial, decimal valor_hora_adicional, DateTime data_inicio, DateTime data_fim)
    {

        var preco = new TabelaPrecoModel
        {
            valor_inicial = valor_hora_inicial,
            valor_adicional = valor_hora_adicional,
            data_inicio = data_inicio,
            data_fim = data_fim
        };

        _context.TabelaPrecos.Add(preco);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
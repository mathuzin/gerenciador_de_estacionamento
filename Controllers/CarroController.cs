using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gerenciador_de_estacionamento.Models;
using gerenciador_de_estacionamento.Data;

namespace gerenciador_de_estacionamento.Controllers;

public class CarroController: Controller
{

    private readonly AppDbContext _context;

    public CarroController(AppDbContext context)
    {
        _context = context;
    }

    CarroModel CarroModel()

    {
        return new CarroModel();
    }
    
public IActionResult Index()
{
    var carros = _context.Carros.ToList();
    return View(carros);
}

[HttpGet]
public IActionResult ListarCarrosEstacionados()
    {
        var carros = _context.Carros.ToList();
        return Json(carros);
    }

[HttpGet]
public CarroModel BuscarCarroPorPlaca(string placa)
    {
        var carro = _context.Carros.Find(placa);
        if (carro == null)
            Console.WriteLine($"Carro nao encontrado");
        
        return carro;
    }


[HttpPost]
public IActionResult CadastroCarro(string placa)
{
    var carro = new CarroModel { num_placa = placa};

    _context.Carros.Add(carro);
    _context.SaveChanges();

    Console.WriteLine($"Carro com placa {carro.num_placa} cadastrado");
    return RedirectToAction("Index");
}

[HttpPut]
public IActionResult CadastroEntrada(string placa)
{
    var carro = BuscarCarroPorPlaca(placa);
    if (carro == null)
        return NotFound();

    carro.hora_entrada = DateTime.Now;
    _context.SaveChanges();

    return Ok(carro);
}

[HttpPut]
public IActionResult CadastroSaida(string placa)
{
    var carro = BuscarCarroPorPlaca(placa);
    if (carro == null)
        return NotFound();

    carro.hora_saida = DateTime.Now;
    _context.SaveChanges();

    Calcular(placa);

    return Ok(carro);
}

[HttpPut]
public IActionResult Calcular(string placa)
    {
        var carro = BuscarCarroPorPlaca(placa);

        if (carro == null)
        {
            return NotFound(new { mensagem = "Carro não encontrado com a placa informada."});
        }

        if (carro.hora_saida == null || carro.hora_entrada == null)
        {
            return BadRequest(new { mensagem = "Datas de entrada ou saída inválidas para este veículo."});
        }

        var duracao = carro.hora_saida - carro.hora_entrada;
        double totalMinutos = duracao.Value.TotalMinutes;

        if (totalMinutos < 1) totalMinutos = 1;

        int horasInteiras = (int)(totalMinutos / 60);
        double minutosRestantes = totalMinutos % 60;
        int fracoesCobradas = 0;

        if (horasInteiras== 0)
        {
            if (minutosRestantes <= 30)
            {
                fracoesCobradas = 1;
            }
            else
            {
                fracoesCobradas = 2;
            }
        }
        else
        {
            fracoesCobradas = horasInteiras * 2;
             
            if (minutosRestantes > 10 && minutosRestantes <= 30)
            {
                fracoesCobradas += 1;
            }
            else if (minutosRestantes > 30)
            {
                fracoesCobradas += 2;
            }
        }

        decimal valorDaFracao = 1.00m;
        decimal valorPagar = fracoesCobradas * valorDaFracao;

        carro.duracao = duracao;
        carro.preco = 2;
        carro.valor = valorPagar;
        carro.tempo_cobrado = fracoesCobradas;

        _context.SaveChanges();

        return Ok(new
        {
            Carro = carro,
            MinutosPermanencia = totalMinutos,
            FracoesCobradas = fracoesCobradas,
            ValorTotal = valorPagar 
        });
    }


}

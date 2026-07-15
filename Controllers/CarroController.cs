using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gerenciador_de_estacionamento.Models;

namespace gerenciador_de_estacionamento.Controllers;

public class CarroController: Controller
{

    CarroModel CarroModel()

    {
        return new CarroModel();
    }
    
public IActionResult Index()
{
    return View();
}

[HttpPost]
public IActionResult listaDeCarros()
{
    Console.WriteLine($"Carro com placa {carro.num_placa} cadastrado");
    return RedirectToAction("Index");
}

[HttpPost]
public IActionResult CadastroCarro(string placa)
{
    var carro = new CarroModel { num_placa = placa};
    Console.WriteLine($"Carro com placa {carro.num_placa} cadastrado");
    return RedirectToAction("Index");
}

[HttpPut]
public IActionResult CadastroEntrada()
{
    var carro = new CarroModel { hora_entrada = DateTime.Now };
    Console.WriteLine($"Carro com placa {carro.num_placa} entrou às {carro.hora_entrada}");
    return RedirectToAction("Index");
}

[HttpPut]
public IActionResult CadastroSaida()
{
    var carro = new CarroModel { hora_saida= DateTime.Now };
    Console.WriteLine($"Carro com placa {carro.num_placa} saiu às {carro.hora_saida}");
    return RedirectToAction("Index");
}
    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

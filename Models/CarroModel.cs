using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciador_de_estacionamento.Models;

[Table("carro")]
public class CarroModel
{
    [Key]
    public string num_placa { get; set; }
    public DateTime hora_entrada { get; set;}
    public DateTime? hora_saida { get; set;}

    public TimeSpan? duracao { get; set;}

    public Int32? tempo_cobrado { get; set;}

    public Decimal? preco{ get; set;}
    public Decimal? valor{ get; set;}
}

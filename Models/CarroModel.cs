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

    public int? tempo_cobrado { get; set;}

    public int? preco_id{ get; set;}
    [ForeignKey("preco_id")]
    public TabelaPrecoModel? preco{ get; set;}
    public Decimal? valor{ get; set;}
}

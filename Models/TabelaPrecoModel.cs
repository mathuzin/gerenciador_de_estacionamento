using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciador_de_estacionamento.Models;

[Table("preco")]
public class TabelaPrecoModel
{
    [Key]
    public int id{ get; set; }
    public Decimal valor_inicial { get; set;}
    public Decimal valor_adicional{ get; set;}
    public DateTime data_inicio { get; set;}
    public DateTime data_fim { get; set;}
}

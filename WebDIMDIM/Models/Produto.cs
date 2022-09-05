using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDIMDIM.Models
{
    [Table("tb_produto")]
    public class Produto
    {
        [Column("Id")]
        [Display(Name = "Código de Identificação")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Column("Valor")]
        [Display(Name = "Valor do Produto")]
        public double Valor { get; set; }

        [Column("Quantidade")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }
    }
}

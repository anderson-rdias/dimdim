using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDIMDIM.Models
{
    [Table("tb_contabancaria")]
    public class ContaBancaria
    {
        [Column("Id")]
        [Display(Name = "Código de Identificação")]
        public int Id { get; set; }

        [Column("Agencia")]
        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        [Column("Conta")]
        [Display(Name = "Conta")]
        public string Conta { get; set; }

        [Column("Saldo")]
        [Display(Name = "Saldo")]
        public double Saldo { get; set; }
    }
}

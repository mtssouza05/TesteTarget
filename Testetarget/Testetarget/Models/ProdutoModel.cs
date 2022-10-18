using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Testetarget.Models
{

	[Table("Produto")]
	public class ProdutoModel
	{
		[Column("Id")]
		[Display(Name ="ID")]
		public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Valor")]
        [Display(Name = "Valor")]
        public float Valor { get; set; }

        [Column("Disponibilidade")]
        [Display(Name = "Disponibilidade")]
        public string Disponibilidade { get; set; }

    }
}

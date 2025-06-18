using Pees.lib.Models;

namespace Pees.Lib.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public int CategoriaId { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueMinimo { get; set; }
        public decimal Preco { get; set; }

        public Categoria Categoria { get; set; }
    }
}

using System;

namespace Pees.Lib.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
    }

    public enum TipoMovimentacao
    {
        Entrada,
        Saida
    }
}

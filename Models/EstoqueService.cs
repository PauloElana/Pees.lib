using System;
using System.Collections.Generic;
using System.Linq;
using Pees.Lib.Models;

namespace Pees.Lib.Services
{
    public class EstoqueService
    {
        private List<Produto> _produtos;
        private List<Movimentacao> _movimentacoes;

        public EstoqueService()
        {
            _produtos = new List<Produto>();
            _movimentacoes = new List<Movimentacao>();
        }

        public void RegistrarEntrada(int produtoId, int quantidade, string observacao = "")
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null) throw new Exception("Produto não encontrado");

            produto.Quantidade += quantidade;
            _movimentacoes.Add(new Movimentacao
            {
                ProdutoId = produtoId,
                Tipo = TipoMovimentacao.Entrada,
                Quantidade = quantidade,
                Data = DateTime.Now,
                Observacao = observacao
            });
        }

        public void RegistrarSaida(int produtoId, int quantidade, string observacao = "")
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == produtoId);
            if (produto == null) throw new Exception("Produto não encontrado");

            if (produto.Quantidade < quantidade)
                throw new Exception("Estoque insuficiente");

            produto.Quantidade -= quantidade;
            _movimentacoes.Add(new Movimentacao
            {
                ProdutoId = produtoId,
                Tipo = TipoMovimentacao.Saida,
                Quantidade = quantidade,
                Data = DateTime.Now,
                Observacao = observacao
            });
        }

        public IEnumerable<Movimentacao> ObterHistorico(int produtoId)
        {
            return _movimentacoes.Where(m => m.ProdutoId == produtoId);
        }

        public IEnumerable<Produto> ObterProdutosAbaixoDoMinimo()
        {
            return _produtos.Where(p => p.Quantidade <= p.EstoqueMinimo);
        }

        // Métodos adicionais para adicionar e listar produtos
        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public IEnumerable<Produto> ListarProdutos()
        {
            return _produtos;
        }
    }
}

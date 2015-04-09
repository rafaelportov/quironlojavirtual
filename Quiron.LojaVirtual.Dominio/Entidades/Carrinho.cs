using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemcarrinho = new List<ItemCarrinho>();

        //Adicionar

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _itemcarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId); //Retorna o primeiro elemento da lista, se não tiver elementos, retorna Default
            if (item == null) //Se o produto ainda não estiver no carrinho
            {
                _itemcarrinho.Add(new ItemCarrinho
                    {
                        Produto = produto,
                        Quantidade = quantidade
                    });
            }
            else //Se o produto já estiver no carrinho, só soma a quantidade
            {
                item.Quantidade += quantidade;
            }
        }

        //Remover

        public void RemoverItem(Produto produto)
        {
            _itemcarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        //Obter o valor total

        public decimal ObterValotTotal()
        {
            return _itemcarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        //Limpar o carrinho

        public void LimparCarrinho()
        {
            _itemcarrinho.Clear();
        }

        //Itens Carrinho

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemcarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}

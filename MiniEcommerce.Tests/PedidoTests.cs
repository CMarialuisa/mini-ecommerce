using Xunit;
using MiniEcommerce.Console;

namespace MiniEcommerce.Tests;

public class PedidoTests
{
    [Fact]
    public void ProcessarCheckout_DeveBaixarEstoque_ELimparCarrinho()
    {
        var produto = new Produto("Rato", 50m, 10);
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarItem(produto, 2);
        
        var pedido = new Pedido();
        pedido.ProcessarCheckout(carrinho);

        Assert.Equal(8, produto.Estoque);
        Assert.Empty(carrinho.Itens);
        Assert.Equal(100m, pedido.ValorTotal);
        Assert.True(pedido.Finalizado);
    }
}
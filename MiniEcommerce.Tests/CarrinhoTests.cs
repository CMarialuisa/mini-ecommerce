using Xunit;
using MiniEcommerce.Console;

namespace MiniEcommerce.Tests;

public class CarrinhoTests
{
    [Fact]
    public void AdicionarItem_DeveLancarExcecao_QuandoEstoqueInsuficiente()
    {
        var produto = new Produto("Monitor", 1000m, 2);
        var carrinho = new CarrinhoDeCompras();

        Assert.Throws<InvalidOperationException>(() => carrinho.AdicionarItem(produto, 3));
    }

    [Fact]
    public void CalcularSubtotal_DeveRetornarSomaCorreta()
    {
        var carrinho = new CarrinhoDeCompras();
        carrinho.AdicionarItem(new Produto("A", 10m, 10), 2); // 20
        carrinho.AdicionarItem(new Produto("B", 15m, 10), 1); // 15

        Assert.Equal(35m, carrinho.CalcularSubtotal());
    }
}
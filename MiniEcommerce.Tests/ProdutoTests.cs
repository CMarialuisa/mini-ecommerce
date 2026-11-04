using Xunit;
using MiniEcommerce.Console;

namespace MiniEcommerce.Tests;

public class ProdutoTests
{
    [Fact]
    public void CriarProduto_DeveLancarExcecao_QuandoPrecoNegativo()
    {
        Assert.Throws<ArgumentException>(() => new Produto("Teclado", -10m, 5));
    }

    [Fact]
    public void CriarProduto_DeveLancarExcecao_QuandoEstoqueNegativo()
    {
        Assert.Throws<ArgumentException>(() => new Produto("Rato", 50m, -1));
    }
}
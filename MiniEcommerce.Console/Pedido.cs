namespace MiniEcommerce.Console;

public class Pedido
{
    public decimal ValorTotal { get; private set; }
    public bool Finalizado { get; private set; }

    public void ProcessarCheckout(CarrinhoDeCompras carrinho)
    {
        if (!carrinho.Itens.Any())
            throw new InvalidOperationException("Não é possível fechar um pedido com o carrinho vazio.");

        ValorTotal = carrinho.CalcularSubtotal();

        foreach (var item in carrinho.Itens)
        {
            item.Produto.BaixarEstoque(item.Quantidade);
        }

        Finalizado = true;
        carrinho.LimparCarrinho();
    }
}
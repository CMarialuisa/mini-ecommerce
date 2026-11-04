namespace MiniEcommerce.Console;

public class ItemCarrinho
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public ItemCarrinho(Produto p, int q) { Produto = p; Quantidade = q; }
}

public class CarrinhoDeCompras
{
    private readonly List<ItemCarrinho> _itens = new();
    public IReadOnlyCollection<ItemCarrinho> Itens => _itens.AsReadOnly();

    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (quantidade <= 0) throw new ArgumentException("A quantidade deve ser maior que zero.");
        
        var itemExistente = _itens.FirstOrDefault(i => i.Produto.Id == produto.Id);
        int quantidadeTotalDesejada = quantidade + (itemExistente?.Quantidade ?? 0);

        if (quantidadeTotalDesejada > produto.Estoque)
            throw new InvalidOperationException($"Estoque insuficiente. Disponível: {produto.Estoque}");

        if (itemExistente != null)
            itemExistente.Quantidade += quantidade;
        else
            _itens.Add(new ItemCarrinho(produto, quantidade));
    }

    public decimal CalcularSubtotal()
    {
        return _itens.Sum(i => i.Produto.Preco * i.Quantidade);
    }

    public void LimparCarrinho() => _itens.Clear();
}
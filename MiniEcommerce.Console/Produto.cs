namespace MiniEcommerce.Console;

public class Produto
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Nome { get; }
    public decimal Preco { get; }
    public int Estoque { get; private set; }

    public Produto(string nome, decimal preco, int estoque)
    {
        if (preco < 0) throw new ArgumentException("O preço não pode ser negativo.");
        if (estoque < 0) throw new ArgumentException("O estoque não pode ser menor que zero.");

        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void BaixarEstoque(int quantidade)
    {
        if (quantidade > Estoque) throw new InvalidOperationException("Estoque insuficiente.");
        Estoque -= quantidade;
    }
}
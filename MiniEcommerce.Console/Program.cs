using MiniEcommerce.Console;

var catalogo = new List<Produto>
{
    new Produto("Teclado Mecânico", 250m, 10),
    new Produto("Rato Gamer", 120m, 5),
    new Produto("Monitor 24p", 900m, 3)
};
var carrinho = new CarrinhoDeCompras();
bool executando = true;

while (executando)
{
    Console.WriteLine("\n=== MINI E-COMMERCE ===");
    Console.WriteLine("1. Ver Catálogo de Produtos");
    Console.WriteLine("2. Adicionar ao Carrinho");
    Console.WriteLine("3. Ver Carrinho");
    Console.WriteLine("4. Finalizar Pedido (Checkout)");
    Console.WriteLine("0. Sair");
    Console.Write("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("\n--- CATÁLOGO ---");
            for (int i = 0; i < catalogo.Count; i++)
                Console.WriteLine($"[{i}] {catalogo[i].Nome} - {catalogo[i].Preco:C} (Estoque: {catalogo[i].Estoque})");
            break;

        case "2":
            Console.Write("ID do Produto (número entre colchetes no catálogo): ");
            if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id < catalogo.Count)
            {
                Console.Write("Quantidade: ");
                if (int.TryParse(Console.ReadLine(), out int qtd))
                {
                    try
                    {
                        carrinho.AdicionarItem(catalogo[id], qtd);
                        Console.WriteLine("[SUCESSO] Adicionado ao carrinho.");
                    }
                    catch (Exception ex) { Console.WriteLine($"[ERRO] {ex.Message}"); }
                }
            }
            else Console.WriteLine("[ERRO] Produto inválido.");
            break;

        case "3":
            Console.WriteLine("\n--- CARRINHO ---");
            foreach (var item in carrinho.Itens)
                Console.WriteLine($"{item.Quantidade}x {item.Produto.Nome} - Subtotal: {item.Produto.Preco * item.Quantidade:C}");
            Console.WriteLine($"Total do Carrinho: {carrinho.CalcularSubtotal():C}");
            break;

        case "4":
            try
            {
                var pedido = new Pedido();
                pedido.ProcessarCheckout(carrinho);
                Console.WriteLine($"\n[SUCESSO] Pedido finalizado! Total pago: {pedido.ValorTotal:C}");
            }
            catch (Exception ex) { Console.WriteLine($"[ERRO] {ex.Message}"); }
            break;

        case "0":
            executando = false;
            Console.WriteLine("A sair...");
            break;

        default:
            Console.WriteLine("[ERRO] Opção inválida.");
            break;
    }
}
class Gerencia
{
    //Propriedade da classe Gerência
    private List<Produto> produtos=new List<Produto>();
    //Método para adicionar produto
    public void AdicionaProduto(Produto produto)
    {
        produtos.Add(produto);
    }
    //Método para listar registros de produtos
    public void ListaProduto()
    {
        foreach(var produto in produtos)
        {
            Console.WriteLine(produto.ToString());
        }
    }
    //Método para buscar o registro de um produto
    public Produto BuscaProduto(int id)
    {
        return produtos.Find(busca=>busca.Id==id);
    }
    //Método para o menu de gerenciamento
    public static void Menu()
    {
        string separador=new string('-',70);
        Console.WriteLine($"{separador}\nGerenciamento de loja\n{separador}");
        Console.WriteLine("1. Cadastrar produto");
        Console.WriteLine("2. Listar produtos");
        Console.WriteLine("3. Buscar produto");
        Console.WriteLine("4. Sair");
        Console.Write("Escolha uma opção:");
    }
    //Método para limpar a tela do console
    public static void LimparTela()
    {
        Console.Clear();
    } 
}
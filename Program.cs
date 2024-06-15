using System.Collections.Generic;
using MySql.Data.MySqlClient;
string separador=new string('-',70);
while(true)
{
    Menu(separador);
    var opcao=Console.ReadLine();
    switch(opcao)
    {
        case "1":
            LimparTela();
            CadastraProduto();
            break;
        case "2":
            LimparTela();
            ListaProduto();
            break;
        case "3":
            LimparTela();
            BuscandoProduto();
            break;
        case "4":
            LimparTela();
            AtualizaProduto();
            break;
        case "5":
            LimparTela();
            ExcluiProduto();
            break;
        case "6":
            Console.ReadKey();
            return;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}
//Método para o menu de gerenciamento
static void Menu(string separador)
{            
    Console.WriteLine($"{separador}\nGerenciamento de loja\n{separador}");
    Console.WriteLine("1. Cadastrar produto");
    Console.WriteLine("2. Listar produtos");
    Console.WriteLine("3. Buscar produto");
    Console.WriteLine("4. Atualizar produto");
    Console.WriteLine("5. Excluir produto");
    Console.WriteLine("6. Sair");
    Console.Write("Escolha uma opção: ");
}
static void CadastraProduto()
{
    //Perguntando os valores ao usuário
    Console.Write("Digite o nome: ");
    string nome=Console.ReadLine();
    Console.Write("Digite a marca: ");
    string marca=Console.ReadLine();
    Console.Write("Digite o preço: ");
    decimal preco=decimal.Parse(Console.ReadLine());
    Console.Write("Digite a data de validade caso possua: ");
    string inserirvalidade=Console.ReadLine();
    DateTime? validade=string.IsNullOrEmpty(inserirvalidade)?(DateTime?)null:DateTime.Parse(inserirvalidade);
    //Criando um objeto da classe Produto com os valores fornecidos pelo usuário
    var produto=new Produto(nome,marca,preco,validade);
    produto.AdicionarProduto();
    Console.WriteLine("Produto adicionado com sucesso.");
}
static void ListaProduto()
{
    //Listando os produtos através de método e objeto
    List<Produto> produtos=Produto.ListarProdutos();
    //Método para listar todos os produtos
    foreach(var produto in produtos)
    {
        Console.WriteLine($"ID: {produto.Id}\nNome: {produto.Nome}\nMarca: {produto.Marca}\nPreço: {produto.Preco:c}\nValidade: {produto.Validade?.ToString("yyyy-MM-dd")??"Sem data de validade"}");
    }
}
static void BuscandoProduto()
{
    //Perguntando ID do produto para busca
    Console.Write("Digite a ID do produto: ");
    int id=int.Parse(Console.ReadLine());
    var encontrarproduto=Produto.ListarProdutos().Find(unidadeproduto=>unidadeproduto.Id==id);
    if(encontrarproduto==null)
    {
        Console.WriteLine("Produto não encontrado.");
        return;
    }
    List<Produto> produtos=Produto.BuscarProdutos(id);
    //Método para imprimir produto
    foreach (var produto in produtos)
    {
        Console.WriteLine($"ID: {produto.Id}\nNome: {produto.Nome}\nMarca: {produto.Marca}\nPreço: {produto.Preco:c}\nValidade: {produto.Validade?.ToString("yyyy-MM-dd")??"Sem data de validade"}");
    }    
}
static void AtualizaProduto()
{
    //Perguntando ID do produto a ser atualizado
    Console.Write("Digite a ID do produto: ");
    int id=int.Parse(Console.ReadLine());
    var produto=Produto.ListarProdutos().Find(unidadeproduto=>unidadeproduto.Id==id);
    if(produto==null)
    {
        Console.WriteLine("Produto não encontrado.");
        return;
    }
    //Perguntando os valores a serem atualizados ao usuário
    Console.Write("Digite o novo nome caso possua: ");
    string nome=Console.ReadLine();
    if (!string.IsNullOrEmpty(nome))produto.AtualizandoProduto(nome,produto.Marca,produto.Preco);
    Console.Write("Digite a nova marca caso possua: ");
    string marca=Console.ReadLine();
    if (!string.IsNullOrEmpty(marca))produto.AtualizandoProduto(produto.Nome,marca,produto.Preco);
    Console.Write("Digite o novo preço caso possua: ");
    string inserirpreco=Console.ReadLine();
    if (!string.IsNullOrEmpty(inserirpreco))
    {
        decimal.TryParse(inserirpreco,out decimal preco);
        produto.AtualizandoProduto(produto.Nome,produto.Marca,preco);
    }
    produto.AtualizarProduto();
    Console.WriteLine("Produto atualizado.");
}
static void ExcluiProduto()
{
    //Perguntando ID do produto a ser excluido
    Console.Write("Digite a ID do produto: ");
    int id=int.Parse(Console.ReadLine());
    var produto=Produto.ListarProdutos().Find(unidadeproduto=>unidadeproduto.Id==id);
    if(produto==null)
    {
        Console.WriteLine("Produto não encontrado.");
        return;
    }
    Produto.ExcluirProduto(id);
    Console.WriteLine("Produto excluído.");
}
//Método para limpar a tela do console
static void LimparTela()
{
    Console.Clear();
}
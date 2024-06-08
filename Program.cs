var gerencia=new Gerencia();
while(true)
{
    Gerencia.Menu();
    var opcao=Console.ReadLine();
    switch(opcao)
    {
        case "1":
            Gerencia.LimparTela();
            //Perguntando os valores ao usuário
            Console.Write("Digite o ID: ");
            int id=int.Parse(Console.ReadLine());
            Console.Write("Digite o nome: ");
            string nome=Console.ReadLine();
            Console.Write("Digite a marca: ");
            string marca=Console.ReadLine();
            Console.Write("Digite o preço: ");
            decimal preco=decimal.Parse(Console.ReadLine());
            Console.Write("Digite a data de validade: ");
            DateTime? validade=DateTime.Parse(Console.ReadLine());
            //Criando um objeto da classe Produto com os valores fornecidos pelo usuário
            var produto=new Produto(id,nome,marca,preco,validade);
            gerencia.AdicionaProduto(produto);
            Console.WriteLine("Produto adicionado com sucesso.");
            break;
        case "2":
            Gerencia.LimparTela();
            gerencia.ListaProduto();
            break;
        case "3":
            Gerencia.LimparTela();
            //Fazendo busca de produto pelo ID
            Console.Write("Digite o ID do produto para buscar: ");
            int BuscaId=int.Parse(Console.ReadLine());
            var ProdutoBusca=gerencia.BuscaProduto(BuscaId);
            if (ProdutoBusca!=null)
            {
                Console.WriteLine(ProdutoBusca.ToString());
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
            break;
        case "4":
            Console.ReadKey();
            return;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}
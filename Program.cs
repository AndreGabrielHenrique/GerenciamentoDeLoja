bool recomecar=true;
while(recomecar)
{
    Produto.Menu();
    var opcao=Console.ReadLine();
    switch(opcao)
    {
        case "1":
            Produto.LimparTela();
            //Perguntando os valores ao usuário
            Console.Write("Digite o ID: ");
            int id=int.Parse(Console.ReadLine());
            Console.Write("Digite o nome: ");
            string nome=Console.ReadLine();
            Console.Write("Digite a marca: ");
            string marca=Console.ReadLine();
            Console.Write("Digite o preço: ");
            double preco = double.Parse(Console.ReadLine());
            Console.Write("Digite a data de validade: ");
            DateTime validade=DateTime.Parse(Console.ReadLine());
            //Criando um objeto da classe Produto com os valores fornecidos pelo usuário
            Produto produto = new Produto(id,nome,marca,preco,validade);
            break;
        case "2":
            Produto.LimparTela();
            break;
        case "3":
            Produto.LimparTela();
            break;
        case "4":
            recomecar=false;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

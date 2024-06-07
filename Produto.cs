public class Produto
    {
        //Propriedades da classe Produto
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Marca{get;set;}
        public double Preco{get;set;}
        public DateTime Validade{get;set;}
        private static List<Produto> ListaDeProdutos=new List<Produto>();
        //Construtor
        public Produto(int id,string nome,string marca,double preco,DateTime validade)
        {
            Id=id;
            Nome=nome;
            Marca=marca;
            Preco=preco;
            Validade=validade;
        }
        //Método estático para listar registros de Produtos
        public static void ListaProduto()
        {
            
        }        
        //Método para buscar o registro de um Produto

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
        public static void LimparTela()
        {
            Console.Clear();
        }  
    }
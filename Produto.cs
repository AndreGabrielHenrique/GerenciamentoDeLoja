using MySql.Data.MySqlClient;
using System.Collections.Generic;
class Produto
{
    //Propriedades da classe Produto
    public int Id{get;private set;}
    public string Nome{get;private set;}
    public string Marca{get;private set;}
    public decimal Preco{get;private set;}
    public DateTime? Validade{get;private set;}
    //Construtor
    public Produto(string nome,string marca,decimal preco,DateTime? validade)
    {
        Nome=nome;
        Marca=marca;
        Preco=preco;
        Validade=validade;
    }
    //Método para adicionar ID
    public void AdicionarID(int id)
    {
        Id=id;
    }
    //Método para adicionar produto
    public void AdicionarProduto()
    {
        using(var connection=BancoDeDados.GetConnection())
        {
            connection.Open();
            string query="insert into Produtos(Nome,Marca,Preco,Validade) values (@nome,@marca,@preco,@validade)";
            MySqlCommand cmd=new MySqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@nome",Nome);
            cmd.Parameters.AddWithValue("@marca",Marca);
            cmd.Parameters.AddWithValue("@preco",Preco);
            cmd.Parameters.AddWithValue("@validade",Validade);
            cmd.ExecuteNonQuery();
            AdicionarID((int)cmd.LastInsertedId);
        }
    }
    //Método para listar registros de produtos
    public static List<Produto> ListarProdutos()
    {
        List<Produto> produtos=new List<Produto>();
        using(var connection=BancoDeDados.GetConnection())
        {
            connection.Open();
            string query="select * from Produtos";
            MySqlCommand cmd=new MySqlCommand(query,connection);
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                DateTime? validade=reader.IsDBNull(reader.GetOrdinal("Validade"))?(DateTime?)null:reader.GetDateTime("Validade");
                var produto=new Produto
                (
                    reader.GetString("Nome"),
                    reader.GetString("Marca"),
                    reader.GetDecimal("Preco"),
                    validade
                );
                produto.AdicionarID(reader.GetInt32("Id"));
                produtos.Add(produto);
            }
        }       
        return produtos;
    }
    //Método para buscar produto pelo ID
    public static List<Produto> BuscarProdutos(int id)
    {
        List<Produto> produtos=new List<Produto>();
        using (var connection=BancoDeDados.GetConnection())
        {
            connection.Open();
            string query="select * from Produtos where Id like @id";
            MySqlCommand cmd=new MySqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@id", $"%{id}%");
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                DateTime? validade=reader.IsDBNull(reader.GetOrdinal("Validade"))?(DateTime?)null:reader.GetDateTime("Validade");
                var produto=new Produto
                (
                    reader.GetString("Nome"),
                    reader.GetString("Marca"),
                    reader.GetDecimal("Preco"),
                    validade
                );
                produto.AdicionarID(reader.GetInt32("Id"));
                produtos.Add(produto);
            }
        }
        return produtos;  
    }
    //Métodos para atualizar produto
    public void AtualizandoProduto(string nome,string marca,decimal preco)
    {
        Nome=nome;
        Marca=marca;
        Preco=preco;        
    }
    public void AtualizarProduto()
    {
        using(var connection=BancoDeDados.GetConnection())
        {
            connection.Open();
            string query="update Produtos set Nome=@nome,Marca=@marca,Preco=@preco where Id=@id";
            MySqlCommand cmd=new MySqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@nome",Nome);
            cmd.Parameters.AddWithValue("@marca",Marca);
            cmd.Parameters.AddWithValue("@preco",Preco);
            cmd.Parameters.AddWithValue("@id",Id);
            cmd.ExecuteNonQuery();
        }
    }
    //Método para excluir produto
    public static void ExcluirProduto(int id)
    {
        using(var connection=BancoDeDados.GetConnection())
        {
            connection.Open();
            string query="delete from Produtos where Id=@id";
            MySqlCommand cmd=new MySqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.ExecuteNonQuery();
        }
    }    
}
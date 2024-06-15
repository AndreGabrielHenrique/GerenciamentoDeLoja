using MySql.Data.MySqlClient;
class BancoDeDados
{
    //Dados para conexão ao servidor do BD
    private static string connectionString="Server=database-lab2.cxw2ioo8az9d.sa-east-1.rds.amazonaws.com;Database=dbGerenciamentoDeLoja;Uid=Aula01;Pwd=Aula01;";
    //Método para conexão ao BD
    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}
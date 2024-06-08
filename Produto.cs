class Produto
{
    //Propriedades da classe Produto
    public int Id{get;}
    public string Nome{get;}
    public string Marca{get;}
    public decimal Preco{get;}
    public DateTime? Validade{get;}
    
    //Construtor
    public Produto(int id,string nome,string marca,decimal preco,DateTime? validade)
    {
        Id=id;
        Nome=nome;
        Marca=marca;
        Preco=preco;
        Validade=validade;
    }
    //Método para sobrepor variáveis com .ToString()          
    public override string ToString()
    {
        return $"ID: {Id}\nNome: {Nome}\nMarca: {Marca}\nPreco: {Preco:c}\nValidade: {Validade}";
    }
}
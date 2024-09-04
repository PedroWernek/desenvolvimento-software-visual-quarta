namespace API.Models;

public class Produto
{
    // C# - construtor da classe
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    //C# - Atributo com 'get' e 'set'
    //Capitalização:
    //PascalCase - Classe/Criação de metodos
    public DateTime CriadoEm { get; set; }
    public string? Id { get; set; }
    public string? Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

    //JAVA - Atributo com 'get' e 'set'
    //Capitalização:

    //CamelCase
    // private double preco;

    // public double getPreco(){
    //     return preco;
    // }

    // public void setPreco(double preco){
    //     this.preco = preco;  
    // }


}

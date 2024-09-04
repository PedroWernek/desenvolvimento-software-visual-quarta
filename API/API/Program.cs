using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//lista para o sexto item
List<UserInfo> listaUsuarios = new List<UserInfo>();

// primeiro:
app.MapGet("/", () => "Hello World!");

// segundo:
app.MapGet("/mickey", () => "Espansão de domínio, casa do mickeymouse");

//terceiro endereço:

app.MapGet("/retornarEndereco", () =>
{
  dynamic endereco = new
  {
    rua = "João",
    numero = "613",
    CEP = "23456-654"
  };
  return endereco;
});

/* TAREFA: criar uma funcionalidade para:
   ♡ receber informações pela URL da requisição
   ♡ receber informações pelo corpo da requisição 
   ♡ guardar as informações em uma lista */

//quarto: receber informações pela URL da requisição

app.MapGet("/receberinfo/{nome}/{idade}", (string nome, int idade) =>
{
  return $"Nome: {nome}, idade: {idade}";
});

//quinto: receber informações pelo corpo da requisição 
app.MapGet("/receberinfopelocorpo", ([FromBody] UserInfo userInfo) =>
{
  listaUsuarios.Add(userInfo);

  return $"Nome: {userInfo.Nome}, idade: {userInfo.Idade} - foi adicionado!";
});

app.MapGet("/lista", () => listaUsuarios);

app.Run();

//classe userInfo
public class UserInfo
{
  public string? Nome { get; set; }
  public int Idade { get; set; }
}
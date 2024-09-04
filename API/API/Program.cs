using API.Models;
//using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//lista para o sexto item
//List<UserInfo> listaUsuarios = new List<UserInfo>();

//EndPoints - Funcionalidades
//GET - pegar alguma coisa

//Toda a aplicação tem CRUD

//Métodos HTTP
// Create - Post
// Retrieve - Get
// Update - Put/Patch
// Delete - Delete


//Request - Configurar URL metodo/verbo HTTP
//Response - Retornar os dados (json/xml) e os status
app.MapGet("/", () => "API de Produtos");

List<Produto> produtos = new List<Produto>();
produtos.Add(new Produto()
  {
    Nome = "Notebook",
    Preco = 5000,
    Quantidade = 54
  });
  produtos.Add(new Produto()
  {
    Nome = "PC",
    Preco = 7000,
    Quantidade = 14
  });
  produtos.Add(new Produto()
  {
    Nome = "Monitor Pichau",
    Preco = 3000,
    Quantidade = 14
  });
  produtos.Add(new Produto()
  {
    Nome = "Notebook acer",
    Preco = 32000,
    Quantidade = 104
  });

//GET: produto/listar
app.MapGet("/produto/listar", () => 
{
  return Results.Ok(produtos);
});

//POST: produto/cadastrar
app.MapPost("/produto/cadastrar/{nome}", (string nome) => 
{
  Produto produto = new Produto();
  produto.Nome = nome;
  produtos.Add(produto);
  return Results.Ok(produtos);
});


// Produto produto = new Produto()
// {
//   Nome = "Notebook",
//   Preco = 5000,
//   Quantidade = 54
// };

// // segundo:
// app.MapGet("/mickey", () => "Espansão de domínio, casa do mickeymouse");

// //terceiro endereço:

// app.MapGet("/retornarEndereco", () =>
// {
//   dynamic endereco = new
//   {
//     rua = "João",
//     numero = 613,
//     CEP = "23456-654"
//   };

//   return endereco;
// });

app.Run();

// C#
// Produto produto = new Produto();
// produto.Preco = 5;
// Console.WriteLine(produto.Preco);
// JAVA
// Produto produto = new Produto();
// produto.setPreco(5);
// Console.WriteLine("Preço: " + produto.getPreco());


// /* TAREFA: criar uma funcionalidade para:
//    ♡ receber informações pela URL da requisição
//    ♡ receber informações pelo corpo da requisição 
//    ♡ guardar as informações em uma lista */

// //quarto: receber informações pela URL da requisição

// app.MapGet("/receberinfo/{nome}/{idade}", (string nome, int idade) =>
// {
//   return $"Nome: {nome}, idade: {idade}";
// });

// //quinto: receber informações pelo corpo da requisição 
// app.MapGet("/receberinfopelocorpo", ([FromBody] UserInfo userInfo) =>
// {
//   listaUsuarios.Add(userInfo);

//   return $"Nome: {userInfo.Nome}, idade: {userInfo.Idade} - foi adicionado!";
// });

// app.MapGet("/lista", () => listaUsuarios);

// app.Run();

// //classe userInfo
// public class UserInfo
// {
//   public string? Nome { get; set; }
//   public int Idade { get; set; }
// }
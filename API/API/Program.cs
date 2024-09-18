using API.Models;
using Microsoft.AspNetCore.Mvc;
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
// produtos.Add(new Produto()
//   {
//     Nome = "Notebook",
//     Preco = 5000,
//     Quantidade = 54
//   });
//   produtos.Add(new Produto()
//   {
//     Nome = "PC",
//     Preco = 7000,
//     Quantidade = 14
//   });
//   produtos.Add(new Produto()
//   {
//     Nome = "Monitor Pichau",
//     Preco = 3000,
//     Quantidade = 14
//   });
//   produtos.Add(new Produto()
//   {
//     Nome = "Notebook acer",
//     Preco = 32000,
//     Quantidade = 104
//   });

//GET: produto/listar
app.MapGet("/produto/listar", () => 
{
  //se a lista tem pelo menos 1 item
  if(produtos.Count() > 0)
  {
    //retorno de requisição
    //count conta a qtd de itens da lista
    //Any retorna um true ou false se tem algo dentro da lista
    return Results.Ok(produtos);
  }

  //404 (not found) qualquer recurso não encontrado
  return Results.NotFound();

});

//POST: produto/cadastrar
//Por possuir informações sensiveis não é ideal usar esse metodo Post
// app.MapPost("/produto/cadastrar/{nome}", (string nome) => 
// {
//   //criar o objeto e preencher
//   Produto produto = new Produto();
//   produto.Nome = nome;
//   produtos.Add(produto);
//   //retorno de requisição
//   return Results.Ok(produtos);
// });

app.MapGet("/produto/buscar/{nome}", (string nome) => 
{
  foreach(Produto produtoCadastrado in produtos){
    if(produtoCadastrado.Nome == nome){
        return Results.Ok(produtoCadastrado);
    }
  }

  return Results.NotFound();
});

//não tem como passar um objeto da URL
app.MapPost("/produto/cadastrar", ([FromBody] Produto produto) =>
{
  produtos.Add(produto);

  return Results.Created("", produto);
});

app.MapDelete("/produto/deletar" => {});
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
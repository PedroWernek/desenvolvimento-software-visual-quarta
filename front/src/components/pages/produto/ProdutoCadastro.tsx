import { useState } from "react";
import { Produto } from "../../../models/Produto";
import "../../../css/ProdutoCadastro.css"
import { Categoria } from "../../../models/Categoria";
function ProdutoCadastro() {

    const [nome, setNome] = useState("");
    const [descricao, setDescricao] = useState("");
    const [quantidade, setQuantidade] = useState("");
    const [preco, setPreco] = useState("");
    const [categoria, setCategoria] = useState<Categoria>();

    function enviarProduto(e : any){
        e.preventDefault();

        const produto : Produto = {
            nome : nome,
            descricao : descricao,
            quantidade : Number(quantidade),
            preco : Number(preco)
        };

        fetch("http://localhost:5020/api/produto/cadastrar", 
            {
                method : "POST",
                headers : {
                    "Content-Type" : "application/json"
                },
                body : JSON.stringify(produto)
            })
            .then(resposta => {
                return resposta.json();
            })
            .then(produto => {
                console.log("Produto cadastrado", produto);
            });

    }

    return (
        <div id="cadastrar_produto">
    <h2>Cadastrar Produto</h2>
    <form onSubmit={enviarProduto}>
        <div>
            <label htmlFor="nome">Nome</label>
            <input type="text" id="nome" name="nome"
                onChange={(e: any) => setNome(e.target.value)} />
        </div>

        <div>
            <label htmlFor="descricao">Descrição</label>
            <input type="text" id="descricao" name="descricao"
                onChange={(e: any) => setDescricao(e.target.value)} />
        </div>

        <div>
            <label htmlFor="preco">Preço</label>
            <input type="number" id="preco" name="preco" 
                onChange={(e: any) => setPreco(e.target.value)} />
        </div>

        <div>
            <label htmlFor="quantidade">Quantidade</label>
            <input type="number" id="quantidade" name="quantidade" 
                onChange={(e: any) => setQuantidade(e.target.value)} />
        </div>
        <div>
            <label htmlFor="categoria">Categoria</label>
                <select onChange={e => console.log(e.target.value)}>
                    <option value="1">Bebidas</option>
                    <option value="2">Comidas</option>
                    <option value="3">Roupas</option>
                </select>

        </div>
        <button type="submit">Cadastrar Produto</button>
    </form>
</div>
    );
}

export default ProdutoCadastro;
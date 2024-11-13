import { useEffect, useState } from "react";

function ConsultarCEP(){    
    //Variáveis, constantes e estados
    const [cep, setCep] = useState("");
    const [bairro, setBairro] = useState("");
    const [estado, setEstado] = useState("");
    const [logradouro, setLogradouro] = useState("");

    useEffect(() => {
        //Função utilizada para executar algum código
        //ao abrir ou renderizar o componente
        //AXIOS biblioteca de requisições HTTP
       
        
    });

    function digitar(e : any){
        setCep(e.target.value);
    }

    function sairCaixaTexto(){
        fetch("https://viacep.com.br/ws/" + cep + "/json/")
            .then(resposta => {
                return resposta.json();
            })
            .then(cep => {
                setBairro(cep.bairro);
                setEstado(cep.estado);
                setLogradouro(cep.logradouro);
            })
    }

    function clicar(){
        // fetch("https://viacep.com.br/ws/" + cep + "/json/")
        //     .then(resposta => {
        //         return resposta.json();
        //     })
        //     .then(cep => {
        //         setBairro(cep.bairro);
        //         setEstado(cep.estado);
        //         setLogradouro(cep.logradouro);
        //     })
    }
    
    return (
        <div>
            <h1>Consultar CEP</h1>

            <input 
                type="text" 
                placeholder="Digite o CEP"
                onChange={digitar}
                onBlur={sairCaixaTexto}/>

                <button onClick={clicar}>Consultar</button>

            <p>{bairro}</p>
            <p>{estado}</p>
            <p>{logradouro}</p>
        </div>
    );
}

export default ConsultarCEP;

//1 - Exibir alguma informação do CEP no navegador
//2 - Realizar a requisição para a sua API
//3 - Resolver o problema de CORS que será mostrado 
//no console
//4 - Exibir a lista de produtos no navegador
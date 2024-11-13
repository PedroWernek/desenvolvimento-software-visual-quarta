import React from 'react';
import ConsultarCEP from './components/samples/ConsultarCEP';
import ProdutoLista from './components/pages/produto/ProdutoLista';
import ProdutoCadastro from './components/pages/produto/ProdutoCadastro';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import "./css/App.css";

function App() {
  return (
<div id="app">
  <BrowserRouter>
    <div className="sidebar">
      <ul>
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/pages/produto/listar">Listar Produtos</Link>
        </li>
        <li>
          <Link to="/pages/produto/cadastrar">Cadastrar Produtos</Link>
        </li>
        <li>
          <Link to="/pages/endereco/consultar">Consultar Endereço</Link>
        </li>
      </ul>
    </div>

    {/* Conteúdo principal */}
    <div className="main-content">
      <Routes>
        <Route path="/" element={<ProdutoLista />} />
        <Route path="/pages/produto/listar" element={<ProdutoLista />} />
        <Route path="/pages/produto/cadastrar" element={<ProdutoCadastro />} />
        <Route path="/pages/endereco/consultar" element={<ConsultarCEP />} />
      </Routes>
    </div>
  </BrowserRouter>
</div>
  );
}

export default App;

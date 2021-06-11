using System;
using System.Collections.Generic;
using Projetos_Produtos.Interfaces;

namespace Projetos_Produtos.Classes
{
    public class Produto : IProduto
    {
        private int Codigo;
        private string NomeProduto;
        private float Preco;
        private string DataCadastro; 
        private string marca;
        private string CadastradoPor;
        List<Produto> ListaProdutos = new List<Produto>();
        public string Cadastrar(Produto produto)
        {
            ListaProdutos.Add(produto);

            return "Produto cadastrado com sucesso";
        }

        public string Deletar(Produto produto)
        {
            ListaProdutos.Remove(produto);

            return "Produto cadastrado com sucesso";
        }

        public void Listar()
        {
            foreach (Produto p in ListaProdutos)
            {
               Console.WriteLine($@"
Nome: {p.NomeProduto}
Preço: {p.Preco:C2}
Data de Cadastro: {p.DataCadastro}
Marca: {p.marca}
Cadastrado por {CadastradoPor}"); 
            }
        }
    }
}
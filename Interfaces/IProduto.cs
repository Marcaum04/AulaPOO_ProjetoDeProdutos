using Projetos_Produtos.Classes;

namespace Projetos_Produtos.Interfaces
{
    public interface IProduto
    {
         string Cadastrar(Produto produto);

         string Deletar(Produto produto);

         void Listar();
    }
}
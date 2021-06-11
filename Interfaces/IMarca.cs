using Projetos_Produtos.Classes;

namespace Projetos_Produtos.Interfaces
{
    public interface IMarca
    {
         string Cadastrar(Marca marca);

         string Deletar(Marca marca);

         void Listar();
    }
}
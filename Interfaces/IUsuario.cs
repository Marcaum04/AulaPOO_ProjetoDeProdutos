using Projetos_Produtos.Classes;

namespace Projetos_Produtos.Interfaces
{
    public interface IUsuario
    {
         string Cadastrar(Usuario usuario);
         string Deletar(Usuario usuario);
    }
}
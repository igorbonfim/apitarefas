using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositories.Interfaces;

public interface IUsuarioRepository
{
    Task<List<UsuarioModel>> BuscarUsuarios();
    Task<UsuarioModel> BuscarPorId(int id);
    Task<UsuarioModel> Adicionar(UsuarioModel usuario);
    Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
    Task<bool> Apagar(int id);

}

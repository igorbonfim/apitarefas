using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models;

public class TarefaModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public StatusTarefa Status { get;  set; }
    public int? UsuarioID { get; set; }
    public virtual UsuarioModel? Usuario { get; set; }
}

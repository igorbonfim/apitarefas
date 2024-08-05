using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly SistemaDeTarefasDbContext _dbContext;

    public TarefaRepository(SistemaDeTarefasDbContext sistemaDeTarefasDbContext)
    {
        _dbContext = sistemaDeTarefasDbContext;
    }

    public async Task<TarefaModel> BuscarPorId(int id)
    {
        return await _dbContext.Tarefas
            .Include(x => x.Usuario)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<TarefaModel>> BuscarTarefas()
    {
        return await _dbContext.Tarefas
            .Include (x => x.Usuario)
            .ToListAsync();
    }

    public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();
        return tarefa;
    }

    public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
    {
        TarefaModel tarefaPorId = await BuscarPorId(id);

        if (tarefaPorId == null)
        {
            throw new Exception($"A tarefa pro ID: {id} não foi encontrada no banco de dados");
        }

        tarefaPorId.Nome = tarefa.Nome;
        tarefaPorId.Descricao = tarefa.Descricao;
        tarefaPorId.Status = tarefa.Status;
        tarefaPorId.UsuarioID = tarefa.UsuarioID;        

        _dbContext.Tarefas.Update(tarefaPorId);
        await _dbContext.SaveChangesAsync();

        return tarefaPorId;
    }

    public async Task<bool> Apagar(int id)
    {
        TarefaModel tarefaPorId = await BuscarPorId(id);

        if (tarefaPorId == null)
        {
            throw new Exception($"A tarefa pro ID: {id} não foi encontrada no banco de dados");
        }

        _dbContext.Tarefas.Remove(tarefaPorId);
        await _dbContext.SaveChangesAsync();
        return true;
    }       
}

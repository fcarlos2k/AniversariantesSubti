using AniversariantesSubti.Models;

namespace AniversariantesSubti.Repositories.Interfaces;

public interface IAniversariantesRepository
{
    IEnumerable<Aniversariantes> ObterTodos();
    Aniversariantes? ObterPorId(int Id);
    IEnumerable<Aniversariantes> ObterPorNome(string Nome);
    void Adicionar(Aniversariantes aniversariantes);
    void Remover(int Id);
}

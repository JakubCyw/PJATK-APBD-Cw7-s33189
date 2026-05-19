using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IPCsService
{
    Task<IEnumerable<PC>> GetAllResponseAsync(CancellationToken cancellationToken);
    Task<PC2> GetByIdResponseAsync(int id, CancellationToken cancellationToken);
    Task<PC> AddAsync(CreatePC request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePC request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}
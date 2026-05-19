using Microsoft.EntityFrameworkCore;
using WebApplication1.Dtos;
using WebApplication1.Exceptions;
using WebApplication1.Infrastructure;
using WebApplication1.Models;
using ComponentManufacturers = WebApplication1.Dtos.ComponentManufacturers;
using Components = WebApplication1.Models.Components;
using PCComponents = WebApplication1.Dtos.PCComponents;

namespace WebApplication1.Services;

public class PCsService(DatabaseContext ctx) : IPCsService
{
    public async Task<IEnumerable<PC>> GetAllResponseAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(pc => new PC(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock)).ToListAsync(cancellationToken);
    }

    public async Task<PC2> GetByIdResponseAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(e => e.Id == id)
            .Select(pc => new PC2(
                pc.Id,
                pc.Name,
                pc.Weight,
                pc.Warranty,
                pc.CreatedAt,
                pc.Stock,
                pc.PCComponents.Select(pcc => new PCComponents(
                    pcc.Amount,
                    new Dtos.Components(
                        pcc.Components.Code,
                        pcc.Components.Name,
                        pcc.Components.Description,
                        new Dtos.ComponentManufacturers(
                            pcc.Components.ComponentManufacturers.Id,
                            pcc.Components.ComponentManufacturers.Abbreviation,
                            pcc.Components.ComponentManufacturers.FullName,
                            pcc.Components.ComponentManufacturers.FoundationDate
                            ),
                        new Dtos.ComponentType(
                            pcc.Components.ComponentTypes.Id,
                            pcc.Components.ComponentTypes.Abbreviation,
                            pcc.Components.ComponentTypes.Name
                            )
                        )
                    ))
                ))
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException("PC not found");
    }

    public async Task<PC> AddAsync(CreatePC request, CancellationToken cancellationToken)
    {
        var PC = new PCs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock,
        };
        ctx.Add(PC);
        await ctx.SaveChangesAsync(cancellationToken);

        return new PC(
            PC.Id,
            PC.Name,
            PC.Weight,
            PC.Warranty,
            PC.CreatedAt,
            PC.Stock
            );
    }

    public async Task UpdateAsync(int id, UpdatePC request, CancellationToken cancellationToken)
    {
        var PC = await ctx.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (PC == null)
            {
            throw new NotFoundException("PC not found");
            }
        PC.Name = request.Name;
        PC.Weight = request.Weight;
        PC.Warranty = request.Warranty;
        PC.CreatedAt = request.CreatedAt;
        PC.Stock = request.Stock;
        await ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var PC = await ctx.PCs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (PC == null)
            {
            throw new NotFoundException("PC not found");
            }
        ctx.PCs.Remove(PC);
        await ctx.SaveChangesAsync(cancellationToken);
    }
}
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController(IPCsService service) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAllResponse(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllResponseAsync(cancellationToken));
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetByIdResponse([FromRoute] int id, CancellationToken cancellationToken)
    {
        return Ok(await service.GetByIdResponseAsync(id, cancellationToken));
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePC request, CancellationToken cancellationToken)
    {
        var PC = await service.AddAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetByIdResponse), new { id = PC.Id }, PC);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePC request, CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdateAsync(id, request, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeleteAsync(id, cancellationToken);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
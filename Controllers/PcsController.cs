using apbd_cw7_EntityFramework.DTOs;
using apbd_cw7_EntityFramework.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_cw7_EntityFramework.Controllers;

[Route("api/pcs")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IPcsService _pcsService;

    public PcsController(IPcsService pcsService)
    {
        _pcsService = pcsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _pcsService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var result = await _pcsService.GetComponentsByPcIdAsync(id);
        if (result is null)
            return NotFound($"PC with id {id} not found.");
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PcCreateDto dto)
    {
        var created = await _pcsService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PcUpdateDto dto)
    {
        var updated = await _pcsService.UpdateAsync(id, dto);
        if (!updated)
            return NotFound($"PC with id {id} not found.");
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _pcsService.DeleteAsync(id);
        if (!deleted)
            return NotFound($"PC with id {id} not found.");
        return NoContent();
    }
}

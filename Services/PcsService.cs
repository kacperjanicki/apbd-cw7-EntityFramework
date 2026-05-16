using apbd_cw7_EntityFramework.DAL;
using apbd_cw7_EntityFramework.DTOs;
using apbd_cw7_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw7_EntityFramework.Services;

public class PcsService : IPcsService
{
    private readonly PcsDbContext _context;

    public PcsService(PcsDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PcGetAllDto>> GetAllAsync()
    {
        return await _context.Pcs
            .Select(p => new PcGetAllDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PcComponentDto>?> GetComponentsByPcIdAsync(int pcId)
    {
        var pcExists = await _context.Pcs.AnyAsync(p => p.Id == pcId);
        if (!pcExists)
            return null;

        return await _context.PcComponents
            .Where(pc => pc.PcId == pcId)
            .Select(pc => new PcComponentDto
            {
                ComponentCode = pc.ComponentCode,
                ComponentName = pc.Component.Name,
                Description = pc.Component.Description,
                Amount = pc.Amount,
                ManufacturerName = pc.Component.Manufacturer.FullName,
                ComponentTypeName = pc.Component.ComponentType.Name
            })
            .ToListAsync();
    }

    public async Task<PcGetAllDto> CreateAsync(PcCreateDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.Pcs.Add(pc);
        await _context.SaveChangesAsync();

        return new PcGetAllDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, PcUpdateDto dto)
    {
        var pc = await _context.Pcs.FindAsync(id);
        if (pc is null)
            return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.Pcs.FindAsync(id);
        if (pc is null)
            return false;

        _context.Pcs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }
}

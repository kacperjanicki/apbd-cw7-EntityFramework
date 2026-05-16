using apbd_cw7_EntityFramework.DTOs;

namespace apbd_cw7_EntityFramework.Services;

public interface IPcsService
{
    Task<IEnumerable<PcGetAllDto>> GetAllAsync();
    Task<IEnumerable<PcComponentDto>?> GetComponentsByPcIdAsync(int pcId);
    Task<PcGetAllDto> CreateAsync(PcCreateDto dto);
    Task<bool> UpdateAsync(int id, PcUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}

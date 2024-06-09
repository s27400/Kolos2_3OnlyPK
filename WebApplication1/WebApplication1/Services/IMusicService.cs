using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IMusicService
{
    public Task<GetMusicianInfoDTO> GetInfo(int musicianId, CancellationToken token);
    public Task<string> AddMusician(AddDTO dto, CancellationToken token);
}
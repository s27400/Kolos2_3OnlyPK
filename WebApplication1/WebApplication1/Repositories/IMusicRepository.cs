using WebApplication1.DTOs;

namespace WebApplication1.Repositories;

public interface IMusicRepository
{
    public Task<int> EnsureMusicianExists(int id, CancellationToken token);
    public Task<GetMusicianInfoDTO> GetMusicianWithTracks(int id, CancellationToken token);
    public Task<string> AddMusician(AddDTO dto, CancellationToken token);
    public Task<int> GetNewMusicianID(AddDTO dto, CancellationToken token);
    public Task<int> GetTrackId(AddDTO dto, CancellationToken token);
    public Task<string> AddTrack(AddDTO dto, CancellationToken token);

    public Task<string> AddMusicianToTrack(int musicianId, int trackId, CancellationToken token);
    public Task<int> TransactionAdding(AddDTO dto, CancellationToken token);
}
using WebApplication1.DTOs;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class MusicService : IMusicService
{

    private readonly IMusicRepository _musicRepository;

    public MusicService(IMusicRepository musicRepository)
    {
        _musicRepository = musicRepository;
    }

    public async Task<GetMusicianInfoDTO> GetInfo(int musicianId, CancellationToken token)
    {
        int verify = await _musicRepository.EnsureMusicianExists(musicianId, token);

        if (verify == -1)
        {
            return new GetMusicianInfoDTO()
            {
                Musician =
                {
                    IdMuzyk = -199,
                    Imie = "asd",
                    Nazwisko = "dsad"
                },
                Tracks = new List<TrackDTO>()
            };
        }

        return await _musicRepository.GetMusicianWithTracks(musicianId, token);
    }

    public async Task<string> AddMusician(AddDTO dto, CancellationToken token)
    {
        int res = await _musicRepository.TransactionAdding(dto, token);
        if (res == -1)
        {
            return "Error: Transaction problem";
        }

        return "Everything added";
    }

}
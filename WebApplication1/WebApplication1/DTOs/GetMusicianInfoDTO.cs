namespace WebApplication1.DTOs;

public class GetMusicianInfoDTO
{
    public MusicianDTO Musician { get; set; }
    public List<TrackDTO> Tracks { get; set; }
}
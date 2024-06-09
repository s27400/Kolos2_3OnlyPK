using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicController : ControllerBase
{
    private readonly IMusicService _musicService;

    public MusicController(IMusicService musicService)
    {
        _musicService = musicService;
    }

    [HttpGet("{musicianId}")]
    public async Task<IActionResult> GetMusician(int musicianId, CancellationToken token)
    {
        var res = await _musicService.GetInfo(musicianId, token);

        if (res.Musician.IdMuzyk == -199)
        {
            return NotFound($"Nie ma muzyka o id : {musicianId}");
        }

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddMusician(AddDTO dto, CancellationToken token)
    {
        string res = await _musicService.AddMusician(dto, token);

        if (res.StartsWith("Error"))
        {
            return NotFound(res);
        }

        return Ok(res);
    }
}
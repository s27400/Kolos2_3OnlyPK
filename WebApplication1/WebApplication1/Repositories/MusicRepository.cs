using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Entities;

namespace WebApplication1.Repositories;

public class MusicRepository : IMusicRepository
{

    private readonly MusicDbContext _context;

    public MusicRepository(MusicDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> EnsureMusicianExists(int id, CancellationToken token)
    {
        var res = await _context.Muzycy
            .FirstOrDefaultAsync(x => x.IdMuzyk == id, token);

        if (res == null)
        {
            return -1;
        }

        return res.IdMuzyk;
    }

    public async Task<GetMusicianInfoDTO> GetMusicianWithTracks(int id, CancellationToken token)
    {
        var tempQuery = _context.Muzycy
            .Where(x => x.IdMuzyk == id)
            .Include(x => x.IdUtwor);
        
        var res = await tempQuery
            .Select(x => new GetMusicianInfoDTO()
            {
                Musician = new MusicianDTO()
                {
                    IdMuzyk = x.IdMuzyk,
                    Imie = x.Imie,
                    Nazwisko = x.Nazwisko,
                    Pseudonim = x.Pseudonim
                },
                Tracks = x.IdUtwor.Select(t => new TrackDTO()
                {
                    IdUtwor = t.IdUtwor,
                    CzasTrwania = t.CzasTrwania,
                    NazwaUtworu = t.NazwaUtworu
                }).ToList()
            }).ToListAsync(token);

        return res[0];
    }



    public async Task<string> AddMusician(AddDTO dto, CancellationToken token)
    {
        Muzyk muzyk = new Muzyk()
        {
            Imie = dto.Imie,
            Nazwisko = dto.Nazwisko,
            Pseudonim = dto.Pseudonim
        };

        await _context.Muzycy.AddAsync(muzyk, token);
        await _context.SaveChangesAsync(token);
        return "Musician Added";
    }


    public async Task<int> GetNewMusicianID(AddDTO dto, CancellationToken token)
    {
        if (dto.Pseudonim == null)
        {
            var temp = await _context.Muzycy
                .FirstOrDefaultAsync(x => x.Imie == dto.Imie && x.Nazwisko == dto.Nazwisko, token);

            return temp.IdMuzyk;
        }

        var res = await _context.Muzycy
            .FirstOrDefaultAsync(x => x.Imie == dto.Imie && x.Nazwisko == dto.Nazwisko && x.Pseudonim == dto.Pseudonim, token);
        return res.IdMuzyk;
    }

    public async Task<int> GetTrackId(AddDTO dto, CancellationToken token)
    {
        var res = await _context.Utwory
            .FirstOrDefaultAsync(x =>
                x.NazwaUtworu == dto.NazwaUtworu && Math.Abs(x.CzasTrwania - dto.CzasTrwania) < 0.001 * x.CzasTrwania, token);

        if (res == null)
        {
            return -1;
        }

        return res.IdUtwor;
    }

    public async Task<string> AddTrack(AddDTO dto, CancellationToken token)
    {
        Utwor utwor = new Utwor()
        {
            CzasTrwania = dto.CzasTrwania,
            NazwaUtworu = dto.NazwaUtworu
        };

        await _context.Utwory.AddAsync(utwor, token);

        await _context.SaveChangesAsync(token);

        return "Track Added";
    }

    public async Task<string> AddMusicianToTrack(int musicianId, int trackId, CancellationToken token)
    {
        Muzyk muzyk = await _context.Muzycy
            .FirstOrDefaultAsync(x => x.IdMuzyk == musicianId, token);

        Utwor utwor = await _context.Utwory
            .FirstOrDefaultAsync(x => x.IdUtwor == trackId, token);
        
        muzyk.IdUtwor.Add(utwor);

        await _context.SaveChangesAsync(token);
        return "Dodano wszystko";
    }

    public async Task<int> TransactionAdding(AddDTO dto, CancellationToken token)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(token);
        try
        {
            await AddMusician(dto, token);
            int musicianId = await GetNewMusicianID(dto, token);

            int trackId = await GetTrackId(dto, token);
            if (trackId == -1)
            {
                await AddTrack(dto, token);
                trackId = await GetTrackId(dto, token);
            }

            await AddMusicianToTrack(musicianId, trackId, token);
            await transaction.CommitAsync(token);
            return 0;
        }
        catch (Exception e)
        {
             await transaction.RollbackAsync(token);
             return -1;
        }
    }

    
}
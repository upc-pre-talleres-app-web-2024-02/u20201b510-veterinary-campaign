using U20201B510VeterinaryCampaign.API.Shared.Domain.Repositories;
using U20201B510VeterinaryCampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace U20201B510VeterinaryCampaign.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWOrk
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}
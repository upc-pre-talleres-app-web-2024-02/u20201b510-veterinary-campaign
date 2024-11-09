using Microsoft.EntityFrameworkCore;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Repositories;
using U20201B510VeterinaryCampaign.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using U20201B510VeterinaryCampaign.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace U20201B510VeterinaryCampaign.API.CRM.Infrastructure.Persistence.EFC.Repositories;

public class ManagerRepository(AppDbContext context) : BaseRepository<Manager>(context), IManagerRepository
{
    
    public async Task<bool> existsManagerByFirstNameAndLastNameAsync(string firstName, string lastName)
    {
        return await Context.Set<Manager>().AnyAsync(manager => manager.FirstName == firstName && manager.LastName == lastName);
    }
}
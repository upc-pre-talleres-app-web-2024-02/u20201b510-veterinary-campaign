using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.Shared.Domain.Repositories;

namespace U20201B510VeterinaryCampaign.API.CRM.Domain.Repositories;

public interface IManagerRepository : IBaseRepository<Manager>
{
    Task<bool> existsManagerByFirstNameAndLastNameAsync(string firstName, string lastName);
}
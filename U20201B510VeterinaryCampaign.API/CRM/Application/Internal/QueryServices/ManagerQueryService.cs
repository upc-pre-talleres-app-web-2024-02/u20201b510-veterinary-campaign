using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Queries;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Repositories;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Services;
using U20201B510VeterinaryCampaign.API.Shared.Domain.Repositories;

namespace U20201B510VeterinaryCampaign.API.CRM.Application.Internal.QueryServices;

public class ManagerQueryService(IManagerRepository managerRepository, IUnitOfWOrk unitOfWork) : IManagerQueryService
{
    public async Task<IEnumerable<Manager>> Handle(GetAllManagerQuery query)
    {
        return await managerRepository.ListAsync();
    }

    public async Task<Manager?> Handle(GetManagerByIdQuery query)
    {
        return await managerRepository.FindByIdAsync(query.Id);
    }
    
}
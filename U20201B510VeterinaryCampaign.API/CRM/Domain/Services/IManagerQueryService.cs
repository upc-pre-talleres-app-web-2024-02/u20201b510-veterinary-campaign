using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Queries;

namespace U20201B510VeterinaryCampaign.API.CRM.Domain.Services;

public interface IManagerQueryService
{ 
    Task<IEnumerable<Manager>> Handle(GetAllManagerQuery query); 
    Task<Manager?> Handle(GetManagerByIdQuery query);
}
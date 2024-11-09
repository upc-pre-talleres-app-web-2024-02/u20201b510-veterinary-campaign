using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Commands;

namespace U20201B510VeterinaryCampaign.API.CRM.Domain.Services;

public interface IManagerCommandService
{
    Task<Manager?> Handle(CreateManagerCommand command);
    
}
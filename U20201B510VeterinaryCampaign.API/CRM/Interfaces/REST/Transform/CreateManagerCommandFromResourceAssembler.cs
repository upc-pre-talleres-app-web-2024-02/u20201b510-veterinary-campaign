using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Commands;
using U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST.Resources;

namespace U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST.Transform;

public static class CreateManagerCommandFromResourceAssembler
{
    public static CreateManagerCommand ToCommandFromResource(CreateManagerResource resource)
    {
        return new CreateManagerCommand(
            resource.VeterinaryCampaignManagerId,
            resource.FirstName,
            resource.LastName,
            resource.Status,
            resource.ContactedAt,
            resource.ApprovedAt,
            resource.ReportedAt);
    }
    
}
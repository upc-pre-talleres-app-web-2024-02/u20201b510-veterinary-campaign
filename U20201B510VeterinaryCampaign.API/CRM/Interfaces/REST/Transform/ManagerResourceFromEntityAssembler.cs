using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.ValueObjects;
using U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST.Resources;

namespace U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST.Transform;

public static class ManagerResourceFromEntityAssembler
{
    public static ManagerResource ToResourceFromEntity(Manager entity)
    {
        return new ManagerResource(
            entity.Id,
            entity.VeterinaryCampaignManagerId,
            entity.FirstName,
            entity.LastName,
            entity.Status.ToString(),
            entity.ContactedAt,
            entity.ApprovedAt,
            entity.ReportedAt);
    }
}


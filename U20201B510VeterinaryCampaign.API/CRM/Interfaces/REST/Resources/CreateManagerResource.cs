namespace U20201B510VeterinaryCampaign.API.CRM.Interfaces.REST.Resources;

public record CreateManagerResource(
    string VeterinaryCampaignManagerId,
    string FirstName, 
    string LastName,
    string Status, 
    DateTime? ContactedAt, 
    DateTime? ApprovedAt, 
    DateTime? ReportedAt);
    
    

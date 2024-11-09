namespace U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Commands;



//public string VeterinaryCampaignManagerId { get; set; }
//public string FirstName { get; set; }
//public string LastName { get; set; }
//public EStatus? Status { get; set; }
//public  Guid AssignedSalesAgentId { get; set; }
//public DateTime? ContactedAt { get; set; }
//public DateTime? ApprovedAt { get; set; }
//public DateTime? ReportedAt { get; set; }

public record CreateManagerCommand(
    string VeterinaryCampaignManagerId,
    string FirstName, 
    string LastName,
    string Status, 
    DateTime? ContactedAt, 
    DateTime? ApprovedAt, 
    DateTime? ReportedAt);
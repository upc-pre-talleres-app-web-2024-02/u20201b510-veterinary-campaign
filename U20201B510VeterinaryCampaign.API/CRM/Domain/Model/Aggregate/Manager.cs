using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Commands;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.ValueObjects;

namespace U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;

public partial class Manager
{
    public int Id { get; private set; }
    
    public string VeterinaryCampaignManagerId { get; private set; }
    public string FirstName { get;private  set; }
    public string LastName { get;private set; }
    public EStatus? Status { get; internal set; }
    public  Guid AssignedSalesAgentId { get;private set; }
    public DateTime? ContactedAt { get;private set; }
    public DateTime? ApprovedAt { get; private set; }
    public DateTime? ReportedAt { get;private  set; }
    
    
    public Manager()
    {
        this.VeterinaryCampaignManagerId = null;
        this.Status = null;
        this.ContactedAt = null;
        this.ApprovedAt = null;
        this.ReportedAt = null;
        this.AssignedSalesAgentId = Guid.NewGuid();
    }
    
    public Manager(CreateManagerCommand command) : this()
    {
        this.VeterinaryCampaignManagerId = command.VeterinaryCampaignManagerId;
        this.FirstName = command.FirstName;
        this.LastName = command.LastName;
        this.Status = Enum.Parse<EStatus>(command.Status);
        this.ContactedAt = command.ContactedAt;
        this.ApprovedAt = command.ApprovedAt;
        this.ReportedAt = command.ReportedAt;
    }
    
    
    
    public bool IsValidStatus(string status)
    {
        foreach (EStatus eStatus in Enum.GetValues(typeof(EStatus)))
        {
            if (eStatus.ToString().Equals(status))
            {
                return true;
            }
        }
        return false;
    }
    
}
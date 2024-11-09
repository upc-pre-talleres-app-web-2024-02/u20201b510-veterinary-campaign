using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Aggregate;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.Commands;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Model.ValueObjects;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Repositories;
using U20201B510VeterinaryCampaign.API.CRM.Domain.Services;
using U20201B510VeterinaryCampaign.API.Shared.Domain.Repositories;

namespace U20201B510VeterinaryCampaign.API.CRM.Application.Internal.CommandServices;

public class ManagerCommandService(IManagerRepository managerRepository, IUnitOfWOrk unitOfWork) : IManagerCommandService
{
    public async Task<Manager?> Handle(CreateManagerCommand command)
    {
        var manager = new Manager(command);
        
        //Validamos si existe dos managers con el mismo nombre y apellido
        bool exists = await managerRepository.existsManagerByFirstNameAndLastNameAsync(
            command.FirstName,
            command.LastName);
        
        if (exists) throw new Exception("A manager with the same data already exists.");
        
        //Validamos si el nombre y apellido tienen entre 4 y 40 caracteres
        if (string.IsNullOrEmpty(command.FirstName) || string.IsNullOrEmpty(command.LastName) || command.FirstName.Length < 4 || command.LastName.Length < 4 || command.FirstName.Length > 40 || command.LastName.Length > 40)
        {
            throw new Exception("The first name and last name must be between 4 and 40 characters long.");
        }
        
        //De no especificarse valor para status, se debe asignar el status Open. 
        if (string.IsNullOrEmpty(command.Status))
        {
            manager.Status = EStatus.Open;
        }
        
        //No permite que se registre un manager con un valor de status Contacted, MeetingSet, Qualified, 
        //Customer, OpportunityLost, Unqualified o InVeterinaryCustomer, si no se incluye un valor válido 
        //para contactedAt. 
        
        if (manager.Status 
            is EStatus.Contacted 
            or EStatus.MeetingSet 
            or EStatus.Qualified 
            or EStatus.Customer 
            or EStatus.OpportunityLost 
            or EStatus.Unqualified 
            or EStatus.InnVeterinaryCustomer)
        {
            if (command.ContactedAt == null) throw new Exception("The contactedAt field is required.");
        }
        
        //No permite que se registre un manager con un valor de status Qualified, Customer, 
        //OpportunityLost, Unqualified, o InVeterinaryCustomer, si no se incluye un valor válido para 
        //approvedAt. 
        
        if (manager.Status 
            is EStatus.Qualified 
            or EStatus.Customer 
            or EStatus.OpportunityLost 
            or EStatus.Unqualified 
            or EStatus.InnVeterinaryCustomer)
        {
            if (command.ApprovedAt == null) throw new Exception("The approvedAt field is required.");
            
        }
      
        //No permite que se registre un manager con un valor de status Unqualified, si no se incluye un 
        //valor válido para reportedAt. 
        
        if (manager.Status is EStatus.Unqualified)
        {
            if (command.ReportedAt == null) throw new Exception("The reportedAt field is required.");
            
        }
        
        
        if (!manager.IsValidStatus(command.Status)) throw new Exception("The status is not valid.");
        
        
        await managerRepository.AddAsync(manager);
        await unitOfWork.CompleteAsync();
        
        return manager;
    }
}
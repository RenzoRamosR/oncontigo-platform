namespace oncontigo_platform.HealthTracking.Domain.Model.Commands
{
    public record UpdateMedicineByIdCommand(int Id, string MedicineName,string MedicineDescription);
   
}

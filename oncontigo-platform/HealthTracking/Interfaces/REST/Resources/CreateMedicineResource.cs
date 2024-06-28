namespace oncontigo_platform.HealthTracking.Interfaces.REST.Resources
{
    public record CreateMedicineResource(string medicineName, string medicineDescription, int patientFollowUpId);
}

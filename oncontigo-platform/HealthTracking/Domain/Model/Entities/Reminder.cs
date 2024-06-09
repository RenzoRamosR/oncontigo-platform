namespace oncontigo_platform.HealthTracking.Domain.Model.Entities
{
    public partial class Reminder
    {
        public int Id { get; set; }
        public string Instruction { get; set; }

        public Reminder(string instruction)
        {
            Instruction = instruction;
        }
    }
}

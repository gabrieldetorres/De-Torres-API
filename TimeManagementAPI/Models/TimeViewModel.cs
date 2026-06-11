namespace TimeManagementAPI.Models
{
    public class TimeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TimeSpan TimeIn { get; set; }

        public TimeSpan Timeout { get; set; }
    }
}

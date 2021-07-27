namespace Kinoshka.Models.Entities
{
    public class JobStatus : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
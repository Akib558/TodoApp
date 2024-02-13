namespace WebApi3.Models
{
    public class TodoModelClass
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedTime { get; set; } // New property for created time

        public string UpdatedTime { get; set;}
        public string CompletedTime { get; set; } // New property for completed time

        public string IsCompleted { get; set; }

        // public string Labels { get; set;}
    }
}
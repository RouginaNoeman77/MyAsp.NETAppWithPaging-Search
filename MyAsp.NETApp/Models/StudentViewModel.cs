namespace MyAsp.NETApp.Models
{
    public class StudentViewModel
    {
        public string Name { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string City { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public bool IsEnrolled { get; set; }

        public int StudentId { get; set; }
    }
}

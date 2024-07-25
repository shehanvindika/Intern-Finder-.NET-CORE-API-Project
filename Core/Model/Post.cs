namespace Core.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Position { get; set; } = null!;
        public string ClosingDate { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CompanyId { get; set; }
        //public Company company { get; set; } = null!;
    }
}
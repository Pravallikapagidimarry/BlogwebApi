namespace BlogWebAPI.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public int UserId { get; set; } //Here the Author information is saved in the User table
                                        //and also the role of the Author whether admin or user
    }
}
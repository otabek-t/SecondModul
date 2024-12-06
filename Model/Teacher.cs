namespace filelar.Model;

public class Teacher
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Subject { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string LikesOrDislikes { get; set; }
}

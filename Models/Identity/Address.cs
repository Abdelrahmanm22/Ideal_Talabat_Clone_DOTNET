namespace Round2Api.Models.Identity
{
    public class Address : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String Country { get; set; }
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
    }
}

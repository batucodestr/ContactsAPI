namespace ContactsAPI.Models
{
    public class UpdateContactContextRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}

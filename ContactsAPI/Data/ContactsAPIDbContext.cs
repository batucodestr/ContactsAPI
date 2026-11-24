using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Data
{
    public class ContactsAPIDbContext : DbContext // DbContext sınıfından türetilmiş bir sınıf oluşturuluyor
    {
        public ContactsAPIDbContext(DbContextOptions<ContactsAPIDbContext> options) : base(options)
        {
            // options ile bağlantı dizisi alınmış olcak
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

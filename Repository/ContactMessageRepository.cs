using DreamProperties.Models;

namespace DreamProperties.Repository
{
    public class ContactMessageRepository : IContactMessageRepository
    {
        private readonly AppDbContext appDbContext;

        public ContactMessageRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task SaveContactMessages(ContactMessage contactMessage)
        {
            await this.appDbContext.SaveContactMessageAsync(contactMessage.Name, contactMessage.Email, contactMessage.Subject, contactMessage.Message);
        }
    }
}

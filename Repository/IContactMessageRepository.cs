using DreamProperties.Models;

namespace DreamProperties.Repository
{
    public interface IContactMessageRepository
    {
        Task SaveContactMessages(ContactMessage contactMessage);
    }
}

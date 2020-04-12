using Model.Entities;

namespace Repositories.Interfaces
{
    public interface IVolunteerRepository
    {
        Volunteer FindOne(string username, string password);
    }
}
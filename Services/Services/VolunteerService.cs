using System.ComponentModel.DataAnnotations;
using Model.Entities;
using Repositories.Interfaces;

namespace Services.Services
{
    public class VolunteerService
    {
        private IVolunteerRepository _volunteerRepository;

        public VolunteerService(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public Volunteer Login(string username, string password)
        {
            Volunteer volunteer = _volunteerRepository.FindOne(username, password);
            if (volunteer == null)
            {
                throw new ValidationException("Unregistered volunteer!");
            }

            return volunteer;
        }
    }
}
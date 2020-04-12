using System;
using Model.Entities;

namespace Networking.Requests
{
    [Serializable]
    public class LoginRequest : IRequest
    {
        private Volunteer _volunteer;

        public LoginRequest(Volunteer volunteer)
        {
            _volunteer = volunteer;
        }

        public Volunteer Volunteer => _volunteer;
    }
}
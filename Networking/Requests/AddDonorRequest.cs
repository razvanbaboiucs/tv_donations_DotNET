using System;

namespace Networking.Requests
{
    [Serializable]
    public class AddDonorRequest : IRequest
    {
        private string name, address, phoneNumber;

        public AddDonorRequest(string name, string address, string phoneNumber)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }

        public string Name => name;

        public string Address => address;

        public string PhoneNumber => phoneNumber;
    }
}
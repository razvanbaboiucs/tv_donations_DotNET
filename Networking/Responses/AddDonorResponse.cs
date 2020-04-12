using System;

namespace Networking.Responses
{
    [Serializable]
    public class AddDonorResponse : IResponse
    {
        private int did;

        public AddDonorResponse(int did)
        {
            this.did = did;
        }

        public int Did => did;
    }
}
using System;

namespace Networking.Requests
{
    [Serializable]
    public class GetAllDonorsBySubstringRequest : IRequest
    {
        private string _substring;

        public GetAllDonorsBySubstringRequest(string substring)
        {
            _substring = substring;
        }

        public string Substring => _substring;
    }
}
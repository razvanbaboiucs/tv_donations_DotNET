using System;
using System.Collections.Generic;
using Model.Entities;

namespace Networking.Responses
{
    [Serializable]
    public class GetAllDonorsBySubstringResponse : IResponse
    {
        private IEnumerable<Donor> _donors;

        public GetAllDonorsBySubstringResponse(IEnumerable<Donor> donors)
        {
            _donors = donors;
        }

        public IEnumerable<Donor> Donors => _donors;
    }
}
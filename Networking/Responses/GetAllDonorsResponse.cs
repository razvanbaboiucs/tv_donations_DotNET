using System;
using System.Collections.Generic;
using Model.Entities;

namespace Networking.Responses
{
    [Serializable]
    public class GetAllDonorsResponse : IResponse
    {
        private IEnumerable<Donor> _donors;

        public GetAllDonorsResponse(IEnumerable<Donor> donors)
        {
            this._donors = donors;
        }

        public IEnumerable<Donor> Donors => _donors;
    }
}
using System;
using System.Collections.Generic;
using Model.Entities;

namespace Networking.Responses.UpdateResponses
{
    [Serializable]
    public class NewDonationAddedUpdate : IUpdateResponse
    {
        private IEnumerable<Donor> _donors;
        private IEnumerable<Case> _cases;

        public NewDonationAddedUpdate(IEnumerable<Donor> donors, IEnumerable<Case> cases)
        {
            _donors = donors;
            _cases = cases;
        }

        public IEnumerable<Donor> Donors => _donors;

        public IEnumerable<Case> Cases => _cases;
    }
}
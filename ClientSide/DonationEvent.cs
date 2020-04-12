using System.Collections.Generic;
using Model.Entities;

namespace ClientServer_TvDonationsProject
{
    public class DonationEvent
    {
        private IEnumerable<Donor> _donors;
        private IEnumerable<Case> _cases;

        public DonationEvent(IEnumerable<Donor> donors, IEnumerable<Case> cases)
        {
            _donors = donors;
            _cases = cases;
        }

        public IEnumerable<Donor> Donors => _donors;

        public IEnumerable<Case> Cases => _cases;
    }
}
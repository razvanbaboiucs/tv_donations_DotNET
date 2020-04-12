using System.Collections.Generic;
using Model.Entities;

namespace Services
{
    public interface IObserver
    {
        void DonationAdded(IEnumerable<Donor> donors, IEnumerable<Case> cases);
    }
}
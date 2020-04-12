using System.Collections.Generic;
using Model.Entities;

namespace Services
{
    public interface IService
    {
        void NotifyObserversDonationAdded();
        void Logout(IObserver client);
        Volunteer FindVolunteer(string username, string password, IObserver client);
        int AddDonor(string name, string address, string phoneNumber);
        IEnumerable<Donor> FindAllDonors();
        IEnumerable<Donor> FindAllDonorsBySubstring(string substring);
        IEnumerable<Case> FindAllCases();
        void AddDonation(int did, int cid, double sumDonated);
        void UpdateCase(int caseId, double sumToAdd);
    }
}
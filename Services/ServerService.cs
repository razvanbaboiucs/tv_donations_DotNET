using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Entities;
using Services.Services;

namespace Services
{
    public class ServerService : IService
    {

        private CaseService _caseService;
        private DonorService _donorService;
        private VolunteerService _volunteerService;
        private DonationService _donationService;
        private IList<IObserver> _observers = new List<IObserver>();
        public ServerService(CaseService caseService, DonorService donorService, VolunteerService volunteerService, DonationService donationService)
        {
            _caseService = caseService;
            _donorService = donorService;
            _volunteerService = volunteerService;
            _donationService = donationService;
        }

        public void NotifyObserversDonationAdded()
        {
            IEnumerable<Donor> donors = FindAllDonors();
            IEnumerable<Case> cases = FindAllCases();
            foreach (var observer in _observers)
            {
                Task.Run(() => observer.DonationAdded(donors, cases));
            }
        }

        public void Logout(IObserver client)
        {
            _observers.Remove(client);
        }

        public Volunteer FindVolunteer(string username, string password, IObserver client)
        {
            Volunteer volunteer = _volunteerService.Login(username, password);
            _observers.Add(client);
            return volunteer;
        }

        public int AddDonor(string name, string address, string phoneNumber)
        {
            int id = _donorService.AddDonor(name, address, phoneNumber);
            return id;
        }

        public IEnumerable<Donor> FindAllDonors()
        {
            return _donorService.FindAll();
        }

        public IEnumerable<Donor> FindAllDonorsBySubstring(string substring)
        {
            return _donorService.FindDonorsBySubstring(substring);
        }

        public IEnumerable<Case> FindAllCases()
        {
            return _caseService.FindAll();
        }

        public void AddDonation(int did, int cid, double sumDonated)
        {
            _donationService.AddDonation(cid, did, sumDonated);
            UpdateCase(cid, sumDonated);
        }

        public void UpdateCase(int caseId, double sumToAdd)
        {
            _caseService.UpdateCase(caseId, sumToAdd);
        }
    }
}
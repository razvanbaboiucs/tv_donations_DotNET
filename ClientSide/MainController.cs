using System;
using System.Collections.Generic;
using Model.Entities;
using Services;

namespace ClientServer_TvDonationsProject
{
    public class MainController : IObserver
    {
        private IService _serverService;
        public event EventHandler<DonationEvent> updateEvent;

        public IService ServerService => _serverService;

        public MainController(IService serverService)
        {
            _serverService = serverService;
        }

        public Volunteer FindVolunteer(string username, string password)
        {
            return ServerService.FindVolunteer(username, password, this);
        }
        public IEnumerable<Donor> FindAllDonors()
        {
            return ServerService.FindAllDonors();
        }

        public IEnumerable<Case> FindAllCases()
        {
            return ServerService.FindAllCases();
        }

        public int AddDonor(string name, string address, string phoneNumber)
        {
            return ServerService.AddDonor(name, address, phoneNumber);
        }

        public void AddDonation(int donorId, int caseId, double sumToDonate)
        {
            ServerService.AddDonation(donorId, caseId, sumToDonate);
        }

        public IEnumerable<Donor> FindAllDonorsBySubstring(string substring)
        {
            return ServerService.FindAllDonorsBySubstring(substring);
        }

        public void DonationAdded(IEnumerable<Donor> donors, IEnumerable<Case> cases)
        {
            Console.WriteLine("Donation added ...");
            DonationEvent donationEvent = new DonationEvent(donors, cases);
            OnUserEvent(donationEvent);
        }

        public void Logout()
        {
            ServerService.Logout(this);
        }

        private void OnUserEvent(DonationEvent donationEvent)
        {
            if (updateEvent == null)
            {
                return;
            }

            updateEvent(this, donationEvent);
            Console.WriteLine("Update event called ...");
        }
    }
}
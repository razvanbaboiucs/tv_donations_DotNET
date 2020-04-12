using Model.Entities;
using Repositories.Interfaces;

namespace Services.Services
{
    public class DonationService
    {
        private IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public void AddDonation(int caseId, int donorId, double sumToDonate)
        {
            Donation donation = new Donation(sumToDonate, caseId, donorId);
            _donationRepository.Add(donation);
        }
    }
}
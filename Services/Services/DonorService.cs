using System.Collections.Generic;
using Model.Entities;
using Repositories.Interfaces;

namespace Services.Services
{
    public class DonorService
    {
        private IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public int AddDonor(string name, string address, string phoneNumber) 
        {
            Donor donor = new Donor(0, name, address, phoneNumber);
            return _donorRepository.Add(donor);
        }

        public IEnumerable<Donor> FindAll()
        {
            return _donorRepository.FindAll();
        }

        public IEnumerable<Donor> FindDonorsBySubstring(string substring)
        {
            return _donorRepository.FindBySubstring(substring);
        }
    }
}
using System.Collections.Generic;
using Model.Entities;
using Repositories.Interfaces;

namespace Services.Services
{
    public class CaseService
    {
        private ICaseRepository _caseRepository;

        public CaseService(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        public IEnumerable<Case> FindAll()
        {
            return _caseRepository.FindAll();
        }

        public void UpdateCase(int cid, double sumToAdd)
        {
            double sum = _caseRepository.FindOne(cid).TotalSumDonated + sumToAdd;
            _caseRepository.Update(cid, sum);
        }
    }
}
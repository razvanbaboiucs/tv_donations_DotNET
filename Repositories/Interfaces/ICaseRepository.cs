using System.Collections.Generic;
using Model.Entities;

namespace Repositories.Interfaces
{
    public interface ICaseRepository
    {
        void Update(int caseId, double sumToDonate);
        Case FindOne(int id);
        IEnumerable<Case> FindAll();
    }
}
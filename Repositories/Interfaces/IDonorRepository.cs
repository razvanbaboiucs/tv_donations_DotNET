using System.Collections.Generic;
using Model.Entities;

namespace Repositories.Interfaces
{
    public interface IDonorRepository
    {
        IEnumerable<Donor> FindBySubstring(string substring);
        int Add(Donor donor);
        void Delete(int id);
        void Update(Donor donor);
        Donor FindOne(int id);
        IEnumerable<Donor> FindAll();
    }
}
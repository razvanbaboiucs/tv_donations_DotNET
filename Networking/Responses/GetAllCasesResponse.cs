using System;
using System.Collections.Generic;
using Model.Entities;

namespace Networking.Responses
{
    [Serializable]
    public class GetAllCasesResponse : IResponse
    {
        private IEnumerable<Case> _cases;

        public GetAllCasesResponse(IEnumerable<Case> cases)
        {
            _cases = cases;
        }

        public IEnumerable<Case> Cases => _cases;
    }
}
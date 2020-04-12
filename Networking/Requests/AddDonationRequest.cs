
using System;

namespace Networking.Requests
{
    [Serializable]
    public class AddDonationRequest : IRequest
    {
        private int did, cid;
        private double sum;

        public AddDonationRequest(int did, int cid, double sum)
        {
            this.did = did;
            this.cid = cid;
            this.sum = sum;
        }

        public int Did => did;

        public int Cid => cid;

        public double Sum => sum;
    }
}
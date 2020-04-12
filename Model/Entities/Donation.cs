using System;
using System.Collections.Generic;

namespace Model.Entities
{
    [Serializable]
    public class Donation : IEntity<KeyValuePair<int, int>>
    {

        private KeyValuePair<int, int> _id;
        private int _donorId;

        public int DonorId
        {
            get => _donorId;
            set => _donorId = value;
        }

        public int CaseId
        {
            get => _caseId;
            set => _caseId = value;
        }

        private int _caseId;
        private double _sumDonated;

        public KeyValuePair<int, int> Id
        {
            get => _id;
            set => _id = value;
        }
        
        public double SumDonated
        {
            get => _sumDonated;
            set => _sumDonated = value;
        }

        public override string ToString()
        {
            return Id + " : " + SumDonated;
        }

       

        public Donation(double sumDonated, int caseId, int donorId)
        {
            Id = new KeyValuePair<int, int>(donorId, caseId);
            SumDonated = sumDonated;
            _caseId = caseId;
            _donorId = donorId;
        }

        public KeyValuePair<int, int> GetId()
        {
            return Id;
        }

        public void SetId(KeyValuePair<int, int> id)
        {
            Id = id;
        }
    }
}
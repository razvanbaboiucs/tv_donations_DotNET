﻿  using System;

   namespace Model.Entities
{
    [Serializable]
    public class Case : IEntity<int>
    {
        private int _id;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double TotalSumDonated
        {
            get => _totalSumDonated;
            set => _totalSumDonated = value;
        }

        private string _name;
        private double _totalSumDonated;
        

        public override string ToString()
        {
            return Id + " : " + Name + " : " + TotalSumDonated;
        }

        public Case(int id, string name, double totalSumDonated)
        {
            Id = id;
            Name = name;
            TotalSumDonated = totalSumDonated;
        }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
﻿﻿  using System;

    namespace Model.Entities
{
    [Serializable]
    public class Donor : IEntity<int>
    {
        private int _id;
        private string _name, _address, _phoneNumber;

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

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value;
        }

        public override string ToString()
        {
            return Id + " : " + Name + " : " + Address + " : " + PhoneNumber;
        }

        
        public Donor(int id, string name, string address, string phoneNumber)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public int GetId()
        {
            return this.Id;
        }

        public void SetId(int id)
        {
            this.Id = id;
        }
    }
}
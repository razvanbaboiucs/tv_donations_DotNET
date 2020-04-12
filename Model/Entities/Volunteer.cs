﻿  using System;

   namespace Model.Entities
{
    [Serializable]
    public class Volunteer : IEntity<int>
    {
        private int _id;
        private string _username;
        private string _password;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public override string ToString()
        {
            return _id + " : " + _username + " : " + _password;
        }
        
        public Volunteer(int id, string username, string password)
        {
            _id = id;
            _username = username;
            _password = password;
        }

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }
    }
}
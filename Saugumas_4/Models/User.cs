﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saugumas_4.Models
{
    public class User
    {
        private string nickname;
        private string accountPassword;
        private List<PasswordEntry> passwords;

        public User(string nickname, string password)
        {
            if (String.IsNullOrWhiteSpace(nickname))
                throw new Exception("Slapyvardis negali buti tuscias");
            if (String.IsNullOrWhiteSpace(password))
                throw new Exception("Slaptazodis negali buti tuscias");

            this.nickname = nickname;
            this.accountPassword = password;
            passwords = new List<PasswordEntry>();
        }

        public string GetNickname() => nickname;
        public string GetAccountPassword() => accountPassword;
        public void SetAccountPassword(string data)
        {
            accountPassword = data;
        }
        public PasswordEntry GetPassword(string title) => passwords.Find(x => x.Title == title);
        public void UpdatePassword(string title, PasswordEntry passwordEntry)
        {
            int index = passwords.FindIndex(x => x.Title == title);
            if (index == -1)
            {
                throw new Exception("Nepavyko rasti šio slaptažodžio");
            }
            passwords[index] = passwordEntry;
        }

        public void AddPassword(PasswordEntry password)
        {
            if (GetPasswordEntry(password.Title) != null)
                throw new Exception("Toks slaptažodis jau egzistuoja");
            
            passwords.Add(password);
        }

        public void RemovePassword(string title)
        {
            PasswordEntry pe = GetPasswordEntry(title);
            if (pe == null)
                throw new Exception("Toks slapatažodis neegzistuoja");
            passwords.Remove(pe);
        }

        public PasswordEntry GetPasswordEntry(string title)
        {
            int index = passwords.FindIndex(x => x.Title == title);
            if (index == -1)
                return null;

            return passwords[index];
        }

        public override string ToString()
        {
            string data = $"{nickname}, {accountPassword}\n";
            foreach (PasswordEntry pe in passwords)
            {
                data += pe.ToString();
            }

            return data;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMPsd.Factory
{
    public class UserFactory
    {
        public static User createMember(int RoleID, string Username, string Password, string Name, string Gender, string PhoneNumber, string Address, bool Banned)
        {
            User member = new User();

            member.RoleID = 1;
            member.Username = Username;
            member.Password = Password;
            member.Name = Name;
            member.Gender = Gender;
            member.PhoneNumber = PhoneNumber;
            member.Address = Address;
            member.Banned = false;

            return member;
        }

        public static User createAdmin(int RoleID, string Username, string Password, string Name, string Gender, string PhoneNumber, string Address)
        {
            User admin = new User();

            admin.RoleID = 2;
            admin.Username = Username;
            admin.Password = Password;
            admin.Name = Name;
            admin.Gender = Gender;
            admin.PhoneNumber = PhoneNumber;
            admin.Address = Address;

            return admin;
        }
    }
}
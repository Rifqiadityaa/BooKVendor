using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMPsd.Factory;

namespace TMPsd.Repository
{
    public class UserRepository
    {
        public static void insertMember(int RoleID, string Username, string Password, string Name, string Gender, string PhoneNumber, string Address, bool Banned)
        {
            User member = UserFactory.createMember(RoleID, Username, Password, Name, Gender, PhoneNumber, Address, Banned);

            Database1Entities db = new Database1Entities();
            db.Users.Add(member);
            db.SaveChanges();
        }

        public static void insertAdmin(int RoleID, string Username, string Password, string Name, string Gender, string PhoneNumber, string Address)
        {
            User admin = UserFactory.createAdmin(RoleID, Username, Password, Name, Gender, PhoneNumber, Address);

            Database1Entities db = new Database1Entities();
            db.Users.Add(admin);
            db.SaveChanges();
        }
    }
}
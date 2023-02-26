using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class User : Member
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; } = false;

        public User() : base()
        {
            
        }

        public bool CheckUserLogin(int userId, string userPass)
        {
            Dictionary<int, Member> listOfMembers = Program.MemberLists();

            bool exists = listOfMembers.ContainsKey(userId) ? true: false;

            if (exists && userPass == listOfMembers[userId].MemberPassword) 
            {
                Console.WriteLine($"Welcome {listOfMembers[userId].Name}!");
                this.IsLoggedIn = true;
                return IsLoggedIn;
            }

            else
            {
                bool runLoop = true;
                int _id;
                string _pass = string.Empty;
                do
                {
                    Console.WriteLine("\nIncorrect Credentials");
                    Console.Write("Enter User Id --> ");

                    bool checkUserId = int.TryParse(Console.ReadLine(), out int id);
                    
                    _id= id;

                    Console.Write("Enter User Pass --> ");
                    _pass = Console.ReadLine();

                    bool existsAgain = listOfMembers.ContainsKey(_id) ? true : false;

                    if (existsAgain && _pass == listOfMembers[_id].MemberPassword)
                    {
                        runLoop = false;
                        this.IsLoggedIn = true;
                        Console.WriteLine("Login Successfull. Welcome {0}.", listOfMembers[_id].Name);
                        return IsLoggedIn;
                    }
                    else
                    {
                        continue;
                    }

                } while (runLoop);
                return false;
            }


        }

        public bool ValidUser()
        {
            return false;
        }

        public void EditBookClass()
        {

        }

        public void EditLibraryClass()
        {

        }

        public void EditMemberClass()
        {

        }

    }
}

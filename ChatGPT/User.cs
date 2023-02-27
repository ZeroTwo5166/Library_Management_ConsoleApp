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



        public bool ValidUser()
        {
            return false;
        }

        public void EditBookClassAsUser()
        {

        }

        public void EditLibraryClassAsUser()
        {

        }

        public void EditMemberClassAs()
        {

        }

    }
}

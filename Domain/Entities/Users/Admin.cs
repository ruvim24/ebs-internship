using Domain.Entities.ObjectValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class Admin : BaseUser
    {
        public Admin(FullName fullName, Contacts contacts) : base(fullName, contacts)
        {
        }


        //make Master

        //make Service
            //first Master becouse Service can't exist without or to Select existing Masters??                       /*(entity Service must have Create() to enforce Creation of Master first)*/


    }
}

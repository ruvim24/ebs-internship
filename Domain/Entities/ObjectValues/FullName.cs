using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ObjectValues
{
    public class FullName
    {
        public string Name { get; private set; }
        public string Surename { get; private set; }

        public FullName(string name, string surename)
        {
            Name = name;
            Surename = surename;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }
        public void ChangeSurename(string newsurename)
        {
            Surename = newsurename;
        }
        public string GetFullName()
        {
            return $"{Name} {Surename}";
        }
    }
}

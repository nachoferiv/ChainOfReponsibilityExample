using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public interface IEmployee
    {
        void SetUsername(string username);
        string GetUsername();
        void SetName(string name);
        string GetName();
        void SetSurname(string surname);
        string GetSurname();
        string GetPosition();
    }
}

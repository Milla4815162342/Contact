using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts
{
    public class Sexes
    {
        static int _count = 3;
        static public string[] Get()
        {
            string[] list = new string[_count];

            list[0] = "Женский";

            list[1] = "Мужской";

            list[2] = "Не выбрано";

            return list;
        }
    }
}
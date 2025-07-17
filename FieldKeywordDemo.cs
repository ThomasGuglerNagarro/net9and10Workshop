using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;
internal class FieldKeywordDemo
{
    public string Username { get => field;
        set => field = value.Trim();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;
internal class RequiredMembersDemo
{
}

internal interface IUser
{
    string Name { get; init; }
}

internal class User : IUser
{
    public required string Name { get; init; }
}

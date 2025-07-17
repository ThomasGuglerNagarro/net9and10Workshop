using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;
public class Feature
{
    internal static bool IsFeatureEnabled => !AppContext.TryGetSwitch("Feature.IsEnabled", out var isEnabled) || isEnabled;

    internal static void DoIt()
    {
        if (IsFeatureEnabled)
        {
            Console.WriteLine("Feature is enabled.");
        }
        else
        {
            Console.WriteLine("Feature is disabled.");
        }
    }

}

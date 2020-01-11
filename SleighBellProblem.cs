using System;
using System.Reflection;
using System.Linq;

namespace codesofxmas
{
    public class SleighBellProblem : ISleighBellProblem
    {
        public object RingTheBells(Type sleighType)
        {
            var genericSleigh = sleighType.MakeGenericType(new Type[] { typeof(string) });
            dynamic magiClass = Activator.CreateInstance(genericSleigh, new object[] { "julemanden" });
            var methods = genericSleigh.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (var method in methods)
            {
                if (!method.IsPublic)
                {
                    continue;
                }
                var prs = method.GetParameters().Select(x => GetNonDefaultVal(x.ParameterType)).ToArray();
                method.Invoke(magiClass, prs);
            }
            return magiClass;
        }

        public object GetNonDefaultVal(Type t)
        {
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Convert.ChangeType(123, Nullable.GetUnderlyingType(t));
            }
            return Convert.ChangeType(123, t);
        }
    }
}


// nuget: Newtonsoft.Json@12.0.3
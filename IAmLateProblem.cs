using HarmonyLib;
using System;
using System.Reflection;
using static System.Console;

namespace IAmLateProblem
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var before = DateTime.Now;
            WriteLine($"Datetime now: {before:o}");

            IAmLateProblem l = new LateProblem();
            l.SkipNextXmas();

            var after = DateTime.Now;

            WriteLine($"Datetime now: {after:o}");

            if (before.AddYears(1) > after)
            {
                WriteLine("fail");
            }
            else
            {
                WriteLine("success");
            }

            if (after < before.AddYears(1))
            {
                WriteLine("fail");
            }
            else
            {
                WriteLine("success");
            }

            ReadLine();
        }
    }



    class LateProblem : IAmLateProblem
    {
        public void SkipNextXmas()
        {
            var harmony = new Harmony("SkipNextXmas");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(DateTime), "get_Now")]
    class get_Now
    {
        static DateTime Postfix(DateTime __result)
        {
            WriteLine("Entering the timemachine");
            return __result.AddYears(1);
        }
    }

    [HarmonyPatch(typeof(DateTime), "op_GreaterThan")]
    class op_GreaterThan
    {
        static bool Postfix(bool __result)
        {
            WriteLine("Fixed op_GreaterThan");
            return false;
        }
    }

    [HarmonyPatch(typeof(DateTime), "op_LessThan")]
    class op_LessThan
    {
        static bool Postfix(bool __result)
        {
            WriteLine("Fixed op_LessThan");
            return false;
        }
    }

    /// <summary>
    /// Christmas is but filled with stress and burdening parties.
    /// I'm always late for everything and never have enough time.
    /// Let's just skip next christmas.
    /// </summary>
    public interface IAmLateProblem
    {
        /// <summary>
        /// After calling this method, DateTime.Now must return
        /// a date at least 1 year in the future. Remember, anything
        /// goes (but Thread.Sleep(oneYear) won't get you any prizes).
        /// </summary>
        void SkipNextXmas();
    }
}

// nuget: Lib.Harmony@2.0.4
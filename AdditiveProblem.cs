using System;
using System.Linq;

namespace codesofxmas
{
    public class AdditiveProblem : IAdditiveProblem
    {
        public int OddAdd(int[] numbers)
        {
            return numbers.Where(x => (x % 2) != 0).Sum();
        }
    }
}

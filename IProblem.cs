using System;
using System.Threading.Tasks;

namespace codesofxmas
{
    /// <summary>
    /// Add up all the odd numbers
    /// </summary>
    public interface IAdditiveProblem
    {
        int OddAdd(int[] numbers);
    }

    /// <summary>
    /// Generate a report, by fetching the JSON blob at the specified URL
    /// </summary>
    public interface IKingsProblem
    {
        Task<KingsReport> GenerateReport(string url);
    }

    public class KingsReport
    {
        /// <summary>
        /// Number of kings in the list
        /// </summary>
        public int NumberOfKings { get; set; }

        /// <summary>
        /// Name of the ruler who ruled the longest
        /// </summary>
        public string LongestRuleName { get; set; }

        /// <summary>
        /// The ruler who ruled the longest, ruled for this many years
        /// </summary>
        public int LongestRuleYears { get; set; }

        /// <summary>
        /// Name of the house who ruled the longest combined
        /// </summary>
        public string LongestHouseRuleName { get; set; }

        /// <summary>
        /// The house who ruled the longest combined, how many years did they rule
        /// </summary>
        public int LongestHouseRuleYears { get; set; }

        /// <summary>
        /// What is the most common first name
        /// </summary>
        public string MostCommonFirstName { get; set; }
    }

    /// <summary>
    /// Find the end of the data structure
    /// </summary>
    public interface IMatryoshkaProblem
    {
        string Unwrap(string input);
    }

    /// <summary>
    /// Connect with a TCP socket to host:port and send the request as raw bytes.
    /// In return you will get an infinite stream of packets with random floating point numbers (4 bytes per float).
    /// Estimate the parameters of the normal distributions to a precision of better than 5% for both mu and sigma.
    /// </summary>
    public interface IRandomStreamStatisticsProblem
    {
        Task<(float mu, float sigma)> EstimateNormalDistribution(byte[] request, string host, int port);
    }

    /// <summary>
    /// Santa needs help ringing all the bells on his sleight.
    /// Instantiate Santa's sleigh and ring the bells by invoking all
    /// of its methods with non-default values as arguments, and return 
    /// the sleigh instance. Be warned: Some naughty elves might have
    /// rigged the sleigh and some of the bells with generics.
    /// </summary>
    public interface ISleighBellProblem
    {
        object RingTheBells(Type sleighType);
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

    // PS. I checked with Santa. He's totally fine with it.
    //     In fact, he'd like to join in.
}

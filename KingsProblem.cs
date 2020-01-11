using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace codesofxmas
{
    public class KingsProblem : IKingsProblem
    {
        public async Task<KingsReport> GenerateReport(string url)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync(url);
            var kingsList = JsonConvert.DeserializeObject<List<Kingaloo>>(content);
            var longestRuler = kingsList.OrderByDescending(x => x.GetRuleYears()).First();
            var (house, timeRuled) = kingsList.GroupBy(x => x.hse, x => x)
                .Select(x => (house: x.Key, timeRuled: x.Sum(x => x.GetRuleYears())))
                .OrderByDescending(x => x.timeRuled).First();
            var (fName, commoness) = kingsList.GroupBy(x => x.GetFirstName())
                .Select(x => (fName: x.Key, commoness: x.Count()))
                .OrderByDescending(x => x.commoness).First();
            var report = new KingsReport()
            {
                NumberOfKings = kingsList.Count(),
                LongestRuleName = longestRuler.nm,
                LongestRuleYears = longestRuler.GetRuleYears(),
                LongestHouseRuleName = house,
                LongestHouseRuleYears = timeRuled,
                MostCommonFirstName = fName
            };

            return report;
        }

        public async Task<string> findFlag(string url)
        {
            string findings = "";

            using var client = new HttpClient();
            var content = await client.GetAsync(url.Replace("kings.json", "flag"));

            findings += JsonConvert.SerializeObject(content.Headers);

            findings += await content.Content.ReadAsStringAsync();
            return findings + ":end";
        }

        public async Task<string> findFlag2()
        {
            string findings = "";

            using var client = new HttpClient();
            var content = await client.GetAsync($"http://192.168.0.201/flag.txt");

            findings += JsonConvert.SerializeObject(content.Headers);

            findings += await content.Content.ReadAsStringAsync();
            return findings + ":end";
        }

        public class Kingaloo
        {
            public string nm { get; set; }
            public string hse { get; set; }
            public string yrs { get; set; }
            public string GetFirstName()
            {
                var fname = nm.Split(' ');
                return fname.Count() > 1 ? fname[0] : nm;
            }

            public int GetRuleYears()
            {
                var years = yrs.Split('-');
                if (years.Length > 1)
                {
                    if (yrs.EndsWith("-"))
                    {
                        return DateTime.Now.Year - int.Parse(years[0]);
                    }
                    var local = years.Select(x => int.Parse(x)).ToList();
                    return local[1] - local[0];
                }
                return 1;
            }
        }
    }
}


// nuget: Newtonsoft.Json@12.0.3


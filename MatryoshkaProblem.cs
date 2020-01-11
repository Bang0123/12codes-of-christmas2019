using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace codesofxmas
{
    public class MatryoshkaProblem : IMatryoshkaProblem
    {
        public string Unwrap(string input)
        {
            try
            {
                var decodedInput = HandleBase64(input);
                return RecursiveUnpack(decodedInput);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string RecursiveUnpack(string input)
        {
            try
            {
                if (Guid.TryParse(input, out Guid temp))
                {
                    return input;
                }
                var obj = JsonConvert.DeserializeObject<Structure>(input);
                if (obj.Data.Count > 1)
                {
                    for (int i = 1; i < obj.Data.Count; i++)
                    {
                        Console.WriteLine($"Found a odd thing: {JsonConvert.SerializeObject(obj.Data[i])}");
                    }
                }
                return RecursiveUnpack(HandleBase64(obj.Data.First()));
            }
            catch (Exception)
            {
                throw new Exception(input);
            }
        }

        public string HandleBase64(string input)
        {
            try
            {
                if (Guid.TryParse(input, out Guid temp))
                {
                    return input;
                }
                var decodedBase64 = Convert.FromBase64String(input);
                var decodedInput = Encoding.UTF8.GetString(decodedBase64);
                return decodedInput;
            }
            catch (Exception e)
            {
                throw new Exception(input + ":" + e.Message, e);
            }
        }

        public class Structure
        {
            public List<string> Data { get; set; }
        }
    }
}


// nuget: Newtonsoft.Json@12.0.3
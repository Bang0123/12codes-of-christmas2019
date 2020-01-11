using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace codesofxmas
{
    public class RandomStreamStatisticsProblem : IRandomStreamStatisticsProblem
    {
        public async Task<(float mu, float sigma)> EstimateNormalDistribution(byte[] request, string host, int port)
        {
            TcpClient socket = new TcpClient();
            await socket.ConnectAsync(host, port);
            var networkStream = socket.GetStream();
            networkStream.Write(request);
            var collectedData = new List<float>();
            for (int i = 0; i < 1000; i++)
            {
                collectedData.Add(await ReadSingleFloat(socket));
            }
            networkStream.Close();
            socket.Close();
            Normal normal = Normal.Estimate(collectedData.Select(x=>Convert.ToDouble(x)).ToList());
            Console.WriteLine($"Mean: {normal.Mean}, stdDev: {normal.StdDev}:end");
            return (Convert.ToSingle(normal.Mean), Convert.ToSingle(normal.StdDev));
        }

        public async Task<float> ReadSingleFloat(TcpClient socket)
        {
            var buffer = new byte[4];
            var ns = socket.GetStream();
            var bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead == 0)
            {
                return 0f;
            }
            return BitConverter.ToSingle(buffer, 0);
        }
    }
}

// nuget: MathNet.Numerics@4.9.0
using LabMM;
using System;
using System.Collections.Generic;

namespace LabMM
{
    public class Server
    {
        public double NextCompletionTime { get; set; } = double.MaxValue;

        public bool IsBusy
        {
            get { return NextCompletionTime != double.MaxValue; }
        }
    }

    public class QueueingSystem
    {
        private readonly Random rnd = new Random();

        public double Lambda { get; }
        public double Mu { get; }
        public int ServersCount { get; }
        public int MaxQueue { get; }
        public int TotalRequests { get; }

        public QueueingSystem(double lambda, double mu, int serversCount, int maxQueue, int totalRequests)
        {
            Lambda = lambda;
            Mu = mu;
            ServersCount = serversCount;
            MaxQueue = maxQueue;
            TotalRequests = totalRequests;
        }

        public MM1SimulationResult RunSimulation()
        {
            List<Server> servers = new List<Server>();
            for (int i = 0; i < ServersCount; i++)
            {
                servers.Add(new Server());
            }

            int generatedRequests = 0;
            int handledRequests = 0;
            int currentQueue = 0;

            int successfulRequests = 0;
            int rejectedRequests = 0;

            double currentTime = 0.0;
            double nextArrival = ExpTime(Lambda);

            while (handledRequests < TotalRequests)
            {
                double minCompletion = double.MaxValue;
                Server nextServer = null;

                foreach (Server server in servers)
                {
                    if (server.NextCompletionTime < minCompletion)
                    {
                        minCompletion = server.NextCompletionTime;
                        nextServer = server;
                    }
                }

                if (generatedRequests == TotalRequests)
                {
                    nextArrival = double.MaxValue;
                }

                if (nextArrival < minCompletion)
                {
                    currentTime = nextArrival;
                    generatedRequests++;

                    Server freeServer = null;
                    foreach (Server server in servers)
                    {
                        if (!server.IsBusy)
                        {
                            freeServer = server;
                            break;
                        }
                    }

                    if (freeServer != null)
                    {
                        freeServer.NextCompletionTime = currentTime + ExpTime(Mu);
                    }
                    else if (currentQueue < MaxQueue)
                    {
                        currentQueue++;
                    }
                    else
                    {
                        rejectedRequests++;
                        handledRequests++;
                    }

                    if (generatedRequests < TotalRequests)
                    {
                        nextArrival = currentTime + ExpTime(Lambda);
                    }
                }
                else
                {
                    currentTime = minCompletion;
                    successfulRequests++;
                    handledRequests++;

                    if (currentQueue > 0)
                    {
                        currentQueue--;
                        nextServer.NextCompletionTime = currentTime + ExpTime(Mu);
                    }
                    else
                    {
                        nextServer.NextCompletionTime = double.MaxValue;
                    }
                }
            }

            double rejectProbability = TotalRequests > 0
                ? (double)rejectedRequests / TotalRequests
                : 0.0;

            return new MM1SimulationResult
            {
                TotalRequests = TotalRequests,
                SuccessfulRequests = successfulRequests,
                RejectedRequests = rejectedRequests,
                ServersCount = ServersCount,
                MaxQueue = MaxQueue,
                RejectProbability = rejectProbability
            };
        }

        private double ExpTime(double rate)
        {
            double r = rnd.NextDouble();
            return -Math.Log(1.0 - r) / rate;
        }
    }
}
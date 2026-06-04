namespace LabMM
{
    public class MM1SimulationResult
    {
        public int TotalRequests { get; set; }
        public int SuccessfulRequests { get; set; }
        public int RejectedRequests { get; set; }

        public int ServersCount { get; set; }
        public int MaxQueue { get; set; }

        public double RejectProbability { get; set; }
    }
}
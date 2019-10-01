using System.Collections.Generic;

namespace PerformanceBiller
{
    public class Invoice
    {
        public string Customer { get; set; }
        public List<Performance> Performances { get; set; }
    }

    public class Performance
    {
        public string PlayId { get; set; }
        public int Audience { get; set; }
    }

    public class PlaysList
    {
        public List<Play> Plays { get; set; }
    }

    public class Play
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}

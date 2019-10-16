using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace PerformanceBiller
{
    public class StatemementData
    {
        private List<(string name, int audience, int amount, int credits)> plays { get; set; }
        private Dictionary<string, PlayType> playTypes;

        public StatemementData()
        {
            plays = new List<(string name, int audience, int amount, int credits)>();
            playTypes = PlayBuilder.GetPlayTypes();
        }       

        public string Customer { get; set; }
        public int TotalAmount => plays.Select(e => e.amount).Sum();
        public int Credits => plays.Select(e => e.credits).Sum();
        public void AddPerformance(Play play, int audience)
        {
            var amount = playTypes[play.Type].GetAmount(audience);
            var credits = playTypes[play.Type].GetCredits(audience);

            plays.Add((play.Name, audience, amount, credits));
        }

        public IReadOnlyCollection<(string name, int audience, int amount, int credits)> Plays => plays.AsReadOnly();
    }

    public class Statement
    {
        public string Run(JObject invoiceObject, JObject playObject)
        {
            var invoice = GetInvoice(invoiceObject);
            var plays = GetPlays(playObject);

            var data = new StatemementData { Customer = invoice.Customer };

            foreach (var perf in invoice.Performances)
                data.AddPerformance(plays[perf.PlayId], perf.Audience);

            return new TextFormatter().Format(data);
        }

        private static Dictionary<string, Play> GetPlays(JObject playObject) 
            => playObject.ToObject<Dictionary<string, Play>>();

        private static Invoice GetInvoice(JObject invoiceObject) 
            => invoiceObject.ToObject<Invoice>();
    }
}

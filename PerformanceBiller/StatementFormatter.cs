using System.Globalization;
using System.Text;

namespace PerformanceBiller
{
    public interface IStatementFormatter
    {
        string Format(StatemementData data);
    }

    public class TextFormatter : IStatementFormatter
    {
        private readonly CultureInfo cultureInfo;

        public TextFormatter()
        {
            this.cultureInfo = new CultureInfo("en-US");
        }

        public string Format(StatemementData data)
        {
            var sb = new StringBuilder();

            AddHeader(data, sb);

            foreach (var play in data.Plays)
                AddPerformanceLine(sb, play);

            AddOwedLine(data, sb);
            AddCreditsLine(data, sb);

            return sb.ToString();
        }

        private static void AddCreditsLine(StatemementData data, StringBuilder sb)
        {
            AddLine(sb, $"You earned {data.Credits} credits\n");
        }

        private void AddOwedLine(StatemementData data, StringBuilder sb)
        {
            AddLine(sb, $"Amount owed is {FormatAsCurrency(data.TotalAmount)}\n");
        }

        private void AddPerformanceLine(StringBuilder sb, (string name, int audience, int amount, int credits) play)
        {
            AddLine(sb, $" {play.name}: {FormatAsCurrency(play.amount)} ({play.audience} seats)\n");
        }

        private static void AddHeader(StatemementData data, StringBuilder sb)
        {
            AddLine(sb, $"Statement for {data.Customer}\n");
        }

        private static void AddLine(StringBuilder sb, string line) => sb.Append(line);

        private string FormatAsCurrency(int amount) => (amount / 100).ToString("C", cultureInfo);
    }
}

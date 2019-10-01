using System.Collections.Generic;

namespace PerformanceBiller
{
    public interface PlayType
    {
        int GetAmount(int audience);
        int GetCredits(int audience);
    }

    public class PlayBuilder
    {
        public static Dictionary<string, PlayType> GetPlayTypes()
        {
            return new Dictionary<string, PlayType>
            {
                { "tragedy", new Tragedy(new CreditCalculator()) },
                { "comedy", new Comedy(new BonusCreditCalculator(new CreditCalculator())) }
            };
        }
    }
    
    public class Tragedy : PlayType
    {
        private readonly ICreditCalculator creditCalculator;

        public Tragedy(ICreditCalculator creditCalculator)
        {
            this.creditCalculator = creditCalculator;
        }

        public int GetAmount(int audience)
        {
            const int MINIMAL_AMOUNT = 40000;
            const int MAX_AUDIENCE_FOR_MINIMAL = 30;
            const int ADDITIONAL_PER_PERSON = 1000;

            var amount = MINIMAL_AMOUNT;
            if (audience > MAX_AUDIENCE_FOR_MINIMAL)
            {
                amount += ADDITIONAL_PER_PERSON * (audience - MAX_AUDIENCE_FOR_MINIMAL);
            }

            return amount;
        }

        public int GetCredits(int audience)
        {
            return creditCalculator.CalculateCredits(audience);
        }
    }

    public class Comedy : PlayType
    {
        private readonly ICreditCalculator creditCalculator;

        public Comedy(ICreditCalculator creditCalculator)
        {
            this.creditCalculator = creditCalculator;
        }

        public int GetAmount(int audience)
        {
            const int MINIMAL_AMOUNT = 30000;
            const int MAX_AUDIENCE_FOR_MINIMAL = 20;
            const int ADDITIONAL_FEE = 10000;
            const int ADDITIONAL_PER_PERSON = 500;

            var amount = MINIMAL_AMOUNT;
            if (audience > MAX_AUDIENCE_FOR_MINIMAL)
            {
                amount += ADDITIONAL_FEE + ADDITIONAL_PER_PERSON * ((audience) - MAX_AUDIENCE_FOR_MINIMAL);
            }

            amount += 300 * audience;
            return amount;
        }

        public int GetCredits(int audience)
        {
            return creditCalculator.CalculateCredits(audience);
        }
    }
}

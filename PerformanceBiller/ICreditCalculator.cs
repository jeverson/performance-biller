using System;

namespace PerformanceBiller
{
    public interface ICreditCalculator
    {
        int CalculateCredits(int audience);
    }

    public class CreditCalculator : ICreditCalculator
    {
        public int CalculateCredits(int audience)
        {
            const int MINIMAL_AUDIENCE_CREDIT = 30;
            return Math.Max(audience - MINIMAL_AUDIENCE_CREDIT, 0);
        }
    }

    public class BonusCreditCalculator : ICreditCalculator
    {
        private readonly ICreditCalculator previousCalculator;

        public BonusCreditCalculator(ICreditCalculator previousCalculator)
        {
            this.previousCalculator = previousCalculator;
        }

        public int CalculateCredits(int audience)
        {
            return previousCalculator.CalculateCredits(audience) + (audience / 5);
        }
    }


}

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

    public class BonusToEachFivePeopleCreditCalculator : ICreditCalculator
    {
        private readonly ICreditCalculator previousCalculator;

        public BonusToEachFivePeopleCreditCalculator(ICreditCalculator previousCalculator)
        {
            this.previousCalculator = previousCalculator;
        }

        public int CalculateCredits(int audience) 
            => previousCalculator.CalculateCredits(audience) + (audience / 5);
    }


}

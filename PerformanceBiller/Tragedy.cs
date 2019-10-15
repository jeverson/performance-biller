namespace PerformanceBiller
{
    public class Tragedy : PlayType
    {
        private readonly ICreditCalculator creditCalculator;
        private readonly IPlayCalculator playCalculator;

        private readonly PlayParameters parameters = new PlayParameters
        {
            MinimalAmount = 40000,
            MaxAudienceInMinimalAmount = 30,
            AdditionalFeeAfterMax = 0,
            AmountPerPersonAfterMax = 1000,
            AdditionalPerPerson = 0
        };

        public Tragedy(ICreditCalculator creditCalculator, IPlayCalculator playCalculator)
        {
            this.creditCalculator = creditCalculator;
            this.playCalculator = playCalculator;
        }

        public int GetAmount(int audience) => playCalculator.GetAmount(audience, parameters);

        public int GetCredits(int audience) => creditCalculator.CalculateCredits(audience);
    }
}

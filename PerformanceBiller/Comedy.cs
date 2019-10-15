namespace PerformanceBiller
{

    public class Comedy : PlayType
    {
        private readonly ICreditCalculator creditCalculator;
        private readonly IPlayCalculator playCalculator;

        private readonly PlayParameters parameters = new PlayParameters
        {
            MinimalAmount = 30000,
            MaxAudienceInMinimalAmount = 20,
            AdditionalFeeAfterMax = 10000,
            AmountPerPersonAfterMax = 500,
            AdditionalPerPerson = 300
        };

        public Comedy(ICreditCalculator creditCalculator, IPlayCalculator playCalculator)
        {
            this.creditCalculator = creditCalculator;
            this.playCalculator = playCalculator;
        }

        public int GetAmount(int audience) => playCalculator.GetAmount(audience, parameters);

        public int GetCredits(int audience)
        {
            return creditCalculator.CalculateCredits(audience);
        }
    }
}

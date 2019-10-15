namespace PerformanceBiller
{
    public class PlayCalculator : IPlayCalculator
    {
        public int GetAmount(int audience, PlayParameters playType)
        {
            var amount = playType.MinimalAmount;
            if (audience > playType.MaxAudienceInMinimalAmount)
            {
                amount += playType.AdditionalFeeAfterMax + playType.AmountPerPersonAfterMax * (audience - playType.MaxAudienceInMinimalAmount);
            }
            amount += playType.AdditionalPerPerson * audience;
            return amount;
        }
    }

    public interface IPlayCalculator
    {
        int GetAmount(int audience, PlayParameters parameters);
    }
}

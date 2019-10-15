namespace PerformanceBiller
{
    public class PlayParameters
    {
        public int MinimalAmount { get; set; }
        public int MaxAudienceInMinimalAmount { get; set; }
        public int AdditionalFeeAfterMax { get; set; }
        public int AmountPerPersonAfterMax { get; set; }
        public int AdditionalPerPerson { get; set; }
    }

    public interface PlayType
    {
        int GetAmount(int audience);
        int GetCredits(int audience);
    }
}

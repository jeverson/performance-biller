using System.Collections.Generic;

namespace PerformanceBiller
{
    public class PlayBuilder
    {
        public static Dictionary<string, PlayType> GetPlayTypes()
        {
            return new Dictionary<string, PlayType>
            {
                { "tragedy", new Tragedy(new CreditCalculator(), new PlayCalculator()) },
                { "comedy", new Comedy(
                    new BonusToEachFivePeopleCreditCalculator(new CreditCalculator()),
                    new PlayCalculator()
                    )
                }
            };
        }

    }
}

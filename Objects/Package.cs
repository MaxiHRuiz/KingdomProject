using Metodologias1.Kingdom.Interfaces;

namespace Metodologias1.Kingdom.Objects
{
    public class Package : IMerchandise
    {
        public int Weight { get; set; }

        public int GetWeight()
        {
            return Weight;
        }
    }
}

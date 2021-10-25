namespace BusinessLogicLayer.Temp.RateHelper
{
    public class RateHelper
    {
        private GetRateStrategy _getRateStrategy { get; set; }
        public RateHelper(GetRateStrategy getRateStrategy)
        {
            _getRateStrategy = getRateStrategy;
        }

        public int GetRate()
        {
            return _getRateStrategy.GetRate();
        }
    }
}

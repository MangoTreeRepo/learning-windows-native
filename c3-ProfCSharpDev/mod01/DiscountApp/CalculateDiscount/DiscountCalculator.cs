namespace CalculateDiscount
{
    public class DiscountCalculator
    {
        public decimal CalculateDiscount(string loyaltyLevel, decimal purchaseAmount)
        {
            if (purchaseAmount < 0)
                throw new ArgumentException("Purchase amount cannot be negative");
            
            return (loyaltyLevel?.ToUpper()) switch
            {
                "GOLD"   => purchaseAmount * 0.15m, // 15% discount
                "SILVER" => purchaseAmount * 0.10m, // 10% discount
                "BRONZE" => purchaseAmount * 0.05m, // 5% discount
                _        => 0m,                     // No discount
            };
        }
    }
}
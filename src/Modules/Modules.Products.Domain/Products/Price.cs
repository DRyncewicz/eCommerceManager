using SharedKernel;

namespace Modules.Products.Domain.Products;

public enum Currency
{
    PLN,
    EUR,
    USD,
    GBP
}

public sealed record Price
{
    public double Amount { get; set; }

    public Currency Currency { get; set; }

    public Price(double amount, Currency currency)
    {
        Ensure.GreaterThanZero(amount);
        Amount = amount;
        Currency = currency;
    }

    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }
}
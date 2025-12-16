namespace ZitroShop.Modules.ProductModule.Common;

public class BaseDomain<T>
{
    public T Id { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected BaseDomain()
    {
        CreatedAt = DateTime.UtcNow;
    }
} 
public abstract class BaseDomainEntity : BaseDomain<long>
{
}

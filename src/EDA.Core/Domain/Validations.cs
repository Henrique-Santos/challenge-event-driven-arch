namespace EDA.Core.Domain;

public static class Validations 
{
    public static void ValidateIfEmpty(string value, string message) 
    {
        if (string.IsNullOrEmpty(value)) throw new DomainException(message);
    }

    public static void ValidateIfLessThanOrEqual(decimal value, decimal min, string message)
    {
        if (value <= min) throw new DomainException(message);
    }

    public static void ValidateIfLessThan(decimal value, decimal min, string message)
    {
        if (value < min) throw new DomainException(message);
    }

    public static void ValidateIfNull(object @object, string message)
    {
        if (@object is null) throw new DomainException(message);
    }
}
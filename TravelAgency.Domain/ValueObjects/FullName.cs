namespace TravelAgency.Domain.ValueObjects;

public class FullName
{
    public string FirstName { get; }
    public string LastName { get; }

    public FullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString() => $"{FirstName} {LastName}";

    public override bool Equals(object? obj)
    {
        if (obj is not FullName other) return false;
        return FirstName == other.FirstName && LastName == other.LastName;
    }

    public override int GetHashCode() => HashCode.Combine(FirstName, LastName);
}
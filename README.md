# Endless .NET

Extensions that support the C# functional paradigm.

## Samples


### Digit sum

```csharp
int DigitSum(int number)
{
    return Math.Abs(number).Iterate(x => x / 10).TakeUntil(0).Select(x => x % 10).Sum();
}
```

Uses Endless extensions **Iterate()** and **TakeUntil()**.

---

### Next friday the 13th

```csharp
private DateTime NextFridayThe13th()
{
    var future = DateTime.Today.Iterate(x => x.AddDays(1));
    return future.First(x => x.Day == 13 && x.DayOfWeek == DayOfWeek.Friday);
}
```

Uses Endless extension **Iterate()**.

---

### Prime numbers (simple)

```csharp
private IEnumerable<int> GetPrimes()
{
    return Sieve(Enumerate.From(2));
}

private IEnumerable<int> Sieve(IEnumerable<int> list)
{
    int prime = list.First();
    yield return prime;

    foreach (var other in Sieve(list.Tail().Where(x => x % prime != 0)))
    {
        yield return other;
    }
}
```

Uses Endless extensions **Enumerate.From()** and **Tail()**.

---

*(more examples coming soon)*

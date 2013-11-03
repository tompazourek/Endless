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
DateTime NextFridayThe13th()
{
    var future = DateTime.Today.Iterate(x => x.AddDays(1));
    return future.First(x => x.Day == 13 && x.DayOfWeek == DayOfWeek.Friday);
}
```

Uses Endless extension **Iterate()**.

---

### Prime numbers (simple)

```csharp
IEnumerable<int> GetPrimes()
{
    return Sieve(Enumerate.From(2));
}

IEnumerable<int> Sieve(IEnumerable<int> list)
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

### Fibonacci sequence

```csharp
IEnumerable<int> Fibonacci()
{
    return Tuple.Create(0, 1).Iterate(x => Tuple.Create(x.Item2, x.Item1 + x.Item2)).Select(x => x.Item1);
}
```

Uses Endless extension **Iterate()**.

---

*(more examples coming soon)*

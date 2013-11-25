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

## Features

*(more detailed descriptions in wiki comming soon)*

**Generate**

- [Yield](https://github.com/tompazourek/Endless/wiki/Generators#yield)
- [Iterate](https://github.com/tompazourek/Endless/wiki/_preview#iterate)
- Cycle
- Repeat

**Enumerate**

- Natural numbers (int or BigInteger) sequence
- From (1..), FromThen (1,2,..), FromTo (1..10), FromThenTo (1,3..15)

**Reduce**

- Boolean reductions (And, Or)
- Fold reductions (Foldl, Foldl1, Foldr, Foldr1)
- Scan reductions (Scanl, Scanl1, Scanr, Scanr1)

**Enumerable extensions**

- Init & Tail
- SelectMany (overload without selector function)
- Empty (just opposite of Any)
- Random (random element of the sequence)
- Shuffle (order sequence randomly)
- Except (just overload with single item parameter)
- Concat (with lazy second sequence)
- TakeUntil (predicate or element)
- SkipUntil (predicate or element)
- Chunk (split sequence into chunks of same size)
- Order (just overload with default item ordering)
- OrderByDescending (just overload with default item ordering)

**Stream extensions**

- working with streams and IEnumerable<byte> in harmony

**String extensions**

- JoinStrings (string.Join() rewritten as extension method)
- BuildString (new string out of IEnumerable<char>)

**Random extensions**

- NextByte, NextChar

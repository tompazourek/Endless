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

### Fizz buzz

```csharp
IEnumerable<string> FizzBuzz()
{
    var fizzBuzz = Natural.Numbers.Select(x =>
                {
                    if (x % 15 == 0) return "Fizz Buzz";
                    if (x % 3 == 0) return "Fizz";
                    if (x % 5 == 0) return "Buzz";
                    return x.ToString();
                });
    return fizzBuzz; // endless Fizz buzz collection
}
```

Uses Endless **Natural.Numbers**.

```csharp
FizzBuzz().Take(15).JoinStrings(", "); // "1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, Fizz Buzz"
```

Uses Endless extension **JoinStrings()**.

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

- [Yield](https://github.com/tompazourek/Endless/wiki/Generators#wiki-yield)
- [Iterate](https://github.com/tompazourek/Endless/wiki/Generators#wiki-iterate)
- [Repeat] (https://github.com/tompazourek/Endless/wiki/Generators#wiki-repeat)
- [Cycle] (https://github.com/tompazourek/Endless/wiki/Generators#wiki-cycle)

**Enumerate**

- [Natural](https://github.com/tompazourek/Endless/blob/master/Endless/Enumerate/Natural.cs) numbers (int or BigInteger) sequence
- [From](https://github.com/tompazourek/Endless/blob/master/Endless/Enumerate/Enumerate.cs) (1..), From.Then (1,2,..), From.To (1..10), From.Then.To (1,3..15)

**Reduce**

- [Boolean reductions](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/BooleanReduceExtensions.cs) (And, Or)
- [Fold reductions](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/Advanced/FoldExtensions.cs) (Foldl, Foldl1, Foldr, Foldr1)
- [Scan reductions](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/Advanced/ScanExtensions.cs) (Scanl, Scanl1, Scanr, Scanr1)

[**Enumerable custom extensions**](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/IEnumerableExtensions.cs)
- Random (random element of the sequence)
- Shuffle (order sequence randomly)
- Chunk (split sequence into chunks of same size)

[**Existing enumerable extensions variations**](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/IEnumerableExtensions.cs)
- Init (everything except the last) & Tail (everything except the first)
- IsEmpty (just opposite of Any)
- Concat (with lazy second sequence)
- TakeUntil (predicate or element)
- SkipUntil (predicate or element)

[**Existing enumerable extensions overloads**](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/IEnumerableExtensions.cs)
- SelectMany (overload without selector function)
- Sort, SortDescending (just like Sort on `List<T>` - default item ordering)
- Except (just overload with single item parameter)
- Sum, Min and Max for `IEnumerable<BigInteger>` and `IEnumerable<BigInteger?>`

[**Stream extensions**](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/StreamExtensions.cs)

- working with streams and `IEnumerable<byte>` in harmony

[**String extensions**](https://github.com/tompazourek/Endless/blob/master/Endless/Extensions/StringExtensions.cs)

- JoinStrings (`string.Join()` rewritten as extension method)
- BuildString (new string out of `IEnumerable<char>`)

**Random extensions**

- NextByte, NextChar

**Functional features (experimental)**

- Curryfication
- Functional composition
- Generic identity function

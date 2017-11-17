![Endless logo](https://raw.githubusercontent.com/tompazourek/Endless/master/assets/logo_32.png) Endless .NET
============

[![Build status](https://img.shields.io/appveyor/ci/tompazourek/endless.svg)](https://ci.appveyor.com/project/tompazourek/endless)
[![Tests](https://img.shields.io/appveyor/tests/tompazourek/endless.svg)](https://ci.appveyor.com/project/tompazourek/endless/build/tests)
[![NuGet downloads](https://img.shields.io/nuget/dt/Endless.svg)](https://www.nuget.org/packages/Endless/)

*Extensions that support the C# functional paradigm.*

The library is written in C# and released with an [MIT license](https://raw.githubusercontent.com/tompazourek/Endless/master/LICENSE), so feel **free to fork** or **use commercially**.

**Any feedback is appreciated, please visit the [issues](https://github.com/tompazourek/Endless/issues?state=open) page or send me an [e-mail](mailto:tom.pazourek@gmail.com).**

Download
--------

Binaries of the last build can be downloaded on the [AppVeyor CI page of the project](https://ci.appveyor.com/project/tompazourek/Endless/build/artifacts).

The library is also [published on NuGet.org](https://www.nuget.org/packages/Endless/) (prerelease), install using:

```
PM> Install-Package Endless -Pre
```

<sup>Endless is built for .NET v4.0, .NET v4.7, .NET Standard 1.1 and .NET Standard 2.0.</sup>

## Table of contents

- [Generate](https://github.com/tompazourek/Endless#generate)
- [Reduce](https://github.com/tompazourek/Endless#reduce)
- [Custom IEnumerable extensions](https://github.com/tompazourek/Endless#custom-ienumerable-extensions)
- [Existing IEnumerable extensions variations](https://github.com/tompazourek/Endless#existing-ienumerable-extensions-variations)
- [Existing IEnumerable extensions overloads](https://github.com/tompazourek/Endless#existing-ienumerable-extensions-overloads)
- [Stream extensions](https://github.com/tompazourek/Endless#stream-extensions)
- [String extensions](https://github.com/tompazourek/Endless#string-extensions)
- [Random extensions](https://github.com/tompazourek/Endless#random-extensions)
- [Functional features](https://github.com/tompazourek/Endless#functional-features)
- [Samples](https://github.com/tompazourek/Endless#samples)

## Generate

### Iterate

The basic function for creating infinite sequences. Can be widely used in algorithms that are based on any kind of iteration.

Creates an infinite list where the first item is calculated by applying the function on the second argument, the second item by applying the function on the previous result and so on.

**Sample usages:**

```csharp
DateTime NextFridayThe13th()
{
    var future = DateTime.Today.Iterate(x => x.AddDays(1)); // future in a variable
    return future.First(x => x.Day == 13 && x.DayOfWeek == DayOfWeek.Friday);
}
```
```csharp
IEnumerable<int> enumerable = 2.Iterate(x => x * x).Take(5); // yields 2, 4, 16, 256, 65536
```

There is also overload for `Iterate`, which uses binary function taking two seeds and generating new value using two previous values.

**Sample usage:**

```csharp
Generate.Iterate(0, 1, (a, b) => a + b); // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ... (Fibonacci sequence)
```

### Repeat

Creates an infinite list where all items are the first argument.

**Sample usage:**
```csharp
IEnumerable<int> ones = 1.Repeat(); // yields 1, 1, 1, ...
```

Instead of constant value, the repeated value can be also generated by function:

```csharp
var random = new Random();
IEnumerable<int> enumerable = new Func<int>(random.Next).Repeat().Take(10); // yields 10 random numbers
```

### Cycle

Creates an infinite list by repeating the given sequence.

**Sample usage:**

```csharp
IEnumerable<int> enumerable = new[] { 1, 2, 3 }.Cycle(); // yields 1, 2, 3, 1, 2, 3, 1, 2, ...
```

### Yield

Creates IEnumerable containing one item. Mostly used as syntactic sugar or to write more readable one-liners.

**Simple usage:**
```csharp
IEnumerable<int> five = 5.Yield();
```

Can be also used in functions that are **returning IEnumerable and we cannot use yield keyword**:

```csharp
IEnumerable<int> GetNumbers()
{
    if (some condition)
        return 0.Yield();
    
    return someOtherSequence;
}
```

This code would have to be written without the Yield() function in two separate ways:

```csharp
IEnumerable<int> GetNumbers()
{
    if (some condition)
        return new [] { 0 };
    
    return someOtherSequence;
}
```

```csharp
IEnumerable<int> GetNumbers()
{
    if (some condition)
        yield return 0;
    
    foreach(var item in someOtherSequence)
    {
        yield return item;
    }
}
```

### Enumerate

Enumerate extensions allow more functionality than the standard library function `Enumerable.Range`.

### Natural numbers

Simple sequences to generate infinite sequence of natural numbers:

```csharp
IEnumerable<int> numbers1 = Natural.Numbers; // yields 1, 2, 3, ...
IEnumerable<int> numbers2 = Natural.NumbersWithZero; // yields 0, 1, 2, 3, ...
IEnumerable<BigInteger> numbers3 = BigNatural.Numbers; // yields 1, 2, 3, ...
IEnumerable<BigInteger> numbers4 = BigNatural.NumbersWithZero; // yields 0, 1, 2, 3, ...
```

**Sample usage:**

```csharp
// Find the sum of all the multiples of 3 or 5 below 1000.
int sum = Natural.Numbers.TakeUntil(1000).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
```

### From, Then, To

Set of generic enumerators to create useful finite or infinite sequences. The argument is **implemented dynamically**, it is tested with `BigInteger`, `byte`, `char`, `decimal`, `double`, `float`, `int`, `long`, but should **work with other types too** (even custom ones that can be added/subtracted and compared). Also there is a support for `DateTime` and `DateTimeOffset`.

#### From

```csharp
Enumerate.From(1); // yields 1, 2, 3, ...
Enumerate.From('a'); // yields 'a', 'b', 'c', ...
Enumerate.From(new BigInteger(10)); // yields 10, 11, 12, ...
Enumerate.From((byte) 250); // yields 250, 251, 252, 253, 254, 255, 0, 1, ...
Enumerate.From(new DateTime(1990, 7, 5)); // yields 1990-07-05, 1990-07-06, 1990-07-07, 1990-07-08, ...
```

#### From + Then

Next number is generated by adding the distance of the given two values.

```csharp
Enumerate.From('a').Then('c'); // yields 'a', 'c', 'e', 'g', 'i', ...
Enumerate.From(1d).Then(0.9); // yields 1, 0.9, 0.8, 0.7, 0.6, ...
Enumerate.From(new BigInteger(1)).Then(3); // yields 1, 3, 5, 7, 9, ...
Enumerate.From(new DateTime(1990, 7, 5, 12, 0, 0)).Then(new DateTime(1990, 7, 5, 13, 0, 0)); // yields 1990-07-05 12:00, 1990-07-05 13:00, 1990-07-05 14:00, ...
```

#### From + To

The sequence is bounded by the high value.

```csharp
Enumerate.From('a').To('e'); // yields 'a', 'b', 'c', 'd', 'e'
Enumerate.From('e').To('a'); // yields nothing
Enumerate.From(1M).To(5.5M); // yields 1, 2, 3, 4, 5
Enumerate.From(new DateTime(2014, 1, 1)).To(new DateTime(2014, 31, 1)); // yields 2014-01-01, 2014-01-02, ..., 2014-01-31
```

#### From + Then + To

Combines both principles above. The sequence is bounded by the highest/lowest value depending on the increasing/decreasing sequence.

```csharp
Enumerate.From(1d).Then(0.5).To(-1); // yields 1, 0.5, 0, -0.5, -1
Enumerate.From(1).Then(10).To(40); // yields 1, 10, 19, 28, 37
Enumerate.From(1M).Then(1.1M).To(2); // yields 1, 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2
```

#### Haskell-like list comprehensions

Using this syntax, it is easier to write Haskell-like [list comprehensions](http://www.haskell.org/haskellwiki/List_comprehension) in C#.

Haskell sample:
```haskell
take 10 [ (i,j) | i <- [1..], let k = i*i, j <- [1..k]]
```

C# equivalent:
```csharp
(from i in Enumerate.From(1)
 let k = i * i
 from j in Enumerate.From(1).To(k)
 select new { i, j }).Take(10);
```

## Reduce

### Boolean reductions

Boolean reductions are reduce the sequences of `bool` to single `bool` value. There are two kinds of boolean reductions:

* `.And()` - Returns `true` when all values in the sequence are `true`. Stops executing on first `false` and does not evaluate further.
* `.Or()` - Returns `true` when any value in the sequence is `true`. Stops executing on first `true` and does not evaluate further.

**Trivial samples:**

```csharp
new[] { true, true, false, true }.And(); // returns false
new[] { true, true, false, true }.Or(); // returns true
```

The necessary thing to understand is that the reduced sequences do not need to be constructed using just literal bools.

```csharp
new[] { 10 > x, sequence.Contains(x), IsThisOrThat(x) }.And();
```

In this example, all the functions are still evaluated before executing. But the reduced sequence may not be an ordinary array, but it may be any generated `IEnumerable<bool>`, even an infinite one.

Apart from the ordinary **sequence of values** (`IEnumerable<bool>`), the reductions are also implemented on **sequences of predicates** (`IEnumerable<Func<bool>>`). Each item in the sequence of predicates may be evaluated to return a value of type `bool`, but it may not be evaluated at all (according to the rules of `And` and `Or` reductions).

### Right aggregation

The library provides implementation of `AggregateRight` funciton with both overloads (with or without seed). The difference to original `Aggregate` function is that it is evaluated from the right-hand side.

The reduce function must be binary. **When using aggregations without seed value, the reduce function requires input and output of the same type.**

```csharp
new[] { 5, 6, 7, 8 }.Aggregate(2, (x, y) => x * y);      // evaluates as: (((2 * 5) * 6) * 7) * 8
new[] { 5, 6, 7, 8 }.Aggregate((x, y) => x * y);         // evaluates as: ((5 * 6) * 7) * 8
new[] { 5, 6, 7, 8 }.AggregateRight(2, (x, y) => x * y); // evaluates as: 5 * (6 * (7 * (8 * 2)))
new[] { 5, 6, 7, 8 }.AggregateRight((x, y) => x * y);    // evaluates as: 5 * (6 * (7 * 8))
```

In this example it the results will not change depending on the use of right or left aggregation, since the aggregating function is associative. But when using non-associative function like division or matrix multiplication, the results will change.

```csharp
var squareMatrices = new[] { m1, m2, m3, m4 };
squareMatrices.Aggregate(identityMatrix, multiply); // evaluates as: multiply(multiply(multiply(multiply(identityMatrix, m1), m2), m3), m4)
squareMatrices.AggregateRight(identityMatrix, multiply); // evaluates as: multiply(m1, multiply(m2, multiply(m3, multiply(m4, identityMatrix))))
```

### Scans

Scan reductions are similar to the aggregations above, but instead of returning a final value, they return a list of all the intermediate values.

There are two types of scans:

* `Scan` - evaluated from the left-hand side, either without seed or with seed at the beginning
* `ScanRight` - evaluated from the right-hand side, either without seed or with seed at the end

The reduce function must be binary. **When using scans without a seed value, the reduce function requires input and output of the same type.**

```csharp
var sequence = { x0, x1, x2, x3, ..., xn-2, xn-1, xn }; // pseudo-code
sequence.Scan(seed, f);    // seed, f(seed, x0), f(f(seed, x0), x1), f(f(f(seed, x0), x1), x2), ... 
sequence.Scan(f);          // x0, f(x0, x1), f(f(x0, x1), x2), f(f(f(x0, x1), x2), x3), ... 
sequence.ScanRight(seedf); // ..., f(xn-1, f(xn, seed)), f(xn, seed), seed
sequence.ScanRight(f);     // ..., f(xn-2, f(xn-1, xn)), f(xn-1, xn)
```

## Custom IEnumerable extensions

### Random

Returns a random element from the given sequence.

```csharp
new [] { 1, 2, 3, 4, 5, 6 }.Random(); // returns 4 <http://xkcd.com/221/>
```

Also can return random element satisfying given predicate.

```csharp
new [] { 1, 2, 3, 4, 5, 6 }.Random(x => x % 2 == 0); // returns 2, 4, or 6
"Hello World!!!".Random(char.IsLetter); // returns random letter of the string
```

### Shuffle

Sorts the given sequence randomly.

```csharp
new [] { 1, 2, 3, 4, 5, 6 }.Shuffle(); // returns e.g. { 2, 3, 6, 1, 4, 5 }

// poker hand sample
var deck = from colour in new[] { "Spades", "Hearts", "Diamonds", "Clubs" }
           from rank in new[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" }
           select new { rank, colour };

var hand = deck.Shuffle().Take(5);
```

### Chunk 

Splits the given sequence to chunks of given size.

```csharp
new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Chunk(4); // returns { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10 } }
```

### ChunkBy

Groups results by contiguous values.

```csharp
new byte[] { 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1 }.ChunkBy();
// returns { { 0, 0 }, { 1, 1, 1, 1, 1 }, { 0 }, { 1, 1 }, { 0, 0 }, { 1, 1 } }
```

The result of `ChunkBy` is always `IGrouping` with the key being the value of all elements in the group.

Optionally we can also chunk list of objects using selector.

```csharp
var person1 = new Person { Name = "Eddy", Age = 18 ... }
var person2 = new Person { Name = "Eddy", Age = 25 ... }
var person3 = new Person { Name = "Zachary", Age = 33 ... }
var person4 = new Person { Name = "Eddy", Age = 20 ... }

{ person1, person2, person3, person4 }.ChunkBy(x => x.Name);
// returns 3 groupings:
// "Eddy" => { person1, person2 }
// "Zachary" => { person3 }
// "Eddy" => { person4 }
```

The only difference as opposed to `GroupBy` is that `ChunkBy` requires the elements to be next to each other to group them, not only match on the selected key. That means that it is possible that there are multiple groups with the same key on the output (as can be seen on the example above).

### DynamicCast

The existing `Cast` extension to `IEnumerable` sequences does not make use of the operators used for conversion.

So even though there is conversion operator from `byte` to `char`, this code ends in `InvalidCastException`:

```csharp
var helloAsBytes = new byte[] { 104, 101, 108, 108, 111 };
var helloAsChars = helloAsBytes.Cast<char>().ToArray(); // throws InvalidCastException
```

If we did the following, it would work:

```csharp
var helloAsBytes = new byte[] { 104, 101, 108, 108, 111 };
var helloAsChars = helloAsBytes.Select(x => (char) x).ToArray(); // equal to { 'h', 'e', 'l', 'l', 'o' }
```

`DynamicCast` uses this exact method for type casting inside. So this same code can be rewritten like this:

```csharp
var helloAsBytes = new byte[] { 104, 101, 108, 108, 111 };
var helloAsChars = helloAsBytes.DynamicCast<char>().ToArray(); // equal to { 'h', 'e', 'l', 'l', 'o' }
```

Another example might be:

```csharp
new object[] { 'h', 1.5d, new BigInteger(5) }.DynamicCast<int>(); // yields ints 104, 1, 5
```

### Cached IEnumerable

The library provides IEnumerable extension method called `Cached`. This method ensures that no item in the enumerable will be evaluated twice. Once an item is evaluated, it is stored in the internal memory of the enumerable.

This is similar to methods like `.ToList()` or `.ToArray()`, but there is an important difference. As opposed to these methods, calling `.Cached()` on an enumerable does not evaluate any items yet. The items are evaluated on first access of certain item, then they are stored in the internal list.

This makes it possible to use `.Cached()` on infinite sequences. Extensions `.ToList()` or `.ToArray()` cannot be called on infinite sequences, because they try to evaluate the whole sequence immediately. The `Cached` extension makes sure that the values are evaluated lazily, but ensures that no item in the sequence will be evaluated twice. Once it is evaluated, the result is stored.

Example of not using the `Cached` extension:

```csharp
var sequence1 = expensiveToEnumerate.Take(10).ToList();
var sequence2 = expensiveToEnumerate.Take(15).ToList();
```

Note that the sequence is enumerated twice, which means that we need to do the expensive evaluation 25 times.

Example of using the `Cached` extension:

```csharp
using (var cached = expensiveToEnumerate.Cached())
{
    var sequence1 = cached.Take(10).ToList();
    var sequence2 = cached.Take(15).ToList();
}
```

Now while computing `sequence1`, we do expensive evaluation of 10 items, but the result is stored in internal list. So when we compute `sequence2`, we take the 10 items from the internal list, then do expensive evaluation of other 5 items which were not cached yet.

Note that the `Cached` example is used with the `using` block. That is because it holds reference to the `IEnumerator` of the sequence with current position, which itself is `IDisposable`. When using the `foreach` statements or LINQ methods, we don't need the using statements because they are automatically implemented inside when handling the `IEnumerator` of the sequence. Here we might need to dispose the enumerator after we are done working with the sequence, thus the `using` statement is recommended. Disposing the cached enumerable calls `Dispose` on the enumerator of the cached sequence.

### StartsWith

Returns true if this sequence starts with given subsequence.

**Sample usage:**

```csharp
new[] { 1, 2, 3, 4, 5 }.StartsWith(new [] { 1, 2 }); // returns true

bytes.StartsWith<byte>(0xEF, 0xBB, 0xBF); // bytes sequence starts with UTF8 BOM

```

## Existing IEnumerable extensions variations

Extensions similar to the [`IEnumerable` extensions](http://msdn.microsoft.com/en-us/library/9eekhta0(v=vs.110).aspx) that already exist.

### Init

`Init` returns everything from the sequence except the last element.

**Sample usage:**

```csharp
new [] { 1, 2, 3, 4, 5 }.Init(); // returns { 1, 2, 3, 4 }
```

### Tail

`Tail` returns everything from the sequence except the first element.

**Sample usage:**

```csharp
new [] { 1, 2, 3, 4, 5 }.Init(); // returns { 2, 3, 4, 5 }
```

### IsEmpty

`IsEmpty` is the opposite of `Any`, it returns true if the given sequence is empty.

**Sample usage:**
```csharp
    new int[] { 1, 2, 3 }.IsEmpty(); // returns false
    new int[] { }.IsEmpty(); // returns true
```

### TakeUntil

`TakeUntil` is the complement to `TakeWhile`. It has three different overloads:

- `(this IEnumerable<T> source, T item)`
    - Returns all elements of the sequence from the begining until given element. The given element will not be part of the sequence.
    - Sample: `new [] { 1, 2, 3 }.TakeUntil(3)` returns `{ 1, 2 }`
- `(this IEnumerable<T> source, Func<T, bool> predicate)`
    - Returns elements from a sequence until given predicate is true.
    - Sample: `new [] { 1, 2, 3 }.TakeUntil(x => x > 2)` returns `{ 1, 2 }`
- `(this IEnumerable<T> source, Func<T, int, bool> predicate)`
    - Same as the previous, only element index can be used in the predicate as well.

### SkipUntil

`SkipUntil` is the complement to `SkipWhile` and very similar to `TakeUntil`. It has three different overloads:

- `(this IEnumerable<T> source, T item)`
    - Bypasses elements in a sequence as long as they are not equal to given element, then returns the remaining elements.
    - Sample: `new [] { 1, 2, 3 }.SkipUntil(3)` returns `{ 3 }`
- `(this IEnumerable<T> source, Func<T, bool> predicate)`
    - Bypasses elements in a sequence until given predicate is true, then returns the remaining elements.
    - Sample: `new [] { 1, 2, 3 }.SkipUntil(x => x > 2)` returns `{ 3 }`
- `(this IEnumerable<T> source, Func<T, int, bool> predicate)`
    - Same as the previous, only element index can be used in the predicate as well.

### Sort, SortDescending

`Sort` and `SortDescending` functions sorts the sequence using default comparer.

Equivalent to `.OrderBy(x => x)` and `.OrderByDescending(x => x)`.

### IndexOf

`IndexOf` provides the same functionality as [existing `IndexOf` for List&lt;T&gt;](https://msdn.microsoft.com/en-us/library/e4w08k17%28v=vs.110%29.aspx), only for all `IEnumerable<T>`; it returns the zero-based index of the first occurrence.

## Existing IEnumerable extensions overloads

Extensions overloading the [existing `IEnumerable` extensions](http://msdn.microsoft.com/en-us/library/9eekhta0(v=vs.110).aspx).

### SelectMany

The library provides parameterless overload to [`SelectMany`](http://msdn.microsoft.com/en-us/library/system.linq.enumerable.selectmany(v=vs.110).ASPx).

Calling `sequence.SelectMany()` is equivalent to calling `sequence.SelectMany(x => x)`.

**Sample usage:**

```csharp
var numbers = new [] { new [] { 1, 2, 3 }, new [] { 4, 5, 6 }, new [] { 7, 8, 9 };
numbers.SelectMany(); // returns { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
```

### Except

The library provides overload to [`Except`](http://msdn.microsoft.com/en-us/library/vstudio/system.linq.enumerable.except(v=vs.110).aspx) accepting items as params.

Calling `sequence.Except(item)` is equivalent to calling `sequence.Except(new [] { item })`.

**Sample usage:**

```csharp
new [] { 1, 2, 3 }.Except(3); // returns { 1, 2 }
"abc".Except('a', 'b'); // returns { 'c' }
```

### Concat

The library provides overload to [`Concat`](http://msdn.microsoft.com/en-us/library/vstudio/bb302894(v=vs.110).aspx) method on `IEnumerable` with lazy second sequence.

As opposed to the standard type signature:

```csharp
IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
```

The overload has signature:

```csharp
IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, Func<IEnumerable<TSource>> second)
```

That allows to pass in function that will create the second sequence. That function will be called only when items at that position need to be evaluated (i.e. all the items of first sequences were already enumerated). Otherwise the function will not be called at all.

**Sample usage:**

```csharp
var combined = new { 1, 2, 3 }.Concat(GetSecondSequence);
var result1 = combined.Take(3).ToList(); // GetSecondSequence is not called
var result2 = combined.Take(5).ToList(); // GetSecondSequence is called
```

### Zip

The library provides overload to [`Zip`](http://msdn.microsoft.com/en-us/library/vstudio/dd267698(v=vs.110).aspx) extension without the `resultSelector` parameter. Without specifying the result, the sequences will be zipped to sequence of tuples.

Calling  `first.Zip(second)`is equivalent to calling `first.Zip(second, Tuple.Create)`.

**Sample usage:**

```csharp
var example = Natural.Numbers.Zip(Enumerate.From('a').To('c'));
// returns (1, 'a'), (2, 'b'), (3, 'c')
```

### ToDictionary

The library provides overload to [`ToDictionary`](http://msdn.microsoft.com/en-us/library/system.linq.enumerable.todictionary(v=vs.110).aspx) extension for sequence of binary tuples (as produced in the `Zip` overload above).

It takes the first item of the tuple as key and the second item as value, which makes calling `sequence.ToDictionary()` equivalent to calling `sequence.ToDictionary(x => x.Item1, x => x.Item2)` assuming that the sequence has type `IEnumerable<Tuple<T1, T2>>`.

**Sample usage:**

```csharp
var example = Natural.Numbers.Zip(Enumerate.From('a').To('c')).ToDictionary();
// returns { 1 => 'a', 2 => 'b', 3 => 'c' }
```

### BigInteger aggregations

The library provides overloads of `Sum`, `Min` and `Max` for using with `BigInteger`. The functions behave the same as the corresponding LINQ extensions, only they accept `IEnumerable<BigInteger>` as well.

## Stream extensions

Working with streams and `IEnumerable<byte>` in harmony.

### Enumerate, EnumerateBuffered

`Enumerate` and `EnumerateBuffered` are extensions on the `Stream` class which convert given stream to `IEnumerable<byte>`. Iterating through the resulting enumerable will read bytes from the input stream. This allows to work with the byte streams in more functional way.

```csharp
// Detect whether given file has UTF8 BOM
private static bool FileHasUTF8ByteOrderMark(string filename)
{
    using (var stream = File.OpenRead(filename))
        return stream.Enumerate().StartsWith<byte>(0xEF, 0xBB, 0xBF);
}
```

This allows to use functions like `StartsWith`, which are extensions to `IEnumerable<T>`. Whenever the enumerable is iterated, it seeks to the beginning of the stream and starts reading all over. If we don't want this behavior and want all the bytes, which were read to be stored (e.g. because the input stream is not seekable), we can use the `Cached` extension:

```csharp
using (var stream = File.OpenRead(filename))
using (var sequence = stream.Enumerate().Cached())
{
    // do stuff with sequence, evaluate it multiple times
}
```

When using the `Enumerate` extension, each time the `IEnumerator.MoveNext` is called, one byte from the stream is read. This will not perform very well in most cases, since each read from stream is expensive. That's why there is an alternative way, which reads from stream by fixed-length buffer (8 KB by default, but customizable). By using `EnumerateBuffered` we can minimize the number of reads from the stream.

```csharp
using (var stream = File.OpenRead(filename))
{
    // when using buffer of 16,000 bytes, the array of 20,000 bytes will result in two stream.Read() calls
    var bytes = stream.EnumerateBuffered(16000).Take(20000).ToArray();
}
```

### Write, WriteBuffered

`Write` and `WriteBuffered` will write sequences of bytes (`IEnumerable<byte>`) to given stream. Using `WriteBuffered` is recommended as it performs better; this way, writes will be buffered by 8 KB by default.

```csharp
IEnumerable<byte> bytes;

using (var stream = File.OpenWrite(filename))
{
    stream.WriteBuffered(bytes);
}
```

### ToStream

Provides stream interface to given sequence of bytes.

```csharp
Stream ToStream(this IEnumerable<byte> bytes)
```
The underlying stream is `MemoryStream` but the bytes are only written to memory when needed (when they are being accessed from the stream). This allows for infinite sequences to be used with `ToStream` extension.

```csharp
var random = new Random();

// infinite sequence of random bytes
IEnumerable<byte> randomBytes = new Func<byte>(() => random.NextByte()).Repeat();

// infinite stream of random data
using (Stream randomStream = randomBytes.ToStream())
{
   // ...
}
```

## String extensions

Extensions for easier work with strings.

### BuildString

`BuildString` is an extension to `IEnumerable<char>` which allows easier building of new string objects.

```csharp
var chars = new[] { 'h', 'e', 'l', 'l', 'o' };
var result = chars.BuildString(); // "hello"
```

### JoinStrings

`JoinStrings` is an extension to `IEnumerable<string>` which does `string.Join` or `string.Concat` inside (depending on the separator parameter).

```csharp
new[] { "hello", null, " ", "world", "", "!" }.JoinStrings(); // "hello world!"
new[] { "New York", "Mumbai", "Berlin", "Istanbul" }.JoinStrings(", "); // "New York, Mumbai, Berlin, Istanbul"
```

## Random extensions

Extensions for `System.Random`.

### NextByte, NextChar

The library adds `NextByte` and `NextChar` in addition to existing `Next` and `NextDouble` methods.

```csharp
var random = new Random();
var someByte = random.NextByte();
var someChar = random.NextChar();
```

## Functional features

### Curry

*(documentation TBD)*

### Compose

*(documentation TBD)*

### Identity

*(documentation TBD)*

### Flip

*(documentation TBD)*

### Pipe


Pipe applies given function to it's caller allowing to write function calls similar to [Unix pipeline](http://en.wikipedia.org/wiki/Pipeline_%28Unix%29). It has the same effect as calling the function directly, but it might be more readable to write some processes in this way.

```csharp
TOut Pipe<TIn, TOut>(this TIn _this, Func<TIn, TOut> func)
```

```csharp
h(g(f(x)))                // normal function call
x.Pipe(f).Pipe(g).Pipe(h) // pipeline
```

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
    return fizzBuzz; // infinite Fizz buzz sequence
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

### ROT13 Cipher

```csharp
var rot = new Func<int, string, string>((degree, input) =>
    {
        var alphabet = Enumerate.From('a').To('z');
        var shiftedAlphabet = alphabet.Cycle().Skip(degree).Take(26);

        var repeatWithUpperCase = new Func<IEnumerable<char>, IEnumerable<char>>(x => x.Concat(x.Select(char.ToUpper)));
        var transformation = alphabet.Pipe(repeatWithUpperCase)
                                     .Zip(shiftedAlphabet.Pipe(repeatWithUpperCase))
                                     .ToDictionary();

        var result = input.Select(c => transformation.ContainsKey(c) ? transformation[c] : c).BuildString();
        return result;
    });
var rot13 = rot.Curry()(13);
```

Uses Endless methods **Enumerate.From()** and **.To()**, **Cycle()**, **Pipe()**, overloads of **Zip()** and **ToDictionary()**, **BuildString()** and **Curry**.

---

### Estimation of &pi; using Monte Carlo method

```csharp
var randomGenerator = new Random(666);

// infinite sequence of random numbers
var randomNumbers = new Func<double>(randomGenerator.NextDouble).Repeat();

// infinite sequence of random points
var randomPoints = randomNumbers.Zip(randomNumbers, (x, y) => new { x, y });

// infinite sequence of pi estimates with increasing precision
var piSequence = randomPoints.Scan(
    // n is the number of points used
    // piQuarter is the current estimate for pi/4
    new { n = 0, piQuarter = 0d }, (previous, point) => new {
        n = previous.n + 1,
        piQuarter =
        (
            previous.piQuarter * previous.n +

            // if the new point falls into the circle, we add 1, otherwise we add 0
            (Math.Sqrt(point.x * point.x + point.y * point.y) < 1 ? 1 : 0)

        ) / (previous.n + 1)
    }).Select(t => t.piQuarter * 4);
```

Uses Endless methods **Repeat()** and **Scan()**.

---

For other samples, visit [this test file](https://github.com/tompazourek/Endless/blob/master/Endless.Tests/Samples.cs).

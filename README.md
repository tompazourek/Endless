# Endless .NET

Extensions that support the C# functional paradigm.

See the wiki for [some samples of usage](https://github.com/tompazourek/Endless/wiki/Samples).

## Features

**Generate**

- [Yield](https://github.com/tompazourek/Endless/wiki/Generators#wiki-yield)
- [Iterate](https://github.com/tompazourek/Endless/wiki/Generators#wiki-iterate)
- [Repeat] (https://github.com/tompazourek/Endless/wiki/Generators#wiki-repeat)
- [Cycle] (https://github.com/tompazourek/Endless/wiki/Generators#wiki-cycle)

**Enumerate**

- [Natural numbers](https://github.com/tompazourek/Endless/wiki/Enumerate#wiki-natural-numbers)
- [Enumerate.From().Then().To()](https://github.com/tompazourek/Endless/wiki/Enumerate#wiki-from-then-to)

**Reduce**

- [Boolean reductions](https://github.com/tompazourek/Endless/wiki/Reductions#wiki-boolean-reductions) (And, Or)
- [Aggregate reductions](https://github.com/tompazourek/Endless/wiki/Reductions#wiki-folds) (AggregateRight)
- [Scan reductions](https://github.com/tompazourek/Endless/wiki/Reductions#wiki-scans) (Scan, ScanRight)

**Enumerable custom extensions**
- [Random](https://github.com/tompazourek/Endless/wiki/Enumerable-custom-extensions#wiki-random) (random element of the sequence)
- [Shuffle](https://github.com/tompazourek/Endless/wiki/Enumerable-custom-extensions#wiki-shuffle) (order sequence randomly)
- [Chunk](https://github.com/tompazourek/Endless/wiki/Enumerable-custom-extensions#wiki-chunk) (split sequence into chunks of same size)

**Existing enumerable extensions variations**
- Init (everything except the last) & Tail (everything except the first)
- IsEmpty (just opposite of Any)
- TakeUntil (predicate or element)
- SkipUntil (predicate or element)
- Sort, SortDescending (just like Sort on `List<T>` - default item ordering)

**Existing enumerable extensions overloads**
- SelectMany (overload without selector function)
- Except (just overload with single item parameter)
- Concat (with lazy second sequence)
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

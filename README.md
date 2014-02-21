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
- [Fold reductions](https://github.com/tompazourek/Endless/wiki/Reductions#wiki-folds) (Foldl, Foldl1, Foldr, Foldr1)
- [Scan reductions](https://github.com/tompazourek/Endless/wiki/Reductions#wiki-scans) (Scanl, Scanl1, Scanr, Scanr1)

**Enumerable custom extensions**
- [Random](https://github.com/tompazourek/Endless/wiki/Enumerable-custom-extensions#wiki-random) (random element of the sequence)
- [Shuffle](https://github.com/tompazourek/Endless/wiki/Enumerable-custom-extensions#wiki-shuffle) (order sequence randomly)
- [Chunk](https://github.com/tompazourek/Endless/wiki/Enumerable-custom-extensions#wiki-chunk) (split sequence into chunks of same size)

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

# CLSS.ExtensionMethods.IEnumerator.LoopNext

### Problem

Looping a collection indefinitely is an operation that maps well to many use cases (such as AI behavior phases, sequentially looping slideshow, infinite scrolling background,  etc...), but since there is no native way to perform this type of loop, you have to write some non-obvious code to do so.

```
var numbers = new int[] { 0, 1, 2, 3 };
int li = 0;
foreach (int i = 0; i < 10; ++i)
{
  var number = numbers[li];
  // do something wih number
  ++li;
  if (li == numbers.Length) li = 0;
}
```

### Solution

`LoopNext` is an extension method that infinitely advances an enumerator in a loop. The above code segment can be rewritten as follows:

```
using CLSS;

var numbers = new int[] { 0, 1, 2, 3 };
var numbersEnumerator = numbers.GetEnumerator();
foreach (int i = 0; i < 10; ++i)
{
  numbersEnumerator.LoopNext();
  DoSomethingWith(numbersEnumerator.Current);
}
```

Because `LoopNext` always returns true, the usual step of checking its result before accessing the `Current` property can be skipped altogether.

Since it then becomes natural to call `LoopNext` and accessing `Current` back-to-back, this package also comes with a `LoopNextElement` extension method that combines these 2 actions, moving to the next element in a loop directly:

```
using CLSS;

DoSomethingWith(numbersEnumerator.LoopNextElement());
```

You can visualize `LoopNextElement` as "popping off" one object from the front end of an infinite queue (that lazily evaluates).

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).
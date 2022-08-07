// A part of the C# Language Syntactic Sugar suite.

using System.Collections;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class IEnumeratorLoopNext
  {
    /// <summary>
    /// If the source enumerator is currently at the end of the collection, sets
    /// the enumerator to its initial position, which is before the first
    /// element in the collection. Then advances the enumerator to the next
    /// element of the collection regardless of whether it has been reset.
    /// </summary>
    /// <typeparam name="T">The type of objects to enumerate.</typeparam>
    /// <param name="enumerator">The source enumerator.</param>
    /// <returns>Always true.</returns>
    public static bool LoopNext<T>(this IEnumerator<T> enumerator)
    {
      if (!enumerator.MoveNext()) { enumerator.Reset(); enumerator.MoveNext(); }
      return true;
    }

    /// <summary>
    /// Advances the source enumerator to the next element of the collection in
    /// a loop and returns the object at that position.
    /// </summary>
    /// <typeparam name="T"><inheritdoc cref="LoopNext{T}(IEnumerator{T})"
    /// path="/typeparam[@name='T']"/></typeparam>
    /// <param name="enumerator">
    /// <inheritdoc cref="LoopNext{T}(IEnumerator{T})"
    /// path="/param[@name='enumerator']"/></param>
    /// <returns>The next element in the enumeration.</returns>
    public static T LoopNextElement<T>(this IEnumerator<T> enumerator)
    { enumerator.LoopNext(); return enumerator.Current; }

    /// <inheritdoc cref="LoopNext{T}(IEnumerator{T})"/>
    public static bool LoopNext(this IEnumerator enumerator)
    {
      if (!enumerator.MoveNext()) { enumerator.Reset(); enumerator.MoveNext(); }
      return true;
    }

    /// <inheritdoc cref="LoopNextElement{T}(IEnumerator{T})"/>
    public static object Pop(this IEnumerator enumerator)
    { enumerator.LoopNext(); return enumerator.Current; }
  }
}

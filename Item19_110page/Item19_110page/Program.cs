using System;
using System.Collections.Generic;

namespace Item19_110page
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public sealed class ReverseEnumerable<T> : IEnumerable<T>
    {
        private class ReverseEnumerator : IEnumerator<T>
        {
            int currentIndex;
            IList<T> collection;

            public ReverseEnumerator(IList<T> srcColleciton)
            {
                collection = srcColleciton;
                currentIndex = collection.Count;
            }

            public T Current => collection[currentIndex];

            public void Dispose()
            {
                // 반드시 구현 필요
                // IEnumerator<T>는 IDisposable을 상속하고 있기 때문
            }

            object System.Collections.IEnumerator.Current => this.Current;
            public bool MoveNext() => --currentIndex >= 0;
            public void Reset() => currentIndex = collection.Count;
        }

        private sealed class ReverseStringEnumerator : IEnumerator<char>
        {
            private string sourceSequence;
            private int currentIndex;

            public ReverseStringEnumerator(string source)
            {
                sourceSequence = source;
                currentIndex = source.Length;
            }

            public char Current => sourceSequence[currentIndex];

            public void Dispose()
            {
                // 세부 내용 구현 필요...
                // IEnumerator<T>는 IDisposable을 상속하고 있기 때문
            }

            object System.Collections.IEnumerator.Current
                => sourceSequence[currentIndex];
            public bool MoveNext() => --currentIndex >= 0;

            /// <summary>
            /// Count가 아니라 Length 사용!
            /// </summary>
            public void Reset() => currentIndex = sourceSequence.Length;
        }

        IEnumerable<T> sourceSequence;
        IList<T> originalSequence;

        public ReverseEnumerable(IEnumerable<T> sequence)
        {
            sourceSequence = sequence;
            originalSequence = sequence as List<T>;
        }

        public ReverseEnumerable(List<T> sequence)
        {
            sourceSequence = sequence;
            originalSequence = sequence;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if(sourceSequence is string)
            {
                return new ReverseStringEnumerator(sourceSequence as string) as IEnumerator<T>;
            }

            if (originalSequence == null)
            {
                if(sourceSequence is ICollection<T>)
                {
                    ICollection<T> source = sourceSequence as ICollection<T>;
                    originalSequence = new List<T>(source.Count);
                }
                else
                    originalSequence = new List<T>();

                foreach (T item in sourceSequence)
                    originalSequence.Add(item);
            }

            return new ReverseEnumerator(originalSequence);
        }

        System.Collections.IEnumerator
            System.Collections.IEnumerable.GetEnumerator() =>
                this.GetEnumerator();
    }
}

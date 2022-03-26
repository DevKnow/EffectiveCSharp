using System;

namespace Item17_95page
{
    class Program
    {
        static void Main(string[] args)
        {
            var something = new MyResourceHog();

            something.Dispose();
        }
    }

    public class MyResourceHog : IDisposable
    {
        private bool alreadyDisposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (alreadyDisposed) return;

            if (isDisposing)
            {
                // 관리 리소스 정리
            }
            // 비관리 리소스 정리

            alreadyDisposed = true;
        }

        public void ExampleMethod()
        {
            if (alreadyDisposed)
                throw new ObjectDisposedException("MyResourceHog",
                    "Called Example Method on Disposed object");
        }
    }

    public class DerivedResourceHog : MyResourceHog
    {
        private bool disposed = false;

        protected override void Dispose(bool isDisposing)
        {
            if (disposed) return;

            if (isDisposing)
            {
                // 비관리 리소스 정리
            }
            // 관리 리소스 정리

            base.Dispose(isDisposing);

            disposed = true;
        }
    }
}
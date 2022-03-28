using System;

namespace Item21_124page
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public interface IEngine
    {
        void DoWork();
    }

    /// <summary>
    /// 여기서 T가 IDisposable을 구현한 타입인 경우 리소스 누수 발생 가능.
    /// T 타입으로 지역 변수를 생성할 때마다 T가 IDisposable을 구현하고 있는지 확인해야 함.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EngineDriverOne<T> where T : IEngine, new()
    {
        public void GetThingsDone()
        {
            T driver = new T();
            using (driver as IDisposable)
            {
                driver.DoWork();
            }
        }
    }

    public sealed class EngineDriver2<T> : IDisposable where T : IEngine, new()
    {
        private Lazy<T> driver = new Lazy<T>(() => new T());

        public void GetThingsDone() => driver.Value.DoWork();

        public void Dispose()
        {
            if (driver.IsValueCreated)
            {
                var resource = driver.Value as IDisposable;
                resource?.Dispose();
            }
        }
    }

    public sealed class EngineDriver3<T> where T : IEngine
    {
        private T driver;

        public EngineDriver3(T driver) => this.driver = driver;
        public void GetThingsDone() => driver.DoWork();
    }
}
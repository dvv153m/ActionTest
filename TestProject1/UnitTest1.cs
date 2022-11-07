using Lib;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test2()
        {
            var t1 = Task.Factory.StartNew(() => {

                IoC2.Register("a", "A");
                Thread.Sleep(2000);
                IoC2.Resolve("a");
            });

            var t2 = Task.Factory.StartNew(() => {

                IoC2.Register("a", "A");
                Thread.Sleep(1000);
                IoC2.Resolve("b");
            });

            Task.WaitAll(t1, t2);

            IoC2.Register("c", "C");
        }

            [Fact]
        public void Test1()
        {
            var t1 = 0;
            var t2 = 0;

            var task1 = Task.Factory.StartNew(() =>
            {
                t1 = Thread.CurrentThread.ManagedThreadId;
            });

            var task2 = Task.Factory.StartNew(() =>
            {
                t2 = Thread.CurrentThread.ManagedThreadId;
            });

            Task.WaitAll(task1, task2);

            Assert.NotEqual(t1, t2);
        }
    }
}
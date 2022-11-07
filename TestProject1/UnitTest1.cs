namespace TestProject1
{
    public class UnitTest1
    {
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
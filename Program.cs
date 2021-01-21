using BenchmarkDotNet.Running;

namespace TestApp
{
    /// <summary>
    /// 配列プールクラス群のベンチマークアプリクラス。
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// メインエントリポイント。
        /// </summary>
        private static void Main() => BenchmarkRunner.Run<Benchmark>();
    }
}

using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace TestApp
{
    /// <summary>
    /// <see cref="ArrayPool{T}"/>,
    /// <see cref="ArrayPoolScope{T}"/>,
    /// <see cref="MemoryPool{T}"/> のベンチマーククラス。
    /// </summary>
    [GroupBenchmarksBy(
        BenchmarkLogicalGroupRule.ByCategory,
        BenchmarkLogicalGroupRule.ByParams)]
    public class Benchmark
    {
        /// <summary>
        /// 確保する配列の最小要素数。 BenchmarkDotNet によって初期化される。
        /// </summary>
        [Params(0, 10, 1000, 1000000)]
        public int Length { get; set; }

        #region ベンチマークメソッド群

        [Benchmark(Baseline = true), BenchmarkCategory(@"byte")]
        public void ArrayPool_Byte() => this.ArrayPoolImpl<byte>();

        [Benchmark, BenchmarkCategory(@"byte")]
        public void ArrayPoolScope_Byte() => this.ArrayPoolScopeImpl<byte>();

        [Benchmark, BenchmarkCategory(@"byte")]
        public void MemoryPool_Byte() => this.MemoryPoolImpl<byte>();

        [Benchmark(Baseline = true), BenchmarkCategory(@"char")]
        public void ArrayPool_Char() => this.ArrayPoolImpl<char>();

        [Benchmark, BenchmarkCategory(@"char")]
        public void ArrayPoolScope_Char() => this.ArrayPoolScopeImpl<char>();

        [Benchmark, BenchmarkCategory(@"char")]
        public void MemoryPool_Char() => this.MemoryPoolImpl<char>();

        [Benchmark(Baseline = true), BenchmarkCategory(@"int")]
        public void ArrayPool_Int() => this.ArrayPoolImpl<int>();

        [Benchmark, BenchmarkCategory(@"int")]
        public void ArrayPoolScope_Int() => this.ArrayPoolScopeImpl<int>();

        [Benchmark, BenchmarkCategory(@"int")]
        public void MemoryPool_Int() => this.MemoryPoolImpl<int>();

        [Benchmark(Baseline = true), BenchmarkCategory(@"object")]
        public void ArrayPool_Object() => this.ArrayPoolImpl<object>();

        [Benchmark, BenchmarkCategory(@"object")]
        public void ArrayPoolScope_Object() => this.ArrayPoolScopeImpl<object>();

        [Benchmark, BenchmarkCategory(@"object")]
        public void MemoryPool_Object() => this.MemoryPoolImpl<object>();

        #endregion

        #region ベンチマーク実処理

        /// <summary>
        /// <see cref="ArrayPool{T}"/> のベンチマーク実処理を行う。
        /// </summary>
        /// <typeparam name="T">配列の要素型。</typeparam>
        private void ArrayPoolImpl<T>()
        {
            var array = ArrayPool<T>.Shared.Rent(this.Length);
            try
            {
                UseArray<T?>(array);
            }
            finally
            {
                ArrayPool<T>.Shared.Return(array);
            }
        }

        /// <summary>
        /// <see cref="ArrayPoolScope{T}"/> のベンチマーク実処理を行う。
        /// </summary>
        /// <typeparam name="T">配列の要素型。</typeparam>
        private void ArrayPoolScopeImpl<T>()
        {
            using var scope = new ArrayPoolScope<T>(this.Length);
            UseArray<T?>(scope.Array);
        }

        /// <summary>
        /// <see cref="MemoryPool{T}"/> のベンチマーク実処理を行う。
        /// </summary>
        /// <typeparam name="T">配列の要素型。</typeparam>
        private void MemoryPoolImpl<T>()
        {
            using var owner = MemoryPool<T>.Shared.Rent(this.Length);
            UseArray(owner.Memory.Span);
        }

        /// <summary>
        /// 配列を受け取るダミーメソッド。インライン展開を抑制している。
        /// </summary>
        /// <typeparam name="T">配列の要素型。</typeparam>
        /// <param name="array">配列。</param>
        [MethodImpl(MethodImplOptions.NoInlining)]
        [SuppressMessage("Style", "IDE0060")]
        private static void UseArray<T>(Span<T> array) { }

        #endregion
    }
}

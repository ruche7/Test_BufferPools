using System;
using System.Buffers;

namespace TestApp
{
    /// <summary>
    /// <see cref="ArrayPool{T?}"/> オブジェクトからレンタルした配列を
    /// <see cref="Dispose"/> メソッドで返却する構造体。
    /// </summary>
    /// <typeparam name="T">配列要素型。</typeparam>
    /// <remarks>
    /// この構造体自体をコピーしてはならない。
    /// </remarks>
    [NonCopyable]
    public struct ArrayPoolScope<T> : IDisposable
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="minimumLength">配列の最小長。</param>
        /// <param name="arrayPool">
        /// <see cref="ArrayPool{T?}"/> オブジェクト。
        /// null ならば <see cref="ArrayPool{T?}.Shared"/> を用いる。
        /// </param>
        public ArrayPoolScope(int minimumLength, ArrayPool<T?>? arrayPool = null)
        {
            this.ArrayPool = arrayPool ?? ArrayPool<T?>.Shared;
            this.array = this.ArrayPool.Rent(minimumLength);
        }

        /// <summary>
        /// 配列を取得する。
        /// </summary>
        /// <remarks>
        /// デフォルト構築された場合や <see cref="Dispose"/> 呼び出し後は空の配列を返す。
        /// </remarks>
        public T?[] Array => this.array ?? System.Array.Empty<T>();

        /// <summary>
        /// レンタルした配列。
        /// </summary>
        private T?[]? array;

        /// <summary>
        /// 配列を <see cref="ArrayPool{T?}"/> オブジェクトに返却する。
        /// </summary>
        public void Dispose()
        {
            if (this.array is not null)
            {
                this.ArrayPool?.Return(this.array);
                this.array = null;
            }
        }

        /// <summary>
        /// <see cref="ArrayPool{T?}"/> オブジェクトを取得する。
        /// </summary>
        /// <remarks>
        /// デフォルト構築された場合は null を返す。
        /// </remarks>
        private ArrayPool<T?>? ArrayPool { get; }
    }
}

using System;
using System.Buffers;

namespace TestApp
{
    /// <summary>
    /// <see cref="ArrayPool{T}"/> からレンタルした配列を
    /// <see cref="Dispose"/> メソッドで返却するクラス。
    /// </summary>
    /// <typeparam name="T">配列要素型。</typeparam>
    public readonly struct ArrayPoolScope<T> : IDisposable
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="minimumLength">配列の最小長。</param>
        /// <param name="arrayPool">
        /// <see cref="ArrayPool{T}"/> オブジェクト。
        /// null ならば <see cref="ArrayPool{T}.Shared"/> を用いる。
        /// </param>
        public ArrayPoolScope(int minimumLength, ArrayPool<T>? arrayPool = null)
        {
            this.ArrayPool = arrayPool ?? ArrayPool<T>.Shared;
            this.Array = this.ArrayPool.Rent(minimumLength);
        }

        /// <summary>
        /// 配列を取得する。
        /// </summary>
        /// <remarks>
        /// <see cref="Dispose"/> メソッド呼び出し後は空の配列を返す。
        /// </remarks>
        public T[] Array { get; }

        /// <summary>
        /// 配列を <see cref="ArrayPool"/> に返却する。
        /// </summary>
        public void Dispose() => this.ArrayPool.Return(this.Array);

        /// <summary>
        /// <see cref="ArrayPool{T}"/> オブジェクトを取得する。
        /// </summary>
        private ArrayPool<T> ArrayPool { get; }
    }
}

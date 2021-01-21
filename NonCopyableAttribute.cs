using System;

namespace TestApp
{
    /// <summary>
    /// NonCopyableAnalyzer によってコピーを禁止する構造体をマークする属性。
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    public sealed class NonCopyableAttribute : Attribute
    {
    }
}

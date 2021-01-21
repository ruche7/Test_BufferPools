# Test_BufferPools

## Summary

* Visual Studio 2019 (Version 16.8.4)
* .NET 5.0 (Console application)
* Enable nullable option
* Use [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

## Benchmark methods

* `ArrayPool_`_Type_
    * Use `ArrayPool<T>.Shared.Rent` and `ArrayPool<T>.Shared.Return`.
* `ArrayPoolScope_`_Type_
    * Use `ArrayPoolScope<T>` (`ArrayPool<T>` wrapper struct) in `using` statement.
* `MemoryPool_`_Type_
    * Use `MemoryPool<T>.Shared.Rent` in `using` statement.

## Benchmark results (on ruche7's PC)

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.746 (2004/?/20H1)
Intel Core i7-5820K CPU 3.30GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  DefaultJob : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
```

**Length** column is minimum array length.

|                Method |  Length |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|---------------------- |-------- |----------:|----------:|----------:|----------:|------:|--------:|
|        ArrayPool_Byte |       0 |  9.603 ns | 0.2242 ns | 0.2303 ns |  9.474 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |       0 | 12.568 ns | 0.2809 ns | 0.3652 ns | 12.485 ns |  1.30 |    0.05 |
|       MemoryPool_Byte |       0 | 22.392 ns | 0.2802 ns | 0.2339 ns | 22.344 ns |  2.33 |    0.07 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |       0 |  9.339 ns | 0.2128 ns | 0.2185 ns |  9.327 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |       0 | 12.390 ns | 0.2759 ns | 0.3177 ns | 12.358 ns |  1.32 |    0.03 |
|       MemoryPool_Char |       0 | 22.563 ns | 0.3506 ns | 0.2737 ns | 22.506 ns |  2.43 |    0.07 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |       0 |  9.799 ns | 0.2257 ns | 0.2509 ns |  9.721 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |       0 | 13.188 ns | 0.1397 ns | 0.1166 ns | 13.142 ns |  1.35 |    0.03 |
|        MemoryPool_Int |       0 | 22.679 ns | 0.4816 ns | 0.5734 ns | 22.571 ns |  2.31 |    0.08 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |       0 | 40.091 ns | 0.8362 ns | 1.1163 ns | 39.372 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |       0 | 42.573 ns | 0.8636 ns | 1.1230 ns | 42.173 ns |  1.06 |    0.04 |
|     MemoryPool_Object |       0 | 69.392 ns | 1.3652 ns | 1.2770 ns | 68.845 ns |  1.74 |    0.05 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte |      10 | 32.616 ns | 0.6576 ns | 1.0618 ns | 32.648 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |      10 | 33.908 ns | 0.7076 ns | 1.1223 ns | 33.291 ns |  1.04 |    0.05 |
|       MemoryPool_Byte |      10 | 41.614 ns | 0.8425 ns | 0.9014 ns | 41.051 ns |  1.28 |    0.05 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |      10 | 30.096 ns | 0.6145 ns | 0.5447 ns | 29.826 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |      10 | 32.573 ns | 0.6612 ns | 0.9692 ns | 31.957 ns |  1.08 |    0.04 |
|       MemoryPool_Char |      10 | 40.318 ns | 0.1289 ns | 0.1006 ns | 40.265 ns |  1.34 |    0.03 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |      10 | 29.709 ns | 0.6182 ns | 1.0328 ns | 29.112 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |      10 | 34.747 ns | 0.5889 ns | 0.4598 ns | 34.743 ns |  1.17 |    0.04 |
|        MemoryPool_Int |      10 | 39.068 ns | 0.8006 ns | 1.1736 ns | 39.005 ns |  1.31 |    0.07 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |      10 | 57.574 ns | 1.1760 ns | 1.2077 ns | 56.621 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |      10 | 61.011 ns | 1.2510 ns | 1.6267 ns | 60.809 ns |  1.06 |    0.04 |
|     MemoryPool_Object |      10 | 87.904 ns | 1.7555 ns | 2.4029 ns | 86.647 ns |  1.53 |    0.06 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte |    1000 | 30.267 ns | 0.6427 ns | 0.9619 ns | 29.716 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |    1000 | 31.100 ns | 0.5145 ns | 0.6507 ns | 30.839 ns |  1.02 |    0.02 |
|       MemoryPool_Byte |    1000 | 39.077 ns | 0.5523 ns | 0.4612 ns | 38.897 ns |  1.27 |    0.05 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |    1000 | 28.595 ns | 0.2529 ns | 0.1974 ns | 28.577 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |    1000 | 31.874 ns | 0.6706 ns | 1.0637 ns | 31.295 ns |  1.14 |    0.04 |
|       MemoryPool_Char |    1000 | 40.375 ns | 0.5514 ns | 0.5157 ns | 40.111 ns |  1.41 |    0.02 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |    1000 | 37.328 ns | 0.7755 ns | 1.2957 ns | 36.847 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |    1000 | 31.608 ns | 0.6680 ns | 1.0201 ns | 31.053 ns |  0.84 |    0.04 |
|        MemoryPool_Int |    1000 | 38.742 ns | 0.7741 ns | 0.6863 ns | 38.387 ns |  1.04 |    0.04 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |    1000 | 52.707 ns | 1.0543 ns | 0.9862 ns | 52.080 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |    1000 | 55.582 ns | 0.0760 ns | 0.0635 ns | 55.594 ns |  1.05 |    0.02 |
|     MemoryPool_Object |    1000 | 85.910 ns | 1.7595 ns | 2.3489 ns | 85.808 ns |  1.64 |    0.06 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte | 1000000 | 30.197 ns | 0.6221 ns | 1.0896 ns | 29.616 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte | 1000000 | 31.085 ns | 0.1332 ns | 0.1040 ns | 31.086 ns |  1.03 |    0.03 |
|       MemoryPool_Byte | 1000000 | 44.701 ns | 0.7641 ns | 0.6381 ns | 44.372 ns |  1.49 |    0.05 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char | 1000000 | 30.531 ns | 0.6138 ns | 0.8803 ns | 30.114 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char | 1000000 | 31.889 ns | 0.2061 ns | 0.1721 ns | 31.936 ns |  1.04 |    0.04 |
|       MemoryPool_Char | 1000000 | 41.762 ns | 0.7557 ns | 0.6699 ns | 41.434 ns |  1.36 |    0.05 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int | 1000000 | 29.935 ns | 0.5880 ns | 0.5212 ns | 29.694 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int | 1000000 | 32.004 ns | 0.1940 ns | 0.1515 ns | 31.982 ns |  1.07 |    0.02 |
|        MemoryPool_Int | 1000000 | 45.195 ns | 0.9122 ns | 1.1536 ns | 44.820 ns |  1.52 |    0.05 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object | 1000000 | 53.849 ns | 0.1147 ns | 0.1017 ns | 53.810 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object | 1000000 | 54.830 ns | 0.2777 ns | 0.2319 ns | 54.820 ns |  1.02 |    0.01 |
|     MemoryPool_Object | 1000000 | 93.586 ns | 0.7573 ns | 0.6714 ns | 93.212 ns |  1.74 |    0.01 |

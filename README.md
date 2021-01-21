# Test_BufferPools

## Summary

* Visual Studio 2019 (Version 16.8.4)
* .NET 5.0 Console Application
* Use [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

## Benchmark methods

* `ArrayPool_`_Type_
    * Use `ArrayPool<T>.Shared.Rent` and `ArrayPool<T>.Shared.Return`.
* `ArrayPoolScope_`_Type_
    * Use `ArrayPoolScope<T>` (`ArrayPool<T>` wrapper struct) in `using` statement.
* `MemoryPool_`_Type_
    * Use `MemoryPool<T>.Shared.Rent` in `using` statement.

## Benchmark results (on ruche7's PC)

``` ini
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.746 (2004/?/20H1)
Intel Core i7-5820K CPU 3.30GHz (Broadwell), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  DefaultJob : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
```

**Length** column is minimum array length.

|                Method |  Length |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|---------------------- |-------- |----------:|----------:|----------:|----------:|------:|--------:|
|        ArrayPool_Byte |       0 |  9.006 ns | 0.2180 ns | 0.4200 ns |  8.683 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |       0 | 10.790 ns | 0.2498 ns | 0.3814 ns | 10.569 ns |  1.20 |    0.07 |
|       MemoryPool_Byte |       0 | 23.474 ns | 0.4976 ns | 0.8035 ns | 23.856 ns |  2.60 |    0.15 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |       0 |  9.184 ns | 0.0656 ns | 0.0548 ns |  9.158 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |       0 | 10.775 ns | 0.2465 ns | 0.3909 ns | 10.923 ns |  1.17 |    0.05 |
|       MemoryPool_Char |       0 | 23.680 ns | 0.5034 ns | 0.8948 ns | 23.220 ns |  2.56 |    0.09 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |       0 |  9.246 ns | 0.2255 ns | 0.3767 ns |  9.290 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |       0 | 10.615 ns | 0.2485 ns | 0.4083 ns | 10.820 ns |  1.15 |    0.07 |
|        MemoryPool_Int |       0 | 22.843 ns | 0.1058 ns | 0.0826 ns | 22.827 ns |  2.42 |    0.10 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |       0 | 39.425 ns | 0.8309 ns | 1.6008 ns | 40.306 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |       0 | 41.472 ns | 0.8648 ns | 1.5146 ns | 40.944 ns |  1.05 |    0.05 |
|     MemoryPool_Object |       0 | 72.865 ns | 1.4939 ns | 2.9489 ns | 70.965 ns |  1.85 |    0.11 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte |       1 | 33.191 ns | 0.6926 ns | 1.5347 ns | 32.988 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |       1 | 30.187 ns | 0.1040 ns | 0.0868 ns | 30.168 ns |  0.92 |    0.04 |
|       MemoryPool_Byte |       1 | 41.668 ns | 0.8607 ns | 1.3898 ns | 42.300 ns |  1.27 |    0.07 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |       1 | 30.264 ns | 0.6340 ns | 1.2950 ns | 29.364 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |       1 | 30.489 ns | 0.6488 ns | 1.4776 ns | 29.539 ns |  1.01 |    0.07 |
|       MemoryPool_Char |       1 | 41.981 ns | 0.0832 ns | 0.0779 ns | 41.987 ns |  1.38 |    0.06 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |       1 | 30.574 ns | 0.6430 ns | 1.4381 ns | 29.660 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |       1 | 32.729 ns | 0.1387 ns | 0.1158 ns | 32.702 ns |  1.05 |    0.05 |
|        MemoryPool_Int |       1 | 42.763 ns | 0.8877 ns | 1.6454 ns | 41.629 ns |  1.41 |    0.08 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |       1 | 56.419 ns | 1.1305 ns | 1.5848 ns | 55.403 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |       1 | 57.005 ns | 1.1766 ns | 3.0790 ns | 54.781 ns |  1.03 |    0.06 |
|     MemoryPool_Object |       1 | 89.716 ns | 1.8227 ns | 3.3329 ns | 87.356 ns |  1.58 |    0.06 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte |     100 | 32.523 ns | 0.6806 ns | 1.4650 ns | 31.456 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |     100 | 30.787 ns | 0.6724 ns | 1.4618 ns | 29.860 ns |  0.95 |    0.06 |
|       MemoryPool_Byte |     100 | 44.805 ns | 0.9271 ns | 1.5233 ns | 43.871 ns |  1.37 |    0.09 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |     100 | 28.718 ns | 0.6295 ns | 1.2859 ns | 27.892 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |     100 | 31.276 ns | 0.6696 ns | 1.4838 ns | 30.327 ns |  1.09 |    0.08 |
|       MemoryPool_Char |     100 | 41.839 ns | 0.8789 ns | 1.6507 ns | 40.648 ns |  1.45 |    0.09 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |     100 | 28.133 ns | 0.0713 ns | 0.0557 ns | 28.140 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |     100 | 29.015 ns | 0.5089 ns | 0.4249 ns | 28.756 ns |  1.03 |    0.02 |
|        MemoryPool_Int |     100 | 45.341 ns | 0.9447 ns | 1.5521 ns | 44.514 ns |  1.62 |    0.06 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |     100 | 51.955 ns | 1.0586 ns | 1.5845 ns | 51.128 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |     100 | 61.888 ns | 1.2620 ns | 2.9249 ns | 60.028 ns |  1.20 |    0.07 |
|     MemoryPool_Object |     100 | 87.801 ns | 1.7897 ns | 3.3615 ns | 85.221 ns |  1.70 |    0.08 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte |    1000 | 34.655 ns | 0.7235 ns | 1.7883 ns | 33.616 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |    1000 | 37.775 ns | 0.7788 ns | 1.9105 ns | 36.918 ns |  1.09 |    0.08 |
|       MemoryPool_Byte |    1000 | 42.403 ns | 0.7748 ns | 1.2731 ns | 41.901 ns |  1.22 |    0.08 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |    1000 | 31.656 ns | 0.6639 ns | 1.4291 ns | 31.777 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |    1000 | 31.165 ns | 0.6611 ns | 1.6948 ns | 30.054 ns |  0.98 |    0.06 |
|       MemoryPool_Char |    1000 | 41.487 ns | 0.1775 ns | 0.1744 ns | 41.502 ns |  1.34 |    0.06 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |    1000 | 29.525 ns | 0.6329 ns | 1.2929 ns | 28.794 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |    1000 | 31.243 ns | 0.6665 ns | 1.4629 ns | 30.682 ns |  1.06 |    0.06 |
|        MemoryPool_Int |    1000 | 39.527 ns | 0.8264 ns | 1.5921 ns | 38.474 ns |  1.34 |    0.07 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |    1000 | 51.070 ns | 0.2303 ns | 0.1798 ns | 50.992 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |    1000 | 56.206 ns | 1.1469 ns | 1.5698 ns | 55.016 ns |  1.10 |    0.03 |
|     MemoryPool_Object |    1000 | 86.696 ns | 0.2040 ns | 0.1704 ns | 86.603 ns |  1.70 |    0.01 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte |   10000 | 29.376 ns | 0.4896 ns | 0.4808 ns | 29.203 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte |   10000 | 31.202 ns | 0.6619 ns | 1.5731 ns | 30.176 ns |  1.06 |    0.04 |
|       MemoryPool_Byte |   10000 | 42.916 ns | 0.8768 ns | 1.4888 ns | 41.775 ns |  1.47 |    0.06 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char |   10000 | 32.642 ns | 0.6838 ns | 1.3969 ns | 31.752 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char |   10000 | 30.400 ns | 0.6498 ns | 1.4930 ns | 29.409 ns |  0.93 |    0.05 |
|       MemoryPool_Char |   10000 | 41.462 ns | 0.0929 ns | 0.0776 ns | 41.435 ns |  1.27 |    0.05 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int |   10000 | 32.310 ns | 0.6932 ns | 1.3520 ns | 31.505 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int |   10000 | 31.539 ns | 0.6670 ns | 1.4918 ns | 30.587 ns |  0.98 |    0.06 |
|        MemoryPool_Int |   10000 | 40.433 ns | 0.8492 ns | 1.4648 ns | 39.489 ns |  1.25 |    0.07 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object |   10000 | 51.924 ns | 1.0574 ns | 1.5499 ns | 53.169 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object |   10000 | 64.640 ns | 1.3260 ns | 3.0200 ns | 62.680 ns |  1.25 |    0.07 |
|     MemoryPool_Object |   10000 | 93.582 ns | 1.8862 ns | 3.5427 ns | 91.311 ns |  1.81 |    0.11 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Byte | 1000000 | 30.404 ns | 0.6564 ns | 1.5978 ns | 29.503 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Byte | 1000000 | 31.188 ns | 0.6653 ns | 1.4463 ns | 30.419 ns |  1.03 |    0.07 |
|       MemoryPool_Byte | 1000000 | 43.430 ns | 0.9006 ns | 1.5773 ns | 42.458 ns |  1.43 |    0.10 |
|                       |         |           |           |           |           |       |         |
|        ArrayPool_Char | 1000000 | 29.711 ns | 0.6562 ns | 1.4945 ns | 28.688 ns |  1.00 |    0.00 |
|   ArrayPoolScope_Char | 1000000 | 31.768 ns | 0.6620 ns | 1.3819 ns | 30.948 ns |  1.07 |    0.08 |
|       MemoryPool_Char | 1000000 | 50.160 ns | 1.0251 ns | 1.7407 ns | 49.053 ns |  1.69 |    0.10 |
|                       |         |           |           |           |           |       |         |
|         ArrayPool_Int | 1000000 | 28.506 ns | 0.1625 ns | 0.1269 ns | 28.452 ns |  1.00 |    0.00 |
|    ArrayPoolScope_Int | 1000000 | 31.479 ns | 0.1270 ns | 0.0991 ns | 31.499 ns |  1.10 |    0.00 |
|        MemoryPool_Int | 1000000 | 42.118 ns | 0.8840 ns | 1.7450 ns | 41.429 ns |  1.48 |    0.06 |
|                       |         |           |           |           |           |       |         |
|      ArrayPool_Object | 1000000 | 57.085 ns | 0.5214 ns | 0.4071 ns | 56.962 ns |  1.00 |    0.00 |
| ArrayPoolScope_Object | 1000000 | 54.280 ns | 0.4518 ns | 0.3527 ns | 54.206 ns |  0.95 |    0.01 |
|     MemoryPool_Object | 1000000 | 90.560 ns | 0.5477 ns | 0.4276 ns | 90.433 ns |  1.59 |    0.01 |

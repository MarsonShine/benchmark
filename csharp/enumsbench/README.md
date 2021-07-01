# 枚举的开销
枚举的直接转换的开销是很低的

```
BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.3 (19D76) [Darwin 19.3.0]
Intel Core i7-4770HQ CPU 2.20GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK=5.0.100
  [Host]     : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT
  DefaultJob : .NET 5.0.0 (5.0.20.51904), X64 RyuJIT


|         Method |    Mean |    Error |   StdDev |
|--------------- |--------:|---------:|---------:|
|  MemoryAnalyze | 5.643 s | 0.0260 s | 0.0243 s |
| MemoryAnalyze2 | 5.978 s | 0.1175 s | 0.1353 s |

// * Hints *
Outliers
  EnumBenchmark.MemoryAnalyze: Default -> 1 outlier  was  removed (5.83 s)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  1 s    : 1 Second (1 sec)

// ***** BenchmarkRunner: End *****
```

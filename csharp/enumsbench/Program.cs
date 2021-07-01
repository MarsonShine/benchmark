using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace enumsbench {
    class Program {
        static void Main(string[] args) {
            var summary = BenchmarkRunner.Run<EnumBenchmark>();
            // Console.WriteLine("Hello World!");
            // var expandMudules = BuildExpandModules();
            // Stopwatch sw = new Stopwatch();
            // sw.Start();
            // for (int i = 0; i < 10000000; i++) {
            //     _ = GetMeetAbilitResult(expandMudules);
            // }
            // sw.Stop();
            // Console.WriteLine($"enum parse elasped: {sw.ElapsedMilliseconds} ms");

            // sw.Restart();
            // for (int i = 0; i < 10000000; i++) {
            //     _ = GetMeetAbilitResult2(expandMudules);
            // }
            // sw.Stop();
            // Console.WriteLine($"enum none parse elasped: {sw.ElapsedMilliseconds} ms");
        }
    }

    public class EnumBenchmark {
        [Benchmark]
        public void MemoryAnalyze() {
            var expandMudules = BuildExpandModules();
            for (int i = 0; i < 10000000; i++) {
                _ = GetMeetAbilitResult(expandMudules);
            }
        }

        [Benchmark]
        public void MemoryAnalyze2() {
            var expandMudules = BuildExpandModules();
            for (int i = 0; i < 10000000; i++) {
                _ = GetMeetAbilitResult2(expandMudules);
            }
        }

        List<ExpandModule> BuildExpandModules() {
            List<ExpandModule> lists = new(20) {
                new(1),
                new(2),
                new(3),
                new(4),
                new(5),
                new(6),
                new(7),
                new(8),
                new(9),
                new(8),
                new(7),
                new(6),
                new(5),
                new(4),
                new(3),
                new(2),
                new(1),
            };
            return lists;
        }
        static int GetMeetAbilitResult2(List<ExpandModule> list) {
            int meetAbilityCount = 0;
            List<ModelEnum> listens = new() {
                ModelEnum.KeepListen,
                ModelEnum.Preview,
                ModelEnum.YxKeepListen,
                ModelEnum.EBook,
                ModelEnum.YxEBook,
                ModelEnum.YxDbbing,
                ModelEnum.Dubbing,
                ModelEnum.DictaionWords
            };
            List<ModelEnum> speeks = new() {
                ModelEnum.SaySaySee,
                ModelEnum.YxDbbing,
                ModelEnum.Dubbing,
            };
            List<ModelEnum> reads = new() {
                ModelEnum.Reader,
                ModelEnum.EBook,
                ModelEnum.YxEBook,
                ModelEnum.Preview
            };
            List<ModelEnum> acts = new() {
                ModelEnum.YxDbbing,
                ModelEnum.Dubbing,
            };

            var listenInfo = list.FirstOrDefault(o => listens.Contains(o.ModelIdEnum));
            if (listenInfo != null) {
                meetAbilityCount += 1;
            }

            var speakInfo = list.FirstOrDefault(o => speeks.Contains(o.ModelIdEnum));
            if (speakInfo != null) {
                meetAbilityCount++;
            }

            var readInfo = list.FirstOrDefault(o => reads.Contains(o.ModelIdEnum));
            if (readInfo != null) {
                meetAbilityCount++;
            }

            var actInfo = list.FirstOrDefault(o => acts.Contains(o.ModelIdEnum));
            if (actInfo != null) {
                meetAbilityCount++;
            }

            return meetAbilityCount >= 3 ? (int) YesNo.Yes : (int) YesNo.No;
        }
        int GetMeetAbilitResult(List<ExpandModule> list) {
            int meetAbilityCount = 0;
            List<int> listens = new List<int>() {
                (int) ModelEnum.KeepListen,
                (int) ModelEnum.Preview,
                (int) ModelEnum.YxKeepListen,
                (int) ModelEnum.EBook,
                (int) ModelEnum.YxEBook,
                (int) ModelEnum.YxDbbing,
                (int) ModelEnum.Dubbing,
                (int) ModelEnum.DictaionWords
            };
            List<int> speeks = new() {
                (int) ModelEnum.SaySaySee,
                (int) ModelEnum.YxDbbing,
                (int) ModelEnum.Dubbing,
            };
            List<int> reads = new() {
                (int) ModelEnum.Reader,
                (int) ModelEnum.EBook,
                (int) ModelEnum.YxEBook,
                (int) ModelEnum.Preview
            };
            List<int> acts = new() {
                (int) ModelEnum.YxDbbing,
                (int) ModelEnum.Dubbing,
            };

            var listenInfo = list.FirstOrDefault(o => listens.Contains(o.ModelId));
            if (listenInfo != null) {
                meetAbilityCount += 1;
            }

            var speakInfo = list.FirstOrDefault(o => speeks.Contains(o.ModelId));
            if (speakInfo != null) {
                meetAbilityCount++;
            }

            var readInfo = list.FirstOrDefault(o => reads.Contains(o.ModelId));
            if (readInfo != null) {
                meetAbilityCount++;
            }

            var actInfo = list.FirstOrDefault(o => acts.Contains(o.ModelId));
            if (actInfo != null) {
                meetAbilityCount++;
            }

            return meetAbilityCount >= 3 ? (int) YesNo.Yes : (int) YesNo.No;
        }
    }
    class ExpandModule {
        public ExpandModule(int modelId) {
            ModelId = modelId;
        }
        public int ModelId { get; }

        public ModelEnum ModelIdEnum => (ModelEnum) ModelId;
    }

    enum ModelEnum {
        KeepListen,
        Preview,
        YxKeepListen,
        EBook,
        YxEBook,
        YxDbbing,
        Dubbing,
        DictaionWords,
        SaySaySee,
        Reader,
    }

    enum YesNo {
        Yes,
        No
    }
}
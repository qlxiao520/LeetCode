namespace LeetCode.questions  {
    using System.Collections.Generic;
    using System.Linq;
    using utils;
    public class LeetCode_56_merge_intervals : LeetCode {
        public override void Test () {
            //MethodName = "TestCase";
            var array1 = new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var array1_expect = new int[][] { new int[] { 1, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var array3 = new int[][] { new int[] { 11, 13 }, new int[] { 12, 16 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
            var array3_expect = new int[][] { new int[] { 8, 10 }, new int[] { 11, 18 } };
            AreEqual (array1, array1_expect.Dumps());
            AreEqual (array3, array3_expect.Dumps());
        }

        public string TestCase(int[][] intervals){
            return Merge(intervals).Dumps();
        }

        public int[][] Merge (int[][] intervals) {

            if (intervals.Length == 0) {
                return intervals;
            }

            List<int[]> result = new List<int[]> ();
            //按照每个区间左边界排序
            intervals = intervals.OrderBy (p => p[0]).ToArray ();
            //遍历数组，比较相邻区间是否能合并
            for (int i = 0; i < intervals.Length - 1; i++) {
                //如果能合并，则向右合并
                if (intervals[i][1] >= intervals[i + 1][0]) {
                    //左区间比下一个大，向右合并左区间
                    intervals[i + 1][0] = intervals[i][0];
                    //有区间比下一个大，向右合并右区间
                    if (intervals[i][1] >= intervals[i + 1][1]) {
                        intervals[i + 1][1] = intervals[i][1];
                    }
                } else {
                    //不能合并，则将结果添加到数组里
                    result.Add (intervals[i]);
                }
            }
            //将最后一个元素添加到结果集
            result.Add (intervals[intervals.Length - 1]);

            return result.ToArray ();
        }

    }
}
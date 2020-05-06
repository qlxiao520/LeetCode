namespace LeetCode.questions {
    using System.Collections.Generic;
    using System.Linq;
    using System;
    public class LeetCode_169_majority_element : LeetCode {
        public override void Test () {
            MethodName = "MajorityElement";
            int[] test1 = { 3, 2, 3 };
            int[] test2 = { 2, 2, 1, 1, 1, 2, 2 };
            AreEqual (test1, 3);
            AreEqual (test2, 2);
        }
        /*
        给定一个大小为 n 的数组，找到其中的多数元素。多数元素是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。
        */
        public int MajorityElement (int[] nums) {
            return MajorityElement4(nums);
        }


        private int MajorityElement1 (int[] nums) {

            Dictionary<int, int> counts = new Dictionary<int, int> ();
            for (var i = 0; i < nums.Length; i++) {
                if (counts.ContainsKey (nums[i])) {
                    counts[nums[i]] += 1;
                } else {
                    counts.Add (nums[i], 1);
                }
            }
            int max = counts.Values.Max ();
            int result = (from d in counts where d.Value == max select d.Key).ToArray () [0];
            return result;

        }
        private int MajorityElement2 (int[] nums) {
            Array.Sort (nums);
            return nums[nums.Length / 2];
        }
        private int MajorityElement3 (int[] nums) {
            Dictionary<int, int> counts = new Dictionary<int, int> ();
            int countTreshold = nums.Length / 2;
            for (var i = 0; i < nums.Length; i++) {
                int temp = nums[i];

                if (counts.ContainsKey (temp)) {
                    counts[temp] += 1;
                } else {
                    counts.Add (temp, 1);
                }
                if (counts[temp] > countTreshold) {
                    return temp;
                }
            }
            return -1;
        }
        //用时最少
        private int MajorityElement4 (int[] nums) {
            int cnt = 1;
            int target = nums[0];
            for (int i = 1; i < nums.Length; i++) {
                if (cnt == 0) {
                    target = nums[i];
                    cnt = 1;
                } else {
                    if (nums[i] == target) cnt++;
                    else cnt--;
                }
            }

            return target;
        }
    }
}
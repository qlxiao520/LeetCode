namespace LeetCode.questions {
    using System;
    using utils;
    public class LeetCode_2_add_two_numbers : LeetCode {
        public override void Test () {
            //MethodName = "TestCase";
            //一个列表比另一个列表长
            AreEqual (new [] { 0, 1 }, new [] { 0, 1, 2 }, new [] { 0, 2, 2 }.GenerateList ().Dumps ());
            //一个列表为空
            AreEqual (new int[] { }, new [] { 0, 1 }, new [] { 0, 1 }.GenerateList ().Dumps ());
            //求和进位
            AreEqual (new [] { 2, 4, 3 }, new [] { 5, 6, 4 }, new [] { 7, 0, 8 }.GenerateList ().Dumps ());
        }

        public string TestCase (int[] input1, int[] input2) {

            return AddTwoNumbers (input1.GenerateList (), input2.GenerateList ()).Dumps ();

        }

        public ListNode AddTwoNumbers (ListNode l1, ListNode l2) {

            var val = 0;
            ListNode pre, lastNode;
            pre = new ListNode (0);
            lastNode = pre;

            while (l1 != null || l2 != null || val != 0) {
                val = val + (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);

                lastNode.next = new ListNode (val % 10);

                lastNode = lastNode.next;

                val = val / 10;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;

            }

            return pre.next;
        }

        int val = 0;

        public ListNode AddTwoNumbersWithRecursion (ListNode l1, ListNode l2) {

            if (l1 == null && l2 == null && val == 0) {
                return null;
            }

            val = val + (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);

            ListNode node = new ListNode (val % 10);

            val = val / 10;

            l1 = l1 == null ? null : l1.next;
            l2 = l2 == null ? null : l2.next;

            node.next = AddTwoNumbersWithRecursion (l1, l2);

            return node;

        }

    }
}
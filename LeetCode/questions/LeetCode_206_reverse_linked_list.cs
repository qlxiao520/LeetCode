namespace LeetCode.questions {
    using System;
    using utils;
    public class LeetCode_206_reverse_linked_list : LeetCode {
        public override void Test () {
            MethodName = "ReverseList";

        }

        public ListNode ReverseList (ListNode head) {
            return ReverseListRecursive (head);
        }

        public ListNode ReverseListRecursive (ListNode head) {

            if (head == null || head.next == null) {
                return head;
            }
            ListNode newHead = ReverseListRecursive (head.next); //递归部分

            //回溯部分
            head.next.next = head; //把当前头结点拿出来，让他的下一个的next指向他自己，就完成了该节点的逆序
            head.next = null; //下一个已经指向他了，可以把指向下一个的删掉了

            return newHead;

        }
        public ListNode ReverseListLoop (ListNode head) {
            ListNode pre = null;
            ListNode next = null;

            while (head != null) {
                next = head.next;
                head.next = pre;
                pre = head;
                head = next;
            }
            return pre;

        }
        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         * Input: 1->2->3->4->5->NULL
         * Output: 5->4->3->2->1->NULL
         */
        public static ListNode CreateListHead () {
            var head = new ListNode (1);
            head.next = null;
            int count = 5;
            for (int i = 0; i < count - 1; i++) {
                var node = new ListNode (count - i);
                node.next = head.next;
                head.next = node;
            }
            return head;
        }

        public static ListNode CreateListTail () {
            var head = new ListNode (1);
            head.next = null;
            var end = head;
            int count = 5;
            for (int i = 0; i < count - 1; i++) {
                var node = new ListNode (i + 2);
                node.next = null;
                end.next = node;
                end = node;
            }
            return head;

        }

        public static void Illustrate (ListNode head) {
            ListNode temp = head;
            Console.WriteLine (temp.val);
            while (temp.next != null) {
                Console.WriteLine (temp.next.val);
                temp = temp.next;
            }
        }
    }
}
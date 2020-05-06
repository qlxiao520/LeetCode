using System.Collections.Generic;
namespace LeetCode.utils {
    public static class LeetCodeExtension {
        /*
         * int[][]的ToString方法
         */
        public static string Dumps (this int[][] t) {
            string result = "[";
            for (int i = 0; i < t.Length; i++) {
                result += "[";
                for (int j = 0; j < t[i].Length; j++) {
                    result += t[i][j] + ",";
                }
                result = result.Remove (result.Length - 1);
                result += "],";
            }
            result = result.Remove (result.Length - 1);
            result += "]";
            return result;
        }
        /*
         * iList<string>的ToString方法
         */
        public static string Dumps (this IList<string> t) {
            string result = "[";

            for (int i = 0; i < t.Count; i++) {
                result += t[i] + ",";
            }
            result = result.Remove (result.Length - 1);
            result += "]";
            return result;
        }
        /*
         * 链表的ToString方法
         */
        public static string Dumps (this ListNode node) {
            string result = "";
            var n = node;
            while (n.next != null) {
                result += (n.val + "->");
                n = n.next;
            }
            result += n.val;
            return result;
        }
        /*
         * 从数组生成一个链表
         */
        public static ListNode GenerateList (this int[] vals) {
            ListNode head = null;
            ListNode last = null;

            foreach (var item in vals) {
                if (head == null) { //第一个节点
                    head = new ListNode (item);
                    last = head;
                } else {
                    last.next = new ListNode (item);
                    last = last.next;
                }
            }
            return head;
        }
        /*
         * 从list生成一个链表
         */
        public static ListNode GenerateList (this List<int> vals) {
            ListNode head = null;
            ListNode last = null;

            foreach (var item in vals) {
                if (head == null) { //第一个节点
                    head = new ListNode (item);
                    last = head;
                } else {
                    last.next = new ListNode (item);
                    last = last.next;
                }
            }
            return head;
        }

        /*
         *链表逆序
         */
        public static ListNode Reverse (this ListNode head) {

            //申请节点，pre和 cur，pre指向null
            ListNode pre = null;
            ListNode cur = head;
            ListNode tmp = null;
            while (cur != null) {
                //记录当前节点的下一个节点
                tmp = cur.next;
                //然后将当前节点指向pre
                cur.next = pre;
                //pre和cur节点都前进一位
                pre = cur;
                cur = tmp;
            }
            return pre;
        }
        /*
         *链表逆序，递归
         */
        public static ListNode ReverseRecursive (this ListNode head) {

            if (head == null || head.next == null) {
                return head;
            }
            ListNode newHead = ReverseRecursive (head.next); //递归部分

            //回溯部分
            head.next.next = head; //把当前头结点拿出来，让他的下一个的next指向他自己，就完成了该节点的逆序
            head.next = null; //下一个已经指向他了，可以把指向下一个的删掉了

            return newHead;

        }
    }

}
namespace LeetCode.questions  {
    using System.Collections.Generic;
    using utils;
    public class LeetCode_22_generate_parentheses : LeetCode {

        public override void Test () {
            //MethodName = "TestCase";
            AreEqual (3, "[((())),(()()),(())(),()(()),()()()]");
        }

        public string TestCase (int input) {
            return GenerateParenthesis (input).Dumps ();
        }
        //8/8 cases passed (284 ms)
        //Your runtime beats 51.48 % of csharp submissions
        //Your memory usage beats 14.29 % of csharp submissions (33 MB)
        public IList<string> GenerateParenthesis (int n) {
            List<string> result = new List<string> ();
            generate (result, n, n, "");
            return result;
        }
        public void generate (List<string> res, int left, int right, string curStr) {
            if (left == 0 && right == 0) {
                res.Add (curStr);
                return;
            }
            if (left > 0) {
                generate (res, left - 1, right, curStr + "(");
            }
            if (right > left) {
                generate (res, left, right - 1, curStr + ")");
            }
        }
    }
}
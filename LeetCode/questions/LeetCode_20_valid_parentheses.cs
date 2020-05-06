namespace LeetCode.questions  {
    using System.Collections.Generic;
    using System.Collections;
    using System;
    public class LeetCode_20_valid_parentheses : LeetCode {

        public override void Test () {
            //MethodName = "IsValid";
            AreEqual ("()", true);
            AreEqual ("()[]{}", true);
            AreEqual ("(]", false);
            AreEqual ("([)]", false);
            AreEqual ("{[]}", true);
            AreEqual (")}", false);
            AreEqual ("){", false);
            AreEqual ("", true);
            AreEqual ("{{)}", false);
            AreEqual ("((", false);
        }
        public bool IsValid_my (string s) {
            if (s.Length == 0) return true;
            if ((s.Length & 1) == 1) return false;
            Stack<char> t = new Stack<char> ();
            for (int i = 0; i < s.Length; i++) {
                char c = s[i];
                if (c == '(' || c == '{' || c == '[') {
                    t.Push (c);
                }
                if (c == ')' || c == '}' || c == ']') {
                    if (t.Count > 0) {
                        if (Math.Abs (t.Pop () - c) > 2) return false;
                    } else {
                        return false;
                    }
                }

            }
            return t.Count == 0;
        }

        //执行用时 :248 ms, 在所有 C# 提交中击败了5.24%的用户
        //内存消耗 :41.6 MB, 在所有 C# 提交中击败了6.10%的用户
        //replace大法
        public bool IsValid_1 (string s) {
            while (s.Contains ("()") || s.Contains ("[]") || s.Contains ("{}")) {
                s = s.Replace ("()", "");
                s = s.Replace ("[]", "");
                s = s.Replace ("{}", "");
            }
            return s.Length == 0;
        }

        //执行用时 :120 ms, 在所有 C# 提交中击败了18.80%的用户
        //内存消耗 :22.5 MB, 在所有 C# 提交中击败了12.20%的用户
        //辅助栈法，栈里留一个元素避免为空
        public bool IsValid (string s) {
            Hashtable ht = new Hashtable ();
            ht.Add ('(', ')');
            ht.Add ('[', ']');
            ht.Add ('{', '}');
            ht.Add ('?', '?');

            Stack<char> st = new Stack<char> ();
            st.Push ('?');

            for (int i = 0; i < s.Length; i++) {
                if (ht.Contains (s[i])) {
                    st.Push (s[i]);
                } else if (s[i] != (char) ht[st.Pop ()]) return false;
            }
            return st.Count == 1;
        }

    }
}
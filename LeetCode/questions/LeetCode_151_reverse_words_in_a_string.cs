namespace LeetCode.questions  {
    using System.Linq;
    using utils;
    public class LeetCode_151_reverse_words_in_a_string : LeetCode {

        public override void Test () {

            MethodName = "ReverseWords";
            AreEqual ("the sky is blue", "blue is sky the");
            AreEqual ("  hello world!  ", "world! hello");
            AreEqual ("a good   example", "example good a");
        }
        public string ReverseWords (string s) {
            return ReverseWordsInASentence (s);
        }

        //执行用时 :116 ms, 在所有 C# 提交中击败了42.17%的用户
        //内存消耗 :42.3 MB, 在所有 C# 提交中击败了50.00%的用户
        public string ReverseWords_my (string s) {
            string result = "";
            var words = s.Split (" ");
            for (int i = words.Length - 1; i >= 0; i--) {
                if (words[i] != "") {
                    result = result + words[i] + " ";
                }
            }
            return result.Trim ();
        }

        public string ReverseWords_while (string s) {
            string result = "";
            int index = s.Length - 1;
            string temp = "";
            //执行用时 :1112 ms, 在所有 C# 提交中击败了6.02%的用户
            //内存消耗 :46.7 MB, 在所有 C# 提交中击败了50.00%的用户
            while (index >= 0) {

                if (s[index] != ' ') {
                    temp += s[index];
                    if (index == 0 || (index >= 1 && s[index - 1] == ' ')) {

                        var t = temp.Reverse ();
                        foreach (var item in t) {
                            result += item;
                        }
                        result += " ";
                        temp = "";
                    }
                }

                index--;
            }
            return result.Trim ();
        }

        public string ReverseWordsFirstTry (string s) {
            /// 执行用时: 112 ms, 在所有 C# 提交中击败了 54.76% 的用户
            /// 内存消耗: 42.7 MB, 在所有 C# 提交中击败了 100.00% 的用户
            string[] words = s.Split (" ");
            string reverseString = "";
            for (int i = words.Length - 1; i >= 0; i--) {
                string trimedWord = words[i].Trim ();

                reverseString += string.IsNullOrEmpty (trimedWord) ? "" : $"{trimedWord} ";
            }
            return reverseString.Trim ();
        }

        public string ReverseWordsWithoutLastTrim (string s) {
            // 执行用时: 124 ms, 在所有 C# 提交中击败了 40.48% 的用户
            // 内存消耗: 42.5 MB, 在所有 C# 提交中击败了 100.00% 的用户
            string[] words = s.Trim ().Split (" ");
            string reverseString = "";
            for (int i = words.Length - 1; i > 0; i--) {
                reverseString += string.IsNullOrEmpty (words[i].Trim ()) ? "" : $"{words[i].Trim()} ";
            }

            if (string.IsNullOrEmpty (words[0].Trim ())) {
                return reverseString;
            } else {
                return $"{reverseString}{words[0].Trim()}";
            }
        }

        public string ReverseWordsThirdTry (string s) {
            // 执行用时: 156 ms, 在所有 C# 提交中击败了 7.14% 的用户
            // 内存消耗: 42.5 MB, 在所有 C# 提交中击败了 100.00% 的用户
            string[] words = s.Trim ().Split (" ");
            string reverseString = "";
            string trimedWord;
            for (int i = words.Length - 1; i > 0; i--) {
                trimedWord = words[i].Trim ();
                reverseString += string.IsNullOrEmpty (trimedWord) ? "" : $"{trimedWord} ";
            }

            trimedWord = words[0].Trim ();
            if (string.IsNullOrEmpty (trimedWord)) {
                return reverseString;
            } else {
                return $"{reverseString}{trimedWord}";
            }
        }

        public string ReverseWordsInASentence (string s) {
            // 执行用时 : 108 ms, 在所有 C# 提交中击败了 71.43% 的用户
            // 内存消耗 : 24.6 MB, 在所有 C# 提交中击败了 100.00% 的用户
            return string.Join (" ", s.Trim ().Split (" ").Where (word => !string.IsNullOrEmpty (word) && !string.IsNullOrEmpty (word.Trim ())).Reverse ());
        }
    }
}
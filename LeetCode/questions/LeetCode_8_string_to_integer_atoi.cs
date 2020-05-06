namespace LeetCode.questions  {
    using System;
    public class LeetCode_8_string_to_integer_atoi : LeetCode {
        public override void Test () {
            //MethodName = "MyAtoi";
            AreEqual ("42", 42);
            AreEqual ("     -42", -42);
            AreEqual ("4193 with words", 4193);
            AreEqual ("words and 987", 0);
            AreEqual ("1", 1);
            AreEqual ("-91283472332", int.MinValue);
            AreEqual ("+1", 1);
            AreEqual ("-", 0);
            AreEqual ("20000000000000000000", int.MaxValue);
            AreEqual (" 0000000000000000", 0);
        }
        //数字字符的 ascii码范围 [48,57]
        public int MyAtoi (string str) {

            if (str.Length == 0) return 0;
            int idx = 0;
            while (idx < str.Length && str[idx] == ' ') {
                idx++;
            }
            if (str.Length == idx) return 0;
            string resultNum = "";
            bool isNegativeNum = false;
            if (str[idx] == '-') {
                isNegativeNum = true;
                idx++;
            } else if (str[idx] == '+') {
                isNegativeNum = false;
                idx++;
            }
            while (idx < str.Length) {
                if (str[idx] >= 48 && str[idx] <= 57) {
                    resultNum += str[idx];
                    idx++;
                } else {
                    break;
                }
            }
            if (resultNum.Length == 0) return 0;
            bool success = int.TryParse (resultNum, out int result);
            if (result == 0) {
                if (success) {
                    return 0;
                } else if (isNegativeNum) {
                    return Int32.MinValue;
                } else {
                    return Int32.MaxValue;
                }
            }
            result = isNegativeNum ? -result : result;
            return result;
        }
    }
}
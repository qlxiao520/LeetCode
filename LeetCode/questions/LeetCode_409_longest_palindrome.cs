namespace LeetCode.questions
{
    public class LeetCode_409_longest_palindrome:LeetCode
    {
        public override void Test(){
            MethodName = "LongestPalindrome";
            AreEqual ("abccccdd", 7);
            AreEqual ("abc", 1);
            AreEqual ("aab", 3);
            AreEqual ("aa", 2);
            AreEqual ("a", 1);
            AreEqual ("aaa", 3);
            AreEqual ("AAAAAA", 6);
            AreEqual ("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth", 983);

        }

       public int LongestPalindrome (string s) {
            return LongestPalindrome_my(s);
        }
                //最长回文串，区分大小写
        private int LongestPalindrome_my (string s) {

            //把偶数(even)个字母和奇数(odd/uneven)个字母分别存下来
            //ascii 小写字母 'a' = 97 -> 'z'=122 , 大写字母 'A' = 65 -> 'Z'=90

            int[] uppercase = new int[26];
            int[] lowercase = new int[26];

            for (int i = 0; i < s.Length; i++) {
                char c = s[i];
                if (c >= 'A' && c <= 'Z') {
                    uppercase[c - 65]++;
                } else {
                    lowercase[c - 97]++;
                }
            }

            //计算回文数 = 奇数 减一变偶数 + 偶数个数之和
            int evenCount = 0;
            int oddCount = 0;

            for (int i = 0; i < 26; i++) {

                if (uppercase[i] % 2 == 0) {
                    evenCount += uppercase[i];
                } else {
                    evenCount += uppercase[i] - 1;
                    oddCount++;
                }

                if (lowercase[i] % 2 == 0) {
                    evenCount += lowercase[i];
                } else {
                    evenCount += lowercase[i] - 1;
                    oddCount++;
                }

            }
            //如果奇数数量不为0，最后在补回一个奇数来放中间
            return oddCount == 0 ? evenCount : evenCount + 1;

        }
    }
}
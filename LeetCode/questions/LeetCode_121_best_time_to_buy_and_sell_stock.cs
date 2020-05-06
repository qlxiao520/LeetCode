namespace LeetCode.questions  {
    using System.Linq;
    using System;
    public class LeetCode_121_best_time_to_buy_and_sell_stock : LeetCode {

        public override void Test () {
            //MethodName = "MaxProfit";
            int[] testArray1 = { 7, 1, 5, 3, 6, 4 };
            int[] testArray2 = { 7, 6, 4, 3, 1 };
            int[] testArray3 = { };
            int[] testArray4 = { 1 };
            int[] testArray5 = { 1, 2 };
            int[] testArray6 = { 2, 4, 1 };
            int[] testArray7 = { 3, 2, 6, 5, 0, 3 };
            AreEqual (testArray1, 5);
        }

        public int MaxProfit (int[] prices) {

            if (prices.Length <= 1) return 0;
            var pricesList = prices.ToList ();
            int min = pricesList[0];
            int max = 0;
            for (var i = 0; i < pricesList.Count; i++) {

                max = Math.Max (max, pricesList[i] - min);
                min = Math.Min (min, pricesList[i]);
            }

            return max;
            /* 我之前的思路
            int result = 0;
            while (pricesList.Count > 0) {

                var min = pricesList.Min ();

                var index = pricesList.IndexOf (min);

                var spanPrices = new Span<int> (prices, index, prices.Length - index);

                var max = spanPrices.ToArray ().Max ();

                result = result > (max - min) ? result : max - min;

                pricesList.Remove (min);
            }
            */

        }
    }
}
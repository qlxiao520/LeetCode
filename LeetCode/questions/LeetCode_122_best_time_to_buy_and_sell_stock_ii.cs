namespace LeetCode.questions  {
    using System;
    public class LeetCode_122_best_time_to_buy_and_sell_stock_ii : LeetCode {
        public override void Test () {
            //MethodName = "MaxProfit";
            AreEqual (new int[] { 7, 1, 5, 3, 6, 4 }, 7);
            AreEqual (new int[] { 1, 2, 3, 4, 5 }, 4);
            AreEqual (new int[] { 7, 6, 4, 3, 1 }, 0);
            AreEqual (new int[] { 7 }, 0);
            AreEqual (new int[] { 7, 1 }, 0);
        }
        public int MaxProfit (int[] prices) {
            if (prices.Length < 2) return 0;
            int buy = -prices[0];
            int sell = 0;
            for (var i = 0; i < prices.Length; i++) {
                buy = Math.Max (buy, sell - prices[i]);
                sell = Math.Max (sell, buy + prices[i]);
            }
            return sell;
        }
    }
}
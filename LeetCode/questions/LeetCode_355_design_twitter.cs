namespace LeetCode.questions {
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class LeetCode_355_design_twitter : LeetCode {

        public override void Test(){
            TestCase1 ();
        }

        static void Log (IList<int> t) {
            foreach (var item in t) {
                Console.Write (item + ",");
            }
            Console.WriteLine ();
        }
        static void TestCase1 () {
            Twitter twitter = new Twitter ();

            // 用户1发送了一条新推文 (用户id = 1, 推文id = 5).
            twitter.PostTweet (1, 5);

            // 用户1的获取推文应当返回一个列表，其中包含一个id为5的推文.
            Log (twitter.GetNewsFeed (1));
            // 用户1关注了用户2.
            twitter.Follow (1, 2);

            // 用户2发送了一个新推文 (推文id = 6).
            twitter.PostTweet (2, 6);

            // 用户1的获取推文应当返回一个列表，其中包含两个推文，id分别为 -> [6, 5].
            // 推文id6应当在推文id5之前，因为它是在5之后发送的.
            Log (twitter.GetNewsFeed (1));
            // 用户1取消关注了用户2.
            twitter.Unfollow (1, 2);

            // 用户1的获取推文应当返回一个列表，其中包含一个id为5的推文.
            // 因为用户1已经不再关注用户2.
            Log (twitter.GetNewsFeed (1));
        }

        static void TestCase2 () {
            Twitter twitter = new Twitter ();
            twitter.PostTweet (1, 5);
            twitter.PostTweet (1, 6);
            twitter.PostTweet (1, 7);
            twitter.PostTweet (1, 8);
            twitter.PostTweet (1, 9);
            twitter.PostTweet (1, 10);
            twitter.PostTweet (1, 11);
            twitter.PostTweet (1, 12);
            twitter.PostTweet (1, 13);
            twitter.PostTweet (1, 15);
            twitter.PostTweet (1, 17);
            twitter.PostTweet (1, 19);
            var tweet1 = twitter.GetNewsFeed (1);
            Log (tweet1);

        }
        static void TestCase3 () {
            Twitter twitter = new Twitter ();
            twitter.PostTweet (1, 5);
            twitter.Follow (1, 2);
            twitter.Follow (2, 1);
            var tweet = twitter.GetNewsFeed (2);
            Log (tweet);
            twitter.PostTweet (2, 6);
            tweet = twitter.GetNewsFeed (1);
            Log (tweet);
            tweet = twitter.GetNewsFeed (2);
            Log (tweet);
        }
        static void TestCase4 () {
            Twitter twitter = new Twitter ();
            twitter.PostTweet (1, 5);
            twitter.Follow (1, 2);
            twitter.Follow (2, 1);
            var tweet = twitter.GetNewsFeed (2);
            Log (tweet);
            twitter.PostTweet (2, 6);
            tweet = twitter.GetNewsFeed (1);
            Log (tweet);
            tweet = twitter.GetNewsFeed (2);
            Log (tweet);
            twitter.Unfollow (2, 1);
            tweet = twitter.GetNewsFeed (1);
            Log (tweet);
            tweet = twitter.GetNewsFeed (2);
            Log (tweet);

        }
    }

    public class Twitter {

        /** Initialize your data structure here. */
        //执行用时 :364 ms, 在所有 C# 提交中击败了85.71%的用户
        //内存消耗 :42.2 MB, 在所有 C# 提交中击败了100.00%的用户
        int id;
        int ID {
            get => id++;
        }

        struct Message {
            public int msgId;
            public int msgContent;
        }

        Dictionary<int, List<Message>> data;
        Dictionary<int, List<int>> follow;
        public Twitter () {

            data = new Dictionary<int, List<Message>> ();
            follow = new Dictionary<int, List<int>> ();
            id = 0;
        }

        /** Compose a new tweet. */
        public void PostTweet (int userId, int tweetId) {

            var msg = new Message () {
                msgId = ID,
                msgContent = tweetId
            };
            if (data.ContainsKey (userId)) {

                data[userId].Add (msg);
            } else {
                data.Add (userId, new List<Message> { msg });
            }
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed (int userId) {

            Dictionary<int, int> tweets = new Dictionary<int, int> ();
            //自己的
            if (data.ContainsKey (userId)) {
                foreach (var item in data[userId]) {
                    tweets[item.msgId] = item.msgContent;
                }
            }

            //关注的
            if (follow.ContainsKey (userId)) {
                foreach (var item in follow[userId]) {
                    if (data.ContainsKey (item)) {
                        foreach (var data1 in data[item]) {
                            tweets[data1.msgId] = data1.msgContent;
                        }
                    }
                }
            }

            var resultTweets = tweets.OrderByDescending (r => r.Key).Select (r => r.Value).Take (10);

            List<int> result = new List<int> ();

            foreach (var item in resultTweets) {
                result.Add (item);
            }
            return result;
        }
        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow (int followerId, int followeeId) {
            if (follow.ContainsKey (followerId)) {
                follow[followerId].Add (followeeId);
            } else {
                follow.Add (followerId, new List<int> { followeeId });
            }
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow (int followerId, int followeeId) {
            if (follow.ContainsKey (followerId)) {
                follow[followerId].Remove (followeeId);
            }
        }

        /**
         * Your Twitter object will be instantiated and called as such:
         * Twitter obj = new Twitter();
         * obj.PostTweet(userId,tweetId);
         * IList<int> param_2 = obj.GetNewsFeed(userId);
         * obj.Follow(followerId,followeeId);
         * obj.Unfollow(followerId,followeeId);
         */
    }
}
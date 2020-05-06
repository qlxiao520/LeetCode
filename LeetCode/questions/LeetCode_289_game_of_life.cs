namespace LeetCode.questions {
    using System;
    public class LeetCode_289_game_of_life : LeetCode {
        public override void Test () {
            MethodName = "GameOfLife";
            TestCase (new int[][] {
                new int[] { 0, 1, 0 },
                    new int[] { 0, 0, 1 },
                    new int[] { 1, 1, 1 },
                    new int[] { 0, 0, 0 }
            });
        }

        public void GameOfLife (int[][] board) {
            //复制一份用来同步更新
            var copy = Copy (board);

            int[] dx = { 0, 0, -1, -1, -1, 1, 1, 1 };
            int[] dy = {-1, 1, -1, 0, 1, -1, 0, 1 };
            int count = 0;
            for (int i = 0; i < board.Length; i++) {
                for (int j = 0; j < board[i].Length; j++) {
                    //8方向寻找
                    count = 0;
                    for (int k = 0; k < 8; k++) {
                        int x = i + dx[k];
                        int y = j + dy[k];
                        //边界判断
                        if (x < 0 || x >= board.Length || y < 0 || y >= board[i].Length) {
                            continue;
                        }
                        //统计活细胞数量
                        if (copy[x][y] == 1) {
                            count++;
                        }
                    }

                    if (board[i][j] == 0 && count == 3) {
                        board[i][j] = 1;
                    }

                    if (count == 3 || count == 2) {
                        board[i][j] = board[i][j] & 1;
                    } else {
                        board[i][j] = 0;
                    }

                }
            }
        }

        void TestCase (int[][] board) {
            GameOfLife (board);
            foreach (var item in board) {
                foreach (var item1 in item) {
                    Console.Write (item1 + "  ");
                }
                Console.WriteLine ();
            }
        }

        public static T Copy<T> (T t) {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream ()) {
                bf.Serialize (ms, t);
                ms.Position = default;
                return (T) bf.Deserialize (ms);
            }
        }

    }
}
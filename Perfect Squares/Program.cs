namespace Perfect_Squares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 13;
            var sol = new Solution();
            var ans = sol.NumSquares_Dp(n);
            Console.WriteLine(ans);
        }
    }

    public class Solution
    {
        // start with simple recursion
        // O(n*sqrt(n))
        public int NumSquares_rec(int n)
        {
            var ans = n;
            for (int i = 1; i * i <= n; i++)
            {
                var sqr = i * i;
                ans = Math.Min(ans, 1 + NumSquares_rec(n - sqr));
            }
            return ans;
        }

        // optiimize with memorization
        // O(n*sqrt(n))
        Dictionary<int, int> cache = new Dictionary<int, int>();
        public int NumSquares_rec_memo(int n)
        {
            if(cache.ContainsKey(n)) return cache[n];
            if(n <= 0) return 0;
            var ans = n;
            for (int i = 1; i * i <= n; i++)
            {
                var sqr = i * i;
                ans = Math.Min(ans, 1 + NumSquares_rec_memo(n - sqr));
            }
            cache[n] = ans;
            return ans;
        }


        // usig DP
        // O(n*sqrt(n))
        //Dictionary<int, int> cache = new Dictionary<int, int>();
        public int NumSquares_Dp(int n)
        {
            var dp = new int[n + 1];
            dp[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                // to make i at max we need i no of sqrs
                // eg - 12 can be make by max 12 no of 1's, when we take 1*1
                dp[i] = i;
                // we have to minumize dp[i]

                // below loop for all sqr from 1
                for (int j = 1; j * j <= i; j++)
                {
                    var sqr = j * j;
                    var diff = i - sqr;
                    dp[i] = Math.Min(dp[i], 1 + dp[diff]);
                }
            }
            return dp[n];
        }
    }
}

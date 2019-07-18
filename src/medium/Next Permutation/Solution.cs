using System;
using System.Collections.Generic;
using System.Linq;

namespace Next_Permutation
{
    class Solution
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            var nums = new int[] { 1, 2, 3 };
            // solution.NextPermutation(nums);
            // nums = new int[] { 1, 3, 2 };
            // solution.NextPermutation(nums);
            // nums = new int[] { 3, 2, 1 };
            // solution.NextPermutation(nums);
            // nums = new int[] { 1, 1, 5 };
            // solution.NextPermutation(nums);
            // nums = new int[] { 5, 1, 1 };
            // solution.NextPermutation(nums);
            nums = new int[] { 1 };
            solution.NextPermutation(nums);
            // nums = new int[] { 1, 1 };
            // solution.NextPermutation(nums);
            // nums = new int[] { 2, 2, 7, 5, 4, 3, 2, 2, 1 };
            // solution.NextPermutation(nums);
            Console.WriteLine("Hello World!");
        }
        private void MergeSort(int[] source, int left, int right)
        {
            if (right - left == 1) return;
            int mid = left + (right - left) / 2;

            // 左半分 [left, mid) をソート
            MergeSort(source, left, mid);

            // 右半分 [mid, right) をソート
            MergeSort(source, mid, right);

            // 一旦「左」と「右」のソート結果をコピーしておく (右側は左右反転)
            List<int> buf = new List<int>();
            for (int i = left; i < mid; i++) buf.Add(source[i]);
            for (int i = right - 1; i >= mid; i--) buf.Add(source[i]);

            // マージする
            int iterator_left = 0;                    // 左側のイテレータ
            int iterator_right = (int)buf.Count - 1; // 右側のイテレータ
            for (int i = left; i < right; i++)
            {
                // 左側採用
                if (buf[iterator_left] <= buf[iterator_right])
                {
                    source[i] = buf[iterator_left++];
                }
                // 右側採用
                else
                {
                    source[i] = buf[iterator_right--];
                }
            }
        }
        /*
        参考実装
        */
        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 1)
            {
                return;
            }
            int left = -1;//index初期位置
            int right = nums.Length - 1;//後ろからさかのぼる
            /*
            123432 -> 34の位置
             */
            for (int i = nums.Length - 1; i > 0; i--)
            {
                /*
               降順の区間を調べる
                 */
                if (nums[i] > nums[i - 1])
                {
                    left = i - 1;
                    break;
                }
            }

            /*
            全て降順=一番大きいので全てをひっくり返す or SORTする。
             */
            if (left == -1)
            {
                // Reverse(nums, 0, nums.Length - 1);
                Array.Sort(nums);
                return;
            }

            /*
            leftが分岐点(12343 -> 12433とする)なので
            leftより後ろで、nums[left]より大きいかつ(nums[left],nums[nums.Length-1]]のなかで
            最小値のものを探す
            基本はnums[nums.Length-1]となるはず
            nums[left+1]はleftより後ろでnums[left]より大きい（だけ）
             */
            //  var max = 99;
            for (int i = nums.Length - 1; i > left; i--)
            {
                if (nums[i] > nums[left])
                {
                    right = i;
                    break;
                }
            }
            //入れ替え
            Swap(nums, left, right);
            //入れ替えた後ろは全て入れ替え
            Reverse(nums, left + 1, nums.Length - 1);
        }

        /*
        swap
        */
        private void Swap(int[] nums, int left, int right)
        {
            int exch = nums[left];
            nums[left] = nums[right];
            nums[right] = exch;
        }
        /*
        指定位置から後ろを入れ替える
        [left, right]　両閉区間
         */
        private void Reverse(int[] nums, int left, int right)
        {
            for (int i = 0; i <= (left + right) / 2 - left; i++)
            {
                Swap(nums, left + i, right - i);
            }
        }
    }
}

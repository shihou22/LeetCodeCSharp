using System;

namespace Search_in_Rotated_Sorted_Array_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine(program.Search(new int[] { 1, 3, 1, 1, 1 }, 3));
            Console.WriteLine(program.Search(new int[] { 3, 1 }, 1));
            Console.WriteLine(program.Search(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 0));
            Console.WriteLine(program.Search(new int[] { 2, 5, 6, 0, 0, 1, 2 }, 3));

            Console.WriteLine("Hello World!");
        }
        public bool Search(int[] nums, int target)
        {
            return binarySearch(nums, target, 0, nums.Length - 1);
        }
        private bool binarySearch(int[] nums, int target, int left, int right)
        {
            if (left > right)
            {
                return false;
            }
            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return true;
            int wkLeft = left;
            int wkRight = right;
            if (nums[mid] < nums[right])
            {
                if (nums[mid] < target && target <= nums[right])
                    wkLeft = mid + 1;
                else
                    wkRight = mid - 1;
            }
            else if (nums[mid] > nums[right])
            {
                if (nums[left] <= target && target < nums[mid])
                    wkRight = mid - 1;
                else
                    wkLeft = mid + 1;
            }
            else
            {
                wkRight -= 1;
            }
            return binarySearch(nums, target, wkLeft, wkRight);
        }
        private bool binarySearch2(int[] nums, int target, int left, int right)
        {
            if (left > right)
                return false;

            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return true;

            // return binarySearch(nums, target, left, mid - 1) || binarySearch(nums, target, mid + 1, right);

            if (nums[left] < nums[mid])
            {
                if (nums[left] <= target && target < nums[mid])
                    return binarySearch2(nums, target, left, mid - 1);
                else
                    return binarySearch2(nums, target, mid + 1, right);
            }
            else if (nums[left] > nums[mid])
            {
                if (nums[mid] < target && target <= nums[right])
                    return binarySearch2(nums, target, mid + 1, right);
                else
                    return binarySearch2(nums, target, left, mid - 1);
            }
            else
            {
                /*
                値を見つけられなかったのでrightを減らしていく
                ここに来るということは、mid==rightの時
                */
                return binarySearch2(nums, target, left + 1, right);
            }

        }
        private bool binarySearchBK(int[] nums, int target, int left, int right)
        {
            if (left > right)
                return false;

            int mid = left + (right - left) / 2;
            if (nums[mid] == target)
                return true;

            // return binarySearch(nums, target, left, mid - 1) || binarySearch(nums, target, mid + 1, right);

            if (nums[mid] < nums[right])
            {
                if (nums[mid] < target && target <= nums[right])
                    return binarySearch(nums, target, mid + 1, right);
                else
                    return binarySearch(nums, target, left, mid - 1);
            }
            else if (nums[mid] > nums[right])
            {
                if (nums[left] <= target && target < nums[mid])
                    return binarySearch(nums, target, left, mid - 1);
                else
                    return binarySearch(nums, target, mid + 1, right);
            }
            else
            {
                /*
                値を見つけられなかったのでrightを減らしていく
                ここに来るということは、mid==rightの時
                */
                return binarySearch(nums, target, left, right - 1);
            }

        }
    }
}
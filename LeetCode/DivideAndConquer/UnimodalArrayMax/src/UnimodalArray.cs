namespace UnimodalArrayMax
{

    public class UnimodalArray
    {

        public int[] Array { get; set; }
        public UnimodalArray(int[] array)
        {
            Array = array;
        }
        public int FindMax()
        {
            return FindMax(0, Array.Length - 1);
        }
        private int FindMax(int start, int end)
        {
            if (end - start <= 1)
            {
                return Array[end] >= Array[start] ? Array[end] : Array[start];
            }
            var middle = (end - start + 1) / 2;
            var left = middle - 1;
            var right = middle + 1;

            if (left >= 0 && right < Array.Length
                && Array[middle] > Array[left] && Array[middle] > Array[right])
            {
                return Array[middle];
            }
            //check left side of Array for max
            if (left >= 0 && Array[left] > Array[middle] && middle / 2 >= left)
            {
                return FindMax(left, middle / 2);
            }
            //check right side of Array for max
            if (right < Array.Length && Array[right] > Array[middle] && middle / 2 <= right)
            {
                return FindMax(middle / 2, right);
            }
            return 0;
        }
    }


}

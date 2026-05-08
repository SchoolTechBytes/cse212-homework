public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // First we need to create a array that that is the size of length, this will be the result array that we will return at the end of the function
        // Next we create a loop that will loop through the array fromm 0 to length -1
        // Then store the new value in the array using the calculations of number * the current index + 1, Index i = number * (i + 1)
        // Finally return the result array they we created at the beginning of the function
        
        // step 1 create the result array
        var result = new double[length];

        // step 2: loop and fill the array with multiples
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // Last step: return the result array
        return result; 
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // First we need to find the split of the list, data.Count - amount, this will be were the list will be split into to parts, the head and the tail
        // Next we extract the tail from the list and store it in a new list called tail
        // Then we have the head of the list, which is the first part of the original list
        // Then we clear the original list and add the tail to the front of the list and then add the head to the end of the list

        // step 1: find the split point
        int splitPoint = data.Count - amount;

        // step 2: extract the tail
        List<int> tail = data.GetRange(splitPoint, amount);

        // step 3: extract the head
        List<int> head = data.GetRange(0, splitPoint);

        // step 4: clear the original list and add the tail and head back in the correct order
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}

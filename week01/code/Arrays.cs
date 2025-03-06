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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create an array of type double with a fixed size of 'length'
        // Given a 'number', this array will store multiples of that number
        // Assume that length is an integer greater than 0, so don't validate the value of length.
        double[] result = new double[length];
        
        // Use a loop to iterate through each index of the new array
        // The loop will run for 'length' times, starting at index 0
        for (int i = 0; i < length; ++i) {
            // Calculate multiples of the 'number' starting at 1 and ending at the 'length' of the array
            // Add 1 to the array index (i + 1) to ensure the multiples start from 1 and not 0
            // and multiply by the given 'number' to get the result for each index
            result[i] = number * (i + 1);
        }

        return result; // return the array of multiples
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Slice the 'data' list into two separate lists, 
        // using the total list items minus the 'amount' as the split point
        int splitPoint = data.Count - amount;
        // list1 will contain the all the items up to the split point
        List<int> list1 = data.GetRange(0, splitPoint);
        // list2 will contain all the items after the split point
        List<int> list2 = data.GetRange(splitPoint, amount);

        // Save the two lists to the 'data' list, putting list2 first 
        data.Clear();
        data.AddRange(list2);
        data.AddRange(list1);
    }
}

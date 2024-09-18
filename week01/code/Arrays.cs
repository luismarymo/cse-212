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

        //The first step to solve this problem must be to create the array were the resulting multiples will be stored with a capacity of "lenght" so that it is able to store the amount of multiples requested, and then start a loop that will run as many times as "lenght". Every time the loop is run, the int "number" will be multiplied by "i" (which is initialized with a value of 1 and increases with every iteration) and the resulting multiple will be added to the array. once the loop is done, the array with multiples will be returned.  

        var results = new double[length]; 
        for (int i = 1; i <= length; i++){
            double multiple = number * i;
            results[i-1] = multiple; //i - 1 because of 0 based index. 
        }

        return results; // replace this return statement with your own
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

        // To solve this problem I will first create a list to store the numbers that will be rotating using .GetRange. To get the proper index from which to start the range I used .Count and deducted "amount". Then those same numbers will be removed from the original list using .RemoveRange and then inserted back in but at index 0 through .InsertRange. 
        List<int> rotatingNumbers = data.GetRange(data.Count-amount, amount);
        data.RemoveRange(data.Count-amount, amount);
        data.InsertRange(0, rotatingNumbers);
    }
}

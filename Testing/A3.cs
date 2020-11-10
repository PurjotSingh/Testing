using System;
using System.Collections.Generic;

namespace COMP10066_Lab3
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     * 
     * ============================================================
     * Providing Variable names that act as self-explanatory:
     * s has been changed to listSum using camelCasing (in Average Method )
     * c has been changed to count (in Average Method )
     * 
     * val has been changed to value (in Sum Method )
     * 
     * s has been changed to sum (in StandardDeviation Method )
     * a has been changed to average (in StandardDeviation Method )
     * stdev has been changed to standardDeviation Using camelCasing (in StandardDeviation Method )
     * 
     * 
     * Extra variables:
     * 'n' and 'v' were extra variables and
     * instead the expression could have been used at their place
     * as they are used only at one or two places and make the code harder to read
     * rather than simplifying.
     * So, instead data.Count and data[i] have been used respectively for 'n' and 'v'.
     * 
     * 
     * Providing Self-explanatory names to the Methods:
     * Avg has been changed to Average in order to avoid using any abbreviations
     * SD has been changed to StandardDeviation using PascalCasing for method names.
     * 
     * =============================
     * Editing done By: Purjot Singh
     * Student ID: 000819156
     * =============================
     */


    /// The class name should also be changed to
    /// Assignment3  instead of A3
    /// as it makes much more sense and is not 
    /// ambiguous as A3.
    public class A3
    {
        /// <summary>
        /// This method calculates the average value of the provided List.
        /// </summary>
        /// <param name="x"> A List that contains double values whose average is to be calculated.</param>
        /// <param name="incneg"> A Boolean value. </param>
        /// <returns> The double value average of the provided List.</returns>
        public static double Average(List<double> x, bool incneg)
        {
            double listSum = Sum(x, incneg);  // Calculates and stores the sum of the List
            int count = 0; // Helps in counting the number of items in the List
            for (int i = 0; i < x.Count; i++)
            {
                if (incneg || x[i] >= 0)
                {
                    count++;
                }
            }
            // Throws an Error if the List contains no item.
            if (count == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            return listSum / count;
        }

        /// <summary>
        /// This method calculates the sum of the double values in the provided List.
        /// </summary>
        /// <param name="x"> A List that contains double value whose sum is to be calculated. </param>
        /// <param name="incneg"> A Boolean value. </param>
        /// <returns> The double value sum of the values in the provide List. </returns>
        public static double Sum(List<double> x, bool incneg)
        {
            if (x.Count < 0) // The value 0 needs to be changed to 1 for it to give exception when empty List is passed
            {
                throw new ArgumentException("x cannot be empty");
            }

            double sum = 0.0;

           // A way to Iterate through the items in the List and Add them
            foreach (double value in x)
            {
                if (incneg || value >= 0)
                {
                    sum += value;
                }
            }
            return sum;
        }

        /// <summary>
        /// This method calculates the Median of the double values in the List. 
        /// </summary>
        /// <param name="data"> A List containing Double values in it. </param>
        /// <returns> The Double value of Median in the List. </returns>
        public static double Median(List<double> data)
        {
            // Throws an Exception Error when the List contains 0 items
            if (data.Count == 0)
            {
                throw new ArgumentException("Size of array must be greater than 0");
            }

            data.Sort(); // Sorts the List in order to get a Median

            double median = data[data.Count / 2];
            if (data.Count % 2 == 0)
            {
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;
            }
            return median;
        }

        /// <summary>
        /// This method calculates the Standard Deviation in the List containing double values.
        /// </summary>
        /// <param name="data"> A Double value List. </param>
        /// <returns> The double value of Standard Deviation in the List. </returns>
        public static double StandardDeviation(List<double> data) 
        {
            // Throws an Exception Error if the List contains 1 or less items.
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            //int n = data.Count;
            double sum = 0; 
            double average = Average(data, true);

            // Iterate through the List Items
            for (int i = 0; i < data.Count; i++)
            {
               // double v = data[i];
                sum += Math.Pow(data[i] - average, 2);
            }

            // To simplify the code more instead of assigning a new variable 
            // a simple return statement could 
            // have been used here. 

            double standardDeviation = Math.Sqrt(sum / (data.Count - 1));
            return standardDeviation;
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<Double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };

            Console.WriteLine("The sum of the array = {0}", Sum(testDataD, true));

            Console.WriteLine("The average of the array = {0}", Average(testDataD, true));

            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", StandardDeviation(testDataD));
        }
    }
}

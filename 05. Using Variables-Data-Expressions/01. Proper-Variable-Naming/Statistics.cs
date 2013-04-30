using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// input parameter "count" is removed, because i suggest we don't need it - 
// we need only input array to find min, max and average value
public class Statistics
{
    public void PrintStatistics(double[] statisticsResults)
    {
        PrintMaxStatisticsValue(statisticsResults);
        PrintMinStatisticsValue(statisticsResults);
        PrintAverageStatisticsValue(statisticsResults);
    }

    private static void PrintMinStatisticsValue(double[] statisticsResults)
    {
        double min = 0;
        for (int index = 0; index < statisticsResults.Length; index++)
        {
            if (statisticsResults[index] < min)
            {
                min = statisticsResults[index];
            }
        }

        Console.WriteLine("Minimum statistic value: {0}", min);
    }

    private static void PrintMaxStatisticsValue(double[] statisticsResults)
    {
        double max = double.MinValue;
        for (int index = 0; index < statisticsResults.Length; index++)
        {
            if (statisticsResults[index] > max)
            {
                max = statisticsResults[index];
            }
        }

        Console.WriteLine("Maximum statistic value: {0}", max);
    }

    private static void PrintAverageStatisticsValue(double[] statisticsResults)
    {
        double sum = 0;
        for (int index = 0; index < statisticsResults.Length; index++)
        {
            sum += statisticsResults[index];
        }

        double average = sum / statisticsResults.Length;
        Console.WriteLine("Average statistic value: {0}", average);
    }
}

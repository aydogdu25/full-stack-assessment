using System.Linq; 
using System.Text.Json; 
using System.Collections.Generic; 

public static string MaxIncreasingSubarrayAsJson(List<int> numbers)
{
    if (numbers == null || numbers.Count == 0)
        return JsonSerializer.Serialize(new List<int>());

    List<int> subArray = new List<int>(numbers.Count);
    List<int> maxArray = new List<int>(numbers.Count);
    int result = 0;
    int maxResult = 0;
    subArray.Add(numbers[0]);

    for (int i = 1; i < numbers.Count; i++)
    {
        if (numbers[i] > numbers[i - 1])
        {
            subArray.Add(numbers[i]);
            result += numbers[i];
        }

        else
        {
            if (maxResult < result)
            {
                maxResult = result;
                maxArray = new List<int>(subArray);
            }
            subArray.Clear();
            subArray.Add(numbers[i]);
            result = numbers[i];
        }

        if (maxResult < result)
            maxArray = new List<int>(subArray);
    }

    return JsonSerializer.Serialize(maxArray);
}

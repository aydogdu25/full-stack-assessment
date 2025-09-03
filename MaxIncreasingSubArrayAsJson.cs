using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
{
    if (numbers == null || numbers.Count == 0)
        return JsonSerializer.Serialize(new List<int>());

    var sequences = numbers.Aggregate(
        new List<List<int>> { new List<int> { numbers[0] } },
        (acc, n) =>
        {
            var lastList = acc.Last();
            if (n > lastList.Last())
                lastList.Add(n); 
            else
                acc.Add(new List<int> { n }); 

            return acc;
        }
    );

    var maxArray = sequences.OrderByDescending(x => x.Sum()).First();

    return JsonSerializer.Serialize(maxArray);
}

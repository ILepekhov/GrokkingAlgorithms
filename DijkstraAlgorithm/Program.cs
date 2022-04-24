List<string> processed = new();

string FindLowesCostNode(Dictionary<string, double> costs2)
{
    var lowestCost = double.PositiveInfinity;
    var lowestCostNode = string.Empty;

    foreach (var node in costs2.Keys)
    {
        double cost = costs2[node];

        if (cost < lowestCost && processed.Contains(node) is false)
        {
            lowestCost = cost;
            lowestCostNode = node;
        }
    }

    return lowestCostNode;
}

void WriteParents(Dictionary<string, string> parents)
{
    foreach (var kvp in parents)
    {
        Console.WriteLine($"{kvp.Key} : {kvp.Value}");
    }
}

Dictionary<string, Dictionary<string, double>> graph = new()
{
    { "start", new Dictionary<string, double>
    {
        { "a", 6 },
        { "b", 2 },
    }},
    { "a", new Dictionary<string, double>
    {
        { "fin", 1 }
    }},
    { "b", new Dictionary<string, double>
    {
        { "a", 3 },
        { "fin", 5 }
    }},
    { "fin", new Dictionary<string, double>() }
};

Dictionary<string, double> costs = new()
{
    {"a", 6},
    {"b", 2},
    {"fin", double.PositiveInfinity}
};

Dictionary<string, string> parents = new()
{
    {"a", "start"},
    {"b", "start"},
    {"fin", string.Empty}
};

WriteParents(parents);

var node = FindLowesCostNode(costs);

while (string.IsNullOrEmpty(node) is false)
{
    var cost = costs[node];
    var neighbors = graph[node];

    foreach (var neighbor in neighbors.Keys)
    {
        var newCost = cost + neighbors[neighbor];
        if (costs[neighbor] > newCost)
        {
            costs[neighbor] = newCost;
            parents[neighbor] = node;
        }
    }
    
    processed.Add(node);

    node = FindLowesCostNode(costs);
}

WriteParents(parents);

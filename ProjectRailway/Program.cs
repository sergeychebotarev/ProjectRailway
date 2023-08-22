
using ProjectRailway.Abstract;
using ProjectRailway.BusinessLogic;
using ProjectRailway.DAL;
using SharpGraph;

IDataLoader dataLoader = new MockLoader();

Console.WriteLine("Part I. (1-4)");
var station = new Station("Main", dataLoader);

Console.WriteLine($"Station '{station.Name}' available parks:\r\n");
foreach (var park in station.Parks)
{
    Console.WriteLine($"Park name is: '{park}' \r\n");
    Console.WriteLine($"All paths of the park: {string.Join("; ", park.Paths)} \r\n");

    var allPoints = station.GetAllParkPoints(park).Values.ToList();
    Console.WriteLine($"All points of the park: {string.Join(", ", allPoints)} \r\n");

    var points = station.BuildParkOutline(park);
    Console.WriteLine($"Park outline points are: {string.Join(", ", points)}");

    Console.WriteLine("-------------------------------------------------\r\n");
}

Console.WriteLine("Press Enter to continue...");

Console.ReadLine();
Console.Clear();

var graph = station.BuildStationGraph();
var allEdges = station.GetAllStationEdges()
    .Values.ToList();
Console.WriteLine($"Station '{station.Name}' available edges:\r\n");
for (int i = 0; i < allEdges.Count; i++)
{
    Console.WriteLine($" {i:d2}, '{allEdges[i].Name}'");
}

while (true)
{
    Console.Write("please, input start edge number > ");
    int.TryParse(Console.ReadLine(), out int n1);

    Console.Write("please, input finish edge number > ");
    int.TryParse(Console.ReadLine(), out int n2);

    var edge1 = allEdges[n1];
    var edge2 = allEdges[n2];

    string start = edge1.PointStart.Name;
    string finish = edge2.PointStart.Name;

    var nodes = graph.FindMinPath(new Node(start), new Node(finish));

    if (nodes != null)
    {
        nodes.Reverse();
        string pathText = string.Join(" -> ", nodes);
        Console.WriteLine($"Min path from '{start}' to '{finish}' is: {pathText}");
    }
    else
    {
        Console.WriteLine("Path not found");
    }
}



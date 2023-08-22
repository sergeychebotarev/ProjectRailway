using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectRailway.Abstract;
using ProjectRailway.Domains;
using SharpGraph;

namespace ProjectRailway.DAL
{
    public class MockLoader : IDataLoader
    {
        public DictionaryPoints GetPoints()
        {
            return new DictionaryPoints()
                .AddPoint("A0", 550, 95)
                .AddPoint("A1", 915, 95)

                .AddPoint("B0", 240, 160)
                .AddPoint("B1", 395, 160)
                .AddPoint("B2", 505, 160)
                .AddPoint("B3", 980, 160)
                .AddPoint("B4", 1200, 160)

                .AddPoint("C0", 150, 200)
                .AddPoint("C1", 355, 200)
                .AddPoint("C2", 465, 200)
                .AddPoint("C3", 485, 180)
                .AddPoint("C4", 1370, 200)

                .AddPoint("D0", 255, 255)
                .AddPoint("D1", 405, 255)
                .AddPoint("D2", 1425, 255)

                .AddPoint("E0", 155, 305)
                .AddPoint("E1", 220, 305)
                .AddPoint("E2", 620, 305)
                .AddPoint("E3", 1215, 305)
                .AddPoint("E4", 1480, 305)

                .AddPoint("F0", 45, 405)
                .AddPoint("F1", 135, 405)
                .AddPoint("F2", 1580, 405)
                .AddPoint("F3", 1640, 405)

                .AddPoint("G0", 45, 480)
                .AddPoint("G1", 95, 480)
                .AddPoint("G2", 1585, 480)
                .AddPoint("G3", 1610, 480)

                .AddPoint("H0", 100, 515)
                .AddPoint("H1", 300, 515)

                .AddPoint("I0", 105, 545)
                .AddPoint("I1", 310, 545)
                .AddPoint("I2", 1540, 545)

                .AddPoint("J0", 350, 620)
                .AddPoint("J1", 1480, 620);
        }

        public DictionaryEdges GetEdges(DictionaryPoints points)
        {
            var dictionaryEdges = new DictionaryEdges()
                .AddEdge(points, "A0-A1")
                .AddEdge(points, "B0-B1", "B1-B2", "B2-B3", "B3-B4")
                .AddEdge(points, "B2-A0", "A1-B3")
                .AddEdge(points, "C0-C1", "C1-C2", "C2-C3", "C2-C4")
                .AddEdge(points, "C1-B1")
                .AddEdge(points, "D0-D1", "D1-D2")
                .AddEdge(points, "D1-C2", "C4-D2")
                .AddEdge(points, "E0-E1", "E1-E2", "E3-E4")
                .AddEdge(points, "E1-D0", "D2-E4")
                .AddEdge(points, "F0-F1", "F1-F2", "F2-F3")
                .AddEdge(points, "F1-E0", "E4-F2")
                .AddEdge(points, "G0-G1", "G1-G2", "G2-G3")
                .AddEdge(points, "H0-H1")
                .AddEdge(points, "H0-G1")
                .AddEdge(points, "I0-I1", "I1-I2")
                .AddEdge(points, "I0-H0", "H1-I1")
                .AddEdge(points, "G2-I2")
                .AddEdge(points, "J0-J1")
                .AddEdge(points, "J0-I1", "J1-I2");

            return dictionaryEdges;
        }

        public DictionaryPaths GetPaths(DictionaryEdges edges)
        {
            var dictionaryPathes = new DictionaryPaths()
                .AddPath(edges, "x01b", "B0-B1;B1-B2;B2-A0;A0-A1;A1-B3;B3-B4")
                .AddPath(edges, "x02b", "B0-B1;B1-B2;B2-B3;B3-B4")
                .AddPath(edges, "x03c", "C0-C1;C1-B1;B1-B2;B2-B3;B3-B4")
                .AddPath(edges, "x04c", "C0-C1;C1-C2;C2-C3")
                .AddPath(edges, "x05c", "C0-C1;C1-C2;C2-C4")
                .AddPath(edges, "x06c", "C0-C1;C1-C2;C2-C4;C4-D2;D2-E4;E4-F2;F2-F3")
                .AddPath(edges, "x07d", "D0-D1;D1-D2;D2-E4")
                .AddPath(edges, "x08d", "D0-D1;D1-C2")
                .AddPath(edges, "x09e", "E0-E1;E1-E2")
                .AddPath(edges, "x10e", "E0-E1;E1-D0;D0-D1")
                .AddPath(edges, "x11e", "E3-E4;E4-F2;F2-F3")
                .AddPath(edges, "x12e", "E3-E4;D2-E4;D1-D2")
                .AddPath(edges, "x13f", "F0-F1;F1-F2;F2-F3")
                .AddPath(edges, "x14f", "F0-F1;F1-E0;E0-E1;E1-E2")
                .AddPath(edges, "x15g", "G0-G1;G1-G2;G2-G3")
                .AddPath(edges, "x16g", "G0-G1;H0-G1;I0-I1;J0-I1;J0-J1;J1-I2")
                .AddPath(edges, "x17h", "H0-H1;H1-I1;I1-I2")
                .AddPath(edges, "x18h", "I0-H0;I0-I1;J0-I1;J0-J1")
                .AddPath(edges, "x19i", "I0-I1;I1-I2;G2-I2;G2-G3")
                .AddPath(edges, "x20i", "I0-I1;J0-I1;J0-J1")
                .AddPath(edges, "x21j", "J0-J1")
                .AddPath(edges, "x22j", "J0-J1;J1-I2;G2-I2;G2-G3");

            return dictionaryPathes;
        }

        public List<RailwayPark> GetParks(DictionaryPaths path)
        {
            return new List<RailwayPark>
            {
                new ("Park1", 
                    path["x01b"], path["x02b"], path["x03c"],
                    path["x04c"], path["x05c"], path["x06c"],
                    path["x07d"], path["x08d"], path["x09e"],
                    path["x10e"], path["x11e"], path["x12e"],
                    path["x13f"], path["x14f"], path["x15g"],
                    path["x16g"], path["x17h"], path["x18h"],
                    path["x19i"], path["x20i"], path["x21j"],
                    path["x22j"]
                    )
            };
        }
    }
}

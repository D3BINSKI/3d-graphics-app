using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _3d_graphics_app.Render
{
    public class AET
    {
        public int YMax { get; set; }
        public float X { get; set; }
        public float InversedM { get; set; }

        public AET(int yMax, float x, float reversedM)
        {
            YMax = yMax;
            X = x;
            InversedM = reversedM;
        }
    }
    
    public class ScanLine
    {
        public static void ForEachPixel(Vector3[] vectorArr, Action<Vector3[], int, int> action)
        {
            Vector3[] v2 = (Vector3[])vectorArr.Clone();
            Array.Sort(v2, (x, y) => (int)(x.Y - y.Y));
            Queue<Vector3> et = new Queue<Vector3>(v2);
            List<AET> aet = new List<AET>();
            int y = (int)et.First().Y;

            while (aet.Count != 0 || et.Count != 0)
            {
                while (et.Count > 0 && et.First().Y < y)
                {
                    Vector3 vertex = et.Dequeue();
                    int index = Array.IndexOf(vectorArr, vertex);
                    int before = index == 0 ? vectorArr.Length - 1 : index - 1;
                    int after = (index + 1) % vectorArr.Length;

                    if (vectorArr[before].Y >= y)
                    {
                        float inversedM = (vectorArr[before].X - vertex.X) / (vectorArr[before].Y - vertex.Y);
                        aet.Add(
                            new AET(
                                (int)vectorArr[before].Y,
                                vertex.X,
                                inversedM)
                        );
                        if (Math.Abs(vectorArr[after].Y - vertex.Y) < 1.0f)
                        {
                            int min = (int)vertex.X;
                            int max = (int)vectorArr[after].X;
                            if (min > max) (min, max) = (max, min);
                            for (; min <= max; min++) action(vectorArr, min, (int)vertex.Y);
                            for (; min <= max; min++) action(vectorArr, min, (int)vectorArr[after].Y);
                        }
                    }

                    if (vectorArr[after].Y >= y)
                    {
                        float inversedM = (vectorArr[after].X - vertex.X) / (vectorArr[after].Y - vertex.Y);
                        aet.Add(
                            new AET(
                                (int)vectorArr[after].Y,
                                vertex.X,
                                inversedM)
                        );
                        if (Math.Abs(vectorArr[after].Y - vertex.Y) < 1.0f)
                        {
                            int min = (int)vertex.X;
                            int max = (int)vectorArr[after].X;
                            if (min > max) (min, max) = (max, min);
                            for (; min <= max; min++) action(vectorArr, min, (int)vertex.Y);
                            for (; min <= max; min++) action(vectorArr, min, (int)vectorArr[after].Y);
                        }
                    }
                }

                if (aet.Count > 0)
                {
                    aet.Sort((x, y) => (int)(x.X - y.X));
                    bool paint = true;
                    int[] changePoints = (int[])aet.Select(x => (int)x.X).Distinct().ToArray();
                    int x = changePoints[0];
                    foreach (var change in changePoints)
                    {
                        bool isMove = false;
                        while (x < change)
                        {
                            isMove = true;
                            if (paint) action(vectorArr, x, y);
                            x++;
                        }

                        if (isMove)
                        {
                            paint = !paint;
                            isMove = false;
                        }
                    }

                    aet.RemoveAll(x => x.YMax <= y);
                    foreach (var elAet in aet)
                    {
                        elAet.X += elAet.InversedM;
                    }
                }
                y++;
            }
        }
    }
}
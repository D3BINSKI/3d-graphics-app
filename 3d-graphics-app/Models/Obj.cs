using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using _3d_graphics_app.Render;

namespace _3d_graphics_app.Models
{
    public class Obj
    {
        private float _moveStep = 1.0f;
        public string Name { get; set; }
        public List<VirtualPoint> VPoints { get; set; }
        public List<Vector3> NormalVectors { get; set; }
        public List<(int[] pointIds, int[] normalVecIds)> Faces { get; set; }
        public Matrix4x4 ModelMatrix { get; set; }
        public Color Color { get; set; }

        public Func<float, Matrix4x4> ModelMatrixFunc;

        public Obj(string filePath, Color color, Matrix4x4 modelMatrix)
        {
            Color = color;
            ModelMatrix = modelMatrix;
            
            ImportObject(filePath);
        }

        public Obj(string filePath, Color color, Func<float, Matrix4x4> modelMatrixFunc)
        {
            Color = color;
            ModelMatrix = Matrix4x4.Identity;
            ModelMatrixFunc = modelMatrixFunc;
            ImportObject(filePath);
        }

        private void ImportObject(string filePath)
        {
            VPoints = new List<VirtualPoint>();
            NormalVectors = new List<Vector3>();
            Faces = new List<(int[], int[])>();

            foreach (var line in System.IO.File.ReadLines(filePath))
            {
                if (line.Length == 0 || line.First() == '#') continue;

                var args = line.Split(' ').Where(arg => !string.IsNullOrWhiteSpace(arg)).ToArray();

                HandleObjArguments(args);
            }
        }

        private void HandleObjArguments(string[] args)
        {
            switch (args[0])
            {
                case "o":
                    Name = args[1];
                    break;
                case "v":
                    var node = new Vector4(
                        float.Parse(args[1], CultureInfo.InvariantCulture),
                        float.Parse(args[2], CultureInfo.InvariantCulture),
                        float.Parse(args[3], CultureInfo.InvariantCulture),
                        1.0f);
                    VPoints.Add(new VirtualPoint(node));
                    break;
                case "vn":
                    var normalVector = new Vector3(
                        float.Parse(args[1], CultureInfo.InvariantCulture),
                        float.Parse(args[2], CultureInfo.InvariantCulture),
                        float.Parse(args[3], CultureInfo.InvariantCulture));
                    NormalVectors.Add(normalVector);
                    break;
                case "f":
                    // f v1/vt1/vn1 v2/vt2/vn2 v3/vt3/vn3
                    (int[] pointIds, int[] normalVecIds) tmp = (new int[args.Length - 1], new int[args.Length - 1]); // ([v1, v2, v3], [vn1, vn2, vn3])
                    for (var i = 1; i < args.Length; i++)
                    {
                        var indices = args[i].Split('/');
                        tmp.Item1[i - 1] = int.Parse(indices[0]) - 1;
                        tmp.Item2[i - 1] = int.Parse(indices[2]) - 1;
                    }

                    Faces.Add(tmp);
                    break;
            }
        }

        public void MoveUp()
        {
            ModelMatrix *= Matrix4x4.CreateTranslation(0, 0, _moveStep);
        }
        
        public void MoveDown()
        {
            ModelMatrix *= Matrix4x4.CreateTranslation(0, 0, -_moveStep);
        }
        
        public void MoveLeft()
        {
            ModelMatrix *= Matrix4x4.CreateTranslation(0, -_moveStep, 0);
        }
        
        public void MoveRight()
        {
            ModelMatrix *= Matrix4x4.CreateTranslation(0, _moveStep, 0);
        }

        public void Update(float time)
        {
            if (ModelMatrixFunc != null) ModelMatrix = ModelMatrixFunc(time);
        }
    }
}
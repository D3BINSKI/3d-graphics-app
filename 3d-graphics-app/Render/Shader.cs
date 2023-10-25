using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using _3d_graphics_app.Models;
using _3d_graphics_app.Visuals;

namespace _3d_graphics_app.Render
{
    public enum ShaderType
    {
        Goraud,
        Constant
    }

    public class Fog
    {
        public (float min, float max) Range;
        public Color Color { get; set; }

        public Fog((float, float) range, Color color)
        {
            Range = range;
            Color = color;
        }
    }

    public class ShaderParameters
    {
        public float Ka { get; set; } = .2f;
        public float Kd { get; set; } = .8f;
        public float Ks { get; set; } = .6f;
        public float M { get; set; } = 8f;

        public ShaderParameters()
        {
        }

        public ShaderParameters(float ka, float kd, float ks, float m)
        {
            Ka = ka;
            Kd = kd;
            Ks = ks;
            M = m;
        }
    }

    public class Shader
    {
        public ShaderType ShaderType { get; set; }
        public PictureBox Canvas { get; set; }

        public ShaderParameters Parameters { get; set; }
        public List<Light> LightSources { get; set; }
        public Camera Camera { get; set; }
        public Fog Fog { get; set; }
        public int[] tmp { get; set; }
        public float[] zBuffer { get; set; }
        
        public Shader(ShaderType shaderType, Camera camera, List<Light> lightSources, Fog fog, PictureBox canvas)
        {
            ShaderType = shaderType;
            Camera = camera;
            Fog = fog;
            Canvas = canvas;
            LightSources = lightSources;
            tmp = new int[canvas.Width * canvas.Height];
            zBuffer = Enumerable.Repeat(fog.Range.max, canvas.Width * canvas.Height).ToArray();
            Parameters = new ShaderParameters();
        }

        public void UpdateBuffers(int width, int height)
        {
            tmp = new int[width * height];
            zBuffer = Enumerable.Repeat(Fog.Range.max, width * height).ToArray();
        }

        public void ResetBuffers()
        {
            zBuffer = Enumerable.Repeat(Fog.Range.max, Canvas.Width * Canvas.Height).ToArray();
            Array.Clear(tmp, 0, tmp.Length);
        }

        public void DrawObject(Obj renderObject, PictureBox canvas)
        {
            Parallel.ForEach(renderObject.Faces, (face) =>
            {
                var points = new Vector3[face.pointIds.Length];
                for (var i = 0; i < face.pointIds.Length; i++)
                {
                    var canvasPoint = renderObject.VPoints[face.pointIds[i]]
                        .GetCanvasPoint(renderObject.ModelMatrix, Camera.View, Camera.Perspective, canvas);

                    if (!IsVisible(canvasPoint)) return;
                    points[i] = canvasPoint;
                }

                var normalVectors = face.normalVecIds
                    .Select(id => Vector3
                        .TransformNormal(renderObject.NormalVectors[id], renderObject.ModelMatrix))
                    .ToArray();

                var colorPoints = face.pointIds.Select(pointId => renderObject.VPoints[pointId].ApplyModelMatrix(renderObject.ModelMatrix))
                    .ToArray();

                var pointColors = new Color[colorPoints.Length];
                for (var i = 0; i < colorPoints.Length; i++)
                {
                    pointColors[i] = GetPointColor(renderObject.Color, colorPoints[i], normalVectors[i]);
                }

                ScanLine.ForEachPixel(points, (vec, x, y) =>
                {
                    Vector3 point = GetPoint(vec, x, y);
                    if (!(point.Z < zBuffer[x + y * canvas.Width])) return;

                    zBuffer[x + y * canvas.Width] = point.Z;
                    tmp[x + y * canvas.Width] = InterpolateColor(vec, pointColors, point);
                });
            });
            
        }

        public void AddFog()
        {
            for (int i = 0; i < zBuffer.Length; i++)
            {
                if (zBuffer[i] > Fog.Range.min && zBuffer[i] < Fog.Range.max)
                {
                    var alpha = (zBuffer[i] - Fog.Range.min) / (Fog.Range.max - Fog.Range.min);
                    tmp[i] = Blend(tmp[i], Fog.Color.ToArgb(), alpha);
                }
            }
        }
        
        private int Blend(int color, int backColor, float amount)
        {
            int r = ((int)(((color & 0xFF0000) >> 16) * (1 - amount) + ((backColor & 0xFF0000) >> 16) * amount)) << 16;
            int g = ((int)(((color & 0xFF00) >> 8) * (1 - amount) + ((backColor & 0xFF00) >> 8) * amount)) << 8;
            int b = (int)((color & 0xFF) * (1 - amount) + (backColor & 0xFF) * amount);
            return (-16777216 | r | g | b);
        }

        private Vector3 GetPoint(Vector3[] face, int x, int y)
        {
            float det = (face[1].Y - face[2].Y) * (face[0].X - face[2].X) +
                        (face[2].X - face[1].X) * (face[0].Y - face[2].Y);
            float l1 = ((face[1].Y - face[2].Y) * (x - face[2].X) + (face[2].X - face[1].X) * (y - face[2].Y)) / det;
            float l2 = ((face[2].Y - face[0].Y) * (x - face[2].X) + (face[0].X - face[2].X) * (y - face[2].Y)) / det;
            float l3 = 1.0f - l1 - l2;
            float res = (l1 * face[0].Z + l2 * face[1].Z + l3 * face[2].Z);
            return new Vector3(x, y, res);
        }

        private int InterpolateColor(Vector3[] face, Color[] colors, Vector3 point)
        {
            float[] weights = BarocentricWeights(face, point);
            int[] rgb = new int[3];
            for (int i = 0; i < 3; i++)
            {
                rgb[0] += (int)(weights[i] * colors[i].R);
                rgb[1] += (int)(weights[i] * colors[i].G);
                rgb[2] += (int)(weights[i] * colors[i].B);
            }

            return Color.FromArgb(rgb[0], rgb[1], rgb[2]).ToArgb();
        }

        private float[] BarocentricWeights(Vector3[] f, Vector3 point)
        {
            Vector3 A = f[1] - f[0];
            Vector3 B = f[2] - f[0];
            Vector3 C = f[2] - f[1];
            
            float P = Vector3.Cross(A, B).Length();
            float P0 = Vector3.Cross((point - f[1]), C).Length();
            float P1 = Vector3.Cross((point - f[0]), B).Length();
            float P2 = Vector3.Cross((point - f[0]), A).Length();
            float[] res = new float[] { P0 / P, P1 / P, P2 / P };
            float sum = res[0] + res[1] + res[2];

            return res.Select(i => i / sum).ToArray();
        }

        private Color GetPointColor(Color color, Vector3 point, Vector3 normalVector)
        {
            var basePointColor = Color.FromArgb(
                (int)Parameters.Ka * color.R,
                (int)Parameters.Ka * color.G,
                (int)Parameters.Ka * color.B
            );

            var redLightSourcesComponent = 0f;
            var greenLightSourcesComponent = 0f;
            var blueLightSourcesComponent = 0f;

            foreach (var lightSource in LightSources)
            {
                if (!lightSource.IsTurnedOn) continue;

                if (!lightSource.IsInRange(point)) continue;

                var pointColor = lightSource.GetLightedPointColor(point, Parameters);

                var observerDirection = Vector3.Normalize(Camera.Position - point);

                var (first, second) =
                    lightSource.GetColorComponents(point, normalVector, observerDirection, Parameters);

                redLightSourcesComponent += (first + second) * color.R * pointColor.R;
                greenLightSourcesComponent += (first + second) * color.G * pointColor.G;
                blueLightSourcesComponent += (first + second) * color.B * pointColor.B;
            }

            return Color.FromArgb(
                (int)Math.Max(Math.Min(basePointColor.R + redLightSourcesComponent, 255), 0),
                (int)Math.Max(Math.Min(basePointColor.G + greenLightSourcesComponent, 255), 0),
                (int)Math.Max(Math.Min(basePointColor.B + blueLightSourcesComponent, 255), 0));
        }

        public void SetCamera(Camera camera)
        {
            Camera = camera;
        }

        private bool IsVisible(Vector3 point)
        {
            return point is { X: >= 0, Y: >= 0 } && point.X <= Canvas.Width && point.Y <= Canvas.Height;
        }
    }
}
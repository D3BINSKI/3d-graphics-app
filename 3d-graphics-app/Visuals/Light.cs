#nullable enable
using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using _3d_graphics_app.Models;
using _3d_graphics_app.Render;

namespace _3d_graphics_app.Visuals
{
    public enum LightType
    {
        DayNight,
        Point,
        FlashLight
    }

    public class Light
    {
        public LightType LightType { get; set; }
        public bool IsTurnedOn { get; set; }
        public Vector3 SourcePosition { get; set; }
        public Vector3? Direction { get; set; }
        public Func<float, Vector3>? SourcePositionFunc;
        public Func<float, Vector3>? DirectionFunc;
        public Obj? OwnerObject;
        public Color Color { get; set; }

        public Light(LightType lightType, Vector3 sourcePosition, Color color, Vector3? direction = null, bool isTurnedOn = true)
        {
            LightType = lightType;
            SourcePosition = sourcePosition;
            if (LightType is LightType.FlashLight && direction is null)
            {
                throw new ArgumentNullException(nameof(direction), @"Flashlight light type must have assigned direction.");
            }
            Direction = direction;
            Color = color;
            IsTurnedOn = isTurnedOn;
        }

        public bool IsInRange(Vector3 point)
        {
            return true;
        }

        public Vector3 GetL(Vector3 point)
        {
            return Vector3.Normalize(SourcePosition - point);
        }

        public Vector3 GetR(Vector3 point, Vector3 normalVector)
        {
            var L = GetL(point);
            return 2 * LightCos(normalVector, L, false)*normalVector - L;
        }

        public (float, float) GetColorComponents(Vector3 point, Vector3 normalVector, Vector3 observerDirection, ShaderParameters shaderParameters)
        {
            (float, float) ColorComponents = (0f, 0f);
            var L = GetL(point);
            var R = GetR(point, normalVector);
            ColorComponents.Item1 = shaderParameters.Kd * LightCos(normalVector, L);
            ColorComponents.Item2 = shaderParameters.Ks * (float)Math.Pow(LightCos(observerDirection, R), shaderParameters.M);

            return ColorComponents;
        }
        
        float LightCos(Vector3 v1, Vector3 v2, bool cut = true)
        {
            var cos = v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z / v1.Length() / v2.Length();
            if (cut && cos < 0.0) cos = 0.0f;
            if (cos > 1.1f)
            {
                throw new Exception("cosinus value is greater than 1");
            }
            return cos;
        }

        public Color GetLightedPointColor(Vector3 point, ShaderParameters shaderParameters)
        {
            var L = GetL(point);
            var cos = (float)Math.Pow(Math.Max(0f, Vector3.Dot(-L, Direction ?? -L)), shaderParameters.M); // Risky: do sprawdzenia
            
            return Color.FromArgb((int)(Color.R * cos), (int)(Color.G * cos), (int)(Color.B * cos));
        }

        public void Update(float animationTime)
        {
            if (SourcePositionFunc is not null) SourcePosition = SourcePositionFunc(animationTime);
            if (DirectionFunc is not null) Direction = DirectionFunc(animationTime);
            
            if (OwnerObject is null) return;
            SourcePosition = Vector3.Transform(SourcePosition, OwnerObject.ModelMatrix);
            if(LightType is LightType.FlashLight) Direction = Vector3.Transform((Vector3)Direction!, OwnerObject.ModelMatrix);
        }
    }
}
using System.Numerics;
using System.Windows.Forms;

namespace _3d_graphics_app.Render
{
    public class VirtualPoint
    {
        private const float Vx = 1.0f;
        private const float Vy = 1.0f;
        
        private Vector4 VPoint { get; set; }
        public VirtualPoint(Vector4 vPoint)
        {
            VPoint = vPoint;
        }

        public Vector3 GetCanvasPoint(Matrix4x4 modelMatrix, Matrix4x4 viewMatrix, Matrix4x4 perspectiveMatrix, PictureBox canvas)
        {
            var pointTransform = Vector4.Transform(Vector4.Transform(Vector4.Transform(
                        VPoint, 
                        modelMatrix),
                    viewMatrix),
                perspectiveMatrix);

            var virtualProjection = new Vector3(
                pointTransform.X / pointTransform.W,
                pointTransform.Y / pointTransform.W,
                pointTransform.Z / pointTransform.W
            );
            
            return VirtualToCanvas(virtualProjection, canvas);
        }

        private static Vector3 VirtualToCanvas(Vector3 vPosition, PictureBox canvas)
        {
            var x = vPosition.X;
            var y = vPosition.Y;

            var newX = 0.5f * canvas.Width * (1.0f + x / Vx);
            var newY = 0.5f * canvas.Height * (1.0f - y / Vy);
            return new Vector3(newX, newY, vPosition.Z);
        }

        public Vector3 ApplyModelMatrix(Matrix4x4 modelMatrix)
        {
            var transformed = Vector4.Transform(VPoint, modelMatrix);
            return new Vector3(
                transformed.X / transformed.W, 
                transformed.Y / transformed.W,
                transformed.Z / transformed.W);
        }
    }
}
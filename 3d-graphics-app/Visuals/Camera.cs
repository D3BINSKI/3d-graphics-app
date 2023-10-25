#nullable enable
using System;
using System.ComponentModel;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using _3d_graphics_app.Models;

namespace _3d_graphics_app.Visuals
{
    public class Camera
    {
        public bool IsDynamic => _ownerObject is not null;
        private float _moveStep = 0.2f;
        private float _rotationStep = 1.0f/180.0f*(float)Math.PI;
        private Obj? _ownerObject;
        private Vector3 _relativePosition;
        private Vector3 _relativeLookAt;

        public Vector3 Position { get; private set; }
        public Matrix4x4 View { get; set; }
        public float Fov { get; set; }
        public Matrix4x4 Perspective { get; set; }

        public Camera(Vector3 relativePosition, Vector3 relativeLookAt, PictureBox canva, Obj? ownerObject = null, float fov = 60.0f)
        {
            _ownerObject = ownerObject;
            _relativePosition = relativePosition;
            _relativeLookAt = relativeLookAt;
            Fov = fov;
            UpdatePerspective(canva.Width, canva.Height);
            
            Refresh();
        }

        public void Refresh()
        {
            Position = _ownerObject is null ? _relativePosition : Vector3.Transform(_relativePosition, _ownerObject.ModelMatrix);
            var lookAt = _ownerObject is null ? _relativeLookAt : Vector3.Transform(_relativeLookAt, _ownerObject.ModelMatrix);
            if (IsDynamic)
            {
                Vector3 target = Vector3.Transform(Vector3.Zero, _ownerObject!.ModelMatrix);
                View = Matrix4x4.CreateLookAt(Position, target, Vector3.UnitZ);
            }
            else
            {
                View = Matrix4x4.CreateLookAt(Position, lookAt, Vector3.UnitZ);
            }
        }

        public void UpdatePerspective(float width, float height)
        {
            Perspective = Matrix4x4.CreatePerspectiveFieldOfView(Fov / 180.0f * (float)Math.PI, width / height, 1.0f, 3.0f);
        }

        public void Up()
        {
            _relativePosition.Z += _moveStep;
            _relativeLookAt.Z += _moveStep;
            Refresh();
        }
        
        public void Down()
        {
            _relativePosition.Z -= _moveStep;
            _relativeLookAt.Z -= _moveStep;
            Refresh();
        }
        
        public void Right()
        {
            _relativePosition.Y += _moveStep;
            _relativeLookAt.Y += _moveStep;
            Refresh();
        }
        
        public void Left()
        {
            _relativePosition.Y -= _moveStep;
            _relativeLookAt.Y -= _moveStep;
            Refresh();
        }
        
        public void Forward()
        {
            _relativePosition.X -= _moveStep;
            _relativeLookAt.X -= _moveStep;
            Refresh();
        }
        
        public void Backward()
        {
            _relativePosition.X += _moveStep;
            _relativeLookAt.X += _moveStep;
            Refresh();
        }

        public void RotateL()
        {
            _relativeLookAt = Vector3.Transform(_relativeLookAt, Matrix4x4.CreateRotationZ(_rotationStep, Position));
            Refresh();
        }
        
        public void RotateR()
        {
            _relativeLookAt = Vector3.Transform(_relativeLookAt, Matrix4x4.CreateRotationZ(-_rotationStep, Position));
            Refresh();
        }
    }
}
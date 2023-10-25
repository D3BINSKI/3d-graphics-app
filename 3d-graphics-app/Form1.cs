using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;
using FastBitmapLib;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using _3d_graphics_app.Models;
using _3d_graphics_app.Render;
using _3d_graphics_app.Visuals;

namespace _3d_graphics_app
{
  public partial class Form1 : Form
  {
    private static string _modelFilesDirectory =
      Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")) + "/Models/ObjectFiles/";
    
    private (float, float) _defaultFogRange = (1.3f, 1.5f);
    private Shader _shader;
    private List<Obj> _renderObjects = new();
    private List<Camera> _cameras = new();
    private List<Light> _lightSources = new();
    private bool IsDay = true;
    private Fog _fog;
    private float _animationTime = 0.0f;
    private Camera _activeCamera;
    private Obj _activeObject;
    private bool IsDynamicCamera = false;
    
    public Form1()
    {
      InitializeComponent();

      _fog = new Fog(_defaultFogRange, Color.White);

      var sphere = new Obj(String.Concat(_modelFilesDirectory, "Sphere.obj"), Color.Red,
        Matrix4x4.CreateTranslation(0.0f, 0.0f, 0.5f));
      _activeObject = sphere;
      _renderObjects.Add(sphere);
      
      var movingSphere = new Obj(String.Concat(_modelFilesDirectory, "Sphere.obj"), Color.Blue,
        t => Matrix4x4.CreateTranslation(10.0f, 0, 0)*Matrix4x4.CreateRotationZ(2.0f*t));
      _renderObjects.Add(movingSphere);
      
      _cameras.Add(new Camera(new Vector3(20.0f, 0.0f, 1.0f), new Vector3(-20.0f, 0.0f, 7.0f), canva));
      _activeCamera = _cameras.First();
      
      _cameras.Add(new Camera(new Vector3(20.0f, 0.0f, 7.0f), new Vector3(-20.0f, 0.0f, 7.0f), canva, movingSphere));
      
      _lightSources.Add(new Light(LightType.DayNight, new Vector3(80.0f, 0.0f, -10f), Color.GreenYellow));
      
      _shader = new Shader(ShaderType.Constant, _activeCamera, _lightSources, _fog, canva);

      animationTimer.Interval = 100;
      animationTimer.Start();
    }

    public void Render()
    {
      Bitmap nextBitmap = new Bitmap(canva.Width, canva.Height);

      Parallel.ForEach(_renderObjects, (obj) =>
      {
        _shader.DrawObject(obj, canva);
      });
      
      _shader.AddFog();

      using var fastBitmap = nextBitmap.FastLock();
      fastBitmap.Clear(IsDay ? Color.White : Color.Black);
      fastBitmap.CopyFromArray(_shader.tmp, true);
      
      canva.Image?.Dispose();
      canva.Image = nextBitmap;
      _shader.ResetBuffers();
      _shader.Camera.Refresh();
    }

    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
      if(_shader is null) return;
      foreach (var camera in _cameras)
      {
        camera.UpdatePerspective(canva.Width, canva.Height);
      }
      _shader.UpdateBuffers(canva.Width, canva.Height);
      Render();
      animationTimer.Start();
    }

    private void Form1_ResizeBegin(object sender, EventArgs e)
    {
      animationTimer.Stop();
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Up:
          _activeCamera.Up();
          break;
        case Keys.Down:
          _activeCamera.Down();
          break;
        case Keys.Right:
          _activeCamera.Right();
          break;
        case Keys.Left:
          _activeCamera.Left();
          break;
        case Keys.W:
          _activeCamera.Forward();
          break;
        case Keys.S:
          _activeCamera.Backward();
          break;
        case Keys.Q:
          _activeCamera.RotateL();
          break;
        case Keys.E:
          _activeCamera.RotateR();
          break;
      }
    }

    private void dynamicCameraRadioBtn_CheckedChanged_1(object sender, EventArgs e)
    {
      IsDynamicCamera = true;
      _activeCamera = _cameras.First(camera => camera.IsDynamic);
      _shader.Camera = _activeCamera;
    }

    private void staticCameraRadioBtn_CheckedChanged_1(object sender, EventArgs e)
    {
      IsDynamicCamera = false;
      _activeCamera = _cameras.First(camera => !camera.IsDynamic);
      _shader.Camera = _activeCamera;
    }

    private void dayRdioBttn_CheckedChanged_1(object sender, EventArgs e)
    {
      IsDay = true;
    }

    private void nightRdioBttn_CheckedChanged_1(object sender, EventArgs e)
    {
      IsDay = false;
    }

    private void animationTimer_Tick_1(object sender, EventArgs e)
    {
      foreach (var obj in _renderObjects)
      {
        obj.Update(_animationTime);
      }
      foreach (var lightSource in _lightSources)
      {
        lightSource.Update(_animationTime);
      }
      _animationTime += animationTimer.Interval / 1000.0f;
      Render();
    }

    private void fogMinTrackBar_Scroll(object sender, EventArgs e)
    {
      _shader.Fog.Range.min = fogMinTrackBar.Value/5f;
    }

    private void fogMaxTrackBar_Scroll(object sender, EventArgs e)
    {
      _shader.Fog.Range.max = fogMaxTrackBar.Value / 5f;
    }

    private void UpBttn_Click(object sender, EventArgs e)
    {
      _activeObject.MoveUp();
    }

    private void DownBttn_Click(object sender, EventArgs e)
    {
      _activeObject.MoveDown();
    }

    private void RightBttn_Click(object sender, EventArgs e)
    {
      _activeObject.MoveRight();
    }

    private void LeftBttn_Click(object sender, EventArgs e)
    {
      _activeObject.MoveLeft();
    }

    private void kaTrackBar_Scroll(object sender, EventArgs e)
    {
      _shader.Parameters.Ka = kaTrackBar.Value / 100f;
    }

    private void ksTrackBar_Scroll(object sender, EventArgs e)
    {
      _shader.Parameters.Ks = ksTrackBar.Value / 100f;
    }

    private void kdTrackBar_Scroll(object sender, EventArgs e)
    {
      _shader.Parameters.Kd = kdTrackBar.Value / 100f;
    }

    private void mTrackBar_Scroll(object sender, EventArgs e)
    {
      _shader.Parameters.M = mTrackBar.Value;
    }

    private void fovNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
      _activeCamera.Fov = (float)fovNumericUpDown.Value;
      _activeCamera.UpdatePerspective(canva.Width, canva.Height);
    }
  }
}

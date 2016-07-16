using SharpGL;
using System;
using System.IO;
using System.Windows.Media.Media3D;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Models
{
    public class ObjectComponent : IDisposable
    {
        Model model;
        ModelVertex[] vertices;
        int[] indices;
        int[] triangles;
        Vector3D position;
        Quaternion rotation;

        public ObjectComponent(string file, string path, Vector3D position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(path + @"Head\" + file))
            {
                model = (Model)serializer.Deserialize(reader.BaseStream);
            }
            vertices = model.Vertices;
            indices = model.View.Indices;
            triangles = model.View.Triangles;
        }

        void RenderGeoset(ModelViewGeoset geoset, OpenGL gl)
        {
            float x, y, z;
            gl.Begin(OpenGL.GL_TRIANGLES);
            for(int i = geoset.triangle; i < geoset.triangle + geoset.triangles; i++)
            {
                x = vertices[indices[triangles[i]]].Position.x;
                y = vertices[indices[triangles[i]]].Position.y;
                z = vertices[indices[triangles[i]]].Position.z;
                gl.Vertex(x, y, z);
            }
            gl.End();
        }

        public void Render(OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(position.X, position.Y, position.Z);
            gl.Rotate(rotation.Angle, rotation.Axis.X, rotation.Axis.Y, rotation.Axis.Z);
            foreach(ModelViewGeoset geoset in model.View.Geosets)
            {
                RenderGeoset(geoset, gl);
            }
            gl.PopMatrix();
        }

        public void Dispose()
        {
            model = null;
            vertices = null;
            indices = null;
            triangles = null;
        }
    }
}

using SharpGL;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Models
{
    abstract class Character
    {
        protected Model model;
        protected ModelVertex[] vertices;
        protected int[] indices;
        protected int[] triangles;
        protected ModelViewGeoset[] geosets;
        protected ModelBone[] bones;
        public float rotation;
        protected List<int> billboards;

        public Character(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(file))
            {
                model = (Model)serializer.Deserialize(reader.BaseStream);
            }
            vertices = model.Vertices;
            indices = model.View.Indices;
            triangles = model.View.Triangles;
            geosets = model.View.Geosets;
            bones = model.Bones;
            billboards = new List<int>();
            for(int i = 0; i < model.Bones.Length; i++)
            {
                if((model.Bones[i].Billboard & 8) == 8)
                {
                    billboards.Add(i);
                }
            }
        }

        public int Geosets
        {
            get { return model.View.Geosets.Length; }
        }

        protected void RenderBillboard(OpenGL gl, int start, int count)
        {
            float x, y, z;
            foreach (int billboard in billboards)
            {
                x = model.Bones[billboard].Position.x;
                y = model.Bones[billboard].Position.y;
                z = model.Bones[billboard].Position.z;
                gl.PushMatrix();
                gl.Translate(x, y, z);
                gl.Rotate(-rotation, 0f, 1f, 0f);
                gl.Translate(-x, -y, -z);
                gl.Begin(OpenGL.GL_TRIANGLES);
                for (int i = start; i < start + count; i++)
                {
                    if (vertices[indices[triangles[i]]].Bones[0].index == billboard)
                    {
                        x = vertices[indices[triangles[i]]].Position.x;
                        y = vertices[indices[triangles[i]]].Position.y;
                        z = vertices[indices[triangles[i]]].Position.z;
                        gl.Vertex(x, y, z);
                    }
                }
                gl.End();
                gl.PopMatrix();
            }
        }

        protected void RenderGeoset(OpenGL gl, int start, int count)
        {
            float x, y, z;
            gl.Begin(OpenGL.GL_TRIANGLES);
            for (int i = start; i < start + count; i++)
            {
                x = vertices[indices[triangles[i]]].Position.x;
                y = vertices[indices[triangles[i]]].Position.y;
                z = vertices[indices[triangles[i]]].Position.z;
                gl.Vertex(x, y, z);
            }
            gl.End();
        }

        protected void RenderSkeleton(OpenGL gl)
        {
            float x, y, z;
            gl.Disable(OpenGL.GL_DEPTH_TEST);
            gl.Begin(OpenGL.GL_LINES);
            for (int i = 0; i < bones.Length; i++)
            {
                if (bones[i].Parent >= 0)
                {
                    x = bones[bones[i].Parent].Position.x;
                    y = bones[bones[i].Parent].Position.y;
                    z = bones[bones[i].Parent].Position.z;
                    gl.Vertex(x, y, z);
                    x = bones[i].Position.x;
                    y = bones[i].Position.y;
                    z = bones[i].Position.z;
                    gl.Vertex(x, y, z);
                }
            }
            gl.End();
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        public abstract void Render(OpenGL gl);
    }
}

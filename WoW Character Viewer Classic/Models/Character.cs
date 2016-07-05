using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using SharpGL;

namespace WoW_Character_Viewer_Classic.Models
{
    abstract class Character
    {
        Model model;
        public int geoset = 1;
        public float rotation;
        List<int> billboards;

        public Character(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(file))
            {
                model = (Model)serializer.Deserialize(reader.BaseStream);
            }
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

        public void Render(OpenGL gl)
        {
            float x, y, z;
            gl.Color(1f, 0f, 0f);
            gl.Begin(OpenGL.GL_TRIANGLES);
            for (int j = model.View.Geosets[0].triangle; j < model.View.Geosets[0].triangle + model.View.Geosets[0].triangles; j++)
            {
                x = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.x;
                y = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.y;
                z = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.z;
                gl.Vertex(x, y, z);
            }
            gl.End();
            gl.Color(1f, 1f, 1f);
            if(billboards.Contains(model.Vertices[model.View.Indices[model.View.Triangles[model.View.Geosets[geoset].triangle]]].Bones[0].index))
            {
                foreach(int billboard in billboards)
                {
                    x = model.Bones[billboard].Position.x;
                    y = model.Bones[billboard].Position.y;
                    z = model.Bones[billboard].Position.z;
                    gl.PushMatrix();
                    gl.Translate(x, y, z);
                    gl.Rotate(-rotation, 0f, 1f, 0f);
                    gl.Translate(-x, -y, -z);
                    gl.Begin(OpenGL.GL_TRIANGLES);
                    for(int j = model.View.Geosets[geoset].triangle; j < model.View.Geosets[geoset].triangle + model.View.Geosets[geoset].triangles; j++)
                    {
                        if(model.Vertices[model.View.Indices[model.View.Triangles[j]]].Bones[0].index == billboard)
                        {
                            x = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.x;
                            y = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.y;
                            z = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.z;
                            gl.Vertex(x, y, z);
                        }
                    }
                    gl.End();
                    gl.PopMatrix();
                }
            }
            else
            {
                gl.Begin(OpenGL.GL_TRIANGLES);
                for(int j = model.View.Geosets[geoset].triangle; j < model.View.Geosets[geoset].triangle + model.View.Geosets[geoset].triangles; j++)
                {
                    x = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.x;
                    y = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.y;
                    z = model.Vertices[model.View.Indices[model.View.Triangles[j]]].Position.z;
                    gl.Vertex(x, y, z);
                }
                gl.End();
            }
            gl.Color(0f, 0f, 1f);
            gl.Disable(OpenGL.GL_DEPTH_TEST);
            gl.Begin(OpenGL.GL_LINES);
            for (int i = 0; i < model.Bones.Count(); i++)
            {
                if (model.Bones[i].Parent >= 0)
                {
                    x = model.Bones[model.Bones[i].Parent].Position.x;
                    y = model.Bones[model.Bones[i].Parent].Position.y;
                    z = model.Bones[model.Bones[i].Parent].Position.z;
                    gl.Vertex(x, y, z);
                    x = model.Bones[i].Position.x;
                    y = model.Bones[i].Position.y;
                    z = model.Bones[i].Position.z;
                    gl.Vertex(x, y, z);
                }
            }
            gl.End();
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }
    }
}

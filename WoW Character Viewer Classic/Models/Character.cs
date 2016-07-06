using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Models
{
    abstract class Character
    {
        public float rotation;
        protected Model model;
        protected ModelVertex[] vertices;
        protected int[] indices;
        protected int[] triangles;
        protected ModelViewGeoset[] geosets;
        protected ModelBone[] bones;
        protected List<int> billboards;
        protected Texture[] textures;
        protected string texturesPath;

        public Character(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(file))
            {
                model = (Model)serializer.Deserialize(reader.BaseStream);
            }
            texturesPath = @"Character\" + model.Name.Replace("Female", "").Replace("Male", "") + @"\";
            vertices = model.Vertices;
            indices = model.View.Indices;
            triangles = model.View.Triangles;
            geosets = model.View.Geosets;
            bones = model.Bones;
            textures = new Texture[model.Textures.Length];
            //for(int i = 0; i < textures.Length; i++)
            //{
            //    textures[i] = new Texture();
            //}
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

        protected void MakeTextures(OpenGL gl)
        {
            for(int i = 0; i < textures.Length; i++)
            {
                switch(model.Textures[i].type)
                {
                    case 1:
                        MakeBodyTexture(gl, i);
                        break;
                }
            }
        }

        void MakeBodyTexture(OpenGL gl, int index)
        {
            textures[index] = new Texture();
            string gender = model.Name.Contains("Female") ? @"Female\" : @"Male\";
            Bitmap bitmap = LoadBitmap(texturesPath + gender + model.Name + "Skin00_00.png");
            textures[index].Create(gl, bitmap);
        }

        Bitmap LoadBitmap(string file)
        {
            Bitmap bitmap;
            using(StreamReader reader = new StreamReader(file))
            {
                bitmap = new Bitmap(reader.BaseStream);
            }
            return bitmap;
        }

        protected void RenderBillboard(OpenGL gl, int start, int count)
        {
            float x, y, z;
            foreach (int billboard in billboards)
            {
                //x = model.Bones[billboard].Position.x;
                //y = model.Bones[billboard].Position.y;
                //z = model.Bones[billboard].Position.z;
                //gl.PushMatrix();
                //gl.Translate(x, y, z);
                //gl.Rotate(-rotation, 0f, 1f, 0f);
                //gl.Translate(-x, -y, -z);
                //gl.Begin(OpenGL.GL_TRIANGLES);
                //for (int i = start; i < start + count; i++)
                //{
                //    if (vertices[indices[triangles[i]]].Bones[0].index == billboard)
                //    {
                //        x = vertices[indices[triangles[i]]].Position.x;
                //        y = vertices[indices[triangles[i]]].Position.y;
                //        z = vertices[indices[triangles[i]]].Position.z;
                //        gl.Vertex(x, y, z);
                //    }
                //}
                //gl.End();
                //gl.PopMatrix();
            }
        }

        protected void RenderGeoset(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            if(textures[FindTexture(geoset)] != null)
            {
                gl.Enable(OpenGL.GL_TEXTURE_2D);
                gl.Begin(OpenGL.GL_TRIANGLES);
                for(int i = start; i < start + count; i++)
                {
                    x = vertices[indices[triangles[i]]].Texture.x;
                    y = vertices[indices[triangles[i]]].Texture.y;
                    gl.TexCoord(x, y);
                    x = vertices[indices[triangles[i]]].Position.x;
                    y = vertices[indices[triangles[i]]].Position.y;
                    z = vertices[indices[triangles[i]]].Position.z;
                    gl.Vertex(x, y, z);
                }
                gl.End();
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
            else
            {
                gl.Begin(OpenGL.GL_TRIANGLES);
                for(int i = start; i < start + count; i++)
                {
                    x = vertices[indices[triangles[i]]].Position.x;
                    y = vertices[indices[triangles[i]]].Position.y;
                    z = vertices[indices[triangles[i]]].Position.z;
                    gl.Vertex(x, y, z);
                }
                gl.End();
            }
        }

        int FindTexture(int geoset)
        {
            for(int i = 0; i < model.View.Textures.Length; i++)
            {
                if(model.View.Textures[i].geoset == geoset)
                {
                    return model.View.Textures[i].texture;
                }
            }
            return -1;
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

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
        protected Model model;
        protected ModelVertex[] vertices;
        protected int[] indices;
        protected int[] triangles;
        protected ModelViewGeoset[] geosets;
        protected ModelBone[] bones;
        protected List<int> billboards;
        protected Texture[] textures;
        protected string texturesPath;
        bool skeleton;
        float rotation;

        public Character(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(file))
            {
                model = (Model)serializer.Deserialize(reader.BaseStream);
            }
            skeleton = false;
            texturesPath = @"Character\" + model.Name.Replace("Female", "").Replace("Male", "") + @"\";
            vertices = model.Vertices;
            indices = model.View.Indices;
            triangles = model.View.Triangles;
            geosets = model.View.Geosets;
            bones = model.Bones;
            textures = new Texture[model.Textures.Length];
            for (int i = 0; i < textures.Length; i++)
            {
                textures[i] = new Texture();
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

        public Model Model
        {
            get { return model; }
        }

        public bool Skeleton
        {
            get { return skeleton; }
            set { skeleton = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
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
                    case 0:
                        MakeTexture(gl, i);
                        break;
                    case 1:
                        MakeBodyTexture(gl, i);
                        break;
                    case 8:
                        MakeExtraTexture(gl, i);
                        break;
                }
            }
        }

        void MakeTexture(OpenGL gl, int index)
        {
            Bitmap bitmap = LoadBitmap(model.Textures[index].file.Replace(".BLP", ".PNG"));
            textures[index].Create(gl, bitmap);
        }

        void MakeBodyTexture(OpenGL gl, int index)
        {
            string gender = model.Name.Contains("Female") ? @"Female\" : @"Male\";
            Bitmap bitmap = LoadBitmap(texturesPath + gender + model.Name + "Skin00_00.png");
            textures[index].Create(gl, bitmap);
        }

        void MakeExtraTexture(OpenGL gl, int index)
        {
            string gender = model.Name.Contains("Female") ? @"Female\" : @"Male\";
            Bitmap bitmap = LoadBitmap(texturesPath + gender + model.Name + "Skin00_00_Extra.png");
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

        protected void RenderBillboard(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            gl.Color(1f, 1f, 1f);
            Blend(gl, geoset);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            textures[FindTexture(geoset)].Bind(gl);
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
                        x = vertices[indices[triangles[i]]].Texture.x;
                        y = vertices[indices[triangles[i]]].Texture.y;
                        gl.TexCoord(x, y);
                        x = vertices[indices[triangles[i]]].Position.x;
                        y = vertices[indices[triangles[i]]].Position.y;
                        z = vertices[indices[triangles[i]]].Position.z;
                        gl.Vertex(x, y, z);
                    }
                }
                gl.End();
                gl.PopMatrix();
            }
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_BLEND);
        }

        protected void RenderGeoset(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            gl.Color(1f, 1f, 1f);
            Blend(gl, geoset);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            textures[FindTexture(geoset)].Bind(gl);
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
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_ALPHA_TEST);
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

        void Blend(OpenGL gl, int geoset)
        {
            switch(model.Blending[FindBlend(geoset)])
            {
                case 1:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.Enable(OpenGL.GL_ALPHA_TEST);
                    gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
                    gl.AlphaFunc(OpenGL.GL_GREATER, 0.9f);
                    break;
                case 2:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.DepthMask((byte)OpenGL.GL_FALSE);
                    gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);
                    break;
                case 4:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.DepthMask((byte)OpenGL.GL_FALSE);
                    gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);
                    break;
            }
        }

        int FindBlend(int geoset)
        {
            for (int i = 0; i < model.View.Textures.Length; i++)
            {
                if (model.View.Textures[i].geoset == geoset)
                {
                    return model.View.Textures[i].blend;
                }
            }
            return -1;
        }

        protected void RenderSkeleton(OpenGL gl)
        {
            float x, y, z;
            if(skeleton)
            {
                gl.Color(1f, 0f, 0f);
                gl.Disable(OpenGL.GL_DEPTH_TEST);
                gl.Begin(OpenGL.GL_LINES);
                for(int i = 0; i < bones.Length; i++)
                {
                    if(bones[i].Parent >= 0)
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
        }

        public abstract void Render(OpenGL gl);
    }
}

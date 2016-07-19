using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
        protected ModelViewGeoset[] geosets;
        protected List<int> billboards;
        Vector3D position;
        Quaternion rotation;
        Vector3D scale;
        Texture[] textures;
        string texture;
        string texturesPath;
        string id;
        bool empty;

        public ObjectComponent()
        {
            empty = true;
            id = "0";
        }

        public string ID { get { return id; } }

        public bool Empty { get { return empty; } }

        public void Initialize()
        {
            empty = true;
            id = null;
            id = "0";
        }

        public void Initialize(string id, string file, string texture, string path, Vector3D position, Quaternion rotation, Vector3D scale)
        {
            if(file == "")
            {
                empty = true;
                return;
            }
            this.id = null;
            this.id = id;
            empty = false;
            this.texture = null;
            this.texture = texture;
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            texturesPath = null;
            texturesPath = path;
            model = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(path + file))
            {
                model = (Model)serializer.Deserialize(reader.BaseStream);
                reader.Dispose();
            }
            vertices = null;
            vertices = model.Vertices;
            indices = null;
            indices = model.View.Indices;
            triangles = null;
            triangles = model.View.Triangles;
            geosets = null;
            geosets = model.View.Geosets;
            textures = null;
            textures = new Texture[model.Textures.Length];
            for(int i = 0; i < textures.Length; i++)
            {
                textures[i] = new Texture();
            }
            billboards = null;
            billboards = new List<int>();
            for(int i = 0; i < model.Bones.Length; i++)
            {
                if((model.Bones[i].Billboard & 8) == 8)
                {
                    billboards.Add(i);
                }
            }
            serializer = null;
        }

        void MakeTextures(OpenGL gl)
        {
            for(int i = 0; i < textures.Length; i++)
            {
                switch(model.Textures[i].type)
                {
                    case 0:
                        MakeTexture(gl, i);
                        break;
                    case 2:
                        MakeObjectTexture(gl, i);
                        break;
                }
            }
        }

        void MakeTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            string[] file = model.Textures[index].file.Replace(".BLP", ".PNG").Replace(".blp", ".png").Split('\\');
            Bitmap bitmap = LoadBitmap(texturesPath + file.Last());
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
            file = null;
        }

        void MakeObjectTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            Bitmap bitmap = LoadBitmap(texturesPath + texture + ".png");
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
        }

        Bitmap LoadBitmap(string file)
        {
            if(File.Exists(file))
            {
                Bitmap bitmap;
                using(StreamReader reader = new StreamReader(file))
                {
                    bitmap = new Bitmap(reader.BaseStream);
                }
                return bitmap;
            }
            return null;
        }

        void RenderBillboard(OpenGL gl, int geoset, float characterRotation, int start, int count)
        {
            float x, y, z;
            SetColor(gl, geoset);
            Blend(gl, geoset);
            textures[FindTexture(geoset)].Bind(gl);
            foreach(int billboard in billboards)
            {
                x = model.Bones[billboard].Position.x;
                y = model.Bones[billboard].Position.y;
                z = model.Bones[billboard].Position.z;
                gl.PushMatrix();
                gl.Translate(position.X, position.Y, position.Z);
                gl.Rotate(rotation.Angle, rotation.Axis.X, rotation.Axis.Y, rotation.Axis.Z);
                gl.Scale(scale.X, scale.Y, scale.Z);
                gl.Translate(x, y, z);
                gl.Rotate(-characterRotation, 0f, 1f, 0f);
                gl.Translate(-x, -y, -z);
                gl.Begin(OpenGL.GL_TRIANGLES);
                for(int i = start; i < start + count; i++)
                {
                    if(vertices[indices[triangles[i]]].Bones[0].index == billboard)
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
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_ALPHA_TEST);
        }

        void RenderGeoset(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            SetColor(gl, geoset);
            Blend(gl, geoset);
            textures[FindTexture(geoset)].Bind(gl);
            gl.PushMatrix();
            gl.Translate(position.X, position.Y, position.Z);
            gl.Rotate(rotation.Angle, rotation.Axis.X, rotation.Axis.Y, rotation.Axis.Z);
            gl.Scale(scale.X, scale.Y, scale.Z);
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
            gl.PopMatrix();
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_ALPHA_TEST);
        }

        void SetColor(OpenGL gl, int geoset)
        {
            int color = FindColor(geoset);
            int transparency = FindTransparency(geoset);
            if(color == -1)
            {
                gl.Color(1f, 1f, 1f, model.Transparencies[transparency]);
            }
            else
            {
                gl.Color(model.Colors[color].red, model.Colors[color].green, model.Colors[color].blue, model.Colors[color].alpha * model.Transparencies[transparency]);
            }
        }

        int FindColor(int geoset)
        {
            foreach(ModelViewTexture viewTexture in model.View.Textures)
            {
                if(viewTexture.geoset == geoset)
                {
                    return viewTexture.color;
                }
            }
            return -1;
        }

        int FindTransparency(int geoset)
        {
            foreach(ModelViewTexture viewTexture in model.View.Textures)
            {
                if(viewTexture.geoset == geoset)
                {
                    return viewTexture.transparency;
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
                    gl.BlendFunc(OpenGL.GL_ONE, OpenGL.GL_ZERO);
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
                case 5:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.DepthMask((byte)OpenGL.GL_FALSE);
                    gl.BlendFunc(OpenGL.GL_DST_COLOR, OpenGL.GL_ZERO);
                    break;
                case 6:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.DepthMask((byte)OpenGL.GL_FALSE);
                    gl.BlendFunc(OpenGL.GL_DST_COLOR, OpenGL.GL_SRC_COLOR);
                    break;
            }
        }

        int FindBlend(int geoset)
        {
            foreach(ModelViewTexture viewTexture in model.View.Textures)
            {
                if(viewTexture.geoset == geoset)
                {
                    return viewTexture.blend;
                }
            }
            return -1;
        }

        int FindTexture(int geoset)
        {
            foreach(ModelViewTexture texture in model.View.Textures)
            {
                if(texture.geoset == geoset)
                {
                    return texture.texture;
                }
            }
            return -1;
        }

        public void Render(OpenGL gl, float characterRotation)
        {
            MakeTextures(gl);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            for(int i = 0; i < geosets.Length; i++)
            {
                if(geosets.Length > 1 && billboards.Contains(vertices[indices[triangles[geosets[i].triangle]]].Bones[0].index))
                {
                    RenderBillboard(gl, i, characterRotation, geosets[i].triangle, geosets[i].triangles);
                }
                else
                {
                    RenderGeoset(gl, i, geosets[i].triangle, geosets[i].triangles);
                }
            }
            gl.Disable(OpenGL.GL_TEXTURE_2D);
        }

        public void Dispose()
        {
            model = null;
            vertices = null;
            indices = null;
            triangles = null;
            geosets = null;
            billboards = null;
            texture = null;
            textures = null;
            texturesPath = null;
        }
    }
}

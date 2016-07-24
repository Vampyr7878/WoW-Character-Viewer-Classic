using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Models
{
    public class Mount : IDisposable
    {
        Model model;
        ModelVertex[] vertices;
        int[] indices;
        int[] triangles;
        protected ModelViewGeoset[] geosets;
        protected List<int> billboards;
        Texture[] textures;
        string texture1;
        string texture2;
        string texture3;
        string texturesPath;
        string id;
        bool disposed;

        public Mount()
        {
            disposed = false;
            Empty = true;
            id = "0";
        }

        public string ID { get { return id; } }

        public bool Empty { get; set; }

        public void Initialize()
        {
            Empty = true;
            id = null;
            id = "0";
        }

        public void Initialize(string id, string file, string texture1, string texture2, string texture3, string path)
        {
            if(file == "")
            {
                Empty = true;
                return;
            }
            this.id = null;
            this.id = id;
            Empty = false;
            this.texture1 = null;
            this.texture1 = texture1;
            this.texture2 = null;
            this.texture2 = texture2;
            this.texture3 = null;
            this.texture3 = texture3;
            texturesPath = null;
            texturesPath = path;
            model = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(path + file + ".xml"))
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

        public ModelBone GetAttachment()
        {
            return (from attachment in model.Attachments where attachment.id == 0 select model.Bones[attachment.bone]).FirstOrDefault();
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
                    case 11:
                        MakeCreature1Texture(gl, i);
                        break;
                    case 12:
                        MakeCreature2Texture(gl, i);
                        break;
                    case 13:
                        MakeCreature3Texture(gl, i);
                        break;
                }
            }
        }

        void MakeTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            Bitmap bitmap = LoadBitmap(model.Textures[index].file.Replace("SPELLS", "CREATURE").Replace("Spells", "Creature").Replace(".BLP", ".PNG").Replace(".blp", ".png"));
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
        }

        void MakeCreature1Texture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            Bitmap bitmap = LoadBitmap(texturesPath + texture1 + ".png");
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
        }

        void MakeCreature2Texture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            Bitmap bitmap = LoadBitmap(texturesPath + texture2 + ".png");
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
        }

        void MakeCreature3Texture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            Bitmap bitmap = LoadBitmap(texturesPath + texture3 + ".png");
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
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

        void RenderBillboard(OpenGL gl, int geoset, float characterRotation, int start, int count)
        {
            float x, y, z;
            SetColor(gl, geoset);
            Blend(gl, geoset, 0);
            textures[FindTexture(geoset, 0)].Bind(gl);
            foreach(int billboard in billboards)
            {
                x = model.Bones[billboard].Position.x;
                y = model.Bones[billboard].Position.y;
                z = model.Bones[billboard].Position.z;
                gl.PushMatrix();
                if(model.Name.Contains("Kodo"))
                {
                    gl.Scale(0.5f, 0.5f, 0.5f);
                }
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
            gl.PushMatrix();
            if(model.Name.Contains("Kodo"))
            {
                gl.Scale(0.5f, 0.5f, 0.5f);
            }
            int layers = CountTextures(geoset);
            for(int i = 0; i < layers; i++)
            {
                Blend(gl, geoset, i);
                textures[FindTexture(geoset, i)].Bind(gl);
                gl.Begin(OpenGL.GL_TRIANGLES);
                for(int j = start; j < start + count; j++)
                {
                    x = vertices[indices[triangles[j]]].Texture.x;
                    y = vertices[indices[triangles[j]]].Texture.y;
                    gl.TexCoord(x, y);
                    x = vertices[indices[triangles[j]]].Position.x;
                    y = vertices[indices[triangles[j]]].Position.y;
                    z = vertices[indices[triangles[j]]].Position.z;
                    gl.Vertex(x, y, z);
                }
                gl.End();
                gl.DepthMask((byte)OpenGL.GL_TRUE);
                gl.Disable(OpenGL.GL_BLEND);
                gl.Disable(OpenGL.GL_ALPHA_TEST);
            }
            gl.PopMatrix();
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

        void Blend(OpenGL gl, int geoset, int layer)
        {
            switch(model.Blending[FindBlend(geoset, layer)])
            {
                case 1:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.Enable(OpenGL.GL_ALPHA_TEST);
                    gl.BlendFunc(OpenGL.GL_ONE, OpenGL.GL_ZERO);
                    gl.AlphaFunc(OpenGL.GL_GREATER, 0.9f);
                    break;
                case 4:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.DepthMask((byte)OpenGL.GL_FALSE);
                    gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE);
                    break;
                case 6:
                    gl.Enable(OpenGL.GL_BLEND);
                    gl.DepthMask((byte)OpenGL.GL_FALSE);
                    gl.BlendFunc(OpenGL.GL_DST_COLOR, OpenGL.GL_SRC_COLOR);
                    break;
            }
        }

        int FindBlend(int geoset, int layer)
        {
            foreach(ModelViewTexture texture in model.View.Textures)
            {
                if(texture.geoset == geoset && texture.layer == layer)
                {
                    return texture.blend;
                }
            }
            return -1;
        }

        int CountTextures(int geoset)
        {
            int count = 0;
            foreach(ModelViewTexture texture in model.View.Textures)
            {
                if(texture.geoset == geoset)
                {
                    count++;
                }
            }
            return count;
        }

        int FindTexture(int geoset, int layer)
        {
            foreach(ModelViewTexture texture in model.View.Textures)
            {
                if(texture.geoset == geoset && texture.layer == layer)
                {
                    return texture.texture;
                }
            }
            return -1;
        }

        bool GeosetBillboard(int start, int count)
        {
            for(int i = start; i < start + count; i++)
            {
                if(!billboards.Contains(vertices[indices[triangles[i]]].Bones[0].index))
                {
                    return false;
                }
            }
            return true;
        }

        public void Render(OpenGL gl, float characterRotation)
        {
            MakeTextures(gl);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            for(int i = 0; i < geosets.Length; i++)
            {
                if(GeosetBillboard(geosets[i].triangle, geosets[i].triangles))
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

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                }
                model = null;
                vertices = null;
                indices = null;
                triangles = null;
                geosets = null;
                billboards = null;
                texture1 = null;
                texture2 = null;
                texture3 = null;
                textures = null;
                texturesPath = null;
                disposed = true;
            }
        }

        ~Mount()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

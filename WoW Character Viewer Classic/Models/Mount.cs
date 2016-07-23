using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
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
        string texture;
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

        public void Initialize(string id, string file, string texture, string path)
        {
            if(file == "")
            {
                Empty = true;
                return;
            }
            this.id = null;
            this.id = id;
            Empty = false;
            this.texture = null;
            this.texture = texture;
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

        void RenderBillboard(OpenGL gl, int geoset, float characterRotation, int start, int count)
        {
            float x, y, z;
            //SetColor(gl, geoset);
            //Blend(gl, geoset, 0);
            //textures[FindTexture(geoset, 0)].Bind(gl);
            foreach(int billboard in billboards)
            {
                x = model.Bones[billboard].Position.x;
                y = model.Bones[billboard].Position.y;
                z = model.Bones[billboard].Position.z;
                gl.PushMatrix();
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
            //gl.DepthMask((byte)OpenGL.GL_TRUE);
            //gl.Disable(OpenGL.GL_BLEND);
            //gl.Disable(OpenGL.GL_ALPHA_TEST);
        }

        void RenderGeoset(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            //SetColor(gl, geoset);
            //int layers = CountTextures(geoset);
            //for (int i = 0; i < layers; i++)
            //{
            //Blend(gl, geoset, i);
            //textures[FindTexture(geoset, i)].Bind(gl);
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
            //}
            //gl.DepthMask((byte)OpenGL.GL_TRUE);
            //gl.Disable(OpenGL.GL_BLEND);
            //gl.Disable(OpenGL.GL_ALPHA_TEST);
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
            //MakeTextures(gl);
            //gl.Enable(OpenGL.GL_TEXTURE_2D);
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
            //gl.Disable(OpenGL.GL_TEXTURE_2D);
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
                texture = null;
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

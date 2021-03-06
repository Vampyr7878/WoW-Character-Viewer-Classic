﻿using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media.Media3D;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Models
{
    public class ObjectComponent : Model3D
    {
        Vector3D position;
        Quaternion rotation;
        Vector3D scale;
        string texture;
        string id;

        public ObjectComponent()
            : base()
        {
            Empty = true;
            id = "0";
        }

        public string ID { get { return id; } }

        public bool Empty { get; set; }

        public override void Initialize()
        {
            Empty = true;
            id = "0";
        }

        public void Initialize(string id, string file, string texture, string path, Vector3D position, Quaternion rotation, Vector3D scale)
        {
            if (file == "")
            {
                Empty = true;
                return;
            }
            this.id = id;
            Empty = false;
            this.texture = texture;
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            texturesPath = path;
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using (StreamReader reader = new StreamReader(path + file))
            {
                model = (Model)serializer.Deserialize(reader);
            }
            vertices = model.Vertices;
            indices = model.View.Indices;
            triangles = model.View.Triangles;
            geosets = model.View.Geosets;
            textures = new Texture[model.Textures.Length];
            for (int i = 0; i < textures.Length; i++)
            {
                textures[i] = new Texture();
            }
            billboards.Clear();
            for (int i = 0; i < model.Bones.Length; i++)
            {
                if ((model.Bones[i].Billboard & 8) == 8)
                {
                    billboards.Add(i);
                }
            }
        }

        public void Modify(Vector3D position, Quaternion rotation, Vector3D scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        protected override void MakeTextures(OpenGL gl)
        {
            for (int i = 0; i < textures.Length; i++)
            {
                switch (model.Textures[i].type)
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

        protected override void MakeTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            string[] file = model.Textures[index].file.Replace(".BLP", ".PNG").Replace(".blp", ".png").Split('\\');
            using (Bitmap bitmap = LoadBitmap(texturesPath + file.Last()))
            {
                if (bitmap != null)
                {
                    textures[index].Create(gl, bitmap);
                }
            }
        }

        void MakeObjectTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            using (Bitmap bitmap = LoadBitmap(texturesPath + texture + ".png"))
            {
                if (bitmap != null)
                {
                    textures[index].Create(gl, bitmap);
                }
            }
        }

        void RenderBillboard(OpenGL gl, int geoset, float characterRotation, int start, int count)
        {
            float x, y, z;
            SetColor(gl, geoset);
            Blend(gl, geoset, 0);
            textures[FindTexture(geoset, 0)].Bind(gl);
            foreach (int billboard in billboards)
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
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_ALPHA_TEST);
        }

        void RenderGeoset(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            SetColor(gl, geoset);
            int layers = CountTextures(geoset);
            gl.PushMatrix();
            gl.Translate(position.X, position.Y, position.Z);
            gl.Rotate(rotation.Angle, rotation.Axis.X, rotation.Axis.Y, rotation.Axis.Z);
            gl.Scale(scale.X, scale.Y, scale.Z);
            for (int i = 0; i < layers; i++)
            {
                Blend(gl, geoset, i);
                textures[FindTexture(geoset, i)].Bind(gl);
                gl.Begin(OpenGL.GL_TRIANGLES);
                for (int j = start; j < start + count; j++)
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

        int CountTextures(int geoset)
        {
            int count = 0;
            foreach (ModelViewTexture texture in model.View.Textures)
            {
                if (texture.geoset == geoset)
                {
                    count++;
                }
            }
            return count;
        }

        bool GeosetBillboard(int start, int count)
        {
            for (int i = start; i < start + count; i++)
            {
                if (!billboards.Contains(vertices[indices[triangles[i]]].Bones[0].index))
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
            for (int i = 0; i < geosets.Length; i++)
            {
                if (GeosetBillboard(geosets[i].triangle, geosets[i].triangles))
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
    }
}

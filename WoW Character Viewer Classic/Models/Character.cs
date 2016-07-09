using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Models
{
    abstract class Character
    {
        Model model;
        protected ModelVertex[] vertices;
        protected int[] indices;
        protected int[] triangles;
        protected ModelViewGeoset[] geosets;
        protected List<int> billboards;
        ModelBone[] bones;
        Texture[] textures;
        string texturesPath;
        string skinName;
        protected int skinsCount;
        string faceName;
        protected int facesCount;
        protected string hairName;
        protected string[] hairNames;
        protected int hairsCount;
        protected string colorName;
        protected int colorsCount;
        protected string facialName;
        protected string[] facialNames;
        protected int facialsCount;

        protected Character(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(file))
            {
                model = (Model)serializer.Deserialize(reader.BaseStream);
            }
            Gear = Enumerable.Repeat("0", 25).ToArray();
            Skeleton = false;
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
            skinName = "Skin Color: ";
            Skin = 0;
            faceName = "Face: ";
            Face = 0;
            Hair = 0;
            Color = 0;
            Facial = 0;
            GetHairNames();
            GetFacialNames();
        }

        public Model Model { get { return model; } }

        public string[] Gear { get; set; }

        public bool Skeleton { get; set; }

        public float Rotation { get; set; }

        public string SkinName { get { return skinName; } }

        public int Skin { get; set; }

        public int SkinsCount { get { return skinsCount; } }

        public string FaceName { get { return faceName; } }

        public int Face { get; set; }

        public int FacesCount { get { return facesCount; } }

        public string HairName { get { return hairName; } }

        public string[] HairNames { get { return hairNames; } }

        public int Hair { get; set; }

        public int HairsCount { get { return hairsCount; } }

        public string ColorName { get { return colorName; } }

        public int Color { get; set; }

        public int ColorsCount { get { return colorsCount; } }

        public string FacialName { get { return facialName; } }

        public string[] FacialNames { get { return facialNames; } }

        public int Facial { get; set; }

        public int FacialsCount { get { return facialsCount; } }

        protected string Number(int number)
        {
            return number > 9 ? number.ToString() : "0" + number;
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
                    case 6:
                        MakeHairTexture(gl, i);
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
            Bitmap bitmap = LoadBitmap(texturesPath + gender + model.Name + "Skin00_" + Number(Skin) + ".png");
            bitmap = new Bitmap(bitmap);
            Graphics graphics = Graphics.FromImage(bitmap);
            DrawLayer(graphics, gender + model.Name + "NakedPelvisSkin00_" + Number(Skin) + ".png", 128, 96);
            if(model.Name.Contains("Female"))
            {
                DrawLayer(graphics, gender + model.Name + "NakedTorsoSkin00_" + Number(Skin) + ".png", 128, 0);
            }
            DrawLayer(graphics, gender + model.Name + "FaceUpper" + Number(Face) + "_" + Number(Skin) + ".png", 0, 160);
            DrawLayer(graphics, gender + model.Name + "FaceLower" + Number(Face) + "_" + Number(Skin) + ".png", 0, 192);
            DrawLayer(graphics, "FacialUpperHair" + GetFacialUpper() + "_" + Number(Color) + ".png", 0, 160);
            DrawLayer(graphics, "FacialLowerHair" + GetFacialLower() + "_" + Number(Color) + ".png", 0, 192);
            DrawLayer(graphics, "ScalpUpperHair" + GetScalpUpper() + "_" + Number(Color) + ".png", 0, 160);
            DrawLayer(graphics, "ScalpLowerHair" + GetScalpLower() + "_" + Number(Color) + ".png", 0, 192);
            textures[index].Create(gl, bitmap);
        }

        void DrawLayer(Graphics graphics, string layer, int x, int y)
        {
            Bitmap bitmap = LoadBitmap(texturesPath + layer);
            if(bitmap != null)
            {
                graphics.DrawImage(bitmap, new Point(x, y));
            }
        }

        void MakeHairTexture(OpenGL gl, int index)
        {
            Bitmap bitmap = LoadBitmap(texturesPath + "Hair" + GetHairTexture() + "_" + Number(Color) + ".png");
            if(bitmap != null)
            {
                textures[index].Create(gl, bitmap);
            }
        }

        void MakeExtraTexture(OpenGL gl, int index)
        {
            string gender = model.Name.Contains("Female") ? @"Female\" : @"Male\";
            Bitmap bitmap = LoadBitmap(texturesPath + gender + model.Name + "Skin00_" + Number(Skin) + "_Extra.png");
            textures[index].Create(gl, bitmap);
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
                gl.Rotate(-Rotation, 0f, 1f, 0f);
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
            foreach(ModelViewTexture texture in model.View.Textures)
            {
                if(texture.geoset == geoset)
                {
                    return texture.texture;
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
            if(Skeleton)
            {
                gl.Color(1f, 0f, 0f);
                gl.Disable(OpenGL.GL_DEPTH_TEST);
                gl.Begin(OpenGL.GL_LINES);
                foreach(ModelBone bone in bones)
                {
                    if(bone.Parent >= 0)
                    {
                        x = bones[bone.Parent].Position.x;
                        y = bones[bone.Parent].Position.y;
                        z = bones[bone.Parent].Position.z;
                        gl.Vertex(x, y, z);
                        x = bone.Position.x;
                        y = bone.Position.y;
                        z = bone.Position.z;
                        gl.Vertex(x, y, z);
                    }
                }
                gl.End();
                gl.Enable(OpenGL.GL_DEPTH_TEST);
            }
        }

        protected abstract void GetHairNames();

        protected abstract void GetFacialNames();

        protected abstract string GetFacialUpper();

        protected abstract string GetFacialLower();

        protected abstract string GetScalpUpper();

        protected abstract string GetScalpLower();

        protected abstract string GetHairTexture();

        protected abstract void HairGeosets();

        protected abstract void FacialGeosets();

        public abstract void Render(OpenGL gl);
    }
}

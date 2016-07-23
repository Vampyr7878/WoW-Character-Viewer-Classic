using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Media3D;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Models
{
    public abstract class Character : IDisposable
    {
        Model model;
        Model standing;
        Model mounted;
        protected Mount mount;
        protected ObjectComponent[] components;
        protected ModelVertex[] vertices;
        protected int[] indices;
        protected int[] triangles;
        protected ModelViewGeoset[] geosets;
        protected List<int> billboards;
        ModelBone[] bones;
        Texture[] textures;
        string texturesPath;
        string objectComponentsPath;
        string textureComponentsPath;
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
        bool disposed;

        protected Character(string file)
        {
            disposed = false;
            XmlSerializer serializer = new XmlSerializer(typeof(Model));
            using(StreamReader reader = new StreamReader(file))
            {
                standing = (Model)serializer.Deserialize(reader.BaseStream);
                reader.Dispose();
            }
            using(StreamReader reader = new StreamReader(file.Replace(".xml", "Mounted.xml")))
            {
                mounted = (Model)serializer.Deserialize(reader.BaseStream);
                reader.Dispose();
            }
            model = standing;
            Gear = new ItemsItem[25];
            Skeleton = false;
            Ranged = false;
            Sheathe = false;
            Mounted = false;
            texturesPath = @"Character\" + model.Name.Replace("Female", "").Replace("Male", "") + @"\";
            objectComponentsPath = @"Item\ObjectComponents\";
            textureComponentsPath = @"Item\TextureComponents\";
            vertices = model.Vertices;
            indices = model.View.Indices;
            triangles = model.View.Triangles;
            geosets = model.View.Geosets;
            bones = model.Bones;
            textures = new Texture[model.Textures.Length];
            for(int i = 0; i < textures.Length; i++)
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
            mount = new Mount();
            components = new[]
            {
                new ObjectComponent(),
                new ObjectComponent(),
                new ObjectComponent(),
                new ObjectComponent(),
                new ObjectComponent(),
                new ObjectComponent()
            };
            serializer = null;
        }

        public Model Model { get { return model; } }

        public ItemsItem[] Gear { get; set; }

        public bool Skeleton { get; set; }

        public float Rotation { get; set; }

        public bool Ranged { get; set; }

        public bool Sheathe { get; set; }

        public bool Mounted { get; set; }

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

        public void Mount(bool mounted)
        {
            Mounted = mounted;
            if(Mounted)
            {
                if(Gear[24].ID != "0")
                {
                    model = this.mounted;
                    Ranged = false;
                    Sheathe = true;
                    vertices = model.Vertices;
                    indices = model.View.Indices;
                    triangles = model.View.Triangles;
                    geosets = model.View.Geosets;
                    bones = model.Bones;
                }
                else
                {
                    Mounted = false;
                }
            }
            else
            {
                model = standing;
                vertices = model.Vertices;
                indices = model.View.Indices;
                triangles = model.View.Triangles;
                geosets = model.View.Geosets;
                bones = model.Bones;
            }
        }

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
                    case 2:
                        MakeCapeTexture(gl, i);
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
            textures[index].Destroy(gl);
            Bitmap bitmap = LoadBitmap(model.Textures[index].file.Replace(".BLP", ".PNG"));
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
        }

        void MakeBodyTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            string gender = model.Name.Contains("Female") ? @"Female\" : @"Male\";
            Bitmap bitmap = LoadBitmap(texturesPath + gender + model.Name + "Skin00_" + Number(Skin) + ".png");
            bitmap = new Bitmap(bitmap);
            Graphics graphics = Graphics.FromImage(bitmap);
            if(!LegUpper())
            {
                DrawLayer(graphics, texturesPath + gender + model.Name + "NakedPelvisSkin00_" + Number(Skin) + ".png", 128, 96);
            }
            if(model.Name.Contains("Female") && !TorsoUpper())
            {
                DrawLayer(graphics, texturesPath + gender + model.Name + "NakedTorsoSkin00_" + Number(Skin) + ".png", 128, 0);
            }
            DrawLayer(graphics, texturesPath + gender + model.Name + "FaceUpper" + Number(Face) + "_" + Number(Skin) + ".png", 0, 160);
            DrawLayer(graphics, texturesPath + gender + model.Name + "FaceLower" + Number(Face) + "_" + Number(Skin) + ".png", 0, 192);
            DrawLayer(graphics, texturesPath + "FacialUpperHair" + GetFacialUpper() + "_" + Number(Color) + ".png", 0, 160);
            DrawLayer(graphics, texturesPath + "FacialLowerHair" + GetFacialLower() + "_" + Number(Color) + ".png", 0, 192);
            DrawLayer(graphics, texturesPath + "ScalpUpperHair" + GetScalpUpper() + "_" + Number(Color) + ".png", 0, 160);
            DrawLayer(graphics, texturesPath + "ScalpLowerHair" + GetScalpLower() + "_" + Number(Color) + ".png", 0, 192);
            MakeLegsTexture(graphics, gender);
            MakeShirtTexture(graphics, gender);
            MakeChestTexture(graphics, gender);
            MakeTabardTexture(graphics, gender);
            MakeWristTexture(graphics, gender);
            MakeHandsTexture(graphics, gender);
            MakeWaistTexture(graphics, gender);
            MakeFeetTexture(graphics, gender);
            textures[index].Create(gl, bitmap);
            graphics.Dispose();
            graphics = null;
            bitmap.Dispose();
            bitmap = null;
            gender = null;
        }

        bool LegUpper()
        {
            if(Gear[4].Textures != null && !string.IsNullOrEmpty(Gear[4].Textures.LegUpper))
            {
                return true;
            }
            if(Gear[5].Textures != null && !string.IsNullOrEmpty(Gear[5].Textures.LegUpper))
            {
                return true;
            }
            if(Gear[6].Textures != null && !string.IsNullOrEmpty(Gear[6].Textures.LegUpper))
            {
                return true;
            }
            return false;
        }

        bool TorsoUpper()
        {
            if(Gear[4].Textures != null && !string.IsNullOrEmpty(Gear[4].Textures.TorsoUpper))
            {
                return true;
            }
            if(Gear[10].Textures != null && !string.IsNullOrEmpty(Gear[10].Textures.TorsoUpper))
            {
                return true;
            }
            return false;
        }

        void MakeLegsTexture(Graphics graphics, string gender)
        {
            if(Gear[10].Textures != null)
            {
                DrawLayer(graphics, ArmorTexture(@"LegUpperTexture\" + Gear[10].Textures.LegUpper, gender), 128, 96);
                DrawLayer(graphics, ArmorTexture(@"LegLowerTexture\" + Gear[10].Textures.LegLower, gender), 128, 160);
            }
        }

        void MakeShirtTexture(Graphics graphics, string gender)
        {
            if(Gear[5].Textures != null)
            {
                DrawLayer(graphics, ArmorTexture(@"ArmUpperTexture\" + Gear[5].Textures.ArmUpper, gender), 0, 0);
                DrawLayer(graphics, ArmorTexture(@"ArmLowerTexture\" + Gear[5].Textures.ArmLower, gender), 0, 64);
                DrawLayer(graphics, ArmorTexture(@"TorsoUpperTexture\" + Gear[5].Textures.TorsoUpper, gender), 128, 0);
                DrawLayer(graphics, ArmorTexture(@"TorsoLowerTexture\" + Gear[5].Textures.TorsoLower, gender), 128, 64);
            }
        }

        void MakeChestTexture(Graphics graphics, string gender)
        {
            if(Gear[4].Textures != null)
            {
                DrawLayer(graphics, ArmorTexture(@"ArmUpperTexture\" + Gear[4].Textures.ArmUpper, gender), 0, 0);
                DrawLayer(graphics, ArmorTexture(@"ArmLowerTexture\" + Gear[4].Textures.ArmLower, gender), 0, 64);
                DrawLayer(graphics, ArmorTexture(@"TorsoUpperTexture\" + Gear[4].Textures.TorsoUpper, gender), 128, 0);
                DrawLayer(graphics, ArmorTexture(@"TorsoLowerTexture\" + Gear[4].Textures.TorsoLower, gender), 128, 64);
                DrawLayer(graphics, ArmorTexture(@"LegUpperTexture\" + Gear[4].Textures.LegUpper, gender), 128, 96);
                if(Gear[4].Models.Robe == "" && (Gear[10].Models == null || Gear[10].Models.Robe == ""))
                {
                    DrawLayer(graphics, ArmorTexture(@"LegLowerTexture\" + Gear[4].Textures.LegLower, gender), 128, 160);
                }
                else if(Gear[4].Models.Robe == "Robe1")
                {
                    DrawLayer(graphics, ArmorTexture(@"LegLowerTexture\" + Gear[4].Textures.LegLower, gender), 128, 160);
                }
            }
        }

        void MakeTabardTexture(Graphics graphics, string gender)
        {
            if(Gear[6].Textures != null)
            {
                DrawLayer(graphics, ArmorTexture(@"TorsoUpperTexture\" + Gear[6].Textures.TorsoUpper, gender), 128, 0);
                DrawLayer(graphics, ArmorTexture(@"TorsoLowerTexture\" + Gear[6].Textures.TorsoLower, gender), 128, 64);
            }
        }

        void MakeWristTexture(Graphics graphics, string gender)
        {
            if(Gear[7].Textures != null && (Gear[4].Models == null || Gear[4].Models.Sleeve == ""))
            {
                DrawLayer(graphics, ArmorTexture(@"ArmLowerTexture\" + Gear[7].Textures.ArmLower, gender), 0, 64);
            }
        }

        void MakeHandsTexture(Graphics graphics, string gender)
        {
            if(Gear[8].Textures != null)
            {
                if(Gear[4].Models == null || Gear[4].Models.Sleeve == "" || Gear[8].Models.Wrist != "Wrist1")
                {
                    DrawLayer(graphics, ArmorTexture(@"ArmLowerTexture\" + Gear[8].Textures.ArmLower, gender), 0, 64);
                }
                DrawLayer(graphics, ArmorTexture(@"HandTexture\" + Gear[8].Textures.Hand, gender), 0, 128);
            }
        }

        void MakeWaistTexture(Graphics graphics, string gender)
        {
            if(Gear[9].Textures != null)
            {
                DrawLayer(graphics, ArmorTexture(@"LegUpperTexture\" + Gear[9].Textures.LegUpper, gender), 128, 96);
            }
        }

        void MakeFeetTexture(Graphics graphics, string gender)
        {
            if(Gear[11].Textures != null)
            {
                if((Gear[4].Models == null || Gear[4].Models.Robe == "") && (Gear[10].Models == null || Gear[10].Models.Robe == ""))
                {
                    DrawLayer(graphics, ArmorTexture(@"LegLowerTexture\" + Gear[11].Textures.LegLower, gender), 128, 160);
                }
                if(!Model.Name.Contains("Tauren") && !Model.Name.Contains("Troll"))
                {
                    DrawLayer(graphics, ArmorTexture(@"FootTexture\" + Gear[11].Textures.Foot, gender), 128, 224);
                }
            }
        }

        string ArmorTexture(string texture, string gender)
        {
            string file = textureComponentsPath + texture + "_U.png";
            if(!File.Exists(file))
            {
                file = gender == @"Male\" ? file.Replace("_U", "_M") : file.Replace("_U", "_F");
            }
            return file;
        }

        void DrawLayer(Graphics graphics, string layer, int x, int y)
        {
            Bitmap bitmap = LoadBitmap(layer);
            if(bitmap != null)
            {
                graphics.DrawImage(bitmap, new Point(x, y));
                bitmap.Dispose();
                bitmap = null;
            }
        }

        void MakeCapeTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            if(Gear[3].Textures != null)
            {
                Bitmap bitmap = LoadBitmap(objectComponentsPath + @"Cape\" + Gear[3].Textures.Left + ".png");
                if(bitmap != null)
                {
                    textures[index].Create(gl, bitmap);
                    bitmap.Dispose();
                    bitmap = null;
                }
            }
        }

        void MakeHairTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            Bitmap bitmap = LoadBitmap(texturesPath + "Hair" + GetHairTexture() + "_" + Number(Color) + ".png");
            if(bitmap != null)
            {
                textures[index].Create(gl, bitmap);
                bitmap.Dispose();
                bitmap = null;
            }
        }

        void MakeExtraTexture(OpenGL gl, int index)
        {
            textures[index].Destroy(gl);
            string gender = model.Name.Contains("Female") ? @"Female\" : @"Male\";
            Bitmap bitmap = LoadBitmap(texturesPath + gender + model.Name + "Skin00_" + Number(Skin) + "_Extra.png");
            textures[index].Create(gl, bitmap);
            bitmap.Dispose();
            bitmap = null;
            gender = null;
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

        protected void EquipGear()
        {
            EquipCape();
            EquipHands();
            EquipFeet();
            EquipLegs();
            EquipShirt();
            EquipWrist();
            EquipChest();
            EquipTabard();
            EquipHead();
            EquipShoulders();
            EquipMainHand();
            EquipOffHand();
            EquipRanged();
            EquipMount();
        }

        void EquipHead()
        {
            if(Gear[0].ID == "0")
            {
                components[0].Initialize();
            }
            else
            {
                ModelBone bone = bones[FindAttachment(11).bone];
                Vector3D position = new Vector3D(bone.Position.x, bone.Position.y, bone.Position.z);
                Quaternion rotation = new Quaternion(bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                Vector3D scale = new Vector3D(bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if(components[0].ID != Gear[0].ID)
                {
                    components[0].Initialize(Gear[0].ID, Gear[0].Models.Left.Replace(".mdx", HeadName()), Gear[0].Textures.Left, objectComponentsPath + @"Head\", position, rotation, scale);
                }
                else
                {
                    components[0].Modify(position, rotation, scale);
                }
                bone = null;
            }
            HideHair();
            HideFacial();
            HideEars();
        }

        void EquipShoulders()
        {
            if(Gear[2].ID == "0")
            {
                components[1].Initialize();
                components[2].Initialize();
            }
            else
            {
                ModelBone bone = bones[FindAttachment(6).bone];
                Vector3D position = new Vector3D(bone.Position.x, bone.Position.y, bone.Position.z);
                Quaternion rotation = new Quaternion(bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                Vector3D scale = new Vector3D(bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if(components[1].ID != Gear[2].ID)
                {
                    components[1].Initialize(Gear[2].ID, Gear[2].Models.Left.Replace(".mdx", ".xml"), Gear[2].Textures.Left, objectComponentsPath + @"Shoulder\", position, rotation, scale);
                }
                else
                {
                    components[1].Modify(position, rotation, scale);
                }
                bone = null;
                bone = bones[FindAttachment(5).bone];
                position = new Vector3D(bone.Position.x, bone.Position.y, bone.Position.z);
                rotation = new Quaternion(bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                scale = new Vector3D(bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if(components[2].ID != Gear[2].ID)
                {
                    components[2].Initialize(Gear[2].ID, Gear[2].Models.Right.Replace(".mdx", ".xml"), Gear[2].Textures.Right, objectComponentsPath + @"Shoulder\", position, rotation, scale);
                }
                else
                {
                    components[2].Modify(position, rotation, scale);
                }
                bone = null;
            }
        }

        void EquipMainHand()
        {
            if(Gear[16].ID == "0" || (Sheathe && (Gear[16].Sheath == 0 || Gear[16].Sheath == 7)))
            {
                components[3].Initialize();
            }
            else
            {
                int attachment = Sheathe ? WoWHelper.SheatheAttachment(Gear[16].Sheath, false) : 1;
                ModelBone bone = bones[FindAttachment(attachment).bone];
                Vector3D position = new Vector3D(bone.Position.x, bone.Position.y, bone.Position.z);
                Quaternion rotation = new Quaternion(bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                rotation = Sheathe ? rotation * WoWHelper.SheatheRotation(Gear[16].Sheath, false) : rotation;
                Vector3D scale = new Vector3D(bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if(Gear[16].ID != components[3].ID)
                {
                    components[3].Initialize(Gear[16].ID, Gear[16].Models.Left.Replace(".mdx", ".xml"), Gear[16].Textures.Left, objectComponentsPath + @"Weapon\", position, rotation, scale);
                }
                else
                {
                    components[3].Modify(position, rotation, scale);
                }
                bone = null;
            }
        }

        void EquipOffHand()
        {
            if(Gear[17].ID == "0" || (Sheathe && (Gear[17].Sheath == 0 || Gear[17].Sheath == 7)))
            {
                components[4].Initialize();
            }
            else
            {
                int attachment = Sheathe ? WoWHelper.SheatheAttachment(Gear[17].Sheath, true) : Gear[17].Type == "Shield" ? 0 : 2;
                ModelBone bone = bones[FindAttachment(attachment).bone];
                string type = Gear[17].Type == "Shield" ? @"Shield\" : @"Weapon\";
                Vector3D position = new Vector3D(bone.Position.x, bone.Position.y, bone.Position.z);
                Quaternion rotation = new Quaternion(bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                rotation = Sheathe ? rotation * WoWHelper.SheatheRotation(Gear[17].Sheath, true) : rotation;
                Vector3D scale = new Vector3D(bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if(Gear[17].ID != components[4].ID)
                {
                    components[4].Initialize(Gear[17].ID, Gear[17].Models.Left.Replace(".mdx", ".xml"), Gear[17].Textures.Left, objectComponentsPath + type, position, rotation, scale);
                }
                else
                {
                    components[4].Modify(position, rotation, scale);
                }
                bone = null;
                type = null;
            }

        }

        void EquipRanged()
        {
            if(!Ranged || Gear[18].ID == "0" || Gear[18].Slot == "Relic")
            {
                components[5].Initialize();
            }
            else
            {
                ModelBone bone = Gear[18].Type == "Bow" ? bones[FindAttachment(2).bone] : bones[FindAttachment(1).bone];
                Vector3D position = new Vector3D(bone.Position.x, bone.Position.y, bone.Position.z);
                Quaternion rotation = new Quaternion(bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                Vector3D scale = new Vector3D(bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if(components[5].ID != Gear[18].ID)
                {
                    components[5].Initialize(Gear[18].ID, Gear[18].Models.Left.Replace(".mdx", ".xml"), Gear[18].Textures.Left, objectComponentsPath + @"Weapon\", position, rotation, scale);
                }
                else
                {
                    components[5].Modify(position, rotation, scale);
                }
                bone = null;
            }
        }

        void EquipMount()
        {
            if(!Mounted || Gear[24].ID == "0")
            {
                mount.Initialize();
            }
            else
            {
                if(mount.ID != Gear[24].ID)
                {
                    mount.Initialize(Gear[24].ID, Gear[24].Models.Left, Gear[24].Textures.Left, @"Creature\");
                }
            }
        }

        ModelAttachment FindAttachment(int id)
        {
            foreach(ModelAttachment attachment in model.Attachments)
            {
                if(attachment.id == id)
                {
                    return attachment;
                }
            }
            return null;
        }

        string HeadName()
        {
            string name = "_" + model.Name.Substring(0, 2);
            if(model.Name.Contains("Female"))
            {
                return name + "F.xml";
            }
            return name + "M.xml";
        }

        protected void RenderBillboard(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            SetColor(gl, geoset);
            Blend(gl, geoset);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            textures[FindTexture(geoset)].Bind(gl);
            foreach(int billboard in billboards)
            {
                x = model.Bones[billboard].Position.x;
                y = model.Bones[billboard].Position.y;
                z = model.Bones[billboard].Position.z;
                gl.PushMatrix();
                gl.Translate(x, y, z);
                gl.Rotate(-Rotation, 0f, 1f, 0f);
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
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_ALPHA_TEST);
            gl.Disable(OpenGL.GL_BLEND);
        }

        protected void RenderGeoset(OpenGL gl, int geoset, int start, int count)
        {
            float x, y, z;
            SetColor(gl, geoset);
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
            }
        }

        int FindBlend(int geoset)
        {
            foreach(ModelViewTexture texture in model.View.Textures)
            {
                if(texture.geoset == geoset)
                {
                    return texture.blend;
                }
            }
            return -1;
        }

        int FindTexture(int geoset)
        {
            foreach (ModelViewTexture texture in model.View.Textures)
            {
                if (texture.geoset == geoset)
                {
                    return texture.texture;
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

        public void Prepare(OpenGL gl)
        {
            HairGeosets();
            FacialGeosets();
            MakeTextures(gl);
            EquipGear();
            if(Mounted)
            {
                ModelBone attachment = mount.GetAttachment();
                Quaternion rotation = new Quaternion(attachment.Rotation.x, attachment.Rotation.y, attachment.Rotation.z, attachment.Rotation.w);
                gl.Translate(attachment.Position.x, attachment.Position.y, attachment.Position.z);
                gl.Rotate(rotation.Angle, rotation.Axis.X, rotation.Axis.Y, rotation.Axis.Z);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    mount.Dispose();
                    foreach (ObjectComponent component in components)
                    {
                        component.Dispose();
                    }
                }
                model = null;
                components = null;
                vertices = null;
                indices = null;
                triangles = null;
                geosets = null;
                billboards = null;
                bones = null;
                textures = null;
                texturesPath = null;
                objectComponentsPath = null;
                skinName = null;
                faceName = null;
                hairName = null;
                hairNames = null;
                colorName = null;
                facialName = null;
                facialNames = null;
                disposed = true;
            }
        }

        ~Character()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

        protected abstract void EquipCape();

        protected abstract void EquipHands();

        protected abstract void EquipFeet();

        protected abstract void EquipLegs();

        protected abstract void EquipShirt();

        protected abstract void EquipWrist();

        protected abstract void EquipChest();

        protected abstract void EquipTabard();

        protected abstract void HideHair();

        protected abstract void HideFacial();

        protected abstract void HideEars();

        public abstract void Render(OpenGL gl);
    }
}

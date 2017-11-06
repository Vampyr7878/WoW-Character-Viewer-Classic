using SharpGL;
using System.Windows.Media.Media3D;

namespace WoW_Character_Viewer_Classic.Models
{
    public class Humanoid : Creature
    {
        ObjectComponent[] components;
        ModelBone[] bones;
        Vector3D position;
        Quaternion rotation;
        Vector3D scale;
        string objectComponentsPath;

        public Humanoid()
            : base()
        {
            components = new[]
            {
                new ObjectComponent(),
                new ObjectComponent()
            };
            objectComponentsPath = @"Item\ObjectComponents\";
        }

        public ItemsItem[] Gear { get; set; }

        public bool Sheathe { get; set; }

        public override void Initialize()
        {
            Gear = new ItemsItem[2];
            Sheathe = false;
        }

        public void Initialize(string file, string texture1, string texture2, string texture3, string path, ObjectComponent component1, ObjectComponent component2, ItemsItem gear1, ItemsItem gear2)
        {
            base.Initialize(file, texture1, texture2, texture3, path);
            components[0] = component1;
            components[1] = component2;
            Gear = new ItemsItem[2];
            Gear[0] = gear1;
            Gear[1] = gear2;
            bones = model.Bones;
        }

        void EquipGear()
        {
            EquipMainHand();
            EquipOffHand();
        }

        Vector3D SetVector3D(Vector3D vector, float x, float y, float z)
        {
            vector.X = x;
            vector.Y = y;
            vector.Z = z;
            return vector;
        }

        Quaternion SetQuaternion(Quaternion quaterion, float x, float y, float z, float w)
        {
            quaterion.X = x;
            quaterion.Y = y;
            quaterion.Z = z;
            quaterion.W = w;
            return quaterion;
        }

        void EquipMainHand()
        {
            if (Gear[0].ID == "0" || (Sheathe && (Gear[0].Sheath == 0 || Gear[0].Sheath == 7)))
            {
                components[0].Initialize();
            }
            else
            {
                int attachment = Sheathe ? WoWHelper.SheatheAttachment(Gear[0].Sheath, false) : 1;
                ModelBone bone = bones[FindAttachment(attachment).bone];
                position = SetVector3D(position, bone.Position.x, bone.Position.y, bone.Position.z);
                rotation = SetQuaternion(rotation, bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                rotation = Sheathe ? rotation * WoWHelper.SheatheRotation(Gear[0].Sheath, false) : rotation;
                scale = SetVector3D(scale, bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if (Gear[0].ID != components[0].ID)
                {
                    components[0].Initialize(Gear[0].ID, Gear[0].Models.Left.Replace(".mdx", ".xml"), Gear[0].Textures.Left, objectComponentsPath + @"Weapon\", position, rotation, scale);
                }
                else
                {
                    components[0].Modify(position, rotation, scale);
                }
            }
        }

        void EquipOffHand()
        {
            if (Gear[1].ID == "0" || (Sheathe && (Gear[1].Sheath == 0 || Gear[1].Sheath == 7)))
            {
                components[1].Initialize();
            }
            else
            {
                int attachment = Sheathe ? WoWHelper.SheatheAttachment(Gear[1].Sheath, true) : Gear[1].Type == "Shield" ? 0 : 2;
                ModelBone bone = bones[FindAttachment(attachment).bone];
                string type = Gear[1].Type == "Shield" ? @"Shield\" : @"Weapon\";
                position = SetVector3D(position, bone.Position.x, bone.Position.y, bone.Position.z);
                rotation = SetQuaternion(rotation, bone.Rotation.x, bone.Rotation.y, bone.Rotation.z, bone.Rotation.w);
                rotation = Sheathe ? rotation * WoWHelper.SheatheRotation(Gear[1].Sheath, true) : rotation;
                scale = SetVector3D(scale, bone.Scale.x, bone.Scale.y, bone.Scale.z);
                if (Gear[1].ID != components[1].ID)
                {
                    components[1].Initialize(Gear[1].ID, Gear[1].Models.Left.Replace(".mdx", ".xml"), Gear[1].Textures.Left, objectComponentsPath + type, position, rotation, scale);
                }
                else
                {
                    components[1].Modify(position, rotation, scale);
                }
            }
        }

        ModelAttachment FindAttachment(int id)
        {
            foreach (ModelAttachment attachment in model.Attachments)
            {
                if (attachment.id == id)
                {
                    return attachment;
                }
            }
            return null;
        }

        public void Render(OpenGL gl, float characterRotation)
        {
            EquipGear();
            base.Render(gl, characterRotation);
            foreach (ObjectComponent component in components)
            {
                if (!component.Empty)
                {
                    component.Render(gl, characterRotation);
                }
            }
        }
    }
}

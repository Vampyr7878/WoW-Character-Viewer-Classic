using SharpGL;
using System.Linq;

namespace WoW_Character_Viewer_Classic.Models
{
    public class Mount : Creature
    {
        string id;

        public Mount()
            : base()
        {
            Empty = true;
        }

        public string ID { get { return id; } }

        public bool Empty { get; set; }

        public override void Initialize()
        {
            Empty = true;
            id = null;
            id = "0";
        }

        public void Initialize(string id, string file, string texture1, string texture2, string texture3, string path)
        {
            this.id = id;
            base.Initialize(file, texture1, texture2, texture3, path);
            Empty = false;
        }

        public ModelBone GetAttachment()
        {
            return (from attachment in model.Attachments where attachment.id == 0 select model.Bones[attachment.bone]).FirstOrDefault();
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
                if (model.Name.Contains("Kodo"))
                {
                    gl.Scale(0.5f, 0.5f, 0.5f);
                }
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
            gl.PushMatrix();
            if (model.Name.Contains("Kodo"))
            {
                gl.Scale(0.5f, 0.5f, 0.5f);
            }
            int layers = CountTextures(geoset);
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
    }
}

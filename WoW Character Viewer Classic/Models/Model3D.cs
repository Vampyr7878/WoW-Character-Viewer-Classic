using SharpGL;
using SharpGL.SceneGraph.Assets;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace WoW_Character_Viewer_Classic.Models
{
    public abstract class Model3D
    {
        protected Model model;
        protected ModelVertex[] vertices;
        protected int[] indices;
        protected int[] triangles;
        protected ModelViewGeoset[] geosets;
        protected List<int> billboards;
        protected Texture[] textures;
        protected string texturesPath;

        public Model3D()
        {
            billboards = new List<int>();
        }

        protected Bitmap LoadBitmap(string file)
        {
            if (File.Exists(file))
            {
                Bitmap bitmap;
                using (StreamReader reader = new StreamReader(file))
                {
                    bitmap = new Bitmap(reader.BaseStream);
                }
                return bitmap;
            }
            return null;
        }

        protected void SetColor(OpenGL gl, int geoset)
        {
            int color = FindColor(geoset);
            int transparency = FindTransparency(geoset);
            if (color == -1)
            {
                gl.Color(1f, 1f, 1f, model.Transparencies[transparency]);
            }
            else
            {
                gl.Color(model.Colors[color].red, model.Colors[color].green, model.Colors[color].blue, model.Colors[color].alpha * model.Transparencies[transparency]);
            }
        }

        protected int FindColor(int geoset)
        {
            foreach (ModelViewTexture viewTexture in model.View.Textures)
            {
                if (viewTexture.geoset == geoset)
                {
                    return viewTexture.color;
                }
            }
            return -1;
        }

        protected int FindTransparency(int geoset)
        {
            foreach (ModelViewTexture viewTexture in model.View.Textures)
            {
                if (viewTexture.geoset == geoset)
                {
                    return viewTexture.transparency;
                }
            }
            return -1;
        }

        protected void Blend(OpenGL gl, int geoset, int layer)
        {
            switch (model.Blending[FindBlend(geoset, layer)])
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

        protected int FindBlend(int geoset, int layer)
        {
            foreach (ModelViewTexture texture in model.View.Textures)
            {
                if (texture.geoset == geoset && texture.layer == layer)
                {
                    return texture.blend;
                }
            }
            return -1;
        }

        protected int FindTexture(int geoset, int layer)
        {
            foreach (ModelViewTexture texture in model.View.Textures)
            {
                if (texture.geoset == geoset && texture.layer == layer)
                {
                    return texture.texture;
                }
            }
            return -1;
        }

        public abstract void Initialize();

        protected abstract void MakeTextures(OpenGL gl);

        protected abstract void MakeTexture(OpenGL gl, int index);
    }
}

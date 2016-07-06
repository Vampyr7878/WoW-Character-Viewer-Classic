using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class ScourgeMale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Hair02,
            Hair03,
            Hair04,
            Hair05,
            Hair06,
            Hair07,
            Hair08,
            Hair09,
            Ears1,
            Ears2,
            Feature1,
            Feature2,
            Feature3,
            Style1,
            Back1,
            Wrist1,
            Sleeve2,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Sleeve1,
            Arms1,
            Cape5,
            Buttons5,
            Cape4,
            Buttons4,
            Cape3,
            Buttons3,
            Cape2,
            Buttons2,
            Cape1,
            Buttons1,
            Spine5,
            Spine4,
            Spine3,
            Spine2,
            Spine1,
            Bones1,
            Skirt2,
            Skirt1,
            Robe1,
            Boots2,
            Boots3,
            Boots5,
            Boots1,
            Boots4,
            Legs1,
            Tabard1,
            Glow1
        };

        List<Geosets> currentGeosets;

        public ScourgeMale() : base(@"Character\Scourge\Male\ScourgeMale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Glow1,
                Geosets.Ears1,
                Geosets.Feature2,
                Geosets.Back1,
                Geosets.Arms1,
                Geosets.Wrist1,
                Geosets.Bones1,
                Geosets.Legs1,
                Geosets.Boots1
            };
        }

        public override void Render(OpenGL gl)
        {
            MakeTextures(gl);
            gl.Color(1f, 1f, 1f);
            foreach(Geosets geoset in currentGeosets)
            {
                if(billboards.Contains(vertices[indices[triangles[geosets[(int)geoset].triangle]]].Bones[0].index))
                {
                    RenderBillboard(gl, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
                else
                {
                    RenderGeoset(gl, (int)geoset, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
            }
            gl.Color(1f, 0f, 0f);
            RenderSkeleton(gl);
        }
    }
}

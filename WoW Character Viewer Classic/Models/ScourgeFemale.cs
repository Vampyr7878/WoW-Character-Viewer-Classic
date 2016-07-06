using System.Collections.Generic;
using SharpGL;

namespace WoW_Character_Viewer_Classic.Models
{
    class ScourgeFemale : Character
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
            Style1,
            Hair08,
            Hair09,
            Hair10,
            Ears1,
            Ears2,
            Arms1,
            Wrist4,
            Wrist3,
            Wrist5,
            Wrist2,
            Sleeve2,
            Wrist1,
            Sleeve1,
            Back1,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Buttons1,
            Buttons2,
            Buttons3,
            Buttons4,
            Buttons5,
            Bones1,
            Skirt2,
            Skirt1,
            Robe1,
            Legs1,
            Boots4,
            Boots3,
            Boots5,
            Boots2,
            Boots1,
            Tabard1,
            Glow1,
            Eyes1
        };

        List<Geosets> currentGeosets;

        public ScourgeFemale() : base(@"Character\Scourge\Female\ScourgeFemale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Glow1,
                Geosets.Ears1,
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
            gl.Color(1f, 1f, 1f);
            foreach(Geosets geoset in currentGeosets)
            {
                if(billboards.Contains(vertices[indices[triangles[geosets[(int)geoset].triangle]]].Bones[0].index))
                {
                    RenderBillboard(gl, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
                else
                {
                    RenderGeoset(gl, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
            }
            gl.Color(1f, 0f, 0f);
            RenderSkeleton(gl);
        }
    }
}

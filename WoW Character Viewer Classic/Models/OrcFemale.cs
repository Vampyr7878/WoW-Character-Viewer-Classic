using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class OrcFemale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Style1,
            Hair02,
            Style2,
            Style3,
            Hair03,
            Style4,
            Ears2,
            Ears1,
            Hair04,
            Style5,
            Hair05,
            Hair06,
            Hair07,
            Wrist1,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Buttons5,
            Buttons4,
            Back1,
            Buttons3,
            Buttons2,
            Buttons1,
            Tabard1,
            Robe1,
            Skirt2,
            Legs1,
            Skirt1,
            Boots1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees1,
            Knees2,
            Feature1,
            Feature2,
            Feature3,
            Feature4,
            Feature5,
            Feature6
        };

        List<Geosets> currentGeosets;

        public OrcFemale() : base(@"Character\Orc\Female\OrcFemale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 9;
            facesCount = 9;
        }

        public override void Render(OpenGL gl)
        {
            MakeTextures(gl);
            foreach(Geosets geoset in currentGeosets)
            {
                if(billboards.Contains(vertices[indices[triangles[geosets[(int)geoset].triangle]]].Bones[0].index))
                {
                    RenderBillboard(gl, (int)geoset, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
                else
                {
                    RenderGeoset(gl, (int)geoset, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
            }
            RenderSkeleton(gl);
        }
    }
}

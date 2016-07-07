using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class HumanFemale : Character
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
            Hair10,
            Ears2,
            Ears1,
            Style1,
            Hair11,
            Style2,
            Hair12,
            Hair13,
            Hair14,
            Hair15,
            Hair16,
            Hair17,
            Hair18,
            Hair19,
            Style3,
            Style4,
            Wrist1,
            Wrist2,
            Wrist3,
            Sleeve1,
            Sleeve2,
            Wrist5,
            Wrist4,
            Cape5,
            Cape4,
            Buttons5,
            Buttons4,
            Cape3,
            Buttons3,
            Cape2,
            Buttons2,
            Cape1,
            Buttons1,
            Back1,
            Robe1,
            Skirt2,
            Tabard1,
            Legs1,
            Boots5,
            Boots2,
            Boots1,
            Boots3,
            Boots4,
            Knees2,
            Knees1,
            Skirt1,
            Eyes1,
            Feature1,
            Feature2,
            Feature3,
            Feature4,
            Feature5,
            Feature6
        };

        List<Geosets> currentGeosets;

        public HumanFemale() : base(@"Character\Human\Female\HumanFemale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Style1,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 10;
            facesCount = 15;
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

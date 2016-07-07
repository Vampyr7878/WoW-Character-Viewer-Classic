using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class DwarfFemale : Character
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
            Hair11,
            Hair12,
            Hair13,
            Style1,
            Style2,
            Style3,
            Hair14,
            Wrist2,
            Wrist4,
            Wrist5,
            Wrist1,
            Wrist3,
            Sleeve1,
            Sleeve2,
            Back1,
            Cape5,
            Cape4,
            Buttons5,
            Cape3,
            Cape2,
            Buttons4,
            Cape1,
            Buttons3,
            Buttons2,
            Buttons1,
            Robe1,
            Legs1,
            Knees1,
            Boots2,
            Boots3,
            Boots5,
            Knees2,
            Skirt2,
            Skirt1,
            Tabard1,
            Feature1,
            Feature2,
            Feature3,
            Feature4,
            Feature5
        };

        List<Geosets> currentGeosets;

        public DwarfFemale() : base(@"Character\Dwarf\Female\DwarfFemale.xml")
        {
			currentGeosets = new List<Geosets>()
			{
			    Geosets.Body1,
                Geosets.Style1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1
			};
            skinsCount = 9;
            facesCount = 10;
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

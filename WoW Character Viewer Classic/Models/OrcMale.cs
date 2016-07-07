using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class OrcMale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Hair02,
            Feature1,
            Facial01,
            Facial02,
            Style1,
            Style2,
            Ears2,
            Ears1,
            Hair03,
            Hair04,
            Style3,
            Style4,
            Hair05,
            Hair06,
            Style5,
            Facial03,
            Facial04,
            Facial05,
            Feature2,
            Facial06,
            Feature3,
            Facial07,
            Facial08,
            Facial09,
            Feature4,
            Wrist1,
            Wrist4,
            Wrist3,
            Wrist5,
            Wrist2,
            Sleeve1,
            Sleeve2,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Back1,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1,
            Robe1,
            Skirt2,
            Skirt1,
            Tabard1,
            Legs1,
            Boots1,
            Boots3,
            Boots5,
            Boots2,
            Knees2,
            Knees1,
            Boots4
        };

        List<Geosets> currentGeosets;

        public OrcMale() : base(@"Character\Orc\Male\OrcMale.xml")
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

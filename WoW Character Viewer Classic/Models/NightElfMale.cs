﻿using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class NightElfMale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Hair02,
            Hair03,
            Hair04,
            Hair05,
            Facial01,
            Ears1,
            Facial02,
            Hair06,
            Hair07,
            Facial03,
            Facial04,
            Facial05,
            Facial06,
            Facial07,
            Facial08,
            Facial09,
            Facial10,
            Facial11,
            Facial12,
            Back1,
            Wrist4,
            Wrist5,
            Wrist1,
            Wrist2,
            Wrist3,
            Sleeve2,
            Sleeve1,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Legs1,
            Skirt1,
            Robe1,
            Skirt2,
            Tabard1,
            Knees1,
            Boots3,
            Boots5,
            Boots1,
            Botos2,
            Knees2,
            Boots4,
            Glow1
        };

        List<Geosets> currentGeosets;

        public NightElfMale() : base(@"Character\NightElf\Male\NightElfMale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1, 
                Geosets.Glow1,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
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
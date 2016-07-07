﻿using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class GnomeMale : Character
    {
        enum Geosets
        {
            Body1,
            Facial01,
            Facial02,
            Facial03,
            Ears1,
            Ears2,
            Facial04,
            Style1,
            Hair01,
            Style2,
            Facial05,
            Facial06,
            Facial07,
            Hair02,
            Style3,
            Hair03,
            Hair04,
            Style4,
            Hair05,
            Style5,
            Hair06,
            Style6,
            Wrist1,
            Wrist5,
            Wrist2,
            Wrist4,
            Sleeve2,
            Sleeve1,
            Wrist3,
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
            Back1,
            Robe1,
            Legs1,
            Knees2,
            Boots2,
            Boots3,
            Boots4,
            Boots5,
            Skirt1,
            Skirt2,
            Knees1,
            Tabard1
        };

        List<Geosets> currentGeosets;

        public GnomeMale() : base(@"Character\Gnome\Male\GnomeMale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Style1,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1
            };
            skinsCount = 5;
            facesCount = 7;
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

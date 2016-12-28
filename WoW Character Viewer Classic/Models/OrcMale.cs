using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class OrcMale : CharacterModel
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
            Skirt1,
            Doublet1,
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
        List<Geosets> list;

        public OrcMale()
            : base(@"Character\Orc\Male\OrcMale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1
            };
            list = new List<Geosets>();
            skinsCount = 9;
            facesCount = 9;
            hairName = "Hair Style: ";
            hairsCount = 7;
            colorName = "Hair Color: ";
            colorsCount = 8;
            facialName = "Facial Hair: ";
            facialsCount = 11;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Topknot",
                "Chonmage",
                "Crest",
                "Chonmage Long",
                "Braided",
                "Tail"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Clean",
                "Rough",
                "Groomed Beard",
                "Cropped Beard",
                "Wild Beard",
                "Thick Braid",
                "Twin Braids",
                "Chop Braids",
                "Thin Braid",
                "Chops",
                "Tufts"
            };
        }

        protected override string GetFacialUpper()
        {
            string facialUpper = "";
            switch (Facial)
            {
                case 1:
                    facialUpper = "00";
                    break;
                case 2:
                    facialUpper = "02";
                    break;
                case 3:
                case 4:
                    facialUpper = "01";
                    break;
                case 5:
                case 6:
                case 8:
                    facialUpper = "05";
                    break;
                case 7:
                case 10:
                    facialUpper = "03";
                    break;
                case 9:
                    facialUpper = "04";
                    break;
            }
            return facialUpper + "_" + Number(Color);
        }

        protected override string GetFacialLower()
        {
            string facialLower = "";
            switch (Facial)
            {
                case 1:
                    facialLower = "00";
                    break;
                case 2:
                    facialLower = "02";
                    break;
                case 3:
                case 4:
                    facialLower = "01";
                    break;
                case 5:
                case 6:
                case 8:
                    facialLower = "05";
                    break;
                case 7:
                case 10:
                    facialLower = "03";
                    break;
                case 9:
                    facialLower = "04";
                    break;
            }
            return facialLower + "_" + Number(Color);
        }

        protected override string GetScalpUpper()
        {
            string scalpUpper = "";
            switch (Hair)
            {
                case 1:
                case 2:
                    scalpUpper = "00";
                    break;
                case 3:
                    scalpUpper = "01";
                    break;
                case 4:
                    scalpUpper = "02";
                    break;
                case 5:
                    scalpUpper = "03";
                    break;
                case 6:
                    scalpUpper = "04";
                    break;
            }
            return scalpUpper + "_" + Number(Color);
        }

        protected override string GetScalpLower()
        {
            string scalpLower = "";
            switch (Hair)
            {
                case 1:
                case 2:
                    scalpLower = "00";
                    break;
                case 3:
                    scalpLower = "01";
                    break;
                case 4:
                    scalpLower = "02";
                    break;
                case 5:
                    scalpLower = "03";
                    break;
                case 6:
                    scalpLower = "04";
                    break;
            }
            return scalpLower + "_" + Number(Color);
        }

        protected override string GetHairTexture()
        {
            return "00";
        }

        protected override void HairGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
            list.Clear();
            switch (Hair)
            {
                case 1:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style4,
                        Geosets.Hair06
                    });
                    break;
                case 2:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style2,
                        Geosets.Hair05
                    });
                    break;
                case 3:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair03
                    });
                    break;
                case 4:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style3,
                        Geosets.Hair01
                    });
                    break;
                case 5:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style1,
                        Geosets.Hair02
                    });
                    break;
                case 6:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style5,
                        Geosets.Hair04
                    });
                    break;
            }
            currentGeosets.AddRange(list);
        }

        protected override void FacialGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Facial"));
            list.Clear();
            switch (Facial)
            {
                case 2:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Facial03
                    });
                    break;
                case 3:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Facial04
                    });
                    break;
                case 4:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Facial05
                    });
                    break;
                case 5:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature2,
                        Geosets.Facial09
                    });
                    break;
                case 6:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature4,
                        Geosets.Facial06
                    });
                    break;
                case 7:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature1,
                        Geosets.Facial01
                    });
                    break;
                case 8:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature3,
                        Geosets.Facial07
                    });
                    break;
                case 9:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Facial08
                    });
                    break;
                case 10:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Facial02
                    });
                    break;
            }
            currentGeosets.AddRange(list);
        }

        protected override void EquipCape()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Back"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Cape"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Buttons"));
            if (Gear[3].ID == "0")
            {
                currentGeosets.Add(Geosets.Back1);
            }
            else
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[3].Models.Cape));
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[3].Models.Cape.Replace("Cape", "Buttons")));
            }
        }

        protected override void EquipHands()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Wrist"));
            if (Gear[8].ID == "0")
            {
                currentGeosets.Add(Geosets.Wrist1);
            }
            else
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[8].Models.Wrist));
            }
            if (currentGeosets.Contains(Geosets.Wrist3))
            {
                currentGeosets.Add(Geosets.Wrist4);
            }
        }

        protected override void EquipFeet()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            if (Gear[11].ID == "0")
            {
                currentGeosets.Add(Geosets.Boots1);
            }
            else
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[11].Models.Boots));
            }
            if (currentGeosets.Contains(Geosets.Boots3))
            {
                currentGeosets.Add(Geosets.Boots4);
            }
        }

        protected override void EquipLegs()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Legs"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Robe"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
            if (Gear[10].ID != "0")
            {
                if (Gear[10].Models.Robe != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[10].Models.Robe));
                }
                if (currentGeosets.Contains(Geosets.Boots1) && Gear[10].Models.Knees != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[10].Models.Knees));
                }
            }
            if (!currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.Add(Geosets.Legs1);
            }
            else
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            }
        }

        protected override void EquipShirt()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            if (Gear[5].ID != "0")
            {
                if ((Gear[4].Textures == null || Gear[4].Textures.ArmLower == "") && currentGeosets.Contains(Geosets.Wrist1) && Gear[5].Models.Sleeve != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[5].Models.Sleeve));
                }
            }
        }

        protected override void EquipWrist()
        {
            if (Gear[7].ID != "0")
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            }
        }

        protected override void EquipChest()
        {
            if (Gear[5].Models == null || Gear[5].Models.Sleeve == "")
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            }
            if (Gear[4].ID != "0")
            {
                if (currentGeosets.Contains(Geosets.Wrist1) && Gear[4].Models.Sleeve != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Sleeve));
                }
                if (!currentGeosets.Contains(Geosets.Robe1) && Gear[4].Models.Robe != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Robe));
                }
            }
            if (currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Legs"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            }
        }

        protected override void EquipTabard()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Tabard"));
            if (Gear[6].ID != "0" && !currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.Add(Geosets.Tabard1);
            }
        }

        protected override void HideHair()
        {
            if (Gear[0].ID != "0" && Gear[0].Male.Hair[1] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
            }
        }

        protected override void HideFacial()
        {
            if (Gear[0].ID != "0" && Gear[0].Male.Beards[1] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Facial"));
            }
        }

        protected override void HideEars()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Ears"));
            if (Gear[0].ID != "0" && Gear[0].Male.Ears[1] == '1')
            {
                currentGeosets.Add(Geosets.Ears2);
            }
            else
            {
                currentGeosets.Add(Geosets.Ears1);
            }
        }

        public override void Render(OpenGL gl)
        {
            gl.PushMatrix();
            Prepare(gl);
            foreach (Geosets geoset in currentGeosets)
            {
                if (billboards.Contains(vertices[indices[triangles[geosets[(int)geoset].triangle]]].Bones[0].index))
                {
                    RenderBillboard(gl, (int)geoset, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
                else
                {
                    RenderGeoset(gl, (int)geoset, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
            }
            foreach (ObjectComponent component in components)
            {
                if (!component.Empty)
                {
                    component.Render(gl, Rotation);
                }
            }
            RenderSkeleton(gl);
            gl.PopMatrix();
            if (!mount.Empty)
            {
                mount.Render(gl, Rotation);
            }
        }
    }
}

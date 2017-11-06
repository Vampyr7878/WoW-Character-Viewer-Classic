using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class ScourgeMale : CharacterModel
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
            Skirt1,
            Doublet1,
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
        List<Geosets> list;

        public ScourgeMale()
            : base(@"Character\Scourge\Male\ScourgeMale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
                Geosets.Arms1,
                Geosets.Bones1
            };
            list = new List<Geosets>();
            skinsCount = 6;
            facesCount = 10;
            hairName = "Hair Style: ";
            hairsCount = 10;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Features: ";
            facialsCount = 17;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Mohawk",
                "Shaggy",
                "Wisps",
                "Spiked",
                "Wild",
                "Scholar",
                "Full",
                "Topknot",
                "Long"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Intact",
                "Rot-Kissed",
                "Strapped",
                "Strapped Slackjaw",
                "Strapped Drooler",
                "Rotting",
                "Rotting Slackjaw",
                "Rotting Drooler",
                "Bonejawed",
                "Jawsome",
                "Toothy",
                "Toothy Slackjaw",
                "Cheeky",
                "Cheeky Slackjaw",
                "Putrid",
                "Putrid Slackjaw",
                "Putrid Drooler"
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
                case 3:
                case 4:
                    facialUpper = "01";
                    break;
                case 5:
                case 6:
                case 7:
                    facialUpper = "02";
                    break;
                case 8:
                case 9:
                    facialUpper = "03";
                    break;
                case 10:
                case 11:
                    facialUpper = "04";
                    break;
                case 12:
                case 13:
                    facialUpper = "05";
                    break;
                case 14:
                case 15:
                case 16:
                    facialUpper = "06";
                    break;
            }
            return facialUpper + "_00";
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
                case 3:
                case 4:
                    facialLower = "01";
                    break;
                case 5:
                case 6:
                case 7:
                    facialLower = "02";
                    break;
                case 8:
                case 9:
                    facialLower = "03";
                    break;
                case 10:
                case 11:
                    facialLower = "04";
                    break;
                case 12:
                case 13:
                    facialLower = "05";
                    break;
                case 14:
                case 15:
                case 16:
                    facialLower = "06";
                    break;
            }
            return facialLower + "_00";
        }

        protected override string GetScalpUpper()
        {
            string scalpUpper = "";
            switch (Hair)
            {
                case 2:
                case 7:
                case 9:
                    scalpUpper = "00";
                    break;
                case 5:
                case 6:
                    scalpUpper = "01";
                    break;
            }
            return scalpUpper + "_" + Number(Color);
        }

        protected override string GetScalpLower()
        {
            string scalpLower = "";
            switch (Hair)
            {
                case 2:
                case 7:
                case 9:
                    scalpLower = "00";
                    break;
                case 5:
                case 6:
                    scalpLower = "01";
                    break;
            }
            return scalpLower + "_" + Number(Color);
        }

        protected override string GetHairTexture()
        {
            string hairTexture = "";
            switch (Hair)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 8:
                case 9:
                    hairTexture = "00";
                    break;
                case 7:
                    hairTexture = "01";
                    break;
            }
            return hairTexture;
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
                        Geosets.Hair09
                    });
                    break;
                case 2:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair05
                    });
                    break;
                case 3:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair02
                    });
                    break;
                case 4:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair06
                    });
                    break;
                case 5:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair07
                    });
                    break;
                case 6:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair03
                    });
                    break;
                case 7:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair08
                    });
                    break;
                case 8:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style1,
                        Geosets.Hair01
                    });
                    break;
                case 9:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair04
                    });
                    break;
            }
            currentGeosets.AddRange(list);
        }

        protected override void FacialGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Glow"));
            list.Clear();
            switch (Facial)
            {
                case 0:
                case 1:
                case 5:
                case 8:
                case 12:
                case 14:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature2,
                        Geosets.Glow1
                    });
                    break;
                case 6:
                case 9:
                case 13:
                case 15:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature3,
                        Geosets.Glow1
                    });
                    break;
                case 7:
                case 16:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature1,
                        Geosets.Glow1
                    });
                    break;
                case 2:
                case 10:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature2
                    });
                    break;
                case 3:
                case 11:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature3
                    });
                    break;
                case 4:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature1
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
            currentGeosets.RemoveAll(item => item.ToString().Contains("Spine"));
            if (Gear[3].ID == "0")
            {
                currentGeosets.Add(Geosets.Back1);
            }
            else
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[3].Models.Cape));
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[3].Models.Cape.Replace("Cape", "Buttons")));
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[3].Models.Cape.Replace("Cape", "Spine")));
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
            if (Gear[10].ID != "0" && Gear[10].Models.Robe != "")
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[10].Models.Robe));
            }
            if (!currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.Add(Geosets.Legs1);
            }
            else
            {
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
            if (Gear[0].ID != "0" && Gear[0].Male.Hair[4] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
            }
        }

        protected override void HideFacial()
        {
            if (Gear[0].ID != "0" && Gear[0].Male.Other[4] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
                currentGeosets.Add(Geosets.Feature2);
            }
        }

        protected override void HideEars()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Ears"));
            if (Gear[0].ID != "0" && Gear[0].Male.Ears[4] == '1')
            {
                currentGeosets.Add(Geosets.Ears2);
            }
            else
            {
                currentGeosets.Add(Geosets.Ears1);
            }
        }

        public override void BearForm(bool shapeshift)
        {
        }

        public override void AquaticForm(bool shapeshift)
        {
        }

        public override void CatForm(bool shapeshift)
        {
        }

        public override void TravelForm(bool shapeshift)
        {
        }

        public override void MoonkinForm(bool shapeshift)
        {
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
            gl.PopMatrix();
            if (!mount.Empty)
            {
                mount.Render(gl, Rotation);
            }
        }
    }
}

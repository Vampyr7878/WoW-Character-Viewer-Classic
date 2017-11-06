using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class HumanMale : CharacterModel
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
            Style1,
            Ears1,
            Ears2,
            Feature1,
            Feature2,
            Style2,
            Hair07,
            Hair08,
            Hair09,
            Style3,
            Style4,
            Style5,
            Feature3,
            Feature4,
            Hair10,
            Hair11,
            Feature5,
            Feature6,
            Hair12,
            Back1,
            Wrist1,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Cape5,
            Cape4,
            Cape3,
            Cape1,
            Cape2,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons1,
            Buttons2,
            Legs1,
            Doublet1,
            Skirt1,
            Tabard1,
            Robe1,
            Knees1,
            Boots1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees2
        };

        List<Geosets> currentGeosets;
        List<Geosets> list;

        public HumanMale()
            : base(@"Character\Human\Male\HumanMale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1
            };
            list = new List<Geosets>();
            skinsCount = 10;
            facesCount = 12;
            hairName = "Hair Style: ";
            hairsCount = 12;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Facial Hair: ";
            facialsCount = 9;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Peasant",
                "Soldier",
                "Monk",
                "Barbarian",
                "Dashing",
                "Loose",
                "Courtier",
                "Scholar",
                "Rogue",
                "Fabulous",
                "Samson"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Bearded",
                "Colonel",
                "Duelist",
                "Goatee",
                "Wizard",
                "Chops",
                "Van Dyke",
                "Mustachioed",
                "Clean"
            };
        }

        protected override string GetFacialUpper()
        {
            return Number(Facial) + "_" + Number(Color);
        }

        protected override string GetFacialLower()
        {
            return Number(Facial) + "_" + Number(Color);
        }

        protected override string GetScalpUpper()
        {
            string scalpUpper = "";
            switch (Hair)
            {
                case 1:
                case 2:
                case 4:
                case 5:
                case 6:
                case 7:
                case 9:
                case 10:
                case 11:
                    scalpUpper = "02";
                    break;
                case 3:
                case 8:
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
                case 1:
                case 2:
                case 4:
                case 5:
                case 6:
                case 7:
                case 9:
                case 10:
                case 11:
                    scalpLower = "02";
                    break;
                case 3:
                case 8:
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
                case 4:
                case 5:
                case 8:
                case 10:
                    hairTexture = "03";
                    break;
                case 2:
                case 3:
                case 6:
                case 7:
                case 9:
                case 11:
                    hairTexture = "02";
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
                case 0:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style2
                    });
                    break;
                case 1:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair07
                    });
                    break;
                case 2:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair08
                    });
                    break;
                case 3:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style5,
                        Geosets.Hair09
                    });
                    break;
                case 4:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style1,
                        Geosets.Hair06
                    });
                    break;
                case 5:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair04
                    });
                    break;
                case 6:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair01
                    });
                    break;
                case 7:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair02
                    });
                    break;
                case 8:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style3,
                        Geosets.Hair05
                    });
                    break;
                case 9:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Style4,
                        Geosets.Hair10
                    });
                    break;
                case 10:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair12
                    });
                    break;
                case 11:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Hair03
                    });
                    break;
            }
            currentGeosets.AddRange(list);
        }

        protected override void FacialGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
            list.Clear();
            switch (Facial)
            {
                case 0:
                case 8:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature2,
                        Geosets.Feature4,
                        Geosets.Feature6
                    });
                    break;
                case 1:
                case 2:
                case 7:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature1,
                        Geosets.Feature4,
                        Geosets.Feature6
                    });
                    break;
                case 3:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature2,
                        Geosets.Feature3,
                        Geosets.Feature5
                    });
                    break;
                case 4:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature1,
                        Geosets.Feature3,
                        Geosets.Feature5
                    });
                    break;
                case 5:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature1,
                        Geosets.Feature3,
                        Geosets.Feature6
                    });
                    break;
                case 6:
                    list.AddRange(new List<Geosets>
                    {
                        Geosets.Feature1,
                        Geosets.Feature4,
                        Geosets.Feature5
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
            if (Gear[0].ID != "0" && Gear[0].Male.Hair[0] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
                currentGeosets.Add(Geosets.Style2);
            }
        }

        protected override void HideFacial()
        {
            if (Gear[0].ID != "0" && Gear[0].Male.Beards[0] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
                currentGeosets.Add(Geosets.Feature2);
                currentGeosets.Add(Geosets.Feature4);
                currentGeosets.Add(Geosets.Feature6);
            }
        }

        protected override void HideEars()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Ears"));
            if (Gear[0].ID != "0" && Gear[0].Male.Ears[0] == '1')
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

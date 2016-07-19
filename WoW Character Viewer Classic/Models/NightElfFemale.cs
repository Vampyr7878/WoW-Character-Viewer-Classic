using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class NightElfFemale : Character
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
            Ears1,
            Facial01,
            Back1,
            Wrist1,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
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
            Legs1,
            Skirt1,
            Doublet1,
            Robe1,
            Tabard1,
            Knees1,
            Boots1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees2,
            Glow1
        };

        List<Geosets> currentGeosets;

        public NightElfFemale() : base(@"Character\NightElf\Female\NightElfFemale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
                Geosets.Glow1
            };
            skinsCount = 9;
            facesCount = 9;
            hairName = "Hair Style: ";
            hairsCount = 7;
            colorName = "Hair Color: ";
            colorsCount = 8;
            facialName = "Markings: ";
            facialsCount = 10;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Long",
                "Loose Tail",
                "Short",
                "High Tail",
                "Braided Tails",
                "Short Tail",
                "Braided Tail"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Bear",
                "Blades",
                "Crane",
                "Leaf",
                "Claws",
                "Wings",
                "Serpent",
                "Owl",
                "Shadow",
                "No Tattoo",
            };
        }

        protected override string GetFacialUpper()
        {
            return Number(Facial + 4);
        }

        protected override string GetFacialLower()
        {
            return Number(Facial + 4);
        }

        protected override string GetScalpUpper()
        {
            return "01";
        }

        protected override string GetScalpLower()
        {
            return "01";
        }

        protected override string GetHairTexture()
        {
            return "00";
        }

        protected override void HairGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
            List<Geosets> list;
            switch(Hair)
            {
                case 0:
                    list = new List<Geosets>
                    {
                        Geosets.Hair01
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Hair07
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Hair03
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Hair06
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Hair05
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Hair04
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Hair02
                    };
                    break;
                default:
                    list = new List<Geosets>();
                    break;
            }
            currentGeosets.AddRange(list);
            list = null;
        }

        protected override void FacialGeosets()
        {

        }

        protected override void EquipCape()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Back"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Cape"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Buttons"));
            if(Gear[3].ID == "0")
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
            if(Gear[8].ID == "0")
            {
                currentGeosets.Add(Geosets.Wrist1);
            }
            else
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[8].Models.Wrist));
            }
            if(currentGeosets.Contains(Geosets.Wrist3))
            {
                currentGeosets.Add(Geosets.Wrist4);
            }
        }

        protected override void EquipFeet()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            if(Gear[11].ID == "0")
            {
                currentGeosets.Add(Geosets.Boots1);
            }
            else
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[11].Models.Boots));
            }
            if(currentGeosets.Contains(Geosets.Boots3))
            {
                currentGeosets.Add(Geosets.Boots4);
            }
        }

        protected override void EquipLegs()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Legs"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Robe"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
            if(Gear[10].ID != "0")
            {
                if(Gear[10].Models.Robe != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[10].Models.Robe));
                }
                if(currentGeosets.Contains(Geosets.Boots1) && Gear[10].Models.Knees != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[10].Models.Knees));
                }
            }
            if(!currentGeosets.Contains(Geosets.Robe1))
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
            if(Gear[5].ID != "0")
            {
                if((Gear[4].Textures == null || Gear[4].Textures.ArmLower == "") && currentGeosets.Contains(Geosets.Wrist1) && Gear[5].Models.Sleeve != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[5].Models.Sleeve));
                }
            }
        }

        protected override void EquipWrist()
        {
            if(Gear[7].ID != "0")
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            }
        }

        protected override void EquipChest()
        {
            if(Gear[5].Models == null || Gear[5].Models.Sleeve == "")
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            }
            if(Gear[4].ID != "0")
            {
                if(currentGeosets.Contains(Geosets.Wrist1) && Gear[4].Models.Sleeve != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Sleeve));
                }
                if(!currentGeosets.Contains(Geosets.Robe1) && Gear[4].Models.Robe != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Robe));
                }
            }
            if(currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Legs"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            }
        }

        protected override void EquipTabard()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Tabard"));
            if(Gear[6].ID != "0" && !currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.Add(Geosets.Tabard1);
            }
        }

        protected override void HideHair()
        {
            if(Gear[0].ID != "0" && Gear[0].Female.Hair[3] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
            }
        }

        protected override void HideFacial()
        {
        }

        protected override void HideEars()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Ears"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Facial"));
            if(Gear[0].ID == "0" || Gear[0].Female.Ears[3] == '0')
            {
                currentGeosets.Add(Geosets.Ears1);
                currentGeosets.Add(Geosets.Facial01);
            }
        }

        public override void Render(OpenGL gl)
        {
            Prepare(gl);
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
            foreach(ObjectComponent component in components)
            {
                if(!component.Empty)
                {
                    component.Render(gl, Rotation);
                }
            }
            RenderSkeleton(gl);
        }

        public new void Dispose()
        {
            base.Dispose();
            currentGeosets = null;
        }
    }
}

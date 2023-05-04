

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedPancakes : CustomItemGroup<AmericanBreakfastItemGroupView>
    {
        public override string UniqueNameID => "PlatedPancakes";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfast");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.Large;
        public override Item DisposesTo => Refs.Plate;
        public override Item DirtiesTo => Refs.DirtyPlate;
        public override bool CanContainSide => true;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Plate
                }
            },
            new ItemSet()
            {
                Max = 3,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Pancake,
                    Refs.Pancake,
                    Refs.Pancake
                }
            },
            new ItemSet()
            {
                Max = 2,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    //Refs.Pancake,
                    //Refs.Syrup,
                    Refs.BaconPortion,
                    Refs.ButterSlice
                }
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pancake = Prefab.GetChild("Pancakes");
            var plate = Prefab.GetChild("Plate/Plate.001");

            //Visuals

            pancake.ApplyMaterialToChildren("Pancake", "Raw Pastry", "Onion");

            pancake.GetChild("Top Pancake").ApplyMaterialToChild("Butter - Slice.002", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Middle Pancake").ApplyMaterialToChild("Butter - Slice.001", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Bottom Pancake").ApplyMaterialToChild("Butter - Slice", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);

            Prefab.ApplyMaterialToChild("Bacon Portion", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name);

            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");

            Prefab.GetChild("Syrup").ApplyMaterialToChild("Plane.002", "Cooked Batter");

            // Scrambies
            /*var scrambies = Prefab.GetChild("ScrambledEggs");
            scrambies.GetChild("Plate.002/Plate.003/Cylinder.001").ApplyMaterial("Plate", "Plate - Ring");
            scrambies.ApplyMaterialToChild("Scrambled Eggs.001", "Egg - Yolk", "Plastic - Orange");*/


            Prefab.GetComponent<AmericanBreakfastItemGroupView>()?.Setup(Prefab);
        }
    }


    public class AmericanBreakfastItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plate/Plate.001/Cylinder"),
                    Item = Refs.Plate,
                },
                new()
                {
                    Item = Refs.Pancake,
                    Objects = new List<GameObject>()
                    {
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Bottom Pancake"),
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Middle Pancake"),
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Top Pancake"),
                    }
                },
                new()
                {
                    Item = Refs.ButterSlice,
                    Objects = new List<GameObject>()
                    {
                        // Pancake
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Bottom Pancake/Butter - Slice"),
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Middle Pancake/Butter - Slice.001"),
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Top Pancake/Butter - Slice.002"),
                        // Waffle
                        GameObjectUtils.GetChildObject(prefab, "Waffle/Butter - Slice"),
                    },
                    DrawAll = true
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Syrup"),
                    Item = Refs.Syrup
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bacon Portion"),
                    Item = Refs.BaconPortion
                },
                // Waffle
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Waffle"),
                    Item = Refs.Waffle,
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "drumstick"),
                    Item = Refs.CookedDrumstick
                }
            };

            ComponentLabels = new()
            {
                new ()
                {
                    Text = "P",
                    Item = Refs.Pancake
                },
                new ()
                {
                    Text = "W",
                    Item = Refs.Waffle
                },
                new ()
                {
                    Text = "S",
                    Item = Refs.Syrup
                },
                new ()
                {
                    Text = "Bu",
                    Item = Refs.ButterSlice
                },
                new ()
                {
                    Text = "Chi",
                    Item = Refs.CookedDrumstick
                },
                new ()
                {
                    Text = "Ba",
                    Item = Refs.BaconPortion
                }
            };
        }
    }
}


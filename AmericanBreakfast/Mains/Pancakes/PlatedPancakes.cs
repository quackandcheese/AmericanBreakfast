using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static KitchenData.ItemGroup;
using KitchenAmericanBreakfast.Utils;
using IngredientLib.Util;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedPancakes : CustomItemGroup<PlatedPancakesItemGroupView>
    {
        public override string UniqueNameID => "PlatedPancakes";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Pancakes");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
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
                Max = 3,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    Refs.Syrup,
                    Refs.Bacon,
                    Refs.ButterSlice
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pancake = Prefab.GetChild("Pancakes");
            var plate = Prefab.GetChildFromPath("Plate/Plate.001");

            //Visuals

            pancake.ApplyMaterialToChildren("Pancake", "Raw Pastry", "Onion");

            pancake.GetChild("Top Pancake").ApplyMaterialToChild("Butter - Slice.002", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Middle Pancake").ApplyMaterialToChild("Butter - Slice.001", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Bottom Pancake").ApplyMaterialToChild("Butter - Slice", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);

            Prefab.ApplyMaterialToChild("Bacon", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name);

            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");

            Prefab.GetChild("Syrup").ApplyMaterialToChild("Plane.002", "Cooked Batter");


            Prefab.GetComponent<PlatedPancakesItemGroupView>()?.Setup(Prefab);
        }
    }


    public class PlatedPancakesItemGroupView : ItemGroupView
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
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Bottom Pancake/Butter - Slice"),
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Middle Pancake/Butter - Slice.001"),
                        GameObjectUtils.GetChildObject(prefab, "Pancakes/Top Pancake/Butter - Slice.002"),
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
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Bacon"),
                    Item = Refs.Bacon
                }
            };
        }
    }
}


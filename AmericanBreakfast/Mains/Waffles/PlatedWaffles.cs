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
    class PlatedWaffles : CustomItemGroup<AmericanBreakfastItemGroupView>
    {
        public override string UniqueNameID => "PlatedWaffles";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfast");
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
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.Waffle
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
                    Refs.CookedDrumstick,
                    Refs.ButterSlice
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {

            //Visuals

            Prefab.ApplyMaterialToChild("Waffle", "Onion", "Cooked Batter", "Bread - Cooked");

            Prefab.GetChild("Waffle").ApplyMaterialToChild("Butter - Slice", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);

            Prefab.ApplyMaterialToChild("drumstick", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Cooked Drumstick\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Cooked Drumstick Bone\""].name);


            Prefab.GetComponent<AmericanBreakfastItemGroupView>()?.Setup(Prefab);
        }
    }
}

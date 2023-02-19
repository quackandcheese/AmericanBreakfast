using KitchenLib.Colorblind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class TriplePlatedPancakes : CustomItemGroup<AmericanBreakfastItemGroupView>
    {
        public override string UniqueNameID => "TriplePlatedPancakes";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfast");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override ItemValue ItemValue => ItemValue.Medium;
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
                    //Refs.Pancake,
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

            // Scrambies
            /*var scrambies = Prefab.GetChild("ScrambledEggs");
            scrambies.GetChildFromPath("Plate.002/Plate.003/Cylinder.001").ApplyMaterial("Plate", "Plate - Ring");
            scrambies.ApplyMaterialToChild("Scrambled Eggs.001", "Egg - Yolk", "Plastic - Orange");*/


            Prefab.GetComponent<AmericanBreakfastItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
    }
}

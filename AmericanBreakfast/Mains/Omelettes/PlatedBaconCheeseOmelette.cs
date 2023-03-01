using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class PlatedBaconCheeseOmelette : CustomItemGroup<PlatedOmelettesItemGroupView>
    {
        public override string UniqueNameID => "Plated Bacon Cheese Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Plated Omelette");
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
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.BaconCheeseOmelette
                }
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            /*var plate = Prefab.GetChildFromPath("Plate/Plate");

            //Bacon Cheese
            var bcOmelette = Prefab.GetChild("Bacon Cheese Omelette");
            var baconCheese = bcOmelette.GetChildFromPath("Bacon Cheese");

            baconCheese.ApplyMaterialToChild("Bacon Portion.002", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name); ;
            baconCheese.ApplyMaterialToChild("Cheese", "Cheese - Default");

            bcOmelette.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");

            //Plate
            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");


            Prefab.GetComponent<PlatedOmelettesItemGroupView>()?.Setup(Prefab);

            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }*/
        }
    }
}


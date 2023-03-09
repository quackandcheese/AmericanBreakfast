using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class BaconCheeseOmelette : CustomItem
    {
        public override string UniqueNameID => "Bacon Cheese Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Bacon Cheese Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override string ColourBlindTag => "BaCh";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var baconCheese = Prefab.GetChildFromPath("Bacon Cheese");

            baconCheese.ApplyMaterialToChild("Bacon Portion.002", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name); ;
            baconCheese.ApplyMaterialToChild("Cheese", "Cheese - Default");

            Prefab.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class TomatoSpinachOmelette : CustomItem
    {
        public override string UniqueNameID => "Tomato Spinach Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Tomato Spinach Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override string ColourBlindTag => "ToSp";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var tomato = Prefab.GetChild("Tomato - Chopped/Tomato Sliced");

            Prefab.ApplyMaterialToChild("Spinaches", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Spinach\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Spinach Stem\""].name);
            tomato.ApplyMaterialToChild("Liquid", "Tomato Flesh");
            tomato.ApplyMaterialToChild("Liquid.001", "Tomato Flesh 2");
            tomato.ApplyMaterialToChild("Skin", "Tomato");

            Prefab.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");
        }
    }
}

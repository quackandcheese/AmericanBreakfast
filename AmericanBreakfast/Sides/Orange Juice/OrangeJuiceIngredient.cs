using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Sides
{
    class OrangeJuiceIngredient : CustomItem
    {
        public override string UniqueNameID => "Orange Juice Ingredient";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Orange Juice Ingredient");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Measuring Cup", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Glass\""].name);
            Prefab.ApplyMaterialToChild("Juice", "Plastic - Orange");
        }
    }
}

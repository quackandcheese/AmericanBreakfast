using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class BaconPortion : CustomItem
    {
        public override string UniqueNameID => "BaconPortion";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Bacon Portion");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Bacon Portion", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name);
        }
    }
}

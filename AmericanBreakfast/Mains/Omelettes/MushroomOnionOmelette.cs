using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class MushroomOnionOmelette : CustomItem
    {
        public override string UniqueNameID => "Mushroom Onion Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Mushroom Onion Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override string ColourBlindTag => "MuO";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("mushroomHalf.016", "Mushroom Dark", "Mushroom Light");

            Prefab.GetChild("Onions").ApplyMaterialToChildren("Circle", "Onion - Flesh", "Onion");

            Prefab.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");
        }
    }
}

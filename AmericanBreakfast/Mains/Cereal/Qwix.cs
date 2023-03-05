using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class Qwix : CustomItem
    {
        public override string UniqueNameID => "Qwix";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Qwix");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Refs.CerealProvider;
        public override string ColourBlindTag => "Tr";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetChild("Bowl").ApplyMaterialToChild("Small Bowl.001", "Plate");
            Prefab.ApplyMaterialToChild("Qwix", "Strawberry", "Egg - Yolk", "Lettuce", "Sea");
        }
    } 
}

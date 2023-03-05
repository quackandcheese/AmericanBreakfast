using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class Cornflakes : CustomItem
    {
        public override string UniqueNameID => "Cornflakes";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cornflakes");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Refs.CerealProvider;
        public override string ColourBlindTag => "Co";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetChild("Bowl").ApplyMaterialToChild("Small Bowl.001", "Plate");
            Prefab.GetChild("Cornflakes").ApplyMaterialToChildren("Cornflakes", "Sweetcorn - Cooked");
        }
    }
}

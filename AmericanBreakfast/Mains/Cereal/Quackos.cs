using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class Quackos : CustomItem
    {
        public override string UniqueNameID => "Quackos";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Quackos");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Refs.CerealProvider;
        public override string ColourBlindTag => "Ch";

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetChild("Bowl").ApplyMaterialToChild("Small Bowl.001", "Plate");
            Prefab.GetChild("Quackos").ApplyMaterialToChildren("Quackos", "Sack");
        }
    }
}

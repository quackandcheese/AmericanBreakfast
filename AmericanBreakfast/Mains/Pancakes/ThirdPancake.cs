using KitchenLib.Colorblind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class ThirdPancake : CustomItemGroup
    {
        public override string UniqueNameID => "ThirdPancake";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Pancake");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 5.5f,
                Process = Refs.Cook,
                IsBad = true,
                Result = Refs.Burnt
            }
        };

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.Pancake
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Pancake.001", "Raw Pastry", "Onion");
        }
    }
}

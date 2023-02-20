using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Sides
{
    class HashBrownsWokCooked : CustomItem
    {
        public override string UniqueNameID => "HashBrownsWokCooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("HashBrownsWokCooked");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Wok;
        public override Item SplitSubItem => Refs.HashBrowns;
        public override int SplitCount => 1;
        public override float SplitSpeed => 1.0f;
        public override List<Item> SplitDepletedItems => new() { Refs.Wok };


        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 10,
                Process = Refs.Cook,
                IsBad = true,
                Result = Refs.BurnedWok
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var wok = Prefab.GetChild("Wok");

            wok.ApplyMaterialToChild("Cylinder", "Metal Black");
            wok.ApplyMaterialToChild("Cylinder.003", "Wood 5 - Grey");

            Prefab.ApplyMaterialToChild("Hash Browns.001", "Dumplings Cooked", "Dumplings Burns");
        }
    }
}

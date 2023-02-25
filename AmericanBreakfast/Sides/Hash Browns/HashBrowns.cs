using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Sides
{
    class HashBrowns : CustomItem
    {
        public override string UniqueNameID => "HashBrowns";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("HashBrowns");
        public override GameObject SidePrefab => Mod.Bundle.LoadAsset<GameObject>("HashBrownsSide");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideMedium;
        public override bool IsMergeableSide => true;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 8,
                Process = Refs.CookWaffle,
                IsBad = true,
                Result = Refs.Burnt
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetChildFromPath("Plate.002/Plate.003/Cylinder.001").ApplyMaterial("Plate", "Plate - Ring");
            Prefab.ApplyMaterialToChild("Hash Browns.002", "Dumplings Cooked", "Dumplings Burns");

            SidePrefab.ApplyMaterialToChild("Hash Browns.002", "Dumplings Cooked", "Dumplings Burns");
        }
    }
}

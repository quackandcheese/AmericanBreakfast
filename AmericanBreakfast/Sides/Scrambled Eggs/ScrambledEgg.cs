using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Sides
{
    class ScrambledEgg : CustomItem
    {
        public override string UniqueNameID => "ScrambledEgg";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ScrambledEggs");
        public override GameObject SidePrefab => Mod.Bundle.LoadAsset<GameObject>("ScrambledEggsSide");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideMedium;
        public override bool IsMergeableSide => true;
        

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetChildFromPath("Plate.002/Plate.003/Cylinder.001").ApplyMaterial("Plate", "Plate - Ring");
            Prefab.ApplyMaterialToChild("Scrambled Eggs.001", "Egg - Yolk", "Cooked Pastry");

            SidePrefab.ApplyMaterialToChild("Scrambled Eggs.001", "Egg - Yolk", "Cooked Pastry");
        }
    }
}

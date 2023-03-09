using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class CookedQuiche : CustomItem
    {
        public override string UniqueNameID => "Cooked Quiche";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked Quiche");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 20f,
                Process = Refs.Cook,
                IsBad = true,
                Result = Refs.Burnt
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            for (int i = 0; i <= 3; i++)
            {
                MaterialUtils.ApplyMaterial(Prefab, $"Slice {i + 1}/Filling", new Material[] { MaterialUtils.GetExistingMaterial("Egg - Yolk") });
                MaterialUtils.ApplyMaterial(Prefab, $"Slice {i + 1}/Slice", new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") });
            }

            Prefab.ApplyMaterialToChild("Herbs", "Lettuce");
        }
    }
}

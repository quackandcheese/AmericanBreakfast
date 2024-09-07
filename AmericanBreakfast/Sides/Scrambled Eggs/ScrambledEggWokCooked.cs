using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Sides
{
    public class ScrambledEggWokCookedItemView : ObjectsSplittableView
    {
        internal void Setup(GameObject prefab)
        {
            var fObjects = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
            fObjects.SetValue(this, new List<GameObject>()
            { 
                prefab.GetChild("Slice1"),
                prefab.GetChild("Slice2"),
                prefab.GetChild("Slice3")
            });
        }
    }

    class ScrambledEggWokCooked : CustomItem
    {
        public override string UniqueNameID => "ScrambledEggWokCooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ScrambledEggWokCooked");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Item DisposesTo => Refs.Wok;
        public override Item SplitSubItem => Refs.ScrambledEgg;
        public override int SplitCount => 3;
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

            Prefab.ApplyMaterialToChild("Slice1", "Egg - Yolk", "Cooked Pastry");
            Prefab.ApplyMaterialToChild("Slice2", "Egg - Yolk", "Cooked Pastry");
            Prefab.ApplyMaterialToChild("Slice3", "Egg - Yolk", "Cooked Pastry");

            if (!Prefab.HasComponent<ScrambledEggWokCookedItemView>())
            {
                var view = Prefab.AddComponent<ScrambledEggWokCookedItemView>();
                view.Setup(Prefab);
            }
        }
    }
}

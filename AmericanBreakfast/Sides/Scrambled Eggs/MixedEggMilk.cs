namespace KitchenAmericanBreakfast.Sides
{
    class MixedEggMilk : CustomItemGroup<MixedEggItemGroupView>
    {
        public override string UniqueNameID => "MixedEggMilk";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MixedEgg");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override string ColourBlindTag => "Egg";
        public override bool AutoCollapsing => true;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.CrackedEgg
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.SplitMilk
                }
            }
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 2f,
                Process = Refs.Cook,
                Result = Refs.CookedOmelette
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Cylinder.002", "Metal Dark");
            Prefab.ApplyMaterialToChild("Plane", "Egg - Yolk");

            Prefab.GetComponent<MixedEggItemGroupView>()?.Setup(Prefab);
        }
    }

    public class MixedEggItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab) =>
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
            };
    }
}

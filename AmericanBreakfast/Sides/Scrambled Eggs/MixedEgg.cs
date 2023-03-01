namespace KitchenAmericanBreakfast.Sides
{
    class MixedEgg : CustomItem//CustomItemGroup<MixedEggItemGroupView>
    {
        public override string UniqueNameID => "MixedEgg";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MixedEgg");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override string ColourBlindTag => "Egg";

        /*public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.SplitMilk
                }
            },
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Refs.CrackedEgg
                }
            }
        };*/

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

            //Prefab.GetComponent<MixedEggItemGroupView>()?.Setup(Prefab);
        }
    }

    /*public class MixedEggItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab) =>
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Cylinder.002"),
                    Item = Refs.SplitMilk
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Plane"),
                    Item = Refs.CrackedEgg
                }
            };
    }*/
}

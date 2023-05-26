namespace KitchenAmericanBreakfast.Sides
{
    class MixedEgg : CustomItem
    {
        public override string UniqueNameID => "MixedEgg";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("MixedEgg");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override string ColourBlindTag => "Egg";

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
        }
    }
}

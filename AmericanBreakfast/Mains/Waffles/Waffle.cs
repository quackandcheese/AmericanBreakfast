namespace KitchenAmericanBreakfast.Mains
{
    class Waffle : CustomItem
    {
        public override string UniqueNameID => "Waffle";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Waffle");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 5,
                Process = Refs.Cook,
                IsBad = true,
                Result = Refs.Burnt
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Waffle", "Onion", "Cooked Batter", "Bread - Cooked");
        }
    }
}

namespace KitchenAmericanBreakfast.Mains
{
    class CookedOmelette : CustomItem
    {
        public override string UniqueNameID => "Cooked Omelette";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked Omelette");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 6f,
                Process = Refs.Cook,
                IsBad = true,
                Result = Refs.Burnt
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Omelette.001", "Bread", "Egg - Yolk");
        }
    }
}

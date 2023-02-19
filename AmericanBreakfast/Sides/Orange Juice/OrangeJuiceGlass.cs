namespace KitchenAmericanBreakfast.Sides
{
    class OrangeJuiceGlass : CustomItem
    {
        public override string UniqueNameID => "OrangeJuiceGlass";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("OrangeJuiceGlass");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;
        public override bool IsMergeableSide => true;
        public override GameObject SidePrefab => Mod.Bundle.LoadAsset<GameObject>("OrangeJuiceGlassSide");

        public override void OnRegister(GameDataObject gameDataObject)
        {
            //
            Prefab.ApplyMaterialToChild("Glass", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Glass\""].name);
            Prefab.ApplyMaterialToChild("Juice", "Plastic - Orange");

            SidePrefab.ApplyMaterialToChild("Glass", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Glass\""].name);
            SidePrefab.ApplyMaterialToChild("Juice", "Plastic - Orange");
        }
    }
}

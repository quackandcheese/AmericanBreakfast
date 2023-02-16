using IngredientLib.Ingredient.Items;

namespace KitchenAmericanBreakfast.Sides
{
    class OrangeJuice : CustomItem
    {
        public override string UniqueNameID => "OrangeJuice";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("OrangeJuice");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override ItemValue ItemValue => ItemValue.SideSmall;
        public override bool IsIndisposable => true;
        public override Item SplitSubItem => Refs.OrangeJuiceGlass;
        public override Appliance DedicatedProvider => Refs.OrangeJuiceProvider;
        public override int SplitCount => 999;
        public override float SplitSpeed => 3.0f;


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Carton", "Plastic - Orange", "Plastic - White", "Plastic - Green");
        }
    }
}

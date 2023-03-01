using ApplianceLib.Api.References;

namespace KitchenAmericanBreakfast.Sides
{
    class OrangeJuiceGlass : CustomItemGroup<OrangeJuiceView>
    {
        public override string UniqueNameID => "OrangeJuiceGlass";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("OrangeJuiceGlass");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.SideSmall;
        public override bool IsMergeableSide => true;
        //public override GameObject SidePrefab => Mod.Bundle.LoadAsset<GameObject>("OrangeJuiceGlassSide");

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Refs.OrangeJuiceIngredient,
                    ApplianceLibGDOs.Refs.Cup
                }
            }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            //
            Prefab.ApplyMaterialToChild("Glass", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Glass\""].name);
            Prefab.ApplyMaterialToChild("Juice", "Plastic - Orange");

            //SidePrefab.ApplyMaterialToChild("Glass", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Glass\""].name);
            //SidePrefab.ApplyMaterialToChild("Juice", "Plastic - Orange");

            //Prefab.GetComponent<OrangeJuiceView>()?.Setup(Prefab);
        }
    }

    public class OrangeJuiceView : ItemGroupView
    {
    }
}

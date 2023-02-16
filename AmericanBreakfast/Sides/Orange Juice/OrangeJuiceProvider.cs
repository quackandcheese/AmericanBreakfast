using Kitchen;
using Unity.Entities;
using UnityEngine;

namespace KitchenAmericanBreakfast.Sides
{
    class OrangeJuiceProvider : CustomAppliance
    {
        public override string UniqueNameID => "OrangeJuiceProvider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("OrangeJuiceProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Orange Juice", "Provides Orange Juice", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            new CItemHolder(),
            GetCItemProvider(Refs.OrangeJuice.ID, 1, 1, false, false, true, false, false, true, false)
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var holdTransform = Prefab.GetChildFromPath("Block/HoldPoint").transform;
            var holdPoint = Prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform;

            // This makes it so when you take off the carton, the model is removed from the prefab
            var sourceView = Prefab.TryAddComponent<LimitedItemSourceView>();
            sourceView.HeldItemPosition = holdTransform;
            ReflectionUtils.GetField<LimitedItemSourceView>("Items").SetValue(sourceView, new List<GameObject>()
            {
                    GameObjectUtils.GetChildObject(Prefab, "Block/HoldPoint/OrangeJuice")
            });


            // Visuals
            GameObject counter = Prefab.GetChildFromPath("Block/Counter2");
            var paintedWood = MaterialHelper.GetMaterialArray("Wood 4 - Painted");
            var defaultWood = MaterialHelper.GetMaterialArray("Wood - Default");
            counter.ApplyMaterialToChild("Counter", paintedWood);
            counter.ApplyMaterialToChild("Counter Doors", paintedWood);
            counter.ApplyMaterialToChild("Counter Surface", defaultWood);
            counter.ApplyMaterialToChild("Counter Top", defaultWood);
            counter.ApplyMaterialToChild("Handles", "Knob");


            Prefab.GetChildFromPath("Block/HoldPoint/OrangeJuice/Carton").ApplyMaterial("Plastic - Orange", "Plastic - White", "Plastic - Green");
            var crate = Prefab.GetChild("Crate");
            crate.ApplyMaterialToChild("Box", "Wood");
            crate.GetChild("Ice").ApplyMaterialToChildren("Cube", "Ice");
        }
    }
}

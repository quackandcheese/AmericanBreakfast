
namespace KitchenAmericanBreakfast.Mains
{
    class WaffleIron : CustomAppliance
    {
        public override string UniqueNameID => "WaffleIron";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("WaffleIron");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Waffle Iron", "Specialized tool that makes waffles what they are", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder(),
            new CRestrictProgressVisibility()
            {
                HideWhenActive = false,
                HideWhenInactive = false,
                ObfuscateWhenActive = true,
                ObfuscateWhenInactive = false
            },
            new CIsInactive(),
            new CRequiresActivation(),
            new CItemTransferRestrictions()
            {
                AllowWhenActive = false,
                AllowWhenInactive = true
            }
            
        };


        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>()
        {
            // ...
            new Appliance.ApplianceProcesses()
            {
                Process = Refs.CookWaffle,                               // reference to the base process
                Speed = 1f,                                              // the speed multiplier when using this appliance (for reference, starter = 0.75, base = 1, danger hob/oven = 2)
                IsAutomatic = true                                       // (optional) whether the process is automatic on this appliance
            }
            // ...
        };

        // Animator code courtesy of IcedMilo: https://github.com/UrFriendKen/PlateUpAutomationPlus/blob/master/Customs/SmartRotatingGrabber.cs
        static FieldInfo animator = ReflectionUtils.GetField<ApplianceProcessView>("Animator", BindingFlags.NonPublic | BindingFlags.Instance);

        public override void OnRegister(GameDataObject gameDataObject)
        {
            ApplianceProcessView applianceProcessView = Prefab.AddComponent<ApplianceProcessView>();

            animator.SetValue(applianceProcessView, Prefab.GetComponent<Animator>());

            var holdTransform = Prefab.GetChildFromPath("HoldPoint").transform;
            var holdPoint = Prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform;

            // Visuals
            var iron = Prefab.GetChild("WaffleIron");
            var counter = iron.GetChild("Base_L_Counter.blend");

            iron.ApplyMaterialToChild("Bottom", "Burned", "AppleBurnt", "Metal Black");
            iron.ApplyMaterialToChild("Top", "Burned", "AppleBurnt", "Metal Black");
            iron.ApplyMaterialToChild("Hinge", "Metal Black");

            // Counter
            iron.ApplyMaterialToChild("Top_L_Counter.blend", "Wood - Default");

            counter.ApplyMaterial("Wood - Default", "Wood 4 - Painted", "Wood 4 - Painted");
            counter.ApplyMaterialToChild("Handle_L_Counter.blend", "Knob");
        }
    }
}


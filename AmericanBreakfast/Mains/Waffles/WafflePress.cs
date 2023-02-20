
namespace KitchenAmericanBreakfast.Mains
{
    class WafflePress : CustomAppliance
    {
        public override string UniqueNameID => "WafflePress";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("WafflePress");
        public override PriceTier PriceTier => PriceTier.Expensive;
        public override RarityTier RarityTier => RarityTier.Rare;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => false;
        public override bool IsPurchasableAsUpgrade => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Waffle Press", "A repurposed hydraulic press", new(), new() { "<sprite name=\"upgrade\" color=#A8FF1E> Automatic", "0.75x <sprite name=\"cookwaffle\">" }) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder()/*,
            new CTakesDuration()
            {
                Total = 2,
                Mode = InteractionMode.Items,

            },
            new CApplyProcessAfterDuration() { BreakOnFailure = false },
            new CSetEnabledAfterDuration() { Activate = false },
            new CLockedWhileDuration(),
            new CDeactivateAtNight(),
            new CSetEnabledAfterDuration(),
            new CRestrictProgressVisibility()
            {
                HideWhenActive = false,
                HideWhenInactive = false,
                ObfuscateWhenActive = true,
                ObfuscateWhenInactive = false
            },
            new CIsInactive(),
            new CItemTransferRestrictions()
            {
                AllowWhenActive = false,
                AllowWhenInactive = true
            }*/
        };


        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>()
        {
            // ...
            new Appliance.ApplianceProcesses()
            {
                Process = Refs.CookWaffle,                               // reference to the base process
                Speed = 0.75f,                                              // the speed multiplier when using this appliance (for reference, starter = 0.75, base = 1, danger hob/oven = 2)
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

            iron.ApplyMaterialToChild("Frame", "AppleBurnt", "Metal Black");
            iron.ApplyMaterialToChild("Piston", "Metal Black", "AppleBurnt", "Burned");
            iron.ApplyMaterialToChild("Tray", "Burned", "AppleBurnt", "Metal Black");

            // Counter
            iron.ApplyMaterialToChild("Top_L_Counter.blend", "Wood - Default");

            counter.ApplyMaterial("Wood - Default", "Wood 4 - Painted", "Wood 4 - Painted");
            counter.ApplyMaterialToChild("Handle_L_Counter.blend", "Knob");
        }
    }
}


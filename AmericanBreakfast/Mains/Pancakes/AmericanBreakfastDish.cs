namespace KitchenAmericanBreakfast.Mains
{
    class AmericanBreakfastDish : CustomDish
    {
        public override string UniqueNameID => "American Breakfast Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("AmericanBreakfastIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<string> StartingNameSet => new List<string>
        {
            "Not Awful Waffles",
            "Waffle This Way",
            "Flippin' Tasty",
            "Slapjack Stackers",
            "Not Awful Waffles",
            "Waffle This Way",
            "Flippin' Tasty",
            "Slapjack Stackers",
            "Flapjack Fantasy"
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.PlatedPancakes,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Flour,
            Refs.Sugar,
            Refs.Egg,
            Refs.Plate
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook,
            Refs.Knead
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine flour, egg, and sugar. Cook, plate, and serve. Customers can order up to 3 pancakes in a stack." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("American Breakfast", "Adds Pancakes as a Main", "Spontaneous stacks") )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var pancake = DisplayPrefab.GetChild("Pancakes");
            var plate = DisplayPrefab.GetChildFromPath("Plate/Plate.001");

            //Visuals

            pancake.ApplyMaterialToChildren("Pancake", "Raw Pastry", "Onion");

            pancake.GetChild("Top Pancake").ApplyMaterialToChild("Butter - Slice.002", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Middle Pancake").ApplyMaterialToChild("Butter - Slice.001", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);
            pancake.GetChild("Bottom Pancake").ApplyMaterialToChild("Butter - Slice", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Butter\""].name);

            DisplayPrefab.ApplyMaterialToChild("Bacon", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon Fat\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Bacon\""].name);

            plate.ApplyMaterialToChild("Cylinder", "Plate", "Plate - Ring");

            DisplayPrefab.GetChild("Syrup").ApplyMaterialToChild("Plane.002", "Cooked Batter");
        }
    }
}

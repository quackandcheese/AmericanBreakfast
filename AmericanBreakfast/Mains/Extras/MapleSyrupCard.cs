namespace KitchenAmericanBreakfast.Mains
{
    class MapleSyrupCard : CustomDish
    {
        public override string UniqueNameID => "MapleSyrupCard";
        public override DishType Type => DishType.Extra;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override int Difficulty => 1;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Refs.AmericanBreakfastDish
        };

        public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.SyrupBottle,
                MenuItem = Refs.PlatedPancakes
            },
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.SyrupBottle,
                MenuItem = Refs.TriplePlatedPancakes
            },
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.SyrupBottle,
                MenuItem = Refs.PlatedWaffles
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.SyrupBottle
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            //{ Locale.English, "Use with plated breakfast to add syrup, then serve." }

            { Locale.English, "Customers can request Maple Syrup while eating American breakfast" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            //( Locale.English, LocalisationUtils.CreateUnlockInfo("Maple Syrup", "Adds maple syrup as an American Breakfast topping", "Simple yet delicious") )
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Maple Syrup", "Customers can request Maple Syrup while eating American breakfast", null) )
        };
    }
}

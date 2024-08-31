namespace KitchenAmericanBreakfast.Mains
{
    class ButterCard : CustomDish
    {
        public override string UniqueNameID => "ButterCard";
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

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.ButterSlice,
                MenuItem = Refs.PlatedPancakes
            },
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.ButterSlice,
                MenuItem = Refs.PlatedWaffles
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Butter
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Chop
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Portion a slice, and add to plated breakfast." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Butter", "Adds butter as an American Breakfast topping", "Perfectly balanced") )
        };
    }
}

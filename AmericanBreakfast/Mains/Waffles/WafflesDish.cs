namespace KitchenAmericanBreakfast.Mains
{
    class WafflesDish : CustomDish
    {
        public override string UniqueNameID => "Waffles Dish";
        public override DishType Type => DishType.Main;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Refs.AmericanBreakfastDish
        };

        /*public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Refs.PlatedWaffles,
                MenuItem = Refs.PlatedPancakes
            }
        };*/

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.PlatedWaffles,
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
            Refs.Knead,
            Refs.CookWaffle
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine flour, cracked (or mixed) egg, sugar, and mix. Put batter in waffle iron, and close to cook. When cooked, open the iron, plate, and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Waffles", "Adds waffles as a main", "Essentially the same thing as pancakes") )
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Mains
{
    class BaconCheeseOmeletteDish : CustomDish
    {
        public override string UniqueNameID => "Bacon Cheese Omelette Dish";
        public override DishType Type => DishType.Main;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override List<Unlock> HardcodedRequirements => new()
        {
            Refs.OmeletteDish
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.PlatedBaconCheeseOmelette,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };

        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Egg,
            //Refs.Milk,
            Refs.Cheese,
            Refs.Pork
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Knead,
            Refs.Chop,
            Refs.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Crack an egg, mix, then cook. Chop and cook pork to make bacon. Add chopped cheese and portioned bacon as fillings and fold omelette" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Bacon And Cheese Omelette", "Adds bacon and cheese omelettes as a main", null) )
        };
    }
}

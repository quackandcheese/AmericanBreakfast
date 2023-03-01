using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenAmericanBreakfast.Sides
{
    class ScrambledEggsCard : CustomDish
    {
        public override string UniqueNameID => "ScrambledEggsCard";
        public override DishType Type => DishType.Side;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.ScrambledEgg,
                Phase = MenuPhase.Side,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Wok,
            Refs.Egg,
            //Refs.Milk
        };

        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Cook,
            Refs.Chop
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Crack an egg, then chop again to mix. Cook in wok, portion, and serve with plated main." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Scrambled Eggs", "Adds scrambled eggs as a side", "Eggalicious") )
        };
    }
}

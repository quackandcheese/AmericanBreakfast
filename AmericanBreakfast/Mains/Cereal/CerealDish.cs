using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;

namespace KitchenAmericanBreakfast.Mains
{
    class CerealDish : CustomDish
    {
        public override string UniqueNameID => "Cereal Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("Cereal Icon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeIncrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<string> StartingNameSet => new List<string>
        {
            "Cereal-ously Awesome",
            "Crunch Time",
            "The Cereal Killer Cafe",
            "The Cereal Box",
            "Conveyor Cornflakes",
            "Cornflakes Cafe",
            "Cheerio!",
            "Ce-real With Me",
            "Let's Be Cerealistic",
            "The Milky Way",
            "Cheery O's",
            "Cheerio Hero",
            "Super Bowls",
            "Admiral Crunch",
            "Honey Bunches of Oafs",
            "Frooty Loop-de-Loops",
            "Cheeri-yo Mama",
            "Apple Jacked-Up",
            "Magic Trix"
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.PlatedCereal,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Cornflakes,
            Refs.Milk,
            Refs.Plate
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Grab a bowl of requested cereal, and fill with a portion of milk. Put on plate and serve." }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Cereal", "Adds three different types of cereal as a main", null) )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            DisplayPrefab.GetChild("Bowl").ApplyMaterialToChild("Small Bowl.001", "Plate");
            DisplayPrefab.GetChild("Quackos").ApplyMaterialToChildren("Quackos", "Sack");

            DisplayPrefab.ApplyMaterialToChild("Milk", "Coffee Cup"); 
        }
    }
}

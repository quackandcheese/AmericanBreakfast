using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;

namespace KitchenAmericanBreakfast.Mains
{
    class OmeletteDish : CustomDish
    {
        public override string UniqueNameID => "Omelette Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("OmelettesIcon").AssignMaterialsByNames();
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease; // subject to change
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override int Difficulty => 3;
        public override List<string> StartingNameSet => new List<string>
        {
            "The Yolk's On You",
            "Omelette You Choose",
            "Pure Eggstasy",
            "Scrambled Shenanigans",
            "Eggcellent Eats",
            "Eggs-treme",
            "Eggstravaganza",
            "The Eggstraordinary Kitchen",
            "Yolked Chefs",
            "The Crack of Dawn",
            "Sunny Side Supper",
            "Egg-cellent service",
            "Overeasy going",
            "Mad Scramble",
            "Fry me to the moon",
            "Hard-boiled service",
            "No yolks about it",
            "I love puns",
            "Egg Pun"
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Refs.PlatedOmelette,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Refs.Egg,
            Refs.Tomato,
            Refs.Spinach,
            Refs.Plate
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Refs.Chop,
            Refs.Knead,
            Refs.Cook
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Crack an egg, mix, then cook. Add chopped tomato and chopped spinach as fillings and fold omelette" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Omelettes", "Adds tomato and basil omelettes as a main", null) )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            var omelette = DisplayPrefab.GetChild("Tomato Spinach Omelette");
            var tomato = omelette.GetChild("Tomato - Chopped/Tomato Sliced");

            omelette.ApplyMaterialToChild("Spinaches", CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Spinach\""].name, CustomMaterials.CustomMaterialsIndex["IngredientLib - \"Spinach Stem\""].name);
            tomato.ApplyMaterialToChild("Liquid", "Tomato Flesh");
            tomato.ApplyMaterialToChild("Liquid.001", "Tomato Flesh 2");
            tomato.ApplyMaterialToChild("Skin", "Tomato");

            omelette.ApplyMaterialToChild("Folded Omelette", "Bread", "Egg - Yolk");
        }
    }
}

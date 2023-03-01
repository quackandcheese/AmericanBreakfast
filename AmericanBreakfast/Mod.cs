global using KitchenAmericanBreakfast.Mains;
global using KitchenAmericanBreakfast.Utils;
global using KitchenAmericanBreakfast.Sides;

global using Kitchen;
global using KitchenLib.References;
global using KitchenLib;
global using KitchenLib.Event;
global using KitchenMods;
global using KitchenData;
global using KitchenLib.Customs;
global using KitchenLib.Utils;
global using KitchenLib.Colorblind;

global using UnityEngine;

global using System;
global using System.Collections.Generic;
global using System.Text;
global using System.Threading.Tasks;
global using System.Linq;
global using System.Reflection;


global using IngredientLib.Util;
global using ApplianceLib.Api.References;

global using static KitchenData.ItemGroup;
global using static KitchenLib.Utils.GDOUtils;
global using static KitchenLib.Utils.KitchenPropertiesUtils;
using TMPro;
using Object = UnityEngine.Object;



// Huge thanks to ZekNikZ, IcedMilo, DepletedSupernova, and many others for helping me make this mod along the way!!
namespace KitchenAmericanBreakfast
{
    public class Mod : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "QuackAndCheese.PlateUp.AmericanBreakfast";
        public const string MOD_NAME = "American Breakfast";
        public const string MOD_VERSION = "0.2.1";
        public const string MOD_AUTHOR = "QuackAndCheese";
        public const string MOD_GAMEVERSION = ">=1.1.3";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        // Boolean constant whose value depends on whether you built with DEBUG or RELEASE mode, useful for testing
#if DEBUG
        public const bool DEBUG_MODE = true;
#else
        public const bool DEBUG_MODE = false;
#endif

        public static AssetBundle Bundle;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        private void AddGameData()
        {
            LogInfo("Attempting to register game data...");

            // Pancakes
            AddGameDataObject<AmericanBreakfastDish>();
            //AddGameDataObject<TripleStackCard>();

            AddGameDataObject<Batter>();
            AddGameDataObject<BatterPortion>();
            AddGameDataObject<Pancake>();
            //AddGameDataObject<ThirdPancake>();
            AddGameDataObject<PlatedPancakes>();
            AddGameDataObject<UnmixedBatter>();
            AddGameDataObject<BaconPortion>();

            AddGameDataObject<MapleSyrupCard>();
            AddGameDataObject<PancakeBaconCard>();
            AddGameDataObject<ButterCard>();

            // Waffles
            AddGameDataObject<WafflesDish>();

            AddGameDataObject<PlatedWaffles>();
            AddGameDataObject<Waffle>();
            AddGameDataObject<WaffleIron>();
            AddGameDataObject<WafflePress>();
            AddGameDataObject<CookWaffle>();

            AddGameDataObject<WafflesChickenCard>();

            // Omelettes
            AddGameDataObject<CookedOmelette>();

            AddGameDataObject<OmeletteDish>();
            AddGameDataObject<PlatedOmelette>();
            AddGameDataObject<CookedTomatoSpinachOmelette>();
            AddGameDataObject<TomatoSpinachOmelette>();

            AddGameDataObject<BaconCheeseOmeletteDish>();
            AddGameDataObject<PlatedBaconCheeseOmelette>();
            AddGameDataObject<CookedBaconCheeseOmelette>();
            AddGameDataObject<BaconCheeseOmelette>();

            AddGameDataObject<MushroomOnionOmeletteDish>();
            AddGameDataObject<PlatedMushroomOnionOmelette>();
            AddGameDataObject<CookedMushroomOnionOmelette>();
            AddGameDataObject<MushroomOnionOmelette>();

            // OJ
            AddGameDataObject<OrangeJuice>();
            AddGameDataObject<OrangeJuiceIngredient>();
            AddGameDataObject<OrangeJuiceGlass>();
            AddGameDataObject<OrangeJuiceProvider>();

            AddGameDataObject<OrangeJuiceCard>();

            // Scrambled Eggs
            AddGameDataObject<MixedEgg>();
            AddGameDataObject<ScrambledEgg>();
            AddGameDataObject<ScrambledEggWokUncooked>();
            AddGameDataObject<ScrambledEggWokCooked>();
            AddGameDataObject<ScrambledEggsCard>();

            // Hash Browns
            AddGameDataObject<HashBrowns>();
            //AddGameDataObject<HashBrownsWokUncooked>();
            //AddGameDataObject<HashBrownsWokCooked>();
            AddGameDataObject<HashBrownsCard>();

            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            LogInfo("Attempting to load asset bundle...");
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();

            Bundle.LoadAllAssets<Texture2D>();
            Bundle.LoadAllAssets<Sprite>();
            var spriteAsset = Bundle.LoadAsset<TMP_SpriteAsset>("CookWaffle");
            TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(spriteAsset);
            spriteAsset.material = Object.Instantiate(TMP_Settings.defaultSpriteAsset.material);
            spriteAsset.material.mainTexture = Bundle.LoadAsset<Texture2D>("CookWaffleTex");
            LogInfo("Done loading asset bundle.");


            // Register custom GDOs
            AddGameData();

            // Perform actions when game data is built
            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                Refs.ChoppedPotato.DerivedProcesses.Add(new Item.ItemProcess()
                {
                    Process = Refs.CookWaffle,         
                    Result = Refs.HashBrowns,
                    Duration = 2f
                });

                Refs.CrackedEgg.DerivedProcesses.Add(new Item.ItemProcess()
                {
                    Process = Refs.Chop,
                    Result = Refs.MixedEgg,
                    Duration = 0.75f
                });

                Refs.Bacon.SplitDepletedItems.Add(Refs.BaconPortion);
                Refs.Bacon.SplitSubItem = Refs.BaconPortion;
                Refs.Bacon.SplitCount = 1;
                Refs.Bacon.SplitSpeed = 2f;
            };
        }
        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}

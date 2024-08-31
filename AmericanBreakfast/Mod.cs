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


//global using IngredientLib.Util;
global using ApplianceLib.Api.References;
global using ApplianceLib.Api;

global using static KitchenData.ItemGroup;
global using static KitchenLib.Utils.GDOUtils;
global using static KitchenLib.Utils.KitchenPropertiesUtils;
using TMPro;
using KitchenLib.Preferences;
using KitchenLib.Systems;
using IngredientLib.Menu;



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
        public const string MOD_VERSION = "0.2.6";
        public const string MOD_AUTHOR = "QuackAndCheese";
        public const string MOD_GAMEVERSION = ">=1.1.3";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until


        #region Preferences
        public const string MIX_EGG_METHOD = "mixEggMethod";
        public const string PANCAKE_OR_WAFFLES_ID = "pancakesOrWaffles";
        #endregion

        internal static PreferenceManager PrefManager;
        internal static PreferenceInt MixEggMethodPreference = new PreferenceInt(MIX_EGG_METHOD, 0);
        internal static PreferenceInt PancakesOrWafflesPreference = new PreferenceInt(PANCAKE_OR_WAFFLES_ID, 0);

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

        private void UpdatePreferenceGDOs()
        {
            Dish americanBreakfastDish = Refs.AmericanBreakfastDish;
            Dish wafflesDish = Refs.WafflesDish;
            PreferenceInt pancakesOrWafflesInt = Mod.PrefManager.GetPreference<PreferenceInt>(Mod.PANCAKE_OR_WAFFLES_ID);
            int pancakesOrWaffles = pancakesOrWafflesInt.Get();

            PreferenceInt mixEggMethodInt = Mod.PrefManager.GetPreference<PreferenceInt>(Mod.MIX_EGG_METHOD);
            int mixEggMethod = mixEggMethodInt.Get();

            if (americanBreakfastDish != null && wafflesDish != null)
            {
                if (pancakesOrWaffles == 0)
                {
                }
                else
                {
                    wafflesDish.Type = DishType.Base;
                    americanBreakfastDish.Type = DishType.Main;

                    wafflesDish.Requires.RemoveAt(0);
                    americanBreakfastDish.Requires.Add(wafflesDish);
                }
            }

            if (mixEggMethod == 0)
            {

            }
            else
            {

                List<Dish> dishesToAddMilk = new List<Dish>()
                {
                    Refs.OmeletteDish,
                    Refs.WafflesDish,
                    Refs.AmericanBreakfastDish,
                    Refs.ScrambledEggsCard,
                    Refs.BaconCheeseOmeletteDish,
                    Refs.MushroomOnionOmeletteDish
                };

                for (int i = 0; i < dishesToAddMilk.Count; i++)
                {
                    dishesToAddMilk[i].MinimumIngredients.Add(Refs.Milk);
                }
            }
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

            AddGameDataObject<UncookedQuiche>();
            AddGameDataObject<CookedQuiche>();
            AddGameDataObject<PlatedQuiche>();
            AddGameDataObject<QuicheDish>();

            // Cereal
            AddGameDataObject<PlatedCereal>();
            AddGameDataObject<Cereal>();
            AddGameDataObject<Quackos>();
            AddGameDataObject<Qwix>();
            AddGameDataObject<Cornflakes>();
            AddGameDataObject<CerealProvider>();
            AddGameDataObject<CerealDish>();

            AddGameDataObject<OatmealDish>();
            AddGameDataObject<OatmealPortion>();
            AddGameDataObject<Oatmeal>(); 
            AddGameDataObject<PlatedOatmeal>();
            AddGameDataObject<OatmealPot>();
            AddGameDataObject<OatmealPotCooked>();

            AddGameDataObject<OatmealCinnamon>();
            AddGameDataObject<OatmealBlueberries>();

            // OJ
            AddGameDataObject<OrangeJuice>();
            AddGameDataObject<OrangeJuiceIngredient>();
            AddGameDataObject<OrangeJuiceGlass>();
            AddGameDataObject<OrangeJuiceProvider>();

            AddGameDataObject<OrangeJuiceCard>();

            // Scrambled Eggs
            AddGameDataObject<MixedEgg>();
            AddGameDataObject<MixedEggMilk>();
            AddGameDataObject<ScrambledEgg>();
            AddGameDataObject<ScrambledEggWokUncooked>();
            AddGameDataObject<ScrambledEggWokCooked>();
            AddGameDataObject<ScrambledEggsCard>();

            //AddGameDataObject<PlatedScrambledEggs>();

            // Hash Browns
            AddGameDataObject<HashBrowns>();
            //AddGameDataObject<HashBrownsWokUncooked>();
            //AddGameDataObject<HashBrownsWokCooked>();
            AddGameDataObject<HashBrownsCard>();

            LogInfo("Done loading game data.");
        }

        private bool colorblindSetup = false;
        protected override void OnUpdate()
        {
            if (!colorblindSetup)
            {
                Refs.CerealProvider.Prefab.GetChild("Colour Blind").AddApplianceColorblindLabel("Co");
                Refs.CerealProvider.Prefab.GetChild("Colour Blind (1)").AddApplianceColorblindLabel("Tr");
                Refs.CerealProvider.Prefab.GetChild("Colour Blind (2)").AddApplianceColorblindLabel("Ch");

                colorblindSetup = true;
            }
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            LogInfo("Attempting to load asset bundle...");
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();

            Bundle.LoadAllAssets<Texture2D>();
            Bundle.LoadAllAssets<Sprite>();
            var spriteAsset = Bundle.LoadAsset<TMP_SpriteAsset>("CookWaffle");
            TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(spriteAsset);
            spriteAsset.material = UnityEngine.Object.Instantiate(TMP_Settings.defaultSpriteAsset.material);
            spriteAsset.material.mainTexture = Bundle.LoadAsset<Texture2D>("CookWaffleTex");
            LogInfo("Done loading asset bundle.");


            PrefManager = new PreferenceManager(MOD_GUID);

            PrefManager.RegisterPreference(MixEggMethodPreference);
            PrefManager.RegisterPreference(PancakesOrWafflesPreference);

            PrefManager.Load();

            ModsPreferencesMenu<MenuAction>.RegisterMenu("American Breakfast", typeof(AmericanBreakfastMenu<MenuAction>), typeof(MenuAction));

            Events.MainMenuView_SetupMenusEvent += (s, args) =>
            {
                args.addMenu.Invoke(args.instance, new object[] { typeof(AmericanBreakfastMenu<MenuAction>), new AmericanBreakfastMenu<MenuAction>(args.instance.ButtonContainer, args.module_list) });
            };
            Events.PlayerPauseView_SetupMenusEvent += (s, args) =>
            {
                args.addMenu.Invoke(args.instance, new object[] { typeof(AmericanBreakfastMenu<MenuAction>), new AmericanBreakfastMenu<MenuAction>(args.instance.ButtonContainer, args.module_list) });
            };

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

                Refs.Bacon.SplitDepletedItems.Add(Refs.BaconPortion);
                Refs.Bacon.SplitSubItem = Refs.BaconPortion;
                Refs.Bacon.SplitCount = 1;
                Refs.Bacon.SplitSpeed = 2f;


                PreferenceInt mixEggMethodInt = Mod.PrefManager.GetPreference<PreferenceInt>(Mod.MIX_EGG_METHOD);
                int mixEggMethod = mixEggMethodInt.Get();

                if (mixEggMethod == 0)
                {
                    Refs.CrackedEgg.DerivedProcesses.Add(new Item.ItemProcess()
                    {
                        Process = Refs.Chop,
                        Result = Refs.MixedEgg,
                        Duration = 1f
                    });
                }

                Dish americanBreakfastDish = Refs.AmericanBreakfastDish;
                Dish wafflesDish = Refs.WafflesDish;
                PreferenceInt pancakesOrWafflesInt = Mod.PrefManager.GetPreference<PreferenceInt>(Mod.PANCAKE_OR_WAFFLES_ID);
                int pancakesOrWaffles = pancakesOrWafflesInt.Get();

                if (americanBreakfastDish != null && wafflesDish != null)
                {
                    /*if (pancakesOrWaffles == 0)
                    {
                        foreach (int thing in MainMenuDishSystem.MenuOptions)
                        {
                            if (thing == wafflesDish.ID)
                            {
                                MainMenuDishSystem.MenuOptions.Remove(thing);
                            }
                        }
                    }
                    else
                    {
                        foreach (int thing in MainMenuDishSystem.MenuOptions)
                        {
                            if (thing == americanBreakfastDish.ID)
                            {
                                MainMenuDishSystem.MenuOptions.Remove(thing);
                            }
                        }
                    }*/
                }
            };

            Events.BuildGameDataPostViewInitEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                LogInfo("Attempting to update preference GDOs...");

                UpdatePreferenceGDOs();

                LogInfo("Done updating preference GDOs.");
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

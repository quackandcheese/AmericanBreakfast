using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Entities;
using KitchenAmericanBreakfast.Utils;
using KitchenAmericanBreakfast;

namespace KitchenAmericanBreakfast.Mains
{
    class TripleStackCard : CustomUnlockCard
    {
        public override string UniqueNameID => "TripleStackCard";
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Generic;
        public override bool IsUnlockable => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Refs.AmericanBreakfastDish
        };

        public override List<UnlockEffect> Effects => new()
        {
            new StatusEffect()
            {
                Status = (RestaurantStatus)VariousUtils.GetID("triplestack")
            }
        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Triple Stack", "Customers can now order up to 3 pancakes in a stack", "The more the merrier!") )
        };
    }
}

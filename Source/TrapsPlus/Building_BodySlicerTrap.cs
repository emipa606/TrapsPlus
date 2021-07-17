using System.Reflection;
using BetaTraps;
using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x02000004 RID: 4
    public class Building_BodySlicerTrap : Building_TrapRearmable
    {
        // Token: 0x04000006 RID: 6
        private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

        // Token: 0x04000007 RID: 7
        private static readonly IntRange DamageCount = new IntRange(1, 2);

        // Token: 0x06000009 RID: 9 RVA: 0x00002328 File Offset: 0x00000528
        protected override void SpringSub(Pawn p)
        {
            typeof(Building_TrapRearmable).GetField("armedInt", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(this, false);
            if (p != null)
            {
                DamagePawn(p);
            }

            if ((bool) typeof(Building_TrapRearmable)
                .GetField("autoRearm", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.GetValue(this))
            {
                Map.designationManager.AddDesignation(new Designation(this, BetaTrapDefOf.RearmTrap));
            }
        }

        // Token: 0x0600000A RID: 10 RVA: 0x000023B4 File Offset: 0x000005B4
        private void DamagePawn(Pawn p)
        {
            var height = BodyPartHeight.Middle;
            var num = Mathf.RoundToInt(this.GetStatValue(StatDefOf.TrapMeleeDamage) * TrapDamageFactor.RandomInRange);
            var randomInRange = DamageCount.RandomInRange;
            for (var i = 0; i < randomInRange; i++)
            {
                if (num <= 0)
                {
                    break;
                }

                var num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * num));
                num -= num2;
                var damageInfo = new DamageInfo(DamageDefOf.Cut, num2, 0, -1f, this);
                damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
                p.TakeDamage(damageInfo);
            }
        }
    }
}
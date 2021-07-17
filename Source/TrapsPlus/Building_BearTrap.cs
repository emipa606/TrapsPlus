using System.Reflection;
using BetaTraps;
using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x02000002 RID: 2
    public class Building_BearTrap : Building_TrapRearmable
    {
        // Token: 0x04000001 RID: 1
        private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

        // Token: 0x04000002 RID: 2
        private static readonly IntRange DamageCount = new IntRange(1, 2);

        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
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

        // Token: 0x06000002 RID: 2 RVA: 0x000020DC File Offset: 0x000002DC
        private void DamagePawn(Pawn p)
        {
            var height = BodyPartHeight.Bottom;
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
                var damageInfo = new DamageInfo(DamageDefOf.Stab, num2, 0, -1f, this);
                var damageInfo2 = new DamageInfo(DamageDefOf.Stun, num2, 0, -1f, this);
                damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
                p.TakeDamage(damageInfo2);
                p.TakeDamage(damageInfo);
            }
        }
    }
}
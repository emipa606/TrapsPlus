using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x02000003 RID: 3
    public class Building_SpikesTrap : Building_Trap
    {
        // Token: 0x04000003 RID: 3
        private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

        // Token: 0x04000004 RID: 4
        private static readonly IntRange DamageCount = new IntRange(1, 2);

        // Token: 0x04000005 RID: 5
        private bool hitCount;

        // Token: 0x06000005 RID: 5 RVA: 0x000021D8 File Offset: 0x000003D8
        private void DamagePawn(Pawn p)
        {
            var height = BodyPartHeight.Bottom;
            var statValue = this.GetStatValue(StatDefOf.TrapMeleeDamage);
            var num = Mathf.RoundToInt(statValue * TrapDamageFactor.RandomInRange);
            var randomInRange = DamageCount.RandomInRange;
            for (var i = 0; i < randomInRange; i++)
            {
                if (!(num > 0))
                {
                    break;
                }

                var num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * num));
                num -= num2;
                var damageInfo = new DamageInfo(DamageDefOf.Stab, num2, 0, -1f, this);
                damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
                p.TakeDamage(damageInfo);
                p.health.AddHediff(HediffDefOfTrap.PoisonedTrap);
            }
        }

        // Token: 0x06000006 RID: 6 RVA: 0x000022AC File Offset: 0x000004AC
        protected override void SpringSub(Pawn p)
        {
            if (p != null && !hitCount)
            {
                DamagePawn(p);
                hitCount = true;
            }
            else
            {
                if (hitCount)
                {
                    hitCount = false;
                }
            }
        }
    }
}
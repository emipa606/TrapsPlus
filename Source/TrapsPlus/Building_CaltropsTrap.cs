using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x02000009 RID: 9
    public class Building_CaltropsTrap : Building_Trap
    {
        // Token: 0x04000013 RID: 19
        private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

        // Token: 0x04000014 RID: 20
        private static readonly IntRange DamageCount = new IntRange(1, 2);

        // Token: 0x04000015 RID: 21
        private bool hitCount;

        // Token: 0x06000023 RID: 35 RVA: 0x000029C4 File Offset: 0x00000BC4
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
                p.health.AddHediff(HediffDefOfTrap.SlowedTrap);
            }
        }

        // Token: 0x06000024 RID: 36 RVA: 0x00002A98 File Offset: 0x00000C98
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
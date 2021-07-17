using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x02000008 RID: 8
    public class Building_SawsTrap : Building_Trap
    {
        // Token: 0x04000010 RID: 16
        private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

        // Token: 0x04000011 RID: 17
        private static readonly IntRange DamageCount = new IntRange(1, 2);

        // Token: 0x04000012 RID: 18
        public CompPowerTrader powerComp;

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x0600001D RID: 29 RVA: 0x0000288C File Offset: 0x00000A8C
        public bool CanDamageNow => powerComp.PowerOn;

        // Token: 0x0600001E RID: 30 RVA: 0x000028A9 File Offset: 0x00000AA9
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            powerComp = GetComp<CompPowerTrader>();
        }

        // Token: 0x0600001F RID: 31 RVA: 0x000028C4 File Offset: 0x00000AC4
        private void DamagePawn(Pawn p)
        {
            var height = BodyPartHeight.Top;
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
                var damageInfo = new DamageInfo(DamageDefOf.Cut, num2, 0, -1f, this);
                damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
                p.TakeDamage(damageInfo);
            }
        }

        // Token: 0x06000020 RID: 32 RVA: 0x00002978 File Offset: 0x00000B78
        protected override void SpringSub(Pawn p)
        {
            if (p != null && CanDamageNow)
            {
                DamagePawn(p);
            }
        }
    }
}
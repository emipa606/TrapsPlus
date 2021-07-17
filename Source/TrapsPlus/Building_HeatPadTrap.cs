using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x02000006 RID: 6
    public class Building_HeatPadTrap : Building_Trap
    {
        // Token: 0x0400000A RID: 10
        private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

        // Token: 0x0400000B RID: 11
        private static readonly IntRange DamageCount = new IntRange(1, 2);

        // Token: 0x0400000C RID: 12
        public CompPowerTrader powerComp;

        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000011 RID: 17 RVA: 0x000025EC File Offset: 0x000007EC
        public bool CanDamageNow => powerComp.PowerOn;

        // Token: 0x06000012 RID: 18 RVA: 0x00002609 File Offset: 0x00000809
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            powerComp = GetComp<CompPowerTrader>();
        }

        // Token: 0x06000013 RID: 19 RVA: 0x00002624 File Offset: 0x00000824
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
                var damageInfo = new DamageInfo(DamageDefOf.Burn, num2, 0, -1f, this);
                damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
                p.TakeDamage(damageInfo);
            }
        }

        // Token: 0x06000014 RID: 20 RVA: 0x000026D8 File Offset: 0x000008D8
        protected override void SpringSub(Pawn p)
        {
            if (p == null || !CanDamageNow)
            {
                return;
            }

            DamagePawn(p);
            if (Rand.Range(0, 2) == 0)
            {
                p.TryAttachFire(Rand.Range(0.1f, 0.15f));
            }
        }
    }
}
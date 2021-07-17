using UnityEngine;
using Verse;

namespace RimWorld
{
    // Token: 0x02000007 RID: 7
    public class Building_FreezePadTrap : Building_Trap
    {
        // Token: 0x0400000D RID: 13
        private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

        // Token: 0x0400000E RID: 14
        private static readonly IntRange DamageCount = new IntRange(1, 2);

        // Token: 0x0400000F RID: 15
        public CompPowerTrader powerComp;

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000017 RID: 23 RVA: 0x00002754 File Offset: 0x00000954
        public bool CanDamageNow => powerComp.PowerOn;

        // Token: 0x06000018 RID: 24 RVA: 0x00002771 File Offset: 0x00000971
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            powerComp = GetComp<CompPowerTrader>();
        }

        // Token: 0x06000019 RID: 25 RVA: 0x0000278C File Offset: 0x0000098C
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
                var damageInfo = new DamageInfo(DamageDefOf.Frostbite, num2, 0, -1f, this);
                damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
                p.TakeDamage(damageInfo);
            }
        }

        // Token: 0x0600001A RID: 26 RVA: 0x00002840 File Offset: 0x00000A40
        protected override void SpringSub(Pawn p)
        {
            if (p != null && CanDamageNow)
            {
                DamagePawn(p);
            }
        }
    }
}
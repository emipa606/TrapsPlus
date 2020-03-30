using System;
using UnityEngine;
using Verse;

namespace RimWorld
{
	// Token: 0x02000008 RID: 8
	public class Building_SawsTrap : Building_Trap
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000288C File Offset: 0x00000A8C
		public bool CanDamageNow
		{
			get
			{
				return this.powerComp.PowerOn;
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000028A9 File Offset: 0x00000AA9
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			base.SpawnSetup(map, respawningAfterLoad);
			this.powerComp = base.GetComp<CompPowerTrader>();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000028C4 File Offset: 0x00000AC4
		private void DamagePawn(Pawn p)
		{
			BodyPartHeight height = BodyPartHeight.Top;
			float statValue = this.GetStatValue(StatDefOf.TrapMeleeDamage, true);
			int num = Mathf.RoundToInt(statValue * Building_SawsTrap.TrapDamageFactor.RandomInRange);
			int randomInRange = Building_SawsTrap.DamageCount.RandomInRange;
			for (int i = 0; i < randomInRange; i++)
			{
				bool flag = num > 0;
				if (!flag)
				{
					break;
				}
				int num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * (float)num));
				num -= num2;
				DamageInfo damageInfo = new DamageInfo(DamageDefOf.Cut, num2, 0, -1f, this, null, null, DamageInfo.SourceCategory.ThingOrUnknown);
				damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
				p.TakeDamage(damageInfo);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002978 File Offset: 0x00000B78
		protected override void SpringSub(Pawn p)
		{
			bool flag = p != null && this.CanDamageNow;
			if (flag)
			{
				this.DamagePawn(p);
			}
		}

		// Token: 0x04000010 RID: 16
		private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

		// Token: 0x04000011 RID: 17
		private static readonly IntRange DamageCount = new IntRange(1, 2);

		// Token: 0x04000012 RID: 18
		public CompPowerTrader powerComp;
	}
}

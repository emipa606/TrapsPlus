using System;
using UnityEngine;
using Verse;

namespace RimWorld
{
	// Token: 0x02000006 RID: 6
	public class Building_HeatPadTrap : Building_Trap
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000025EC File Offset: 0x000007EC
		public bool CanDamageNow
		{
			get
			{
				return this.powerComp.PowerOn;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002609 File Offset: 0x00000809
		public override void SpawnSetup(Map map, bool respawningAfterLoad)
		{
			base.SpawnSetup(map, respawningAfterLoad);
			this.powerComp = base.GetComp<CompPowerTrader>();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002624 File Offset: 0x00000824
		private void DamagePawn(Pawn p)
		{
			BodyPartHeight height = BodyPartHeight.Bottom;
			float statValue = this.GetStatValue(StatDefOf.TrapMeleeDamage, true);
			int num = Mathf.RoundToInt(statValue * Building_HeatPadTrap.TrapDamageFactor.RandomInRange);
			int randomInRange = Building_HeatPadTrap.DamageCount.RandomInRange;
			for (int i = 0; i < randomInRange; i++)
			{
				bool flag = num > 0;
				if (!flag)
				{
					break;
				}
				int num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * (float)num));
				num -= num2;
				DamageInfo damageInfo = new DamageInfo(DamageDefOf.Burn, num2, 0, -1f, this, null, null, DamageInfo.SourceCategory.ThingOrUnknown);
				damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
				p.TakeDamage(damageInfo);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000026D8 File Offset: 0x000008D8
		protected override void SpringSub(Pawn p)
		{
			bool flag = p != null && this.CanDamageNow;
			if (flag)
			{
				this.DamagePawn(p);
				bool flag2 = Rand.Range(0, 2) == 0;
				if (flag2)
				{
					p.TryAttachFire(Rand.Range(0.1f, 0.15f));
				}
			}
		}

		// Token: 0x0400000A RID: 10
		private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

		// Token: 0x0400000B RID: 11
		private static readonly IntRange DamageCount = new IntRange(1, 2);

		// Token: 0x0400000C RID: 12
		public CompPowerTrader powerComp;
	}
}

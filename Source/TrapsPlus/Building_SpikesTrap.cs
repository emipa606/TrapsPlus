using System;
using UnityEngine;
using Verse;

namespace RimWorld
{
	// Token: 0x02000003 RID: 3
	public class Building_SpikesTrap : Building_Trap
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000021D8 File Offset: 0x000003D8
		private void DamagePawn(Pawn p)
		{
			BodyPartHeight height = BodyPartHeight.Bottom;
			float statValue = this.GetStatValue(StatDefOf.TrapMeleeDamage, true);
			int num = Mathf.RoundToInt(statValue * Building_SpikesTrap.TrapDamageFactor.RandomInRange);
			int randomInRange = Building_SpikesTrap.DamageCount.RandomInRange;
			for (int i = 0; i < randomInRange; i++)
			{
				bool flag = num > 0;
				if (!flag)
				{
					break;
				}
				int num2 = Mathf.Max(1, Mathf.RoundToInt(Rand.Value * (float)num));
				num -= num2;
				DamageInfo damageInfo = new DamageInfo(DamageDefOf.Stab, num2, 0, -1f, this, null, null, DamageInfo.SourceCategory.ThingOrUnknown);
				damageInfo.SetBodyRegion(height, BodyPartDepth.Outside);
				p.TakeDamage(damageInfo);
				p.health.AddHediff(HediffDefOfTrap.PoisonedTrap, null, null);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000022AC File Offset: 0x000004AC
		protected override void SpringSub(Pawn p)
		{
			bool flag = p != null && !this.hitCount;
			if (flag)
			{
				this.DamagePawn(p);
				this.hitCount = true;
			}
			else
			{
				bool flag2 = this.hitCount;
				if (flag2)
				{
					this.hitCount = false;
				}
			}
		}

		// Token: 0x04000003 RID: 3
		private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

		// Token: 0x04000004 RID: 4
		private static readonly IntRange DamageCount = new IntRange(1, 2);

		// Token: 0x04000005 RID: 5
		private bool hitCount = false;
	}
}

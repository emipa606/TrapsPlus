using System;
using UnityEngine;
using Verse;

namespace RimWorld
{
	// Token: 0x02000009 RID: 9
	public class Building_CaltropsTrap : Building_Trap
	{
		// Token: 0x06000023 RID: 35 RVA: 0x000029C4 File Offset: 0x00000BC4
		private void DamagePawn(Pawn p)
		{
			BodyPartHeight height = BodyPartHeight.Bottom;
			float statValue = this.GetStatValue(StatDefOf.TrapMeleeDamage, true);
			int num = Mathf.RoundToInt(statValue * Building_CaltropsTrap.TrapDamageFactor.RandomInRange);
			int randomInRange = Building_CaltropsTrap.DamageCount.RandomInRange;
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
				p.health.AddHediff(HediffDefOfTrap.SlowedTrap, null, null);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002A98 File Offset: 0x00000C98
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

		// Token: 0x04000013 RID: 19
		private static readonly FloatRange TrapDamageFactor = new FloatRange(0.7f, 1.3f);

		// Token: 0x04000014 RID: 20
		private static readonly IntRange DamageCount = new IntRange(1, 2);

		// Token: 0x04000015 RID: 21
		private bool hitCount = false;
	}
}

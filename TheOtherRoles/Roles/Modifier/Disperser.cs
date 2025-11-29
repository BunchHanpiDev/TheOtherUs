using UnityEngine;

namespace TheOtherRoles.Roles.Modifier
{
	public static class Disperser
	{
		public static PlayerControl disperser;
		public static Color color = new Color32(48, 21, 89, byte.MaxValue);
		public static int remainingDisperses = 1;
		private static Sprite buttonSprite;

		public static Sprite getButtonSprite()
		{
			if (buttonSprite) return buttonSprite;
			buttonSprite = Helpers.loadSpriteFromResources("TheOtherRoles.Resources.Disperse.png", 115f);
			return buttonSprite;
		}


		public static void clearAndReload()
		{
			disperser = null;
			remainingDisperses = 1;
		}
	}
}

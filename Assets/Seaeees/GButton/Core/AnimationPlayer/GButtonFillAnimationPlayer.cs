using Seaeees.GButton.Tween;
using UnityEngine;
using UnityEngine.UI;

namespace Seaeees.GButton.Core
{
	internal class GButtonFillAnimationPlayer
	{
		private MonoBehaviour monoBehaviour;

		private bool useFillAmountAnimation;
		private Image fillImage;
		private EaseType fillImageEaseType = EaseType.Linear;
		private float fillImageDuration = 0.3f;

		private Coroutine _fillAnimationCoroutine;

		public GButtonFillAnimationPlayer(MonoBehaviour monoBehaviour, Image fillImage, EaseType fillImageEaseType, bool useFillAmountAnimation, float fillImageDuration)
		{
			this.monoBehaviour = monoBehaviour;
			this.fillImage = fillImage;
			this.fillImageEaseType = fillImageEaseType;
			this.useFillAmountAnimation = useFillAmountAnimation;
			this.fillImageDuration = fillImageDuration;
		}

		public void PlayFillAmoutAnimation(AnimationType type)
		{
			if(!fillImage) return;
			if(!useFillAmountAnimation) return;
			if(type == AnimationType.PointerEnter)
				GButtonCoroutineUtility.ResetCoroutine(ref _fillAnimationCoroutine, monoBehaviour, fillImage.AnimateFillAmount(1, fillImageDuration, fillImageEaseType));
			else if(type == AnimationType.PointerExit)
				GButtonCoroutineUtility.ResetCoroutine(ref _fillAnimationCoroutine, monoBehaviour, fillImage.AnimateFillAmount(0, fillImageDuration, fillImageEaseType));
		}
	}
}
using Seaeees.GButton.Tween;
using UnityEngine;
using UnityEngine.UI;

namespace Seaeees.GButton.Core
{
	internal class GButtonFillAnimationPlayer
	{
		private MonoBehaviour monoBehaviour;

		private bool useFillAmountAnimation;
		private EaseType fillImageEaseType = EaseType.Linear;
		private Image fillImage;
		private float fillImageDuration = 0.3f;

		private Coroutine _fillAnimationCoroutine;

		public GButtonFillAnimationPlayer(MonoBehaviour monoBehaviour, bool useFillAmountAnimation, EaseType fillImageEaseType, Image fillImage, float fillImageDuration)
		{
			this.monoBehaviour = monoBehaviour;
			this.useFillAmountAnimation = useFillAmountAnimation;
			this.fillImageEaseType = fillImageEaseType;
			this.fillImage = fillImage;
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
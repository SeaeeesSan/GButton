using Seaeees.GButton.Tween;
using UnityEngine;
using UnityEngine.UI;

namespace Seaeees.GButton.Core
{
	internal class GButtonColorAnimationPlayer
	{
		private MonoBehaviour monoBehaviour;

		private bool useColorAnimationOnHover;
		private bool useColorAnimationOnClick;
		private Image image;
		private Color colorOnHover = Color.gray;
		private Color colorOnClick = Color.gray;
		private EaseType colorEaseType = EaseType.Linear;
		private ColorSpaceType colorSpaceType = ColorSpaceType.RGB;
		private float colorDurationOnHover = 0.3f;
		private float colorDurationOnClick;

		private Coroutine _colorAnimationCoroutine;
		private Color _defaultColor;

		public GButtonColorAnimationPlayer(MonoBehaviour monoBehaviour, Image image, EaseType colorEaseType, ColorSpaceType colorSpaceType,
			bool useColorAnimationOnHover, Color colorOnHover, float colorDurationOnHover,
			bool useColorAnimationOnClick, Color colorOnClick, float colorDurationOnClick)
		{
			this.monoBehaviour = monoBehaviour;
			this.image = image;
			this.colorEaseType = colorEaseType;
			this.colorSpaceType = colorSpaceType;
			this.useColorAnimationOnHover = useColorAnimationOnHover;
			this.colorOnHover = colorOnHover;
			this.colorDurationOnHover = colorDurationOnHover;
			this.useColorAnimationOnClick = useColorAnimationOnClick;
			this.colorOnClick = colorOnClick;
			this.colorDurationOnClick = colorDurationOnClick;

			_defaultColor = image.color;
		}

		public void PlayColorAnimation(AnimationType animationType)
		{
			if(animationType == AnimationType.PointerEnter && useColorAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(colorOnHover, colorDurationOnHover, colorEaseType, colorSpaceType));
			else if(animationType == AnimationType.PointerExit && useColorAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(_defaultColor, colorDurationOnHover, colorEaseType, colorSpaceType));
			else if(animationType == AnimationType.PointerDown && useColorAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(colorOnClick, colorDurationOnClick, colorEaseType, colorSpaceType));
			else if(animationType == AnimationType.PointerUp && useColorAnimationOnClick && useColorAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(colorOnHover, colorDurationOnClick, colorEaseType, colorSpaceType));
			else if(animationType == AnimationType.PointerUp && useColorAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(_defaultColor, colorDurationOnClick, colorEaseType, colorSpaceType));
		}
	}
}

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
		private EaseType colorEaseTypeOnHover = EaseType.Linear;
		private ColorSpaceType colorSpaceTypeOnHover = ColorSpaceType.RGB;
		private EaseType colorEaseTypeOnClick = EaseType.Linear;
		private ColorSpaceType colorSpaceTypeOnClick = ColorSpaceType.RGB;
		private float colorDurationOnHover = 0.3f;
		private float colorDurationOnClick;

		private Coroutine _colorAnimationCoroutine;
		private Color _defaultColor;

		public GButtonColorAnimationPlayer(MonoBehaviour monoBehaviour, Image image,
			bool useColorAnimationOnHover, Color colorOnHover, float colorDurationOnHover, EaseType colorEaseTypeOnHover, ColorSpaceType colorSpaceTypeOnHover,
			bool useColorAnimationOnClick, Color colorOnClick, float colorDurationOnClick, EaseType colorEaseTypeOnClick, ColorSpaceType colorSpaceTypeOnClick)
		{
			this.monoBehaviour = monoBehaviour;
			this.image = image;
			this.colorEaseTypeOnClick = colorEaseTypeOnClick;
			this.colorSpaceTypeOnClick = colorSpaceTypeOnClick;
			this.colorEaseTypeOnHover = colorEaseTypeOnHover;
			this.colorSpaceTypeOnHover = colorSpaceTypeOnHover;
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
			//Pointer Enter
			if(animationType == AnimationType.PointerEnter && useColorAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(colorOnHover, colorDurationOnHover, colorEaseTypeOnHover, colorSpaceTypeOnHover));
			//Pointer Exit
			else if(animationType == AnimationType.PointerExit && useColorAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(_defaultColor, colorDurationOnHover, colorEaseTypeOnHover, colorSpaceTypeOnHover));
			//Pointer Down
			else if(animationType == AnimationType.PointerDown && useColorAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(colorOnClick, colorDurationOnClick, colorEaseTypeOnClick, colorSpaceTypeOnClick));
			//Pointer Up (+ Hover)
			else if(animationType == AnimationType.PointerUp && useColorAnimationOnClick && useColorAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(colorOnHover, colorDurationOnClick, colorEaseTypeOnClick, colorSpaceTypeOnClick));
			//Pointer Up
			else if(animationType == AnimationType.PointerUp && useColorAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _colorAnimationCoroutine, monoBehaviour, image.AnimateColor(_defaultColor, colorDurationOnClick, colorEaseTypeOnClick, colorSpaceTypeOnClick));
		}
	}
}

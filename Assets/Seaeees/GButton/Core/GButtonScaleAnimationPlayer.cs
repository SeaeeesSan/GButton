using Seaeees.GButton.Tween;
using UnityEngine;

namespace Seaeees.GButton.Core
{
	internal class GButtonScaleAnimationPlayer
	{
		private MonoBehaviour monoBehaviour;

		private bool useScaleAnimationOnClick;
		private bool useScaleAnimationOnHover;
		private RectTransform rectTransform;	
		private Vector2 scaleOnHover = Vector2.zero;
		private Vector2 scaleOnClick = Vector2.zero;
		private EaseType scaleEaseTypeOnHover = EaseType.Linear;
		private EaseType scaleEaseTypeOnClick = EaseType.Linear;
		private float scaleDurationOnClick;
		private float scaleDurationOnHover = 0.3f;

		private Coroutine _scaleAnimationCoroutine;
		private Vector2 _defaultScale;
		private Vector2 _calculatedScaleOnHover;	
		private Vector2 _calculatedScaleOnClick;

		public GButtonScaleAnimationPlayer(MonoBehaviour monoBehaviour, RectTransform rectTransform,
			bool useScaleAnimationOnHover, Vector2 scaleOnHover, float scaleDurationOnHover, EaseType scaleEaseTypeOnHover,
			bool useScaleAnimationOnClick, Vector2 scaleOnClick,  float scaleDurationOnClick, EaseType scaleEaseTypeOnClick)
		{
			this.monoBehaviour = monoBehaviour;
			this.rectTransform = rectTransform;
			this.useScaleAnimationOnHover = useScaleAnimationOnHover;
			this.scaleOnHover = scaleOnHover;
			this.scaleDurationOnHover = scaleDurationOnHover;
			this.scaleEaseTypeOnHover = scaleEaseTypeOnHover;
			this.useScaleAnimationOnClick = useScaleAnimationOnClick;
			this.scaleOnClick = scaleOnClick;
			this.scaleDurationOnClick = scaleDurationOnClick;
			this.scaleEaseTypeOnClick = scaleEaseTypeOnClick;

			_defaultScale = this.rectTransform.sizeDelta;
		}

		public void CalculateScale()
		{
			_calculatedScaleOnHover = new Vector2(_defaultScale.x + scaleOnHover.x, _defaultScale.y + scaleOnHover.y);
			_calculatedScaleOnClick = new Vector2(_defaultScale.x + scaleOnClick.x, _defaultScale.y + scaleOnClick.y);
		}

		public void PlayScaleAnimation(AnimationType animationType)
		{
			//Pointer Enter
			if(animationType == AnimationType.PointerEnter && useScaleAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_calculatedScaleOnHover, scaleDurationOnHover, scaleEaseTypeOnHover));
			//Pointer Exit
			else if(animationType == AnimationType.PointerExit && useScaleAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_defaultScale, scaleDurationOnHover, scaleEaseTypeOnHover));
			//Pointer Down
			else if(animationType == AnimationType.PointerDown && useScaleAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_calculatedScaleOnClick, scaleDurationOnClick, scaleEaseTypeOnClick));
			//Pointer Up (+ Hover)
			else if(animationType == AnimationType.PointerUp && useScaleAnimationOnClick && useScaleAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_calculatedScaleOnHover, scaleDurationOnClick, scaleEaseTypeOnClick));
			//Pointer Up
			else if(animationType == AnimationType.PointerUp && useScaleAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_defaultScale, scaleDurationOnClick, scaleEaseTypeOnClick));
		}
	}
}
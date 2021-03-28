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
		private EaseType scaleEaseType = EaseType.Linear;
		private float scaleDurationOnClick;
		private float scaleDurationOnHover = 0.3f;

		private Coroutine _scaleAnimationCoroutine;
		private Vector2 _defaultScale;
		private Vector2 _calculatedScaleOnHover;	
		private Vector2 _calculatedScaleOnClick;

		public GButtonScaleAnimationPlayer(MonoBehaviour monoBehaviour, RectTransform rectTransform, EaseType scaleEaseType,
			bool useScaleAnimationOnHover, Vector2 scaleOnHover, float scaleDurationOnHover,
			bool useScaleAnimationOnClick, Vector2 scaleOnClick,  float scaleDurationOnClick)
		{
			this.monoBehaviour = monoBehaviour;
			this.rectTransform = rectTransform;
			this.scaleEaseType = scaleEaseType;
			this.useScaleAnimationOnHover = useScaleAnimationOnHover;
			this.scaleOnHover = scaleOnHover;
			this.scaleDurationOnHover = scaleDurationOnHover;
			this.useScaleAnimationOnClick = useScaleAnimationOnClick;
			this.scaleOnClick = scaleOnClick;
			this.scaleDurationOnClick = scaleDurationOnClick;

			_defaultScale = this.rectTransform.sizeDelta;
		}

		public void CalculateScale()
		{
			_calculatedScaleOnHover = new Vector2(_defaultScale.x + scaleOnHover.x, _defaultScale.y + scaleOnHover.y);
			_calculatedScaleOnClick = new Vector2(_defaultScale.x + scaleOnClick.x, _defaultScale.y + scaleOnClick.y);
		}

		public void PlayScaleAnimation(AnimationType animationType)
		{
			if(animationType == AnimationType.PointerEnter && useScaleAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_calculatedScaleOnHover, scaleDurationOnHover, scaleEaseType));
			else if(animationType == AnimationType.PointerExit && useScaleAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_defaultScale, scaleDurationOnHover, scaleEaseType));
			else if(animationType == AnimationType.PointerDown && useScaleAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_calculatedScaleOnClick, scaleDurationOnClick, scaleEaseType));
			else if(animationType == AnimationType.PointerUp && useScaleAnimationOnClick && useScaleAnimationOnHover)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_calculatedScaleOnHover, scaleDurationOnClick, scaleEaseType));
			else if(animationType == AnimationType.PointerUp && useScaleAnimationOnClick)
				GButtonCoroutineUtility.ResetCoroutine(ref _scaleAnimationCoroutine, monoBehaviour, rectTransform.AnimateScale(_defaultScale, scaleDurationOnClick, scaleEaseType));
		}
	}
}
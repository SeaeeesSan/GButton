using System.Collections;
using Seaeees.GButton.Core;
using Seaeees.GButton.Tween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Seaeees.GButton
{
    public class GButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Coroutine _colorAnimationCoroutine;
        private Image _image;
        private Color _defaultColor;
        private Sprite _defaultSprite;

        private GButtonCore _core;

        [SerializeField] private bool useScaleAnimationOnHover;
        [SerializeField] private bool useScaleAnimationOnClick;
        [SerializeField] private bool useColorAnimationOnHover;
        [SerializeField] private bool useColorAnimationOnClick;
        [SerializeField] private bool useAudioPlayer;
        [SerializeField] private bool useFillAmountAnimation;
        [SerializeField] private bool useImageChangerOnHover;
        [SerializeField] private bool useImageChangerOnClick;
        [SerializeField] private EaseType scaleEaseType = EaseType.Linear;
        [SerializeField] private Vector2 scaleOnHover = Vector2.zero;
        [SerializeField] private float scaleDurationOnHover = 0.3f;
        [SerializeField] private Vector2 scaleOnClick = Vector2.zero;
        [SerializeField] private float scaleDurationOnClick;
        [SerializeField] private EaseType colorEaseType = EaseType.Linear;
        [SerializeField] private ColorSpaceType colorSpaceType = ColorSpaceType.RGB;
        [SerializeField] private Color colorOnHover = Color.gray;
        [SerializeField] private float colorDurationOnHover = 0.3f;
        [SerializeField] private Color colorOnClick = Color.gray;
        [SerializeField] private float colorDurationOnClick;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip hoverEnterAudioClip;
        [SerializeField] private AudioClip hoverExitAudioClip;
        [SerializeField] private AudioClip downAudioClip;
        [SerializeField] private AudioClip upAudioClip;
        [SerializeField] private EaseType fillImageEaseType = EaseType.Linear;
        [SerializeField] private Image fillImage;
        [SerializeField] private float fillImageDuration = 0.3f;
        [SerializeField] private Sprite hoverImage;
        [SerializeField] private Sprite clickImage;

        private void Awake()
        {
            var rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();

            _defaultColor = _image.color;
            _defaultSprite = _image.sprite;

            var audioPlayer = new GButtonAudioPlayer(useAudioPlayer, audioSource, hoverEnterAudioClip, hoverExitAudioClip, downAudioClip, upAudioClip);
            var fillAnimationPlayer = new GButtonFillAnimationPlayer(this, useFillAmountAnimation, fillImageEaseType, fillImage, fillImageDuration);
            var scaleAnimationPlayer = new GButtonScaleAnimationPlayer(this, rectTransform, scaleEaseType, useScaleAnimationOnHover, scaleOnHover, scaleDurationOnHover, useScaleAnimationOnClick, scaleOnClick, scaleDurationOnClick);

            _core = new GButtonCore(audioPlayer, fillAnimationPlayer, scaleAnimationPlayer);

            _core.CalculateScale();
        }

        private void OnValidate() => _core.CalculateScale();

        public void OnPointerEnter(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerEnter);

        public void OnPointerExit(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerExit);

        public void OnPointerDown(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerDown);

        public void OnPointerUp(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerUp);

        private void PlayButtonEffects(AnimationType type)
        {
            _core.PlayButtonEffects(type);
            AnimationColor(type);
            ImageChange(type);
        }

        private void AnimationColor(AnimationType animationType)
        {
            if (animationType == AnimationType.PointerEnter && useColorAnimationOnHover)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(colorOnHover, colorDurationOnHover, colorEaseType, colorSpaceType));
            else if (animationType == AnimationType.PointerExit && useColorAnimationOnHover)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(_defaultColor, colorDurationOnHover, colorEaseType, colorSpaceType));
            else if (animationType == AnimationType.PointerDown && useColorAnimationOnClick)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(colorOnClick, colorDurationOnClick, colorEaseType, colorSpaceType));
            else if (animationType == AnimationType.PointerUp && useColorAnimationOnClick && useColorAnimationOnHover)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(colorOnHover, colorDurationOnClick, colorEaseType, colorSpaceType));
            else if (animationType == AnimationType.PointerUp && useColorAnimationOnClick)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(_defaultColor, colorDurationOnClick, colorEaseType, colorSpaceType));
        }

        private void ImageChange(AnimationType animationType)
        {
            if (animationType == AnimationType.PointerEnter && useImageChangerOnHover)
                _image.sprite = hoverImage;
            else if (animationType == AnimationType.PointerExit && useImageChangerOnHover)
                _image.sprite = _defaultSprite;
            else if (animationType == AnimationType.PointerDown && useImageChangerOnClick)
                _image.sprite = clickImage;
            else if (animationType == AnimationType.PointerUp && useImageChangerOnClick && useImageChangerOnHover)
                _image.sprite = hoverImage;
            else if (animationType == AnimationType.PointerUp && useImageChangerOnClick)
                _image.sprite = _defaultSprite;
        }

        private void ResetCoroutine(ref Coroutine coroutine, IEnumerator enumerator)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(enumerator);
        }
    }
}

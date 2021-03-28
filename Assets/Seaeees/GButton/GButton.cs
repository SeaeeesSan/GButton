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
            InitializeCore();
        }

        private void OnValidate()
        {
            InitializeCore();
        }

        public void OnPointerEnter(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerEnter);

        public void OnPointerExit(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerExit);

        public void OnPointerDown(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerDown);

        public void OnPointerUp(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerUp);

        private void PlayButtonEffects(AnimationType type)
        {
            _core.PlayButtonEffects(type);
        }

        private void InitializeCore()
        {
            var rectTransform = GetComponent<RectTransform>();
            var image = GetComponent<Image>();

            var audioPlayer = new GButtonAudioPlayer(useAudioPlayer, audioSource, hoverEnterAudioClip, hoverExitAudioClip, downAudioClip, upAudioClip);
            var fillAnimationPlayer = new GButtonFillAnimationPlayer(this, useFillAmountAnimation, fillImageEaseType, fillImage, fillImageDuration);
            var scaleAnimationPlayer = new GButtonScaleAnimationPlayer(this, rectTransform, scaleEaseType, useScaleAnimationOnHover, scaleOnHover, scaleDurationOnHover, useScaleAnimationOnClick, scaleOnClick, scaleDurationOnClick);
            var colorAnimationPlayer = new GButtonColorAnimationPlayer(this, image, colorEaseType, colorSpaceType, useColorAnimationOnHover, colorOnHover, colorDurationOnHover, useColorAnimationOnClick, colorOnClick, colorDurationOnClick);
            var imageChanger = new GButtonImageChanger(image, useImageChangerOnHover, hoverImage, useImageChangerOnClick, clickImage);

            _core = new GButtonCore(audioPlayer, fillAnimationPlayer, scaleAnimationPlayer, colorAnimationPlayer, imageChanger);

            _core.CalculateScale();
        }
    }
}

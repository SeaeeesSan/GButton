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
        
        [SerializeField] private Vector2 scaleOnHover = Vector2.zero;
        [SerializeField] private float scaleDurationOnHover = 0.3f;
        [SerializeField] private EaseType scaleEaseTypeOnHover = EaseType.Linear;
        [SerializeField] private Vector2 scaleOnClick = Vector2.zero;
        [SerializeField] private float scaleDurationOnClick;
        [SerializeField] private EaseType scaleEaseTypeOnClick = EaseType.Linear;
        
        [SerializeField] private EaseType colorEaseTypeOnClick = EaseType.Linear;
        [SerializeField] private ColorSpaceType colorSpaceTypeOnClick = ColorSpaceType.RGB;
        [SerializeField] private EaseType colorEaseTypeOnHover = EaseType.Linear;
        [SerializeField] private ColorSpaceType colorSpaceTypeOnHover = ColorSpaceType.RGB;
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

            var scaleAnimationPlayer = new GButtonScaleAnimationPlayer(this, rectTransform, useScaleAnimationOnHover, scaleOnHover, scaleDurationOnHover,scaleEaseTypeOnHover, useScaleAnimationOnClick, scaleOnClick, scaleDurationOnClick,scaleEaseTypeOnClick);
            var colorAnimationPlayer = new GButtonColorAnimationPlayer(this, image, useColorAnimationOnHover, colorOnHover, colorDurationOnHover, colorEaseTypeOnHover,colorSpaceTypeOnHover, useColorAnimationOnClick, colorOnClick, colorDurationOnClick,colorEaseTypeOnClick,colorSpaceTypeOnClick);
            var audioPlayer = new GButtonAudioPlayer(useAudioPlayer, audioSource, hoverEnterAudioClip, hoverExitAudioClip, downAudioClip, upAudioClip);
            var imageChanger = new GButtonImageChanger(image, useImageChangerOnHover, hoverImage, useImageChangerOnClick, clickImage);
            var fillAnimationPlayer = new GButtonFillAnimationPlayer(this, fillImage, fillImageEaseType, useFillAmountAnimation, fillImageDuration);

            _core = new GButtonCore(scaleAnimationPlayer, colorAnimationPlayer, audioPlayer, imageChanger, fillAnimationPlayer);

            _core.CalculateScale();
        }
    }
}

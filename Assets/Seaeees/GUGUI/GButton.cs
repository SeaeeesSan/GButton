using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Seaeees.GUGUI.Tween;

namespace Seaeees.GUGUI
{
    public class GButton : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Coroutine _scaleAnimationCoroutine;
        private Coroutine _colorAnimationCoroutine;
        private Coroutine _fillAnimationCoroutine;
        
        private RectTransform _rectTransform;
        private Image _image;
        private Image _fillImage;
        
        private Color _defaultColor;
        private Vector2 _defaultScale;
        private Sprite _defaultSprite;
        
        private Vector2 _calculatedScaleOnHover;
        private Vector2 _calculatedScaleOnClick;
        
        //[SerializeField] private GButtonTemplate template;

        [SerializeField] private bool useScaleAnimationOnHover;
        [SerializeField] private bool useScaleAnimationOnClick;
        [SerializeField] private bool useColorAnimationOnHover;
        [SerializeField] private bool useColorAnimationOnClick;
        [SerializeField] private bool useAudioPlayer;
        [SerializeField] private bool useFillAmountAnimation;
        [SerializeField] private bool useImageChangerOnHover;
        [SerializeField] private bool useImageChangerOnClick;

        [SerializeField] private EaseType scaleEaseType = EaseType.Linear;
        [SerializeField] private Vector2 scaleOnHover;
        [SerializeField] private float scaleDurationOnHover = 0.1f;
        [SerializeField] private Vector2 scaleOnClick;
        [SerializeField] private float scaleDurationOnClick = 0.1f;

        [SerializeField] private Color colorOnHover = Color.gray;
        [SerializeField] private float colorDurationOnHover = 0.1f;
        [SerializeField] private Color colorOnClick = Color.gray;
        [SerializeField] private float colorDurationOnClick = 0.1f;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip hoverEnterAudioClip;
        [SerializeField] private AudioClip hoverExitAudioClip;
        [SerializeField] private AudioClip downAudioClip;
        [SerializeField] private AudioClip upAudioClip;

        [SerializeField] private EaseType fillImageEaseType = EaseType.Linear;
        [SerializeField] private Image fillImage;
        [SerializeField] private float fillImageDuration = 0.1f;
        [SerializeField] private Sprite hoverImage;
        [SerializeField] private Sprite clickImage;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
            
            var delta = _rectTransform.sizeDelta;

            _fillImage = fillImage;
            _defaultScale = delta;
            _defaultColor = _image.color;
            _defaultSprite = _image.sprite;
            
            _calculatedScaleOnHover = new Vector2(delta.x + scaleOnHover.x, delta.y + scaleOnHover.y);
            _calculatedScaleOnClick = new Vector2(delta.x + scaleOnClick.x, delta.y + scaleOnClick.y);
        }

        public void OnPointerEnter(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerEnter);

        public void OnPointerExit(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerExit);

        public void OnPointerDown(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerDown);

        public void OnPointerUp(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerUp);
        
        private void PlayButtonEffects(AnimationType type)
        {
            PlayAudio(type);
            AnimationFillAmount(type);
            AnimationScale(type);
            AnimationColor(type);
            ImageChange(type);
            
            //TODO:クリック後の動作
            if(type == AnimationType.PointerUp) PlayButtonEffects(AnimationType.PointerEnter);
        }
        
        private void PlayAudio(AnimationType animationType)
        {
            if (!audioSource) return;
            switch (animationType)
            {
                case AnimationType.PointerEnter when useAudioPlayer:
                    audioSource.PlayOneShot(hoverEnterAudioClip);
                    break;
                case AnimationType.PointerExit when useAudioPlayer:
                    audioSource.PlayOneShot(hoverExitAudioClip);
                    break;
                case AnimationType.PointerDown when useAudioPlayer:
                    audioSource.PlayOneShot(downAudioClip);
                    break;
                case AnimationType.PointerUp when useAudioPlayer:
                    audioSource.PlayOneShot(upAudioClip);
                    break;
            }
        }
        
        private void AnimationFillAmount(AnimationType animationType)
        {
            if (!_fillImage) return;
            switch (animationType)
            {
                case AnimationType.PointerEnter when useFillAmountAnimation:
                    ResetCoroutine(ref _fillAnimationCoroutine, _fillImage.AnimateFillAmount(1, fillImageDuration, fillImageEaseType));
                    break;
                case AnimationType.PointerExit when useFillAmountAnimation:
                    ResetCoroutine(ref _fillAnimationCoroutine, _fillImage.AnimateFillAmount(0, fillImageDuration, fillImageEaseType));
                    break;
            }
        }
        
        private void AnimationScale(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.PointerEnter when useScaleAnimationOnHover:
                    ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_calculatedScaleOnHover, scaleDurationOnHover, scaleEaseType));
                    break;
                case AnimationType.PointerExit when useScaleAnimationOnHover:
                    ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_defaultScale, scaleDurationOnHover, scaleEaseType));
                    break;
                case AnimationType.PointerDown when useScaleAnimationOnClick:
                    ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_calculatedScaleOnClick, scaleDurationOnClick, scaleEaseType));
                    break;
                case AnimationType.PointerUp when useScaleAnimationOnClick:
                    ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_defaultScale, scaleDurationOnClick, scaleEaseType));
                    break;
            }
        }
        
        private void AnimationColor(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.PointerEnter when useColorAnimationOnHover:
                    ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(colorOnHover, colorDurationOnHover)); 
                    break;
                case AnimationType.PointerExit when useColorAnimationOnHover:
                    ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(_defaultColor, colorDurationOnHover)); 
                    break;
                case AnimationType.PointerDown when useColorAnimationOnClick:
                    ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(colorOnClick, colorDurationOnClick)); 
                    break;
                case AnimationType.PointerUp when useColorAnimationOnClick:
                    ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(_defaultColor, colorDurationOnClick)); 
                    break;
            }
        }
        
        private void ImageChange(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.PointerEnter when useImageChangerOnHover:
                    _image.sprite = hoverImage;
                    break;
                case AnimationType.PointerExit when useImageChangerOnHover:
                    _image.sprite = _defaultSprite;
                    break;
                case AnimationType.PointerDown when useImageChangerOnClick:
                    _image.sprite = clickImage;
                    break;
                case AnimationType.PointerUp when useImageChangerOnClick:
                    _image.sprite = _defaultSprite;
                    break;
            }
        }
        
        private void ResetCoroutine(ref Coroutine coroutine, IEnumerator enumerator)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(enumerator);
        }
    }
}

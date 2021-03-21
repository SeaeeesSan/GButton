using System.Collections;
using Seaeees.GUGUI.Tween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Seaeees.GUGUI
{
    public class GButtonWithTemplate : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Coroutine _scaleAnimationCoroutine;
        private Coroutine _colorAnimationCoroutine;
        private RectTransform _rectTransform;
        private Image _image;
        private Color _defaultColor;
        private Vector2 _defaultScale;
        private Sprite _defaultSprite;
        private Vector2 _calculatedScaleOnHover;
        private Vector2 _calculatedScaleOnClick;

        [SerializeField] private GButtonTemplate template;
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
            
            _defaultScale = _rectTransform.sizeDelta;
            _defaultColor = _image.color;
            _defaultSprite = _image.sprite;
            
            _calculatedScaleOnHover = new Vector2(_defaultScale.x + template.scaleOnHover.x, _defaultScale.y + template.scaleOnHover.y);
            _calculatedScaleOnClick = new Vector2(_defaultScale.x + template.scaleOnClick.x, _defaultScale.y + template.scaleOnClick.y);
        }

        public void OnPointerEnter(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerEnter);

        public void OnPointerExit(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerExit);

        public void OnPointerDown(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerDown);

        public void OnPointerUp(PointerEventData eventData) => PlayButtonEffects(AnimationType.PointerUp);
        
        private void PlayButtonEffects(AnimationType type)
        {
            PlayAudio(type);
            AnimationScale(type);
            AnimationColor(type);
            ImageChange(type);
            
            //TODO:クリック後の動作
            if(type == AnimationType.PointerUp) PlayButtonEffects(AnimationType.PointerEnter);
        }
        
        private void PlayAudio(AnimationType animationType)
        {
            if (!template.audioSource) return;
            if (!template.useAudioPlayer) return;
            if (animationType == AnimationType.PointerEnter)
                template.audioSource.PlayOneShot(template.hoverEnterAudioClip);
            else if (animationType == AnimationType.PointerExit)
                template.audioSource.PlayOneShot(template.hoverExitAudioClip);
            else if (animationType == AnimationType.PointerDown)
                template.audioSource.PlayOneShot(template.downAudioClip);
            else if (animationType == AnimationType.PointerUp) 
                template.audioSource.PlayOneShot(template.upAudioClip);
        }
        private void AnimationScale(AnimationType animationType)
        {
            if (animationType == AnimationType.PointerEnter && template.useScaleAnimationOnHover)
                ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_calculatedScaleOnHover, template.scaleDurationOnHover, template.scaleEaseType));
            else if (animationType == AnimationType.PointerExit && template.useScaleAnimationOnHover)
                ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_defaultScale, template.scaleDurationOnHover, template.scaleEaseType));
            else if (animationType == AnimationType.PointerDown && template.useScaleAnimationOnClick)
                ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_calculatedScaleOnClick, template.scaleDurationOnClick, template.scaleEaseType));
            else if (animationType == AnimationType.PointerUp && template.useScaleAnimationOnClick)
                ResetCoroutine(ref _scaleAnimationCoroutine, _rectTransform.AnimateScale(_defaultScale, template.scaleDurationOnClick, template.scaleEaseType));
        }
        
        private void AnimationColor(AnimationType animationType)
        {
            if (animationType == AnimationType.PointerEnter && template.useColorAnimationOnHover)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(template.colorOnHover, template.colorDurationOnHover));
            else if (animationType == AnimationType.PointerExit && template.useColorAnimationOnHover)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(_defaultColor, template.colorDurationOnHover));
            else if (animationType == AnimationType.PointerDown && template.useColorAnimationOnClick)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(template.colorOnClick, template.colorDurationOnClick));
            else if (animationType == AnimationType.PointerUp && template.useColorAnimationOnClick)
                ResetCoroutine(ref _colorAnimationCoroutine, _image.AnimateColor(_defaultColor, template.colorDurationOnClick));
        }
        
        private void ImageChange(AnimationType animationType)
        {
            if (animationType == AnimationType.PointerEnter && template.useImageChangerOnHover)
                _image.sprite = template.hoverImage;
            else if (animationType == AnimationType.PointerExit && template.useImageChangerOnHover)
                _image.sprite = _defaultSprite;
            else if (animationType == AnimationType.PointerDown && template.useImageChangerOnClick)
                _image.sprite = template.clickImage;
            else if (animationType == AnimationType.PointerUp && template.useImageChangerOnClick) 
                _image.sprite = _defaultSprite;
        }
        
        private void ResetCoroutine(ref Coroutine coroutine, IEnumerator enumerator)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(enumerator);
        }
    }
    
}

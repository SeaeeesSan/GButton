using System;
using System.Collections;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Seaeees.GUGUI.Tween;
using UnityEngine.Serialization;

namespace Seaeees.GUGUI
{
    [CreateAssetMenu(fileName = "GButtonTemplate", menuName = "GUGUI/GButtonTemplate")]
    public class GButtonTemplate : ScriptableObject
    {
        [SerializeField] public bool useScaleAnimationOnHover;
        [SerializeField] public bool useScaleAnimationOnClick;
        [SerializeField] public bool useColorAnimationOnHover;
        [SerializeField] public bool useColorAnimationOnClick;
        [SerializeField] public bool useAudioPlayer;
        [SerializeField] public bool useFillAmountAnimation;
        [SerializeField] public bool useImageChangerOnHover;
        [SerializeField] public bool useImageChangerOnClick;
        [SerializeField] public EaseType scaleEaseType = EaseType.Linear;
        [SerializeField] public Vector2 scaleOnHover;
        [SerializeField] public float scaleDurationOnHover = 0.1f;
        [SerializeField] public Vector2 scaleOnClick;
        [SerializeField] public float scaleDurationOnClick = 0.1f;
        [SerializeField] public Color colorOnHover = Color.gray;
        [SerializeField] public float colorDurationOnHover = 0.1f;
        [SerializeField] public Color colorOnClick = Color.gray;
        [SerializeField] public float colorDurationOnClick = 0.1f;
        [SerializeField] public AudioSource audioSource;
        [SerializeField] public AudioClip hoverEnterAudioClip;
        [SerializeField] public AudioClip hoverExitAudioClip;
        [SerializeField] public AudioClip downAudioClip;
        [SerializeField] public AudioClip upAudioClip;
        [SerializeField] public Sprite hoverImage;
        [SerializeField] public Sprite clickImage;
    }
}

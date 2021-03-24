using System;
using UnityEngine;
namespace Seaeees.GButton.Tween
{
    public class ColorEase
    {
        public static Color ColorLerpWithEase(Color from, Color to, float t, EaseType ease, ColorSpaceType colorSpace)
        {
            switch (colorSpace)
            {
                case ColorSpaceType.RGB:
                    return RGBColorLerp(from, to, t, ease);
                case ColorSpaceType.HSV:
                    return HSVColorLerp(from, to, t, ease);
                default:
                    throw new ArgumentOutOfRangeException(nameof(colorSpace), colorSpace, null);
            }
        }

        private static Color RGBColorLerp(Color from, Color to, float t, EaseType ease)
        {
            float alpha = Ease.LerpWithEase(from.a, to.a, t, ease);
            float r = Ease.LerpWithEase(from.r, to.r, t, ease);
            float g = Ease.LerpWithEase(from.g, to.g, t, ease);
            float b = Ease.LerpWithEase(from.b, to.b, t, ease);

            return new Color(r, g, b, alpha);
        }

        private static Color HSVColorLerp(Color from, Color to, float t, EaseType ease)
        {
            float fromH, fromS, fromV;
            float toH, toS, toV;
            Color.RGBToHSV(from, out fromH, out fromS, out fromV);
            Color.RGBToHSV(to, out toH, out toS, out toV);
            float alpha = Ease.LerpWithEase(from.a, to.a, t, ease);
            float h = Ease.LerpWithEase(fromH, toH, t, ease);
            float s = Ease.LerpWithEase(fromS, toS, t, ease);
            float v = Ease.LerpWithEase(fromV, toV, t, ease);

            return Color.HSVToRGB(h,s,v);
        }
    }
}

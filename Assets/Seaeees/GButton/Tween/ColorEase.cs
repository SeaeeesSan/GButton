using UnityEngine;
namespace Seaeees.GButton.Tween
{
    public class ColorEase
    {
        public static Color ColorLerpWithEase(Color from, Color to, float t, EaseType ease)
        {
            float alpha = Ease.LerpWithEase(from.a, to.a, t, ease);
            float r = Ease.LerpWithEase(from.r, to.r, t, ease);
            float g = Ease.LerpWithEase(from.g, to.g, t, ease);
            float b = Ease.LerpWithEase(from.b, to.b, t, ease);

            return new Color(r, g, b, alpha);
        }
    }
}

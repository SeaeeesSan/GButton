using System;

namespace Seaeees.GUGUI.Tween
{
    public delegate float Easing(float a,float b,float t);
    public static class Ease
    {
        public static float LerpWhithEase(float a, float b, float t, EaseType ease)
        {
            return GetEase(ease)(a,b,t);
        }

        private static Easing GetEase(EaseType type)
        {
            return type switch
            {
                EaseType.Linear => Linear,
                EaseType.QuadIn => QuadIn,
                EaseType.QuadOut => QuadOut,
                EaseType.QuadInOut => QuadInOut,
                EaseType.CubicIn => CubicIn,
                EaseType.CubicOut => CubicOut,
                EaseType.CubicInOut => CubicInOut,
                EaseType.QuartIn => QuartIn,
                EaseType.QuartOut => QuartOut,
                EaseType.QuartInOut => QuartInOut,
                EaseType.QuintIn => QuintIn,
                EaseType.QuintOut => QuintOut,
                EaseType.QuintInOut => QuintInOut,
                EaseType.ExpoIn => ExpoIn,
                EaseType.ExpoOut => ExpoOut,
                EaseType.ExpoInOut => ExpoInOut,
                _ => Linear
            };
        }
        
        private static float Linear(float a, float b,float t)
        {
            b -= a;
            t /= 1;
            return b * t + a;
        }
        
        private static float QuadIn(float a, float b,float t)
        {
            b -= a;
            t /= 1;
            return b * t * t + a;
        }
        
        private static float QuadOut(float a, float b,float t)
        {
            b -= a;
            t /= 1;
            return -b * t*(t-2) + a;
        }
        
        private static float QuadInOut(float a, float b,float t)
        {
            b -= a;
            t /= 0.5f;
            if (t < 1) return b/2*t*t + a;
            t--;
            return -b/2 * (t*(t-2) - 1) + a;
        }
        private static float CubicIn(float a, float b,float t)
        {
            b -= a;
            t /= 1;
            return b * t * t * t + a;
        }
        
        private static float CubicOut(float a, float b,float t)
        {
            b -= a;
            t /= 1;
            t--;
            return b*(t*t*t + 1) + a;
        }
        
        private static float CubicInOut(float a, float b,float t)
        {
            b -= a;
            t /= 0.5f;
            if (t < 1) return b/2*t*t*t + a;
            t -= 2;
            return b / 2 * (t * t * t + 2) + a;
        }
        
        private static float QuartIn(float a, float b,float t)
        {
            t /= 1;
            return b*t*t*t*t + a;
        }
        
        private static float QuartOut(float a, float b,float t)
        {
            t /= 1;
            t--;
            return -b * (t*t*t*t - 1) + a;
        }
        
        private static float QuartInOut(float a, float b,float t)
        {
            b -= a;
            t /= 0.5f;
            if (t < 1) return b/2*t*t*t*t + a;
            t -= 2;
            return -b/2 * (t*t*t*t - 2) + a;
        }
        
        private static float QuintIn(float a, float b,float t)
        {
            t /= 1;
            return b*t*t*t*t*t + a;
        }
        
        private static float QuintOut(float a, float b,float t)
        {
            t /= 1;
            t--;
            return b*(t*t*t*t*t + 1) + a;
        }
        
        private static float QuintInOut(float a, float b,float t)
        {
            b -= a;
            t /= 0.5f;
            if (t < 1) return b/2*t*t*t*t*t + a;
            t -= 2;
            return b/2*(t*t*t*t*t + 2) + a;
        }
        
        private static float ExpoIn(float a, float b,float t)
        {
            b -= a;
            t /= 1;
            return b * (float)Math.Pow( 2, 10 * (t - 1) ) + a;
        }
        
        private static float ExpoOut(float a, float b,float t)
        {
            b -= a;
            t /= 1;
            return b * (float)(-Math.Pow( 2, -10 * t ) + 1 ) + a;
        }
        
        private static float ExpoInOut(float a, float b,float t)
        {
            b -= a;
            t /= 0.5f;
            if (t < 1) return b/2 * (float)Math.Pow( 2, 10 * (t - 1) ) + a;
            t--;
            return b/2 * (float)(-Math.Pow( 2, -10 * t) + 2 ) + a;
        }
    }
}

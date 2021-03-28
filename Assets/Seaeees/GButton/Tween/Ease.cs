using System;

namespace Seaeees.GButton.Tween
{
    public static class Ease
    {
        public static float LerpWithEase(float a, float b, float t, EaseType ease)
        {
            switch (ease)
            {
                case EaseType.Linear:
                    return Linear(a, b, t);
                case EaseType.QuadIn:
                    return QuadIn(a, b, t);
                case EaseType.QuadOut:
                    return QuadOut(a, b, t);
                case EaseType.QuadInOut:
                    return QuadInOut(a, b, t);
                case EaseType.CubicIn:
                    return CubicIn(a, b, t);
                case EaseType.CubicOut:
                    return CubicOut(a, b, t);
                case EaseType.CubicInOut:
                    return CubicInOut(a, b, t);
                case EaseType.QuartIn:
                    return QuartIn(a, b, t);
                case EaseType.QuartOut:
                    return QuartOut(a, b, t);
                case EaseType.QuartInOut:
                    return QuartInOut(a, b, t);
                case EaseType.QuintIn:
                    return QuintIn(a, b, t);
                case EaseType.QuintOut:
                    return QuintOut(a, b, t);
                case EaseType.QuintInOut:
                    return QuintInOut(a, b, t);
                case EaseType.ExpoIn:
                    return ExpoIn(a, b, t);
                case EaseType.ExpoOut:
                    return ExpoOut(a, b, t);
                case EaseType.ExpoInOut:
                    return ExpoInOut(a, b, t);
                case EaseType.CircIn:
                    return CircIn(a, b, t);
                case EaseType.CircOut:
                    return CircOut(a, b, t);
                case EaseType.CircInOut:
                    return CircInOut(a, b, t);
                default:
                    return Linear(a, b, t);
            }
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
            b -= a;
            t /= 1;
            return b*t*t*t*t + a;
        }

        private static float QuartOut(float a, float b,float t)
        {
            b -= a;
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
            b -= a;
            t /= 1;
            return b*t*t*t*t*t + a;
        }

        private static float QuintOut(float a, float b,float t)
        {
            b -= a;
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

        private static float CircIn(float a, float b, float t)
        {
            b -= a;
            t /= 1;
            return -b * (float)(Math.Sqrt(1 - t * t) - 1) + a;
        }

        private static float CircOut(float a, float b, float t)
        {
            b -= a;
            t /= 1;
            t--;
            return b * (float)Math.Sqrt(1 - t * t) + a;
        }

        private static float CircInOut(float a, float b, float t)
        {
            b -= a;
            t /= 0.5f;
            if (t < 1) return -b / 2 * (float) (Math.Sqrt(1 - t * t) - 1) + a;
            t -= 2;
            return b / 2 * (float)(Math.Sqrt(1 - t * t) + 1) + a;
        }
    }
}

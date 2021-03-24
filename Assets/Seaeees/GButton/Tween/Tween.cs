using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Seaeees.GButton.Tween
{
    public static class Tween
    {
        public static IEnumerator AnimateScale(this RectTransform obj, Vector2 to, float interval,EaseType ease)
        {
            if(!obj) yield break;
            Vector2 pos = obj.sizeDelta;
            float timer = 0;
            while (timer <= interval) {
                if (interval == 0) break;
                obj.sizeDelta = new Vector2(Ease.LerpWithEase (pos.x, to.x, timer / interval,ease),Ease.LerpWithEase (pos.y, to.y, timer / interval,ease));
                timer += Time.unscaledDeltaTime;
                yield return null;
            }
            obj.sizeDelta = to;
        }

        public static IEnumerator AnimateColor(this Image obj, Color to, float interval, EaseType ease,ColorSpaceType colorSpace)
        {
            if(!obj) yield break;
            Color col = obj.color;
            float timer = 0;
            while (timer <= interval)
            {
                if (interval == 0) break;
                obj.color = ColorEase.ColorLerpWithEase(col, to, timer / interval,ease,colorSpace);
                timer += Time.unscaledDeltaTime;
                yield return null;
            }
            obj.color = to;
        }

        public static IEnumerator AnimateFillAmount(this Image obj, float to, float interval, EaseType ease)
        {
            if(!obj) yield break;
            float fill = obj.fillAmount;
            float timer = 0;
            while (timer <= interval)
            {
                if (interval == 0) break;
                obj.fillAmount = Ease.LerpWithEase(fill, to, timer / interval,ease);
                timer += Time.unscaledDeltaTime;
                yield return null;
            }
            obj.fillAmount = to;
        }
    }
}

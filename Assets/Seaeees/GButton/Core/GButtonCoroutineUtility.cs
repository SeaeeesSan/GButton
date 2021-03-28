using System.Collections;
using UnityEngine;

namespace Seaeees.GButton.Core
{
	internal class GButtonCoroutineUtility
	{
		public static void ResetCoroutine(ref Coroutine coroutine, MonoBehaviour ownMonoBehaviour,IEnumerator enumerator)
		{
			if(coroutine != null) ownMonoBehaviour.StopCoroutine(coroutine);
			coroutine = ownMonoBehaviour.StartCoroutine(enumerator);
		}
	}
}
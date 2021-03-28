using Seaeees.GButton.Tween;
using UnityEngine;
using UnityEngine.UI;

namespace Seaeees.GButton.Core
{
	internal class GButtonImageChanger
	{
		private Image image;
		private bool useImageChangerOnHover;
		private bool useImageChangerOnClick;
		private Sprite hoverSprite;
		private Sprite clickSprite;

		private Sprite _defaultSprite;

		public GButtonImageChanger(Image image, bool useImageChangerOnHover, Sprite hoverSprite, bool useImageChangerOnClick, Sprite clickSprite)
		{
			this.image = image;
			this.useImageChangerOnHover = useImageChangerOnHover;
			this.hoverSprite = hoverSprite;
			this.useImageChangerOnClick = useImageChangerOnClick;
			this.clickSprite = clickSprite;

			_defaultSprite = this.image.sprite;
		}

		public void ChangeImage(AnimationType animationType)
		{
			if(animationType == AnimationType.PointerEnter && useImageChangerOnHover)
				image.sprite = hoverSprite;
			else if(animationType == AnimationType.PointerExit && useImageChangerOnHover)
				image.sprite = _defaultSprite;
			else if(animationType == AnimationType.PointerDown && useImageChangerOnClick)
				image.sprite = clickSprite;
			else if(animationType == AnimationType.PointerUp && useImageChangerOnClick && useImageChangerOnHover)
				image.sprite = hoverSprite;
			else if(animationType == AnimationType.PointerUp && useImageChangerOnClick)
				image.sprite = _defaultSprite;
		}
	}
}
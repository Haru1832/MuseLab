/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using UnityEngine;

namespace FancyScrollView.Example03
{
    class ItemData
    {
        public string Message { get; }
        public Sprite Image { get; }

        public ItemData(string message,Sprite image)
        {
            Message = message;
            Image = image;
        }
    }
}

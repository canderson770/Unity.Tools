namespace UnityEngine.UI
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Sets color of image, if image is not null
        /// </summary>
        public static void SetColorIfNotNull(this Image image, Color color)
        {
            if (image != null)
                image.color = color;
        }

        /// <summary>
        /// Sets sprite of image, if image is not null
        /// </summary>
        public static void SetSpriteIfNotNull(this Image image, Sprite sprite)
        {
            if (image != null)
                image.sprite = sprite;
        }
    }
}
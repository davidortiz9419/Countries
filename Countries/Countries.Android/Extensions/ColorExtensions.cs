namespace Countries.Droid.Extensions
{
    using Android.Content;
    using Android.Graphics;
    using Android.Util;

    public static class ColorExtensions
    {
        public static Color GetColorByResourceId(this Context context, int resId)
        {
            var themeAccentColor = new TypedValue();
            context.Theme.ResolveAttribute(resId, themeAccentColor, true);
            return new Color(themeAccentColor.Data);
        }
    }
}
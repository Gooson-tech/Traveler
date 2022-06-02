using Microsoft.Xna.Framework;

namespace Nez.UI
{
    public static class ScalingExt
    {
        /// <summary>
        /// Returns the size of the source scaled to the target
        /// </summary>
        /// <param name="self">Self.</param>
        /// <param name="sourceWidth">Source width.</param>
        /// <param name="sourceHeight">Source height.</param>
        /// <param name="targetWidth">Target width.</param>
        /// <param name="targetHeight">Target height.</param>
        public static Vector2 Apply(this Scaling self, float sourceWidth, float sourceHeight, float targetWidth,
            float targetHeight)
        {
            var temp = new Vector2();
            switch (self)
            {
                case Scaling.Fit:
                {
                    var targetRatio = targetHeight / targetWidth;
                    var sourceRatio = sourceHeight / sourceWidth;
                    var scale = targetRatio > sourceRatio ? targetWidth / sourceWidth : targetHeight / sourceHeight;
                    temp.X = sourceWidth * scale;
                    temp.Y = sourceHeight * scale;
                    break;
                }
                case Scaling.Fill:
                {
                    var targetRatio = targetHeight / targetWidth;
                    var sourceRatio = sourceHeight / sourceWidth;
                    var scale = targetRatio < sourceRatio ? targetWidth / sourceWidth : targetHeight / sourceHeight;
                    temp.X = sourceWidth * scale;
                    temp.Y = sourceHeight * scale;
                    break;
                }
                case Scaling.FillX:
                {
                    var scale = targetWidth / sourceWidth;
                    temp.X = sourceWidth * scale;
                    temp.Y = sourceHeight * scale;
                    break;
                }
                case Scaling.FillY:
                {
                    var scale = targetHeight / sourceHeight;
                    temp.X = sourceWidth * scale;
                    temp.Y = sourceHeight * scale;
                    break;
                }
                case Scaling.Stretch:
                    temp.X = targetWidth;
                    temp.Y = targetHeight;
                    break;
                case Scaling.StretchX:
                    temp.X = targetWidth;
                    temp.Y = sourceHeight;
                    break;
                case Scaling.StretchY:
                    temp.X = sourceWidth;
                    temp.Y = targetHeight;
                    break;
                case Scaling.None:
                    temp.X = sourceWidth;
                    temp.Y = sourceHeight;
                    break;
            }

            return temp;
        }
    }
}
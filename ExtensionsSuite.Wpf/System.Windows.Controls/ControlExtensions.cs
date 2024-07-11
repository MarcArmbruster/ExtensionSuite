namespace System.Windows.Controls
{
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public static class ControlExtensions
    {
        /// <summary>
        /// Save current view of the control as PNG image.
        /// </summary>
        /// <param name="target">The control to be saved.</param>
        /// <param name="filePath">The 'save as' file path.</param>
        public static void SaveAsPng(this Control target, string filePath) 
        {
            //Encoding the rendered bitmap as PNG
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            SaveAsPicture(target, filePath, encoder);
        }

        /// <summary>
        /// Save current view of the control as JPG image.
        /// </summary>
        /// <param name="target">The control to be saved.</param>
        /// <param name="filePath">The 'save as' file path.</param>
        public static void SaveAsJpg(this Control target, string filePath)
        {
            //Encoding the rendered bitmap as JPG
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            SaveAsPicture(target, filePath, encoder);
        }

        /// <summary>
        /// Save current view of the control as GIF image.
        /// </summary>
        /// <param name="target">The control to be saved.</param>
        /// <param name="filePath">The 'save as' file path.</param>
        public static void SaveAsGif(this Control target, string filePath)
        {
            //Encoding the rendered bitmap as GIF
            GifBitmapEncoder encoder = new GifBitmapEncoder();
            SaveAsPicture(target, filePath, encoder);
        }

        /// <summary>
        /// Save current view of the control as GIF image.
        /// </summary>
        /// <param name="target">The control to be saved.</param>
        /// <param name="filePath">The 'save as' file path.</param>
        public static void SaveAsBmp(this Control target, string filePath)
        {
            //Encoding the rendered bitmap as GIF
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            SaveAsPicture(target, filePath, encoder);
        }

        /// <summary>
        /// Save current view of the control as a picture.
        /// </summary>
        /// <param name="target">The control to be saved.</param>
        /// <param name="filePath">The 'save as' file path.</param>
        private static void SaveAsPicture(this Control target, string filePath, BitmapEncoder encoder)
        {
            // Render the Visual with specified parameters of:
            // Widht, Height, horizontal DPI of the bitmap, vertical DPI of the bitmap,
            // The format of the bitmap
            RenderTargetBitmap renderTargetBitmap
                = new RenderTargetBitmap(
                    (int)target.ActualWidth,
                    (int)target.ActualHeight,
                    96,
                    96,
                    PixelFormats.Pbgra32);

            renderTargetBitmap.Render(target);

            //Encoding the rendered bitmap 
            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            // Save the image on the desired location
            using (Stream stream = File.Create(filePath))
            {
                encoder.Save(stream);
            }
        }
    }
}
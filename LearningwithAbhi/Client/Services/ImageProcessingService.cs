using ImageMagick;

public class ImageProcessingService
{
    public void ResizeImage(string inputPath, string outputPath, int width, int height)
    {
       
          using (MagickImage image = new MagickImage(inputPath))
        {
            image.Resize(width, height);
            image.Write(outputPath);
        }
    }
}

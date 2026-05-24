
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

public class ImageProcessingService
{
    static void Main(string[] args)
    {
        // Paths to the input and output images
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Desired width and height
        int newWidth = 800;
        int newHeight = 600;

        ResizeTheImage(inputPath, outputPath, newWidth, newHeight);
    }

   public static void ResizeTheImage(string inputPath, string outputPath, int width, int height)
    {
        using (Image image = Image.Load(inputPath))
        {
            image.Mutate(x => x.Resize(width, height));
            image.Save(outputPath, new JpegEncoder());
        }
    }
}

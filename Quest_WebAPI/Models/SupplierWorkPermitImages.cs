using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace WebAPI.Models;

public static class SupplierWorkPermitImages
{
    public static void ImageGrid(this IContainer parent, List<byte[]> images, int rowWidth = 523, int imageWidth = 261)
    {
        if (images?.Count > 0)
        {
            int imageCount = images.Count;
            int perRowImages = rowWidth / imageWidth;
            int requiredRow = 1;
            if (imageCount > perRowImages)
                requiredRow = (int)Math.Ceiling(Convert.ToDouble(imageCount / perRowImages));

            parent.Column(c =>
            {
                for (int i = 0; i < requiredRow; i++)
                {
                    c.Item().Row(row =>
                    {
                        for (int j = 0; j < perRowImages; j++)
                        {
                            int imageNumber = i * perRowImages + j;

                            if (imageNumber < imageCount)
                                row.AutoItem().Width(imageWidth).Padding(2).Image(images[imageNumber]);
                        }
                    });
                }
            });
        }
    }

    public static List<byte[]> GetCheckBoxImagesData()
    {
        return new List<byte[]>
        {
            File.ReadAllBytes("wwwroot\\images\\3.png"),
            File.ReadAllBytes("wwwroot\\images\\4.png"),
            File.ReadAllBytes("wwwroot\\images\\5.png"),
            //File.ReadAllBytes("wwwroot\\images\\6.png"),
        };
    }

    public static List<byte[]> GetRadiosImagesData()
    {
        return new List<byte[]>
        {
            File.ReadAllBytes("wwwroot\\images\\1.png"),
            File.ReadAllBytes("wwwroot\\images\\2.png"),
            File.ReadAllBytes("wwwroot\\images\\3.png"),
            File.ReadAllBytes("wwwroot\\images\\4.png"),
            File.ReadAllBytes("wwwroot\\images\\5.png"),
            File.ReadAllBytes("wwwroot\\images\\6.png"),
        };
    }
}

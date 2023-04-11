using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Легковаговик
{
    internal class Class1
    {
        // Типы облаков
        public enum CloudType
        {
            small,
            midle,
            big
        }

        // Картинки для облаков
        public static class CloudImageFactory
        {
            private static Dictionary<CloudType, Image> _cloudImages;

            static CloudImageFactory()
            {
                _cloudImages = new Dictionary<CloudType, Image>();

                // Загрузка картинок облаков
                _cloudImages[CloudType.small] = Image.FromFile("\"D:\\Легковаговик\\64546_8414.jpg\"");
                _cloudImages[CloudType.midle] = Image.FromFile("\"D:\\Легковаговик\\134353168712334_2420.jpg\"");
                _cloudImages[CloudType.big] = Image.FromFile("\"D:\\Легковаговик\\images.jpg\"");
            }

            public static Image GetCloudImage(CloudType type)
            {
                return _cloudImages[type];
            }
        }

        // Облако - легковес
        public class Cloud
        {
            public CloudType Type { get; set; }
            public Image Image { get; set; }
            public Point Position { get; set; }

            public Cloud(CloudType type, Point position)
            {
                Type = type;
                Image = CloudImageFactory.GetCloudImage(type);
                Position = position;
            }

            public void Draw(Graphics graphics)
            {
                graphics.DrawImage(Image, Position);
            }
        }

        // Менеджер облаков
        public class CloudManager
        {
            private List<Cloud> _clouds;

            public CloudManager()
            {
                _clouds = new List<Cloud>();
            }

            public void AddCloud(CloudType type, Point position)
            {
                Cloud cloud = new Cloud(type, position);
                _clouds.Add(cloud);
            }

            public void Draw(Graphics graphics)
            {
                foreach (Cloud cloud in _clouds)
                {
                    cloud.Draw(graphics);
                }
            }
            public void Update(int deltaX, int deltaY)
            {
                foreach (Cloud cloud in _clouds)
                {
                    // Например, перемещаем облака по прямой
                    cloud.Position = new Point(cloud.Position.X + deltaX, cloud.Position.Y + deltaY);
                }
            }
        }
    }
}

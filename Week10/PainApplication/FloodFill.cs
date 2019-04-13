using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PainApplication
{
    class FloodFill
    {
        Color originalColor;
        public Bitmap bitmap;
        Queue<Point> queue;

        public FloodFill(ref Bitmap bitmap, Point originalPoint)
        {
            this.bitmap = bitmap;
            originalColor = bitmap.GetPixel(originalPoint.X, originalPoint.Y);
            queue = new Queue<Point>();
            queue.Enqueue(originalPoint);
        }

        public void Fill(Color color)
        {
            while (queue.Count != 0)
            {
                Point currentPoint = queue.Dequeue();
                Color pixelColor = bitmap.GetPixel(currentPoint.X, currentPoint.Y);

                ProcessPoint(currentPoint);

                if (pixelColor == originalColor)
                {
                    bitmap.SetPixel(currentPoint.X, currentPoint.Y, color);
                }
            }
        }

        private void ProcessPoint(Point point)
        {
            if (bitmap.GetPixel(point.X, point.Y) == originalColor)
            {
                if (point.X > 0)
                {
                    queue.Enqueue(new Point(point.X - 1, point.Y));
                }

                if (point.X < bitmap.Width - 1)
                {
                    queue.Enqueue(new Point(point.X + 1, point.Y));
                }

                if (point.Y > 0)
                {
                    queue.Enqueue(new Point(point.X, point.Y - 1));
                }

                if (point.Y < bitmap.Height - 1)
                {
                    queue.Enqueue(new Point(point.X, point.Y + 1));
                }
            }
           
        }
    }
}

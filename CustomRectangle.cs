using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1
{
    public class CustomRectangle
    {
        public Brush Color;
        public string ColorString;
        public CustomPoint Point1; 
        public CustomPoint Point2;
        public CustomPoint Point3;
        public CustomPoint Point4;
        private List<CustomPoint> PointsList = new List<CustomPoint>();
        private List<CustomPoint> PointsListOneColor = new List<CustomPoint>();
        public List<double> CoordX = new List<double>();
        public List<double> CoordY = new List<double>();

        public CustomRectangle(string color, CustomPoint point1, CustomPoint point3)
        {
            ColorString = color;

            switch (color)
            {
                case "Green": Color = Brushes.Green; break;
                case "Blue": Color = Brushes.Blue; break;
                case "Red": Color = Brushes.Red; break;
                default:
                    Color = Brushes.Yellow;
                    break;
            }

            Point1 = point1;
            Point3 = point3;
            Point2 = new CustomPoint(Point3.x, Point1.y);
            Point4 = new CustomPoint(Point1.x, Point3.y); 

        }
        public void GenerateListCoordXY()
        {

            PointsList.Add(Point1); PointsList.Add(Point2); PointsList.Add(Point3); PointsList.Add(Point4);

            foreach (var _Point in PointsList)
            {
                CoordX.Add(_Point.x);
                CoordY.Add(_Point.y);
            }
        }
        public void GenerateListCoordXY(string color)
        {

            PointsList.Add(Point1); PointsList.Add(Point2); PointsList.Add(Point3); PointsList.Add(Point4);

            foreach (var _Point in PointsList)
            {
                CoordX.Add(_Point.x);
                CoordY.Add(_Point.y);
            }
        }

    }

    public class CustomPoint
    {
        public double x; public double y;

        public CustomPoint(double _x, double _y)
        {
            x = _x; y = _y;
        }
    }
}

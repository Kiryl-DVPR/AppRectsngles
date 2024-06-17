using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        CustomRectangle rect1;
        CustomRectangle rect2 ;
        CustomRectangle rect3 ;
        CustomRectangle rect4 ;
        CustomRectangle rect5 ;
        List<double> CoordXList = new List<double>();
        List<double> CoordYList = new List<double>();
        List<string> ChechedColors = new List<string>();
        string Log;
       
        string path = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\LogApp.txt";

        public MainWindow()
        {
            InitializeComponent();

            Log = Log + $"\nГлавный прямоугольник: " +
                $"{Polyl.Points} \n";


            File.WriteAllTextAsync(path, Log);
        }

        public void CreateRectangle(CustomRectangle rect1, Polygon rect1Polyg)
        {
            rect1Polyg.Points.Clear();
            
            double x1, x3;
            double y1, y3;

            x1 = rect1.Point1.x; 
            y1 = rect1.Point1.y; 
            x3 = rect1.Point3.x;
            y3 = rect1.Point3.y;

            rect1Polyg.Fill = rect1.Color;
            rect1Polyg.Points.Add(new Point(x1, y1));
            rect1Polyg.Points.Add(new Point(x3, y1));
            rect1Polyg.Points.Add(new Point(x3, y3));
            rect1Polyg.Points.Add(new Point(x1, y3));

        }

        public void Generation(object sender, EventArgs e)
        {

            Random r = new Random();

            rect1 = new CustomRectangle("Blue", new CustomPoint(10*r.Next(5,10), 10*r.Next(5, 10)), new CustomPoint(20 * r.Next(7, 10), 20 * r.Next(7, 10)));
            rect2 = new CustomRectangle("Blue", new CustomPoint(17 * r.Next(5, 10), 17 * r.Next(5, 10)), new CustomPoint(27 * r.Next(7, 10), 27 * r.Next(7, 10)));
            rect3 = new CustomRectangle("Red", new CustomPoint(23 * r.Next(5, 10), 23 * r.Next(5, 10)), new CustomPoint(32 * r.Next(7, 10), 32 * r.Next(7, 10)));
            rect4 = new CustomRectangle("Blue", new CustomPoint(29 * r.Next(5, 10), 29 * r.Next(5, 10)), new CustomPoint(38 * r.Next(7, 10), 38 * r.Next(7, 10)));
            rect5 = new CustomRectangle("Green", new CustomPoint(30 * r.Next(5, 10), 30 * r.Next(5, 10)), new CustomPoint(40 * r.Next(7, 10), 40 * r.Next(7, 10)));


            CreateRectangle(rect1, Rect1);
            CreateRectangle(rect2, Rect2);
            CreateRectangle(rect3, Rect3);
            CreateRectangle(rect4, Rect4);
            CreateRectangle(rect5, Rect5);

            checkBox1.Content = rect1.ColorString;
            checkBox2.Content = rect3.ColorString;
            checkBox3.Content = rect5.ColorString;

            List<CustomRectangle> rects = new List<CustomRectangle>() { rect1,rect2,rect3,rect4,rect5};

            int i = 1;

            foreach (CustomRectangle rect in rects)
            {
  
                Log = Log + ($"Rectangle {i} {rect.ColorString}\n {rect.Point1.x},{rect.Point1.y},{rect.Point2.x},{rect.Point2.y},{rect.Point3.x},{rect.Point3.y},{rect.Point4.x},{rect.Point2.y} \n");
                i++;
            }

            File.WriteAllTextAsync(path, Log);

        }

        public void VButton1(object sender, EventArgs e)
        {
            try
            {
                Polyl.Points.Clear();

                List<CustomRectangle> ListRectangle = new List<CustomRectangle>() { rect1, rect2, rect3, rect4, rect5 };


                foreach (CustomRectangle rectangle in ListRectangle)
                {
                    rectangle.GenerateListCoordXY();

                    foreach (var coordx in rectangle.CoordX)
                    {
                        CoordXList.Add(coordx);

                    }
                    foreach (var coordy in rectangle.CoordY)
                    {

                        CoordYList.Add(coordy);
                    }
                }

                Polyl.Points.Add(new Point(CoordXList.Min(), CoordYList.Min()));
                Polyl.Points.Add(new Point(CoordXList.Max(), CoordYList.Min()));
                Polyl.Points.Add(new Point(CoordXList.Max(), CoordYList.Max()));
                Polyl.Points.Add(new Point(CoordXList.Min(), CoordYList.Max()));
                Polyl.Points.Add(new Point(CoordXList.Min(), CoordYList.Min()));

                Log = Log + $"V1 - Вариант 1\nГлавный прямоугольник: {CoordXList.Min()},{CoordYList.Min()},{CoordXList.Max()},{CoordYList.Min()},{CoordXList.Max()},{CoordYList.Max()},{CoordXList.Min()},{CoordYList.Max()} ";

                File.WriteAllTextAsync(path, Log);

                ListRectangle.Clear();
                CoordXList.Clear();
                CoordYList.Clear();
            }
            catch 
            {
                Polyl.Points.Add(new Point(100, 100));
                Polyl.Points.Add(new Point(400, 100));
                Polyl.Points.Add(new Point(400, 300));
                Polyl.Points.Add(new Point(100, 300));
                Polyl.Points.Add(new Point(100, 100));

                Log = Log + $"\nГлавный прямоугольник: " +
                "100,100,400,100,400,300,100,300,100,100";

            }
            
            

        }

        public void VButton2(object sender, EventArgs e)
        {

            try
            {
                var PolyPoints = Polyl.Points;

                List<double> CoordPolyX = new List<double>();
                List<double> CoordPolyY = new List<double>();

                foreach (var p in PolyPoints)
                {
                    CoordPolyX.Add(p.X);
                    CoordPolyY.Add(p.Y);
                }

                List<CustomRectangle> ListRectangle = new List<CustomRectangle>() { rect1, rect2, rect3, rect4, rect5 };

                foreach (CustomRectangle rectangle in ListRectangle)
                {
                    rectangle.GenerateListCoordXY();

                    foreach (var coordx in rectangle.CoordX)
                    {
                        CoordXList.Add(coordx);

                    }
                    foreach (var coordy in rectangle.CoordY)
                    {

                        CoordYList.Add(coordy);
                    }
                }



                List<double> CoordXLisnewX = CoordXList.Distinct().ToList();

                List<double> CoordXLisnewY = CoordYList.Distinct().ToList();


                if (CoordPolyX.Min() > CoordXLisnewX.Min()) CoordXLisnewX.Remove(CoordXLisnewX.Min());
                if (CoordPolyX.Max() < CoordXLisnewX.Max()) CoordXLisnewX.Remove(CoordXLisnewX.Max());
                if (CoordPolyY.Min() > CoordXLisnewY.Min()) CoordXLisnewY.Remove(CoordXLisnewY.Min());
                if (CoordPolyY.Max() < CoordXLisnewY.Max()) CoordXLisnewY.Remove(CoordXLisnewY.Max());

                Polyl.Points.Clear();

                Polyl.Points.Add(new Point(CoordXLisnewX.Min(), CoordXLisnewY.Min()));
                Polyl.Points.Add(new Point(CoordXLisnewX.Max(), CoordXLisnewY.Min()));
                Polyl.Points.Add(new Point(CoordXLisnewX.Max(), CoordXLisnewY.Max()));
                Polyl.Points.Add(new Point(CoordXLisnewX.Min(), CoordXLisnewY.Max()));
                Polyl.Points.Add(new Point(CoordXLisnewX.Min(), CoordXLisnewY.Min()));

                Log = Log + $"V2 - Вариант 2\nГлавный прямоугольник: " +
                    $"{CoordXLisnewX.Min()},{CoordXLisnewY.Min()}," +
                    $"{CoordXLisnewX.Max()},{CoordXLisnewY.Min()}," +
                    $"{CoordXLisnewX.Max()},{CoordXLisnewY.Max()}," +
                    $"{CoordXLisnewX.Min()},{CoordXLisnewX.Min()} ";

                File.WriteAllTextAsync(path, Log);

                ListRectangle.Clear();
                CoordXList.Clear();
                CoordYList.Clear();
            }
            catch 
            {
                Polyl.Points.Add(new Point(100, 100));
                Polyl.Points.Add(new Point(400, 100));
                Polyl.Points.Add(new Point(400, 300));
                Polyl.Points.Add(new Point(100, 300));
                Polyl.Points.Add(new Point(100, 100));

                Log = Log + $"\nГлавный прямоугольник: " +
                "100,100,400,100,400,300,100,300,100,100";

            }
            
            

        }

        public void VButton3(object sender, EventArgs e)
        {
            try
            {
                Polyl.Points.Clear();

                List<CustomRectangle> ListRectangle = new List<CustomRectangle>() { rect1, rect2, rect3, rect4, rect5 };
                List<CustomRectangle> ListColorRectangle = new List<CustomRectangle>() { };

                foreach (var color in ChechedColors)
                {
                    foreach (var rect in ListRectangle)
                    {
                        if (rect.ColorString == color)
                        {
                            ListColorRectangle.Add(rect);
                        };
                    }
                }

                Log = Log + "V3 - Вариант 3";
                foreach (var color in ChechedColors)
                {
                    Log = Log + $"Check: {color}\n";
                }

                foreach (CustomRectangle rectangle in ListColorRectangle)
                {
                    rectangle.GenerateListCoordXY();

                    foreach (var coordx in rectangle.CoordX)
                    {
                        CoordXList.Add(coordx);

                    }
                    foreach (var coordy in rectangle.CoordY)
                    {

                        CoordYList.Add(coordy);
                    }
                }
                try
                {
                    Polyl.Points.Add(new Point(CoordXList.Min(), CoordYList.Min()));
                    Polyl.Points.Add(new Point(CoordXList.Max(), CoordYList.Min()));
                    Polyl.Points.Add(new Point(CoordXList.Max(), CoordYList.Max()));
                    Polyl.Points.Add(new Point(CoordXList.Min(), CoordYList.Max()));
                    Polyl.Points.Add(new Point(CoordXList.Min(), CoordYList.Min()));

                    Log = Log + $"\nГлавный прямоугольник: " +
                    $"{CoordXList.Min()},{CoordYList.Min()}," +
                    $"{CoordXList.Max()},{CoordYList.Min()}," +
                    $"{CoordXList.Max()},{CoordYList.Max()}," +
                    $"{CoordXList.Min()},{CoordYList.Max()} ";
                }
                catch
                {
                    Polyl.Points.Add(new Point(100, 100));
                    Polyl.Points.Add(new Point(400, 100));
                    Polyl.Points.Add(new Point(400, 300));
                    Polyl.Points.Add(new Point(100, 300));
                    Polyl.Points.Add(new Point(100, 100));

                    Log = Log + $"\nГлавный прямоугольник: " +
                    "100,100,400,100,400,300,100,300,100,100";

                }


                File.WriteAllTextAsync(path, Log);


                ListRectangle.Clear();
                CoordXList.Clear();
                CoordYList.Clear();
            }
            catch 
            {

                Polyl.Points.Add(new Point(100, 100));
                Polyl.Points.Add(new Point(400, 100));
                Polyl.Points.Add(new Point(400, 300));
                Polyl.Points.Add(new Point(100, 300));
                Polyl.Points.Add(new Point(100, 100));

                Log = Log + $"\nГлавный прямоугольник: " +
                "100,100,400,100,400,300,100,300,100,100";
            }
            
            

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox a = (CheckBox)sender;

            try
            {
                a.Content.ToString();

                ChechedColors.Add(a.Content.ToString());
            }
            catch 
            {

                
            }
            
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox a = (CheckBox)sender;


            try
            {
                a.Content.ToString();

                ChechedColors.Remove(a.Content.ToString());
            }
            catch
            { }

                
            
        }

        

    }
}
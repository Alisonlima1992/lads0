using lab0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lads0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle tr;
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            CreateRandomTriangle();
            DrawTriangle(tr!);
        }

        private void CreateRandomTriangle()
        {
            Point2D p1 = new Point2D(rnd.Next(50, (int)Scene.Width - 50), rnd.Next(50, (int)Scene.Height - 50));
            Point2D p2 = new Point2D(rnd.Next(50, (int)Scene.Width - 50), rnd.Next(50, (int)Scene.Height - 50));
            Point2D p3 = new Point2D(rnd.Next(50, (int)Scene.Width - 50), rnd.Next(50, (int)Scene.Height - 50));
            tr = new Triangle(p1, p2, p3);
        }

        public void DrawLine(Point2D p1, Point2D p2)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;
            Scene.Children.Add(line);
        }

        public void DrawTriangle(Triangle tr)
        {
            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }

        public void ClearScene()
        {
            Scene.Children.Clear();
        }

        public void DrawRectangle(Rectangle rect)
        {
            Point2D[] points = rect.GetPoints();

            DrawLine(points[0], points[1]);
            DrawLine(points[1], points[2]);
            DrawLine(points[2], points[3]);
            DrawLine(points[3], points[0]);
        }
    }
}
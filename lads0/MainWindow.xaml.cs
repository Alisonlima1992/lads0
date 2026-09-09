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
        Rectangle rect;
        Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            CreateRandomTriangle();
            if (tr != null)
                DrawTriangle(tr);
        }

        private void CreateRandomTriangle()
        {
            Point2D p1 = new Point2D(rnd.Next(50, (int)Scene.Width - 50), rnd.Next(50, (int)Scene.Height - 50));
            Point2D p2 = new Point2D(rnd.Next(50, (int)Scene.Width - 50), rnd.Next(50, (int)Scene.Height - 50));
            Point2D p3 = new Point2D(rnd.Next(50, (int)Scene.Width - 50), rnd.Next(50, (int)Scene.Height - 50));
            tr = new Triangle(p1, p2, p3);
        }

        private void CreateTriangleWithPoints(Point2D p1, Point2D p2, Point2D p3)
        {
            tr = new Triangle(p1, p2, p3);
        }

        private void CreateRandomSquare()
        {
            int x = rnd.Next(50, (int)Scene.Width - 150);
            int y = rnd.Next(50, (int)Scene.Height - 150);
            int size = rnd.Next(30, 100);
            Point2D topLeft = new Point2D(x, y);
            rect = new Rectangle(topLeft, size, size);
        }

        private void CreateSquareWithParams(int x, int y, int size)
        {
            Point2D topLeft = new Point2D(x, y);
            rect = new Rectangle(topLeft, size, size);
        }

        private void CreateRandomRectangle()
        {
            int x = rnd.Next(50, (int)Scene.Width - 200);
            int y = rnd.Next(50, (int)Scene.Height - 150);
            int width = rnd.Next(30, 150);
            int height = rnd.Next(30, 100);
            Point2D topLeft = new Point2D(x, y);
            rect = new Rectangle(topLeft, width, height);
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

        private void RandomTriangle_Click(object sender, RoutedEventArgs e)
        {
            ClearScene();
            CreateRandomTriangle();
            if (tr != null)
                DrawTriangle(tr);
        }

        private void RandomRectangle_Click(object sender, RoutedEventArgs e)
        {
            ClearScene();
            CreateRandomRectangle();
            if (rect != null)
                DrawRectangle(rect);
        }

        private void RandomSquare_Click(object sender, RoutedEventArgs e)
        {
            ClearScene();
            CreateRandomSquare();
            if (rect != null)
                DrawRectangle(rect);
        }

        private void DrawSquare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = int.Parse(InputX.Text);
                int y = int.Parse(InputY.Text);
                int size = int.Parse(InputSize.Text);

                ClearScene();
                CreateSquareWithParams(x, y, size);
                if (rect != null)
                    DrawRectangle(rect);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректные числа!", "Ошибка");
            }
        }

        private void DrawTriangle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = int.Parse(InputX.Text);
                int y = int.Parse(InputY.Text);
                int size = int.Parse(InputSize.Text);

                ClearScene();
                Point2D p1 = new Point2D(x, y);
                Point2D p2 = new Point2D(x + size, y);
                Point2D p3 = new Point2D(x + size / 2, y - size);
                CreateTriangleWithPoints(p1, p2, p3);
                if (tr != null)
                    DrawTriangle(tr);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректные числа!", "Ошибка");
            }
        }

        private void ClearScene_Click(object sender, RoutedEventArgs e)
        {
            ClearScene();
        }

        private void MoveShape_Click(object sender, RoutedEventArgs e)
        {
            int deltaX = (int)SliderX.Value;
            int deltaY = (int)SliderY.Value;

            if (tr != null)
            {
                tr.AddX(deltaX);
                tr.AddY(deltaY);
                ClearScene();
                DrawTriangle(tr);
            }
            else if (rect != null)
            {
                rect.AddX(deltaX);
                rect.AddY(deltaY);
                ClearScene();
                DrawRectangle(rect);
            }
        }
    }
}
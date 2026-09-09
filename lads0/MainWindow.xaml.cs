using lab0;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lads0
{
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
            if (tr == null)
                return;

            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }

        public void ClearScene()
        {
            Scene.Children.Clear();

        }

        private void ClearAll()
        {
            Scene.Children.Clear();
            tr = null;
            rect = null;
        }

        public void DrawRectangle(Rectangle rect)
        {
            if (rect == null)
                return;

            Point2D[] points = rect.GetPoints();
            DrawLine(points[0], points[1]);
            DrawLine(points[1], points[2]);
            DrawLine(points[2], points[3]);
            DrawLine(points[3], points[0]);
        }

        private void RandomSquare_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            CreateRandomSquare();
            if (rect != null)
                DrawRectangle(rect);
        }

        private void RandomTriangle_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            CreateRandomTriangle();
            if (tr != null)
                DrawTriangle(tr);
        }

        private void RandomRectangle_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            CreateRandomRectangle();
            if (rect != null)
                DrawRectangle(rect);
        }

        void DrawSquare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = int.Parse(InputX.Text);
                int y = int.Parse(InputY.Text);
                int size = int.Parse(InputSize.Text);

                ClearAll();
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

                ClearAll();
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
            ClearAll();
        }


        private void MoveShape_Click(object sender, RoutedEventArgs e)
        {
            int deltaX = (int)SliderX.Value;
            int deltaY = (int)SliderY.Value;

            if (tr != null)
            {
                bool canMoveX = true;
                bool canMoveY = true;

                Point2D[] points = new Point2D[] { tr.P1, tr.P2, tr.P3 };

                foreach (var p in points)
                {
                    int newX = p.X + deltaX;
                    int newY = p.Y + deltaY;

                    if (newX < 10 || newX > Scene.Width - 10)
                        canMoveX = false;
                    if (newY < 10 || newY > Scene.Height - 10)
                        canMoveY = false;
                }

                if (canMoveX)
                    tr.AddX(deltaX);
                if (canMoveY)
                    tr.AddY(deltaY);

                ClearScene();
                DrawTriangle(tr);
            }
            else if (rect != null)
            {
                Point2D[] points = rect.GetPoints();
                bool canMoveX = true;
                bool canMoveY = true;

                foreach (var p in points)
                {
                    int newX = p.X + deltaX;
                    int newY = p.Y + deltaY;

                    if (newX < 10 || newX > Scene.Width - 10)
                        canMoveX = false;
                    if (newY < 10 || newY > Scene.Height - 10)
                        canMoveY = false;
                }

                if (canMoveX)
                    rect.AddX(deltaX);
                if (canMoveY)
                    rect.AddY(deltaY);

                ClearScene();
                DrawRectangle(rect);
            }

            SliderX.Value = 0;
            SliderY.Value = 0;
        }

        private void SliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MoveShape_Click(sender, e);
        }

        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MoveShape_Click(sender, e);
        }
    }
}
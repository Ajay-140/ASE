using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEProject
{
    internal class variables
    {
    /// <summary>
    /// To draw basic shapes by variables
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="radius"></param>
        // Function to draw a circle
        static void DrawCircle(int x, int y, int radius)
        {
            // Draw a circle at (x, y) with the given radius
            // (Assuming a graphics library or API for drawing)
            Console.WriteLine($"Drawing circle at ({x}, {y}) with radius {radius}");
        }

        // Function to draw an equilateral triangle
        static void DrawTriangle(int x, int y, int sideLength)
        {
            // Draw an equilateral triangle at (x, y) with the given side length
            // (Assuming a graphics library or API for drawing)
            Console.WriteLine($"Drawing triangle at ({x}, {y}) with side length {sideLength}");
        }

        // Function to draw a rectangle
        static void DrawRectangle(int x, int y, int width, int height)
        {
            // Draw a rectangle at (x, y) with the given width and height
            // (Assuming a graphics library or API for drawing)
            Console.WriteLine($"Drawing rectangle at ({x}, {y}) with width {width} and height {height}");
        }

        // Function to draw a line
        static void DrawLine(int x1, int y1, int x2, int y2)
        {
            // Draw a line from (x1, y1) to (x2, y2)
            // (Assuming a graphics library or API for drawing)
            Console.WriteLine($"Drawing line from ({x1}, {y1}) to ({x2}, {y2})");
        }

        static void BasicVariables()
        {
            int numCircles = 2;      // Variable to determine the number of circle iterations
            int numTriangles = 2;    // Variable to determine the number of triangle iterations
            int numRectangles = 2;   // Variable to determine the number of rectangle iterations
            int numLines = 2;        // Variable to determine the number of line iterations

            // Variables as parameters for drawing commands
            int canvasWidth = 800;
            int canvasHeight = 600;
            int circleRadius = 50;
            int triangleSideLength = 80;
            int rectangleWidth = 100;
            int rectangleHeight = 60;
            int lineX1 = 20, lineY1 = 20, lineX2 = 200, lineY2 = 100;

            // Loop to draw circles
            for (int i = 0; i < numCircles; i++)
            {
                int x = i * (canvasWidth / numCircles);
                int y = canvasHeight / 5;

                DrawCircle(x, y, circleRadius);
            }

            // Loop to draw triangles
            for (int i = 0; i < numTriangles; i++)
            {
                int x = i * (canvasWidth / numTriangles);
                int y = 2 * (canvasHeight / 5);

                DrawTriangle(x, y, triangleSideLength);
            }

            // Loop to draw rectangles
            for (int i = 0; i < numRectangles; i++)
            {
                int x = i * (canvasWidth / numRectangles);
                int y = 3 * (canvasHeight / 5);

                DrawRectangle(x, y, rectangleWidth, rectangleHeight);
            }

            // Loop to draw lines
            for (int i = 0; i < numLines; i++)
            {
                DrawLine(lineX1, lineY1, lineX2, lineY2);
            }
        }
    }

}

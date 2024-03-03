using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w05_duanconran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int check=0;
            int[] x = new int[100];
            int[] y = new int[100];
            int foodA=3, foodB=5;
            int longSnake = 1;
            int maxWidth = 26, maxHeight = 11;
            for (int i = 0; i <= maxWidth; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i, 0);
                Console.Write(" ");
                Console.SetCursorPosition(i, maxHeight);
                Console.Write(" ");

            }
            for (int i = 0; i <= maxHeight; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, i);
                Console.Write(" ");
                Console.SetCursorPosition(maxWidth, i);
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Green;
            int positionX = maxWidth / 2 + 1;
            int positionY = maxHeight / 2 + 1;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(" ");
            while (true)
            {

                ConsoleKeyInfo userKey = Console.ReadKey();
                switch (userKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        positionY--;
                        break;
                    case ConsoleKey.DownArrow:
                        positionY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        positionX--;
                        break;
                    case ConsoleKey.RightArrow:
                        positionX++;
                        break;

                }
                if (positionX == 0 || positionX == maxWidth || positionY == 0 || positionY == maxHeight)
                {
                    Console.WriteLine("Game over:" + longSnake + " Point");
                    return;
                }
                    
                resetBG();

                //in ran
                Console.BackgroundColor = ConsoleColor.Green;
                ViTri(x,y,longSnake,positionX,positionY);
                inSnake(longSnake,x,y);
               
                food(ref foodA,ref foodB,ref check);
                checkk(foodA,foodB,positionX,positionY,ref check, ref longSnake,x,y);
                Console.BackgroundColor = ConsoleColor.Green;
                




            }

            Console.ReadKey();
        }
        public static void inSnake(int longSnake, int[] x, int[] y)
        {

            for (int i = 0; i < longSnake; i++)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x[i], y[i]);
                Console.Write(" ");
            }
        }
        public static void ViTri(int[] x, int[] y, int longSnake, int positionX, int positionY)
        {
            for (int i = 0; i < longSnake; i++)
            {
                x[i + 1] = x[i];
                y[i + 1] = y[i];
            }
            x[0] = positionX;
            y[0] = positionY;
        }
        public static void resetBG()
        {
            for (int i = 1; i < 26; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }

            }

        }
        public static void food(ref int foodA, ref int foodB,ref int check)
        {
            if (check == 1)
            {
                Random rand = new Random();
                foodA = rand.Next(1, 25);
                foodB = rand.Next(1, 10);
                check = 0;
            }
            Console.SetCursorPosition(foodA, foodB);
            Console.BackgroundColor= ConsoleColor.Blue;
            Console.Write(" ");
        }
        public static void checkk(int foodA,int foodB,int positionX, int positionY,ref int check, ref int longSnake, int[] x, int[]y)
        {
            if (foodA==positionX&& foodB == positionY)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                ViTri(x, y, longSnake, positionX, positionY);
                inSnake(longSnake, x, y);

                check = 1;
                longSnake++;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EjercicioJuego_Tuma_Joel_Fiori_Tomas
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            Random aleatorio = new Random();

            int x = 40, y = 12;

            //Obstaculos
            int xo1 = 20, yo1 = 15;
            int xo2 = 25, yo2 = 5;
            int xo3 = 62, yo3 = 21;

            int[] xObstaculos = new int[3];
            int[] yObstaculos = new int[3];

            for(int i = 0; i<3; i++)
            {
                xObstaculos[i] = aleatorio.Next(1, 80);
                yObstaculos[i] = aleatorio.Next(1, 24);
            }

            //Enemigos
            int xe1 = 1, ye1 = 1;
            int xe2 = 17, ye2 = 20;
            int incr1 = 1, incr2 = 1;

            int fin = 0; // 0 = no terminado, 1 = terminado

            //Premios
            int premio1 = 0, premio2 = 0;
            int xp1 = aleatorio.Next(1, 80), yp1 = aleatorio.Next(1, 25);
            int xp2 = aleatorio.Next(1, 80), yp2 = aleatorio.Next(1, 25);

            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\tBIENVENIDO {0}!", nombre);
            Console.WriteLine("Acumula 100 puntos para GANAR --> /");
            Console.WriteLine("Si chocas con un enemigo u obstaculo PIERDES.");
            Console.WriteLine("Presiona una tecla para comenzar! ");
            Console.ReadKey();

            while (fin == 0)
            {
                Console.Clear();
                Console.SetCursorPosition(x, y);
                Console.Write("A");

                Console.SetCursorPosition(xo1, yo1); // Obstáculos
                Console.Write("o");
                Console.SetCursorPosition(xo2, yo2);
                Console.Write("o");
                Console.SetCursorPosition(xo3, yo3);
                Console.Write("o");
                for (int i = 0; i<3; i++)
                {
                    Console.SetCursorPosition(xObstaculos[i], yObstaculos[i]);
                    Console.Write("0");
                }

                Console.SetCursorPosition(xe1, ye1); // Enemigo
                Console.Write("@");
                Console.SetCursorPosition(xe2, ye2);
                Console.Write("#");
                Console.SetCursorPosition(xp1, yp1);

                Console.Write("/"); //Premios
                Console.SetCursorPosition(xp2, yp2);
                Console.Write("/");

                tecla = Console.ReadKey(false);
                if ((tecla.Key == ConsoleKey.RightArrow) && (x < 79)) x++;
                if ((tecla.Key == ConsoleKey.LeftArrow) && (x > 0)) x--;
                if ((tecla.Key == ConsoleKey.DownArrow) && (y < 24)) y++;
                if ((tecla.Key == ConsoleKey.UpArrow) && (y > 0)) y--;

                xe1 = xe1 + incr1;
                if ((xe1 == 0) || (xe1 == 79))
                    incr1 = -incr1;

                ye2 = ye2 + incr2;
                if ((ye2 == 0) || (ye2 == 24))
                    incr2 = -incr2;

                if ((x == xp1) && (y == yp1))
                {
                    premio1 += 10;
                    //Generando nueva posicion del premio1
                    xp1 = aleatorio.Next(1, 80);
                    yp1 = aleatorio.Next(1, 24);
                }
                if ((x == xp2) && (y == yp2))
                {
                    premio2 += 10;
                    //Generando nueva posicion del premio2
                    xp2 = aleatorio.Next(1, 80);
                    yp2 = aleatorio.Next(1, 24);
                }

                //Si llega a los 100 puntos el jugador gana y se termina el juego.
                if((premio1+premio2) == 100)
                {
                    Console.Clear();
                    Console.WriteLine("\n\tGANASTE!!!");
                    Console.WriteLine("ACUMULASTE 100 PUNTOS :)");
                    Console.ReadKey();
                    fin = 1;
                }

                for(int i = 0; i < 3; i++)
                {
                    if ((xObstaculos[i] == x) && (yObstaculos[i] == y))
                    {
                        msjPerdiste(premio1, premio2);
                        fin = 1;
                    }
                }

                if (((x == xo1) && (y == yo1)) 
                    || ((x == xo2) && (y == yo2)) 
                    || ((x == xo3) && (y == yo3))
                    || ((x == xe1) && (y == ye1))
                    || ((x == xe2) && (y == ye2)))
                {
                    msjPerdiste(premio1, premio2);
                    fin = 1;
                }

            }

            Thread.Sleep(40);
        }

        static void msjPerdiste(int p1, int p2)
        {
            Console.Clear();
            Console.WriteLine("\n\tPerdiste!");
            Console.WriteLine("Puntos acumulados: " + (p1 + p2));
            Console.ReadKey();
        }

    }
}
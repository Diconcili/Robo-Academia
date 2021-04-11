using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] direções = { 'N', 'L', 'S', 'O' };
            string direçãoInicial;
            double índiceDireção = 0;
            
            for (int z = 0; z<2; z++) { 
            Console.WriteLine("Digite a posição inicial do robô em X");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite a posição inicial do robô em Y");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite a direção inicial do robô");
            direçãoInicial = Console.ReadLine();

            índiceDireção = IndiceDireçãoInicial(direçãoInicial, índiceDireção);

            Console.WriteLine("Digite os comandos para o robô");
            string comandos = Console.ReadLine();
            char[] leComandos = new char[100];

            leComandos = comandos.ToCharArray();

            índiceDireção = ViraRobô(índiceDireção, x ,  y , comandos);     
            


            Console.ReadLine();

        }

        private static void MoveRobô(double índiceDireção, ref double x, ref double y, string comandos)
            {
                foreach (char M in comandos)
                {
                    if (índiceDireção == 0)
                    {
                        x++;
                    }
                    if (índiceDireção == 2)
                    {
                        x--;
                    }
                    if (índiceDireção == 1)
                    {
                        y++;
                    }
                    if (índiceDireção == 3)
                    {
                        y--;
                    }
                }
                Console.WriteLine("Posição: " + x + " " + y);

            }
          
        }

        private static double ViraRobô(double índiceDireção, double x,  double y,string comandos)
        {
            if (comandos.Contains("E") || comandos.Contains("M")) { índiceDireção = ViraParaEsquerda(índiceDireção,  x ,  y , comandos); }
            else { if (comandos.Contains("D") || comandos.Contains("M")) { índiceDireção = ViraParaDireita(índiceDireção,  x,  y , comandos); } }

            return índiceDireção;
        }

        private static double ViraParaDireita(double índiceDireção, double x , double y ,string comandos){
            double direçãoCorrigida = 0;
            foreach (char D in comandos)
            {
                double direçãoFinal = índiceDireção++;
                direçãoCorrigida = CorrigeErroDireção(direçãoFinal + 1, 4);
            }

            Console.WriteLine(direçãoCorrigida);
            if (direçãoCorrigida == 0)
            {
                Console.WriteLine("N");
            }
            if (direçãoCorrigida == 1)
            {
                Console.WriteLine("L");
            }
            if (direçãoCorrigida == 2)
            {
                Console.WriteLine("S");
            }
            if (direçãoCorrigida == 3)
            {
                Console.WriteLine("O");
            }

            MoveRobô(índiceDireção, ref x, ref y, comandos); 

            return índiceDireção;
        }

        private static double ViraParaEsquerda(double índiceDireção, double x, double  y , string comandos)
        {
            double direçãoCorrigida = 0;
            foreach (char E in comandos)
            {
                double direçãoFinal = índiceDireção--;
                direçãoCorrigida = CorrigeErroDireção(direçãoFinal - 1, 4);                
            }

            Console.WriteLine(direçãoCorrigida);
            if (direçãoCorrigida == 0)
            {
                Console.WriteLine("N");
            }
            if (direçãoCorrigida == 1)
            {
                Console.WriteLine("L");
            }
            if (direçãoCorrigida == 2)
            {
                Console.WriteLine("S");
            }
            if (direçãoCorrigida == 3)
            {
                Console.WriteLine("O");
            }

             MoveRobô(índiceDireção, ref x, ref y, comandos); 

            return índiceDireção;
        }        

        private static double IndiceDireçãoInicial(string direçãoInicial, double índiceDireção)
        {
            switch (direçãoInicial)
            {
                case "N": índiceDireção = 0; Console.WriteLine("Direção inicial: " + índiceDireção); break;
                case "L": índiceDireção = 1; Console.WriteLine("Direção inicial: " + índiceDireção); break;
                case "S": índiceDireção = 2; Console.WriteLine("Direção inicial: " + índiceDireção); break;
                case "O": índiceDireção = 3; Console.WriteLine("Direção inicial: " + índiceDireção); break;

                default:
                    Console.WriteLine("Direção inexistente");
                    break;
            }

            return índiceDireção;
        }        

            private static double CorrigeErroDireção(double direçãoFinal, double índiceDireção)
        {
            double direçãoInicial = índiceDireção;

            double corrigido = direçãoFinal % direçãoInicial;
            if (corrigido < 0)
            {
                return corrigido + direçãoInicial;
            }else
            {
                return corrigido;
            }       
        } 
    }
}
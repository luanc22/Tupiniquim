using System;

namespace Tupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool fecharApp = false;

            while (fecharApp == false)
            {
                Console.WriteLine("===== Projeto Tupiniquim I =====");
                Console.WriteLine("");
                Console.WriteLine("Utilize esse programa parar guiar e controlar os robos tripulantes da Tupiniquim I por Marte.");
                Console.WriteLine("");
                Console.WriteLine("===================================");
                Console.WriteLine("Instrucoes para utilizar os robos.");
                Console.WriteLine("");
                Console.WriteLine("Passe a instrucao D para move-lo a 90 graus a direita.");
                Console.WriteLine("Passe a instrucao E para move-lo a 90 graus a esquerda.");
                Console.WriteLine("Passe a instrucao M para move-lo a a frente.");
                Console.WriteLine("");
                Console.WriteLine("===================================");

                Console.WriteLine("");

                Console.Write("Digite os valores inteiros da area de analise, separados por virgula (X, Y): ");
                string inputCrdArea = Console.ReadLine();
                string[] inputCrdAreaArr = inputCrdArea.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] crdArea = new int[2];
                crdArea[0] = int.Parse(inputCrdAreaArr[0]);
                crdArea[1] = int.Parse(inputCrdAreaArr[1]);

                Console.WriteLine("");

                Console.Write("Digite a coordenada inicial do Robo I e a sua direcao inicial, separados por virgula (X, Y, D): ");
                string inputCrdRobI = Console.ReadLine();
                string[] inputCrdRobIArr = inputCrdRobI.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                inputCrdRobIArr[2] = inputCrdRobIArr[2].Replace(" ", "");
                int[] crdRobI = new int[2];
                char dirRobI;

                crdRobI[0] = int.Parse(inputCrdRobIArr[0]);
                crdRobI[1] = int.Parse(inputCrdRobIArr[1]);
                string uppChrI = inputCrdRobIArr[2].ToUpper();
                dirRobI = char.Parse(uppChrI);
 

                Console.WriteLine("");

                if (crdArea[0] <= 0 || crdArea[1] <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!\nArea invalida para analise.");
                    Console.WriteLine("");
                    Console.WriteLine("Mensagem de erro: Voce digitou uma area de analise menor ou igual a 0.");
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.Write("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (crdRobI[0] < 0 || crdRobI[1] < 0 || crdRobI[0] > crdArea[0] || crdRobI[1] > crdArea[1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!\nPosicao inicial invalida.");
                    Console.WriteLine("");
                    Console.WriteLine("Mensagem de erro: Voce digitou uma coordenada inicial invalida para robo, esta coordenada pode ter sido menor do que 0 ou fora da area a ser escaneada.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.Write("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (dirRobI != 'N' && dirRobI != 'S' && dirRobI != 'L' && dirRobI != 'O')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!\nPosicao inicial invalida.");
                    Console.WriteLine("");
                    Console.WriteLine("Mensagem de erro: Voce digitou uma direcao inicial invalida do robo, utilize uma da disponiveis na tabela abaixo.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("===================");
                    Console.WriteLine("N = Norte.\nS = Sul.\nL = Leste.\nO = Oeste.");
                    Console.WriteLine("===================");
                    Console.WriteLine("");
                    Console.Write("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    int dirRobINum = 0;
                    bool opcaoValida = false;

                    while (opcaoValida == false)
                    {
                        Console.Write("Digite sequencialmente os comandos para o Robo I (EMEMEMEMDMDM): ");
                        char[] cmdSqc = Console.ReadLine().ToCharArray();

                        switch (dirRobI)
                        {
                            case 'N':
                                dirRobINum = 1;
                                break;
                            case 'L':
                                dirRobINum = 2;
                                break;
                            case 'S':
                                dirRobINum = 3;
                                break;
                            case 'O':
                                dirRobINum = 4;
                                break;
                        }

                        for (int i = 0; i < cmdSqc.Length; i++)
                        {
                            if (cmdSqc[i] == 'E')
                            {
                                dirRobINum = dirRobINum - 1;
                                if (dirRobINum == 0)
                                {
                                    dirRobINum = 4;
                                }
                            }
                            else if (cmdSqc[i] == 'D')
                            {
                                dirRobINum = dirRobINum + 1;
                                if (dirRobINum == 5)
                                {
                                    dirRobINum = 1;
                                }
                            }
                            else if (cmdSqc[i] == 'M')
                            {
                                switch (dirRobINum)
                                {
                                    case 1:
                                        crdRobI[0] = crdRobI[0] + 1;
                                        break;
                                    case 2:
                                        crdRobI[1] = crdRobI[1] + 1;
                                        break;
                                    case 3:
                                        crdRobI[0] = crdRobI[0] - 1;
                                        break;
                                    case 4:
                                        crdRobI[1] = crdRobI[1] - 1;
                                        break;
                                }
                            }
                        }

                        switch (dirRobINum)
                        {
                            case 1:
                                dirRobI = 'N';
                                break;
                            case 2:
                                dirRobI = 'L';
                                break;
                            case 3:
                                dirRobI = 'S';
                                break;
                            case 4:
                                dirRobI = 'O';
                                break;
                        }

                        Console.WriteLine("");

                        if (crdRobI[0] < 0 || crdRobI[1] < 0 || crdRobI[0] > crdArea[0] || crdRobI[1] > crdArea[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERRO!\nPosicionamento do robo invalido.");
                            Console.WriteLine("");
                            Console.WriteLine("Mensagem de erro: Voce digitou um comando que leva a uma coordenada invalida, verifique se as instrucoes levam para uma coordenada x,y dentro da area determinada.");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.Write("Aperte ENTER para prosseguir.");
                            Console.ReadLine();
                            Console.Clear();
                            
                            // ARRUMAR AQUI DEPOIS

                            Console.WriteLine("===== Projeto Tupiniquim I =====");
                            Console.WriteLine("");
                            Console.WriteLine("Utilize esse programa parar guiar e controlar os robos tripulantes da Tupiniquim I por Marte.");
                            Console.WriteLine("");
                            Console.WriteLine("===================================");
                            Console.WriteLine("Instrucoes para utilizar os robos.");
                            Console.WriteLine("");
                            Console.WriteLine("Passe a instrucao D para move-lo a 90 graus a direita.");
                            Console.WriteLine("Passe a instrucao E para move-lo a 90 graus a esquerda.");
                            Console.WriteLine("Passe a instrucao M para move-lo a a frente.");
                            Console.WriteLine("");
                            Console.WriteLine("===================================");
                        }
                        else
                        {
                            opcaoValida = true;
                        }
                    }

                    Console.Write("Digite a coordenada inicial do Robo II e a sua direcao inicial, separados por virgula (X, Y, D): ");
                    string inputCrdRobII = Console.ReadLine();
                    string[] inputCrdRobIIArr = inputCrdRobII.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    inputCrdRobIIArr[2] = inputCrdRobIIArr[2].Replace(" ", "");
                    int[] crdRobII = new int[2];
                    char dirRobII;

                    crdRobII[0] = int.Parse(inputCrdRobIIArr[0]);
                    crdRobII[1] = int.Parse(inputCrdRobIIArr[1]);
                    string uppChrII = inputCrdRobIIArr[2].ToUpper();
                    dirRobI = char.Parse(uppChrII);



                    Console.WriteLine("Coordenada final e posicionamento do Robo I (X, Y, D): {0}, {1}, {2}.", crdRobI[0], crdRobI[1], dirRobI);
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.Write("Confirme as informacoes digitadas e aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();

                }
            }
        }
    }
}

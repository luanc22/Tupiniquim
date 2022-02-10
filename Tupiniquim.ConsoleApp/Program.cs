using System;

namespace Tupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linha 9 a Linha 47: Declaracao das variaveis utilizadas no programa.

            // Variaveis para declaracao das coordenadas de area.
            // crd = Coordenada; crdArea[0] = Coordenada X, crdArea[1] = Coordenada Y.
            string inputCrdArea;
            int[] crdArea = new int[2];

            // Variaveis para declarao das coordenadas do robo 1.
            // RobI = Robo 1; dir = Direcao; crdRobI[] = Coordenadas do Robo.
            int[] crdRobI = new int[2];
            string inputCrdRobI;
            string uppChrI;
            char dirRobI;
            int dirRobINum;

            // Variaveis para declarao das coordenadas do robo 2.
            // RobII = Robo 2; dir = Direcao; crdRobII[] = Coordenadas do Robo.
            int[] crdRobII = new int[2];
            string inputCrdRobII;
            string uppChrII;
            char dirRobII;
            int dirRobIINum;

            // Variavel declarada para backup das coordenadas iniciais, em caso, o input de instrucoes dos robos retorne erro.
            // bck = Backup.
            char bckDirRobI;
            int[] bckCrdRobI = new int[2];
            char bckDirRobII;
            int[] bckCrdRobII = new int[2];

            // Variavel declarada para receber as instrucoes dos robos e transformar em letra maiuscula, caso seja inputado em minuscula.
            // cmd = Comando; Str = String; Up = Uppercase.
            string cmdStrI;
            string cmdStrUpI;
            string cmdStrII;
            string cmdStrUpII;

            // Variavel e abertura do loop para rodar o programa novamente apos o usuario utilizar o mesmo.
            bool fecharApp = false;
            while (fecharApp == false)
            {
                Console.WriteLine("===== Projeto Tupiniquim I =====");
                Console.WriteLine("");
                Console.WriteLine("Utilize esse programa parar guiar e controlar os robos tripulantes da Tupiniquim I por Marte.");
                Console.WriteLine("");
                Console.WriteLine("===================================");
                Console.WriteLine("");
                Console.WriteLine("Instrucoes para utilizar os robos.");
                Console.WriteLine("");
                Console.WriteLine("Passe a instrucao D para move-lo a 90 graus a direita.");
                Console.WriteLine("Passe a instrucao E para move-lo a 90 graus a esquerda.");
                Console.WriteLine("Passe a instrucao M para move-lo a a frente.");
                Console.WriteLine("");
                Console.WriteLine("===================================");

                Console.WriteLine("");
                Console.WriteLine("=======> Area <=======");
                Console.WriteLine("");

                // Linha 68 a Linha 74: Input e atribuicao das coordenadas da area.

                Console.Write("Digite os valores inteiros da area de analise, separados por virgula (X, Y): ");
                inputCrdArea = Console.ReadLine();
                string[] inputCrdAreaArr = inputCrdArea.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                crdArea[0] = int.Parse(inputCrdAreaArr[0]);
                crdArea[1] = int.Parse(inputCrdAreaArr[1]);

                Console.WriteLine("");
                Console.WriteLine("=======> Robo 1 <=======");
                Console.WriteLine("");

                // Linha 82 a Linha 90: Input e atribuicao das coordenadas e direcao iniciais do Robo 1.

                Console.Write("Digite a coordenada inicial do Robo I e a sua direcao inicial, separados por virgula (X, Y, D): ");
                inputCrdRobI = Console.ReadLine();
                string[] inputCrdRobIArr = inputCrdRobI.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                inputCrdRobIArr[2] = inputCrdRobIArr[2].Replace(" ", "");

                crdRobI[0] = int.Parse(inputCrdRobIArr[0]);
                crdRobI[1] = int.Parse(inputCrdRobIArr[1]);
                uppChrI = inputCrdRobIArr[2].ToUpper();
                dirRobI = char.Parse(uppChrI);

                Console.WriteLine("");

                // Linha 96 a Linha 135: Condicoes para verificar se as coordenadas de Area e do Robo I passadas sao validas.

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
                    // Atribuicao de valores as variveis de backup do Robo 1.
                    dirRobINum = 0;
                    bckDirRobI = dirRobI;
                    bckCrdRobI[0] = crdRobI[0];
                    bckCrdRobI[1] = crdRobI[1];

                    // Variavel e abertura do loop para rodar a opcao de digitar o comando novamente, em caso, o input de instrucoes do robo 1 retorne erro.
                    bool posicaoValidaI = false;
                    while (posicaoValidaI == false)
                    {
                        // Linha 150 a Linha 153: Input da sequencia de comandos do Robo 1.

                        Console.Write("Digite sequencialmente os comandos para o Robo I (ex. EMEMEMEMDMDM): ");
                        cmdStrI = Console.ReadLine();
                        cmdStrUpI = cmdStrI.ToUpper();
                        char[] cmdSqcI = cmdStrUpI.ToCharArray();

                        // Switch para passar a direcao do Robo 1 em numero.
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

                        // For para verificar as instrucoes passadas e realizar as instrucoes.
                        for (int i = 0; i < cmdSqcI.Length; i++)
                        {
                            // Como atribuimos numeros a direcoes, funciona como um relogio.
                            // Caso voce vire anti-horario, ou esquerda, voce diminui o valor. Caso voce vire horario, ou direita, voce aumenta o valor.
                            // Caso esse valor passe da quantidade de direcoes (0 ou 5), ele retorna para o valor da proxima direcao (4 ou 1).
                            if (cmdSqcI[i] == 'E')
                            {
                                dirRobINum = dirRobINum - 1;
                                if (dirRobINum == 0)
                                {
                                    dirRobINum = 4;
                                }
                            }
                            else if (cmdSqcI[i] == 'D')
                            {
                                dirRobINum = dirRobINum + 1;
                                if (dirRobINum == 5)
                                {
                                    dirRobINum = 1;
                                }
                            }
                            else if (cmdSqcI[i] == 'M')
                            {
                                // Considerando as direcoes como numeros e pensando em um plano cartesiano de X e Y.
                                // se 1 = Norte, entao a coordenada Y tem que aumentar em 1 ao se movimentar.
                                // se 2 = Leste, entao a coordenada X tem que aumentar em 1 ao se movimentar.
                                // o mesmo se repete negativamente para Sul e Oeste.
                                switch (dirRobINum)
                                {
                                    case 1:
                                        crdRobI[1] = crdRobI[1] + 1;
                                        break;
                                    case 2:
                                        crdRobI[0] = crdRobI[0] + 1;
                                        break;
                                    case 3:
                                        crdRobI[1] = crdRobI[1] - 1;
                                        break;
                                    case 4:
                                        crdRobI[0] = crdRobI[0] - 1;
                                        break;
                                }
                            }
                        }

                        // Retornando o numero da direcao apos a movimentacao para letra, afim de mostrar no resultado.
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

                        // Linha 239 a Linha 258: Condicoes para verificar se a posicao do robo 1 apos a movimentacao eh valida ou se sera necessario passar outras instrucoes.

                        if (crdRobI[0] < 0 || crdRobI[1] < 0 || crdRobI[0] >= crdArea[0] || crdRobI[1] >= crdArea[1])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERRO!\nPosicionamento do robo invalido.");
                            Console.WriteLine("");
                            Console.WriteLine("Mensagem de erro: Voce digitou um comando que leva a uma coordenada invalida, verifique se as instrucoes levam para uma coordenada x,y dentro da area determinada.");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.Write("Aperte ENTER para prosseguir.");
                            Console.ReadLine();
                            Console.WriteLine("");
                            dirRobI = bckDirRobI;
                            crdRobI[0] = bckCrdRobI[0];
                            crdRobI[1] = bckCrdRobI[1];
                        }
                        else
                        {
                            posicaoValidaI = true;
                        }
                    }

                    Console.WriteLine("=======> Robo 2 <=======");
                    Console.WriteLine("");

                    // Linha 265 a Linha 273: Input e atribuicao das coordenadas e direcao iniciais do Robo 2.

                    Console.Write("Digite a coordenada inicial do Robo II e a sua direcao inicial, separados por virgula (X, Y, D): ");
                    inputCrdRobII = Console.ReadLine();
                    string[] inputCrdRobIIArr = inputCrdRobII.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    inputCrdRobIIArr[2] = inputCrdRobIIArr[2].Replace(" ", "");

                    crdRobII[0] = int.Parse(inputCrdRobIIArr[0]);
                    crdRobII[1] = int.Parse(inputCrdRobIIArr[1]);
                    uppChrII = inputCrdRobIIArr[2].ToUpper();
                    dirRobII = char.Parse(uppChrII);

                    // Linha 277 a Linha 304: Condicoes para verificar se as coordenadas e a direcao iniciais do Robo 2 sao validas.

                    if (crdRobII[0] < 0 || crdRobII[1] < 0 || crdRobII[0] > crdArea[0] || crdRobII[1] > crdArea[1])
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
                    else if (dirRobII != 'N' && dirRobII != 'S' && dirRobII != 'L' && dirRobII != 'O')
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
                        Console.WriteLine("");

                        // Atribuicao de valores as variveis de backup do Robo 2.
                        dirRobIINum = 0;
                        bckDirRobII = dirRobII;
                        bckCrdRobII[0] = crdRobII[0];
                        bckCrdRobII[1] = crdRobII[1];

                        // Variavel e abertura do loop para rodar a opcao de digitar o comando novamente, em caso, o input de instrucoes do robo 2 retorne erro.
                        bool posicaoValidaII = false;
                        while (posicaoValidaII == false)
                        {
                            // Linha 321 a Linha 324: Input da sequencia de comandos do Robo 2.

                            Console.Write("Digite sequencialmente os comandos para o Robo II (ex. EMEMEMEMDMDM): ");
                            cmdStrII = Console.ReadLine();
                            cmdStrUpII = cmdStrII.ToUpper();
                            char[] cmdSqcII = cmdStrUpII.ToCharArray();

                            // Linha 328 a Linha 396: Segue a mesma logica do Robo 1 para calcular a direcao e movimento.

                            switch (dirRobII)
                            {
                                case 'N':
                                    dirRobIINum = 1;
                                    break;
                                case 'L':
                                    dirRobIINum = 2;
                                    break;
                                case 'S':
                                    dirRobIINum = 3;
                                    break;
                                case 'O':
                                    dirRobIINum = 4;
                                    break;
                            }

                            for (int i = 0; i < cmdSqcII.Length; i++)
                            {
                                if (cmdSqcII[i] == 'E')
                                {
                                    dirRobIINum = dirRobIINum - 1;
                                    if (dirRobIINum == 0)
                                    {
                                        dirRobIINum = 4;
                                    }
                                }
                                else if (cmdSqcII[i] == 'D')
                                {
                                    dirRobIINum = dirRobIINum + 1;
                                    if (dirRobIINum == 5)
                                    {
                                        dirRobIINum = 1;
                                    }
                                }
                                else if (cmdSqcII[i] == 'M')
                                {
                                    switch (dirRobIINum)
                                    {
                                        case 1:
                                            crdRobII[1] = crdRobII[1] + 1;
                                            break;
                                        case 2:
                                            crdRobII[0] = crdRobII[0] + 1;
                                            break;
                                        case 3:
                                            crdRobII[1] = crdRobII[1] - 1;
                                            break;
                                        case 4:
                                            crdRobII[0] = crdRobII[0] - 1;
                                            break;
                                    }
                                }
                            }

                            switch (dirRobIINum)
                            {
                                case 1:
                                    dirRobII = 'N';
                                    break;
                                case 2:
                                    dirRobII = 'L';
                                    break;
                                case 3:
                                    dirRobII = 'S';
                                    break;
                                case 4:
                                    dirRobII = 'O';
                                    break;
                            }

                            Console.WriteLine("");

                            // Linha 402 a Linha 421: Condicoes para verificar se a posicao do robo 2 apos a movimentacao eh valida ou se sera necessario passar outras instrucoes.

                            if (crdRobII[0] < 0 || crdRobII[1] < 0 || crdRobII[0] >= crdArea[0] || crdRobII[1] >= crdArea[1])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERRO!\nPosicionamento do robo invalido.");
                                Console.WriteLine("");
                                Console.WriteLine("Mensagem de erro: Voce digitou um comando que leva a uma coordenada invalida, verifique se as instrucoes levam para uma coordenada x,y dentro da area determinada.");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.Write("Aperte ENTER para prosseguir.");
                                Console.ReadLine();
                                Console.WriteLine("");
                                dirRobII = bckDirRobII;
                                crdRobII[0] = bckCrdRobII[0];
                                crdRobII[1] = bckCrdRobII[1];
                            }
                            else
                            {
                                posicaoValidaII = true;
                            }
                        }

                        Console.WriteLine("=======> Resultado dos Movimentos <=======");
                        Console.WriteLine("");

                        // Linha 428 a Linha 432: Output do resultado.

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Coordenada final e posicionamento do Robo I (X, Y, D): {0}, {1}, {2}.", crdRobI[0], crdRobI[1], dirRobI);
                        Console.WriteLine("Coordenada final e posicionamento do Robo II (X, Y, D): {0}, {1}, {2}.", crdRobII[0], crdRobII[1], dirRobII);
                        Console.ResetColor();
                        Console.WriteLine("");

                        // Variavel e abertura do loop para rodar o menu de opcoes, para caso o usuario deseje fechar o programa ou rodalo novamente.
                        bool opcaoValida = false;
                        while (opcaoValida == false)
                        {
                            Console.WriteLine("Caso deseje realizar rodar o programa novamente e inserir novos comandos, digite 1 e aperte ENTER.");
                            Console.WriteLine("Caso deseje fechar o programa, digite 0 e aperte ENTER.");
                            Console.Write("Opcao escolhida: ");
                            string fecharBotao = Console.ReadLine();

                            if (fecharBotao == "0")
                            {
                                fecharApp = true;
                                opcaoValida = true;
                            }
                            else if (fecharBotao == "1")
                            {
                                Console.Clear();
                                opcaoValida = true;
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Opcao invalida, selecione uma opcao valida!");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.WriteLine("Aperte ENTER para prosseguir.");
                                Console.ReadLine();
                                continue;
                            }
                        }
                    }
                }
            }
        }
    }
}

// Obrigado por ler o codigo ate aqui e espero que tenha um bom dia!
// Codigo feito pelo Luan da Academia do Programador 2022.
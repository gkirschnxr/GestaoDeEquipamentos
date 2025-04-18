﻿using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();

        while (true)
        {
            string opcaoEscolhida = telaEquipamento.ApresentarMenu();

            switch (opcaoEscolhida)
            {
                case "1":
                    telaEquipamento.CadastrarEquipamento();
                    break;

                case "2":
                    telaEquipamento.EditarEquipamento();
                    break;

                case "3":
                    telaEquipamento.ExcluirEquipamento();
                    break;

                case "4":
                    telaEquipamento.VisualizarEquipamentos(true);
                    break;

                case "5":
                    TelaChamado telaChamado = new TelaChamado();

                    string opcaoChamadoEscolhida = telaChamado.ApresentarChamados();

                    switch (opcaoChamadoEscolhida)
                    {
                        case "1":
                            telaChamado.NovoChamado();
                            break;

                        case "2":
                            telaChamado.EditarChamado();
                            break;

                        case "3":
                            telaChamado.ExcluirChamado();
                            break;

                        case "4":
                            telaChamado.VisualizarChamado();
                            break;
                    }
                    break;

                default:
                    Console.WriteLine("Saindo do Programa...");
                    break;

            }

            Console.ReadLine();
            break;
        }
    }
}

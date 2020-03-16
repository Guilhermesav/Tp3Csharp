using System;
using System.Collections.Generic;
using System.Linq;

namespace Tp3Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, DateTime> Pessoas = new Dictionary<string, DateTime>();
          
            string escolha;
        
            do
            {
                Console.WriteLine("Escolha uma opção:");

                Console.WriteLine("A. Pesquisar Pessoas");
                Console.WriteLine("B. Adicionar Pessoas");
                Console.WriteLine("C. Sair");
                escolha = Console.ReadLine();
                escolha.ToLower();
                if (escolha == "a")
                {
                    Console.WriteLine("Escreva o nome da pessoa");
                    string nomePessoa = Console.ReadLine();
                    var resultadoPesquisa = (from pessoa in Pessoas where pessoa.Key.ToLower().Contains(nomePessoa.ToLower()) select pessoa).ToList();
                    if (resultadoPesquisa.Count >0)
                    {
                        Console.WriteLine("Escolha um dos nomes abaixo");
                        for (var i = 0; i< resultadoPesquisa.Count; i++)
                        {
                            Console.WriteLine($"{i}- {resultadoPesquisa[i].Key}");
                        }
                        var exibicao = Convert.ToInt32(Console.ReadLine());

                        if (exibicao < resultadoPesquisa.Count)
                        {
                            var pessoaSelecionada = resultadoPesquisa[exibicao];

                            Console.WriteLine("Informações Pessoais");
                            Console.WriteLine($"Nome: {pessoaSelecionada.Key}");
                            Console.WriteLine($"Data de Nascimento: {pessoaSelecionada.Value:dd/mm/yyyy}");

                            var aniversarioAtual = new DateTime(DateTime.Now.Year, pessoaSelecionada.Value.Month, pessoaSelecionada.Value.Day);

                            var tempoParaAniversario = aniversarioAtual - DateTime.Now.Date;
                            if (tempoParaAniversario.Days > 0)
                            {
                                Console.WriteLine($"Tempo para proximo aniversario: {tempoParaAniversario.Days} dias");
                               
                            }
                            else if (tempoParaAniversario.Days == 0)
                            {
                                Console.WriteLine("Você esta fazendo aniversario hoje.");

                            }
                            else
                            {
                                Console.WriteLine("Seu aniversario já passou");
                            }
                        }
                    }
                }       
                if (escolha == "b")
                {
                    Console.WriteLine("Escreva o nome que deseja adicionar:");
                    string nomePessoa = Console.ReadLine();
                    Console.WriteLine("Insira a data de nascimento da pessoa:");
                    string dataNiver = Console.ReadLine();

                    var niverDateTime = Convert.ToDateTime(dataNiver);

                    Pessoas.Add(nomePessoa, niverDateTime);
                    Console.WriteLine("Retornando ao Inicio");
                }
                if (escolha == "c")
                {
                    Console.WriteLine("Finalizando o programa");

                }
            } while (escolha != "c");

        }
    }
}

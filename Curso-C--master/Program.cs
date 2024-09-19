using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaGerenciamentoCursos
{
    class Program
    {
        static List<Curso> cursos = new List<Curso>();
        static List<Aluno> alunos = new List<Aluno>();
        static List<Matricula> matriculas = new List<Matricula>();

        static string caminhoCursos = @"C:\path\to\cursos.json"; // Caminho para o arquivo cursos.json
        static string caminhoAlunos = @"C:\path\to\alunos.json"; // Caminho para o arquivo alunos.json
        static string caminhoMatriculas = @"C:\path\to\matriculas.json"; // Caminho para o arquivo matriculas.json

        static void Main(string[] args)
        {
            CarregarDados();

            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("=========  SISTEMA DE GERENCIAMENTO  =========");
                Console.WriteLine("==========    DE CURSOS E ALUNOS   ===========");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Gerenciar Cursos");
                Console.WriteLine("2. Gerenciar Alunos");
                Console.WriteLine("3. Gerenciar Matrículas");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuCursos();
                        break;
                    case 2:
                        MenuAlunos();
                        break;
                    case 3:
                        MenuMatriculas();
                        break;
                    case 0:
                        SalvarDados();
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void MenuCursos()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========  GERENCIAR CURSOS  ================");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Curso");
                Console.WriteLine("2. Listar Cursos");
                Console.WriteLine("3. Atualizar Curso");
                Console.WriteLine("4. Remover Curso");
                Console.WriteLine("0. Voltar");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarCurso();
                        break;
                    case 2:
                        ListarCursos();
                        break;
                    case 3:
                        AtualizarCurso();
                        break;
                    case 4:
                        RemoverCurso();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void MenuAlunos()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   GERENCIAR ALUNOS   ==============");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Aluno");
                Console.WriteLine("2. Listar Alunos");
                Console.WriteLine("3. Atualizar Aluno");
                Console.WriteLine("4. Remover Aluno");
                Console.WriteLine("0. Voltar");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarAluno();
                        break;
                    case 2:
                        ListarAlunos();
                        break;
                    case 3:
                        AtualizarAluno();
                        break;
                    case 4:
                        RemoverAluno();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void MenuMatriculas()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   GERENCIAR MATRÍCULAS   ==========");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Matrícula");
                Console.WriteLine("2. Listar Matrículas");
                Console.WriteLine("3. Atualizar Matrícula");
                Console.WriteLine("4. Remover Matrícula");
                Console.WriteLine("0. Voltar");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarMatricula();
                        break;
                    case 2:
                        ListarMatriculas();
                        break;
                    case 3:
                        AtualizarMatricula();
                        break;
                    case 4:
                        RemoverMatricula();
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        // Métodos para gerenciar Cursos
        static void AdicionarCurso()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======    ADICIONAR NOVO CURSO    ============");
            Console.WriteLine("==============================================");
            Console.Write("Digite o nome do curso: ");
            string nome = Console.ReadLine();

            int id = cursos.Count > 0 ? cursos[^1].Id + 1 : 1;
            Curso curso = new Curso(id, nome);
            cursos.Add(curso);

            Console.WriteLine("\nCurso adicionado com sucesso!");
            SalvarDados();
        }

        static void ListarCursos()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========      LISTA DE CURSOS    ==========");
            Console.WriteLine("==============================================");

            if (cursos.Count == 0)
            {
                Console.WriteLine("\nNenhum curso cadastrado.");
            }
            else
            {
                foreach (var curso in cursos)
                {
                    Console.WriteLine($"ID: {curso.Id} - Nome: {curso.Nome}");
                }
            }
        }

        static void AtualizarCurso()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("========== ATUALIZAR CURSO   ================");
            Console.WriteLine("==============================================");

            Console.Write("Digite o ID do curso a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var curso = cursos.Find(c => c.Id == id);

            if (curso != null)
            {
                Console.Write("Digite o novo nome do curso: ");
                curso.Nome = Console.ReadLine();

                Console.WriteLine("\nCurso atualizado com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\nCurso não encontrado.");
            }
        }

        static void RemoverCurso()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   REMOVER CURSO    ===============");
            Console.WriteLine("==============================================");

            Console.Write("Digite o ID do curso a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            var curso = cursos.Find(c => c.Id == id);

            if (curso != null)
            {
                cursos.Remove(curso);
                Console.WriteLine("\nCurso removido com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\nCurso não encontrado.");
            }
        }

        // Métodos para gerenciar Alunos
        static void AdicionarAluno()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======    ADICIONAR NOVO ALUNO    ============");
            Console.WriteLine("==============================================");
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            int id = alunos.Count > 0 ? alunos[^1].Id + 1 : 1;
            Aluno aluno = new Aluno(id, nome);
            alunos.Add(aluno);

            Console.WriteLine("\nAluno adicionado com sucesso!");
            SalvarDados();
        }

        static void ListarAlunos()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========      LISTA DE ALUNOS    ==========");
            Console.WriteLine("==============================================");

            if (alunos.Count == 0)
            {
                Console.WriteLine("\nNenhum aluno cadastrado.");
            }
            else
            {
                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"ID: {aluno.Id} - Nome: {aluno.Nome}");
                }
            }
        }

        static void AtualizarAluno()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("========== ATUALIZAR ALUNO   ================");
            Console.WriteLine("==============================================");

            Console.Write("Digite o ID do aluno a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.Find(a => a.Id == id);

            if (aluno != null)
            {
                Console.Write("Digite o novo nome do aluno: ");
                aluno.Nome = Console.ReadLine();

                Console.WriteLine("\nAluno atualizado com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado.");
            }
        }

        static void RemoverAluno()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   REMOVER ALUNO    ===============");
            Console.WriteLine("==============================================");

            Console.Write("Digite o ID do aluno a ser removido: ");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.Find(a => a.Id == id);

            if (aluno != null)
            {
                alunos.Remove(aluno);
                Console.WriteLine("\nAluno removido com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado.");
            }
        }

        // Métodos para gerenciar Matrículas
        static void AdicionarMatricula()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("======    ADICIONAR NOVA MATRÍCULA   =========");
            Console.WriteLine("==============================================");

            ListarCursos();
            Console.Write("\nDigite o ID do curso: ");
            int idCurso = int.Parse(Console.ReadLine());

            ListarAlunos();
            Console.Write("\nDigite o ID do aluno: ");
            int idAluno = int.Parse(Console.ReadLine());

            int id = matriculas.Count > 0 ? matriculas[^1].Id + 1 : 1;
            Matricula matricula = new Matricula(id, idAluno, idCurso);
            matriculas.Add(matricula);

            Console.WriteLine("\nMatrícula realizada com sucesso!");
            SalvarDados();
        }

        static void ListarMatriculas()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========      LISTA DE MATRÍCULAS   ========");
            Console.WriteLine("==============================================");

            if (matriculas.Count == 0)
            {
                Console.WriteLine("\nNenhuma matrícula registrada.");
            }
            else
            {
                foreach (var matricula in matriculas)
                {
                    var aluno = alunos.Find(a => a.Id == matricula.IdAluno);
                    var curso = cursos.Find(c => c.Id == matricula.IdCurso);

                    if (aluno != null && curso != null)
                    {
                        Console.WriteLine($"Matrícula ID: {matricula.Id} - Aluno: {aluno.Nome} - Curso: {curso.Nome}");
                    }
                }
            }
        }

        static void AtualizarMatricula()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("========== ATUALIZAR MATRÍCULA   =============");
            Console.WriteLine("==============================================");

            Console.Write("Digite o ID da matrícula a ser atualizada: ");
            int id = int.Parse(Console.ReadLine());

            var matricula = matriculas.Find(m => m.Id == id);

            if (matricula != null)
            {
                ListarCursos();
                Console.Write("\nDigite o novo ID do curso: ");
                matricula.IdCurso = int.Parse(Console.ReadLine());

                ListarAlunos();
                Console.Write("\nDigite o novo ID do aluno: ");
                matricula.IdAluno = int.Parse(Console.ReadLine());

                Console.WriteLine("\nMatrícula atualizada com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\nMatrícula não encontrada.");
            }
        }

        static void RemoverMatricula()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   REMOVER MATRÍCULA    ===========");
            Console.WriteLine("==============================================");

            Console.Write("Digite o ID da matrícula a ser removida: ");
            int id = int.Parse(Console.ReadLine());

            var matricula = matriculas.Find(m => m.Id == id);

            if (matricula != null)
            {
                matriculas.Remove(matricula);
                Console.WriteLine("\nMatrícula removida com sucesso!");
                SalvarDados();
            }
            else
            {
                Console.WriteLine("\nMatrícula não encontrada.");
            }
        }

        // Métodos para carregar e salvar dados em arquivos JSON
        static void CarregarDados()
        {
            if (File.Exists(caminhoCursos))
            {
                string jsonCursos = File.ReadAllText(caminhoCursos);
                cursos = JsonSerializer.Deserialize<List<Curso>>(jsonCursos);
            }

            if (File.Exists(caminhoAlunos))
            {
                string jsonAlunos = File.ReadAllText(caminhoAlunos);
                alunos = JsonSerializer.Deserialize<List<Aluno>>(jsonAlunos);
            }

            if (File.Exists(caminhoMatriculas))
            {
                string jsonMatriculas = File.ReadAllText(caminhoMatriculas);
                matriculas = JsonSerializer.Deserialize<List<Matricula>>(jsonMatriculas);
            }
        }

        static void SalvarDados()
        {
            string jsonCursos = JsonSerializer.Serialize(cursos);
            File.WriteAllText(caminhoCursos, jsonCursos);

            string jsonAlunos = JsonSerializer.Serialize(alunos);
            File.WriteAllText(caminhoAlunos, jsonAlunos);

            string jsonMatriculas = JsonSerializer.Serialize(matriculas);
            File.WriteAllText(caminhoMatriculas, jsonMatriculas);
        }
    }

    // Definição das classes
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Curso(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class Matricula
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public int IdCurso { get; set; }

        public Matricula(int id, int idAluno, int idCurso)
        {
            Id = id;
            IdAluno = idAluno;
            IdCurso = idCurso;
        }
    }
}

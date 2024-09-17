
/*namespace BibliotecaVeiculos
{

    class Program
    {
        static List<Usuario> usuarios = new List<Usuario>(); // Lista de usuários

        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            int opcao = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   SISTEMA DE GERENCIAMENTO   ======");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Biblioteca de Livros");
                Console.WriteLine("2. Gerenciar Usuários");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuBiblioteca(biblioteca);
                        break;
                    case 2:
                        MenuUsuarios();
                        break;
                    case 0:
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void MenuBiblioteca(Biblioteca biblioteca)
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   BIBLIOTECA DE LIVROS   ==========");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Listar Livros");
                Console.WriteLine("3. Emprestar Livro");
                Console.WriteLine("4. Devolver Livro");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("==============================================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro(biblioteca);
                        break;
                    case 2:
                        biblioteca.ListarLivros();
                        break;
                    case 3:
                        EmprestarLivro(biblioteca);
                        break;
                    case 4:
                        DevolverLivro(biblioteca);
                        break;
                    case 0:
                        Console.WriteLine("\nVoltando ao menu principal...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey(); // Pausa para permitir que o usuário veja a mensagem antes de continuar
            } while (opcao != 0);
        }

        static void MenuUsuarios()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   GERENCIAR USUÁRIOS   ============");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Usuário");
                Console.WriteLine("2. Listar Usuários");
                Console.WriteLine("3. Remover Usuário");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("==============================================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarUsuario();
                        break;
                    case 2:
                        ListarUsuarios();
                        break;
                    case 3:
                        RemoverUsuario();
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

        static void AdicionarUsuario()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========   ADICIONAR NOVO USUÁRIO   =========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o nome do usuário: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF do usuário: ");
            string cpf = Console.ReadLine();

            Usuario usuario = new Usuario(nome, cpf);
            usuarios.Add(usuario);
            Console.WriteLine("\nUsuário adicionado com sucesso!");
        }

        static void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========   LISTA DE USUÁRIOS CADASTRADOS   =========");
            Console.WriteLine("==============================================");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("\nNenhum usuário cadastrado.");
            }
            else
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {usuarios[i].Nome} - CPF: {usuarios[i].Cpf}");
                }
            }
        }

        static Usuario SelecionarUsuario()
        {
            ListarUsuarios();
            if (usuarios.Count == 0)
            {
                return null;
            }

            Console.Write("\nSelecione o número do usuário: ");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha > 0 && escolha <= usuarios.Count)
            {
                return usuarios[escolha - 1];
            }
            else
            {
                Console.WriteLine("\nUsuário inválido.");
                return null;
            }
        }

        static void RemoverUsuario()
        {
            ListarUsuarios();
            if (usuarios.Count == 0)
            {
                return;
            }

            Console.Write("\nSelecione o número do usuário a ser removido: ");
            int escolha = int.Parse(Console.ReadLine());

            if (escolha > 0 && escolha <= usuarios.Count)
            {
                usuarios.RemoveAt(escolha - 1);
                Console.WriteLine("\nUsuário removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nUsuário inválido.");
            }
        }

        static void AdicionarLivro(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("=========   ADICIONAR NOVO LIVRO   ==========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Digite o autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write("Digite o ano de publicação: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Digite o número de páginas: ");
            int paginas = int.Parse(Console.ReadLine());

            Livro livro = new Livro(titulo, autor, ano, paginas);
            biblioteca.AdicionarLivro(livro);
            Console.WriteLine("\nLivro adicionado com sucesso!");
        }

        static void EmprestarLivro(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   EMPRÉSTIMO DE LIVRO   ==========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o título do livro a ser emprestado: ");
            string titulo = Console.ReadLine();
            Livro livro = biblioteca.BuscarLivroPorTitulo(titulo);
            if (livro != null)
            {
                Usuario usuario = SelecionarUsuario();
                if (usuario != null)
                {
                    usuario.EmprestarLivro(livro, biblioteca);
                    Console.WriteLine("\nLivro emprestado com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nOperação cancelada: Usuário inválido.");
                }
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado no acervo.");
            }
        }

        static void DevolverLivro(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("===========   DEVOLUÇÃO DE LIVRO   ===========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o título do livro a ser devolvido: ");
            string titulo = Console.ReadLine();
            Livro livro = biblioteca.BuscarLivroPorTitulo(titulo);
            if (livro != null)
            {
                Usuario usuario = SelecionarUsuario();
                if (usuario != null)
                {
                    usuario.DevolverLivro(livro, biblioteca);
                    Console.WriteLine("\nLivro devolvido com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nOperação cancelada: Usuário inválido.");
                }
            }
            else
            {
                Console.WriteLine("\nLivro não encontrado na lista de empréstimos.");
            }
        }
    }

}
*/

/*namespace Curso_C_
{
    class Program
    {
        static List<Aluno> alunos = new List<Aluno>();
        static List<Curso> cursos = new List<Curso>();
        static List<Matricula> matriculas = new List<Matricula>();

        static void Main()
        {
            // Adiciona dados de exemplo
            alunos.Add(new Aluno(1, "João Silva", "joao.silva@email.com"));
            cursos.Add(new Curso(1, "Matemática", 4));

            bool continuar = true;
            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("Sistema de Gerenciamento de Cursos");
                Console.WriteLine("1. Gerenciar Alunos");
                Console.WriteLine("2. Gerenciar Cursos");
                Console.WriteLine("3. Gerenciar Matrículas");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        GerenciarAlunos();
                        break;
                    case "2":
                        GerenciarCursos();
                        break;
                    case "3":
                        GerenciarMatriculas();
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GerenciarAlunos()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("Gerenciar Alunos");
                Console.WriteLine("1. Listar Alunos");
                Console.WriteLine("2. Adicionar Aluno");
                Console.WriteLine("3. Atualizar Aluno");
                Console.WriteLine("4. Excluir Aluno");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListarAlunos();
                        break;
                    case "2":
                        AdicionarAluno();
                        break;
                    case "3":
                        AtualizarAluno();
                        break;
                    case "4":
                        ExcluirAluno();
                        break;
                    case "5":
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListarAlunos()
        {
            Console.Clear();
            Console.WriteLine("Lista de Alunos:");
            if (alunos.Count == 0)
            {
                Console.WriteLine("Nenhum aluno cadastrado.");
            }
            else
            {
                foreach (var aluno in alunos)
                {
                    Console.WriteLine(aluno);
                }
            }
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void AdicionarAluno()
        {
            Console.Clear();
            Console.Write("Digite o ID do aluno: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o email do aluno: ");
            string email = Console.ReadLine();

            // Verifica se o ID já está em uso
            if (alunos.Any(a => a.Id == id))
            {
                Console.WriteLine("Já existe um aluno com esse ID. Pressione qualquer tecla para voltar...");
            }
            else
            {
                alunos.Add(new Aluno(id, nome, email));
                Console.WriteLine("Aluno adicionado com sucesso. Pressione qualquer tecla para voltar...");
            }
            Console.ReadKey();
        }

        static void AtualizarAluno()
        {
            Console.Clear();
            Console.Write("Digite o ID do aluno a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno != null)
            {
                Console.Write("Digite o novo nome do aluno: ");
                aluno.Nome = Console.ReadLine();
                Console.Write("Digite o novo email do aluno: ");
                aluno.Email = Console.ReadLine();
                Console.WriteLine("Aluno atualizado com sucesso. Pressione qualquer tecla para voltar...");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado. Pressione qualquer tecla para voltar...");
            }
            Console.ReadKey();
        }

        static void ExcluirAluno()
        {
            Console.Clear();
            Console.Write("Digite o ID do aluno a ser excluído: ");
            int id = int.Parse(Console.ReadLine());

            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if (aluno != null)
            {
                alunos.Remove(aluno);
                // Remove todas as matrículas associadas ao aluno
                matriculas.RemoveAll(m => m.Aluno.Id == id);
                Console.WriteLine("Aluno excluído com sucesso. Pressione qualquer tecla para voltar...");
            }
            else
            {
                Console.WriteLine("Aluno não encontrado. Pressione qualquer tecla para voltar...");
            }
            Console.ReadKey();
        }

        static void GerenciarCursos()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("Gerenciar Cursos");
                Console.WriteLine("1. Listar Cursos");
                Console.WriteLine("2. Adicionar Curso");
                Console.WriteLine("3. Voltar");
                Console.Write("Escolha uma opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListarCursos();
                        break;
                    case "2":
                        AdicionarCurso();
                        break;
                    case "3":
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListarCursos()
        {
            Console.Clear();
            Console.WriteLine("Lista de Cursos:");
            if (cursos.Count == 0)
            {
                Console.WriteLine("Nenhum curso cadastrado.");
            }
            else
            {
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso);
                }
            }
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void AdicionarCurso()
        {
            Console.Clear();
            Console.Write("Digite o ID do curso: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do curso: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a quantidade de créditos do curso: ");
            int creditos = int.Parse(Console.ReadLine());

            // Verifica se o ID já está em uso
            if (cursos.Any(c => c.Id == id))
            {
                Console.WriteLine("Já existe um curso com esse ID. Pressione qualquer tecla para voltar...");
            }
            else
            {
                cursos.Add(new Curso(id, nome, creditos));
                Console.WriteLine("Curso adicionado com sucesso. Pressione qualquer tecla para voltar...");
            }
            Console.ReadKey();
        }

        static void GerenciarMatriculas()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("Gerenciar Matrículas");
                Console.WriteLine("1. Listar Matrículas");
                Console.WriteLine("2. Adicionar Matrícula");
                Console.WriteLine("3. Voltar");
                Console.Write("Escolha uma opção: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ListarMatriculas();
                        break;
                    case "2":
                        AdicionarMatricula();
                        break;
                    case "3":
                        voltar = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListarMatriculas()
        {
            Console.Clear();
            Console.WriteLine("Lista de Matrículas:");
            if (matriculas.Count == 0)
            {
                Console.WriteLine("Nenhuma matrícula cadastrada.");
            }
            else
            {
                foreach (var matricula in matriculas)
                {
                    Console.WriteLine(matricula);
                }
            }
            Console.WriteLine("Pressione qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void AdicionarMatricula()
        {
            Console.Clear();
            Console.Write("Digite o ID do aluno: ");
            int alunoId = int.Parse(Console.ReadLine());
            Console.Write("Digite o ID do curso: ");
            int cursoId = int.Parse(Console.ReadLine());

            var aluno = alunos.FirstOrDefault(a => a.Id == alunoId);
            var curso = cursos.FirstOrDefault(c => c.Id == cursoId);

            if (aluno != null && curso != null)
            {
                matriculas.Add(new Matricula(aluno, curso, DateTime.Now));
                Console.WriteLine("Matrícula adicionada com sucesso. Pressione qualquer tecla para voltar...");
            }
            else
            {
                Console.WriteLine("Aluno ou Curso não encontrado. Pressione qualquer tecla para voltar...");
            }
            Console.ReadKey();
        }
    }
}
*/

/*

// Instância de Cachorro
Cachorro cachorro = new Cachorro("Rex");
cachorro.ExibirInformacoes();
cachorro.FazerSom();
cachorro.ExplicarHeranca();

// Instância de Gato
Gato gato = new Gato("Mimi");
gato.ExibirInformacoes();
gato.FazerSom();
gato.ExplicarHeranca();

*/

/*
// Criando um objeto Endereco que pode existir independentemente
Endereco endereco = new Endereco("Rua Principal", "Cidade Exemplo");

// Criando um objeto Pessoa que contém um Endereco (agregação)
PessoaAgrecacao pessoa = new PessoaAgrecacao("João", endereco);

// Exibir as informações da pessoa e seu endereço
pessoa.ExibirInformacoes();

// Explicando o conceito de agregação
pessoa.ExplicarAgregacao();
*/

/*
// Criando um objeto Departamento
Departamento departamento = new Departamento("Recursos Humanos");

// Criando um objeto Funcionario que está associado a um Departamento
Funcionario funcionarioComDepartamento = new Funcionario("Ana", departamento);

// Criando um objeto Funcionario sem associação a nenhum Departamento
Funcionario funcionarioSemDepartamento = new Funcionario("Carlos");

// Exibir as informações dos funcionários
funcionarioComDepartamento.ExibirInformacoes();
funcionarioSemDepartamento.ExibirInformacoes();

// Explicando o conceito de associação
funcionarioComDepartamento.ExplicarAssociacao();
*/

/*
// Criando um objeto Carro, que inclui a criação de um Motor
Carro carro = new Carro("Fusca", "Motor 1600");

// Exibindo informações sobre o carro e seu motor
carro.ExibirInformacoes();

// Explicando o conceito de composição
carro.ExplicarComposicao();
*/

/*

// Criando funcionários
FuncionarioMulti funcionario1 = new FuncionarioMulti("Ana");
FuncionarioMulti funcionario2 = new FuncionarioMulti("Carlos");

// Criando um projeto
Projeto projeto = new Projeto("Desenvolvimento de Software");

// Adicionando funcionários ao projeto
projeto.AdicionarFuncionario(funcionario1);
projeto.AdicionarFuncionario(funcionario2);

// Exibindo informações sobre o projeto e seus funcionários
projeto.ExibirInformacoes();

// Explicando o conceito de multiplicidade
projeto.ExplicarMultiplicidade();
*/

/*
AnimalAbs cachorro = new CachorroAbs("Rex");
AnimalAbs gato = new GatoAbs("Mimi");

// Exibindo informações e fazendo som dos animais
cachorro.ExibirInformacoes();
cachorro.FazerSom();

gato.ExibirInformacoes();
gato.FazerSom();

// Explicando o conceito de classe abstrata
cachorro.ExplicarClasseAbstrata();
*/

/*
// Criando instâncias de classes que implementam a interface
IAnimal cachorro = new CachorroInter("Rex");
IAnimal gato = new GatoInter("Mimi");

 Exibindo informações e sons dos animais
cachorro.ExibirInformacoes();
cachorro.FazerSom();

gato.ExibirInformacoes();
gato.FazerSom();

// Explicando o conceito de interface
ExplicadorDeInterface explicador = new ExplicadorDeInterface();
explicador.ExplicarInterface();
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaGerenciamentoCursos
{
    class Program
    {
        static List<Aluno> alunos = new List<Aluno>();
        static List<Curso> cursos = new List<Curso>();
        static List<Matricula> matriculas = new List<Matricula>();

        static void Main(string[] args)
        {
            string caminhoAlunos = @"C:\Users\Aluno Noite\Downloads\Curso-C--master\Curso-C--master\alunos.json"; // Altere para o caminho absoluto do seu arquivo alunos.json
            string caminhoCursos = @"C:\Users\Aluno Noite\Downloads\Curso-C--master\Curso-C--master\cursos.json"; // Altere para o caminho absoluto do seu arquivo cursos.json
            string caminhoMatriculas = @"C:\Users\Aluno Noite\Downloads\Curso-C--master\Curso-C--master\matriculas.json"; // Altere para o caminho absoluto do seu arquivo matriculas.json

            CarregarDados(caminhoAlunos, caminhoCursos, caminhoMatriculas);

            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("========== SISTEMA DE GERENCIAMENTO ==========");
                Console.WriteLine("==========       DE CURSOS       ============");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Gerenciar Alunos");
                Console.WriteLine("2. Gerenciar Cursos");
                Console.WriteLine("3. Gerenciar Matrículas");
                Console.WriteLine("0. Sair");

                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuAlunos();
                        break;
                    case 2:
                        MenuCursos();
                        break;
                    case 3:
                        MenuMatriculas();
                        break;
                    case 0:
                        SalvarDados(caminhoAlunos, caminhoCursos, caminhoMatriculas); // Salva dados antes de sair
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void MenuAlunos()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   GERENCIAR ALUNOS   =============");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Aluno");
                Console.WriteLine("2. Listar Alunos");
                Console.WriteLine("3. Atualizar Aluno");
                Console.WriteLine("4. Remover Aluno");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("==============================================");
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
                Console.ReadKey(); // Pausa para permitir que o usuário veja a mensagem antes de continuar
            } while (opcao != 0);
        }

        static void MenuCursos()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("==========   GERENCIAR CURSOS   =============");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Adicionar Curso");
                Console.WriteLine("2. Listar Cursos");
                Console.WriteLine("3. Atualizar Curso");
                Console.WriteLine("4. Remover Curso");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("==============================================");
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

        static void MenuMatriculas()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("========== GERENCIAR MATRÍCULAS ==============");
                Console.WriteLine("==============================================\n");
                Console.WriteLine("1. Realizar Matrícula");
                Console.WriteLine("2. Cancelar Matrícula");
                Console.WriteLine("3. Listar Matrículas");
                Console.WriteLine("0. Voltar");
                Console.WriteLine("==============================================");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RealizarMatricula();
                        break;
                    case 2:
                        CancelarMatricula();
                        break;
                    case 3:
                        ListarMatriculas();
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

        static void AdicionarAluno()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========    ADICIONAR NOVO ALUNO   =========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o email do aluno: ");
            string email = Console.ReadLine();

            if (alunos.Exists(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nAluno já cadastrado.");
            }
            else
            {
                int id = alunos.Count + 1; // Geração simples de ID
                alunos.Add(new Aluno(id, nome, email));
                Console.WriteLine("\nAluno adicionado com sucesso!");
            }
        }

        static void ListarAlunos()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========       LISTA DE ALUNOS   ===========");
            Console.WriteLine("==============================================");

            if (alunos.Count == 0)
            {
                Console.WriteLine("\nNenhum aluno cadastrado.");
            }
            else
            {
                foreach (var aluno in alunos)
                {
                    Console.WriteLine(aluno);
                }
            }
        }

        static void AtualizarAluno()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   ATUALIZAR INFORMAÇÕES   =========");
            Console.WriteLine("==============================================");
            Console.WriteLine("Digite o email do aluno a ser atualizado:");
            ListarAlunos();

            string emailAtual = Console.ReadLine();
            var aluno = alunos.Find(a => a.Email.Equals(emailAtual, StringComparison.OrdinalIgnoreCase));

            if (aluno != null)
            {
                Console.Write("Digite o novo nome do aluno: ");
                aluno.Nome = Console.ReadLine();
                Console.Write("Digite o novo email do aluno: ");
                string novoEmail = Console.ReadLine();

                if (alunos.Exists(a => a.Email.Equals(novoEmail, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("\nEmail de aluno já existente.");
                }
                else
                {
                    aluno.Email = novoEmail;
                    Console.WriteLine("\nInformações do aluno atualizadas com sucesso!");
                }
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
            Console.WriteLine("==========     REMOVER ALUNO    ==============");
            Console.WriteLine("==============================================");
            Console.WriteLine("Digite o email do aluno a ser removido:");
            ListarAlunos();

            string email = Console.ReadLine();
            var aluno = alunos.Find(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (aluno != null)
            {
                alunos.Remove(aluno);
                Console.WriteLine("\nAluno removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado.");
            }
        }

        static void AdicionarCurso()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========    ADICIONAR NOVO CURSO   =========");
            Console.WriteLine("==============================================");
            Console.Write("Digite o nome do curso: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a carga horária do curso (em horas): ");
            int cargaHoraria = int.Parse(Console.ReadLine());

            if (cursos.Exists(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("\nCurso já cadastrado.");
            }
            else
            {
                int id = cursos.Count + 1; // Geração simples de ID
                cursos.Add(new Curso(id, nome, cargaHoraria));
                Console.WriteLine("\nCurso adicionado com sucesso!");
            }
        }

        static void ListarCursos()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========       LISTA DE CURSOS   ===========");
            Console.WriteLine("==============================================");

            if (cursos.Count == 0)
            {
                Console.WriteLine("\nNenhum curso cadastrado.");
            }
            else
            {
                foreach (var curso in cursos)
                {
                    Console.WriteLine(curso);
                }
            }
        }

        static void AtualizarCurso()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   ATUALIZAR INFORMAÇÕES   =========");
            Console.WriteLine("==============================================");
            Console.WriteLine("Digite o nome do curso a ser atualizado:");
            ListarCursos();

            string nomeAtual = Console.ReadLine();
            var curso = cursos.Find(c => c.Nome.Equals(nomeAtual, StringComparison.OrdinalIgnoreCase));

            if (curso != null)
            {
                Console.Write("Digite o novo nome do curso: ");
                curso.Nome = Console.ReadLine();
                Console.Write("Digite a nova carga horária do curso (em horas): ");
                curso.CargaHoraria = int.Parse(Console.ReadLine());

                Console.WriteLine("\nInformações do curso atualizadas com sucesso!");
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
            Console.WriteLine("==========     REMOVER CURSO    ==============");
            Console.WriteLine("==============================================");
            Console.WriteLine("Digite o nome do curso a ser removido:");
            ListarCursos();

            string nome = Console.ReadLine();
            var curso = cursos.Find(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (curso != null)
            {
                cursos.Remove(curso);
                Console.WriteLine("\nCurso removido com sucesso!");
            }
            else
            {
                Console.WriteLine("\nCurso não encontrado.");
            }
        }

        static void RealizarMatricula()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========   REALIZAR MATRÍCULA   ============");
            Console.WriteLine("==============================================");
            Console.WriteLine("Selecione o aluno para matrícula:");
            ListarAlunos();

            int idAluno = int.Parse(Console.ReadLine());
            var aluno = alunos.Find(a => a.Id == idAluno);

            if (aluno != null)
            {
                Console.WriteLine("Selecione o curso para matrícula:");
                ListarCursos();

                int idCurso = int.Parse(Console.ReadLine());
                var curso = cursos.Find(c => c.Id == idCurso);

                if (curso != null)
                {
                    matriculas.Add(new Matricula(aluno, curso));
                    Console.WriteLine("\nMatrícula realizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nCurso não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("\nAluno não encontrado.");
            }
        }

        static void CancelarMatricula()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========  CANCELAR MATRÍCULA  =============");
            Console.WriteLine("==============================================");
            Console.WriteLine("Selecione a matrícula para cancelar:");
            ListarMatriculas();

            int indice = int.Parse(Console.ReadLine()) - 1;

            if (indice >= 0 && indice < matriculas.Count)
            {
                matriculas.RemoveAt(indice);
                Console.WriteLine("\nMatrícula cancelada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNúmero de matrícula inválido.");
            }
        }

        static void ListarMatriculas()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("==========     LISTA DE MATRÍCULAS  ===========");
            Console.WriteLine("==============================================");

            if (matriculas.Count == 0)
            {
                Console.WriteLine("\nNenhuma matrícula registrada.");
            }
            else
            {
                foreach (var matricula in matriculas)
                {
                    Console.WriteLine(matricula);
                }
            }
        }

        static void CarregarDados(string caminhoAlunos, string caminhoCursos, string caminhoMatriculas)
        {
            if (File.Exists(caminhoAlunos))
            {
                string jsonAlunos = File.ReadAllText(caminhoAlunos);
                alunos = JsonSerializer.Deserialize<List<Aluno>>(jsonAlunos) ?? new List<Aluno>();
            }

            if (File.Exists(caminhoCursos))
            {
                string jsonCursos = File.ReadAllText(caminhoCursos);
                cursos = JsonSerializer.Deserialize<List<Curso>>(jsonCursos) ?? new List<Curso>();
            }

            if (File.Exists(caminhoMatriculas))
            {
                string jsonMatriculas = File.ReadAllText(caminhoMatriculas);
                matriculas = JsonSerializer.Deserialize<List<Matricula>>(jsonMatriculas) ?? new List<Matricula>();
            }
        }

        static void SalvarDados(string caminhoAlunos, string caminhoCursos, string caminhoMatriculas)
        {
            string jsonAlunos = JsonSerializer.Serialize(alunos);
            File.WriteAllText(caminhoAlunos, jsonAlunos);

            string jsonCursos = JsonSerializer.Serialize(cursos);
            File.WriteAllText(caminhoCursos, jsonCursos);

            string jsonMatriculas = JsonSerializer.Serialize(matriculas);
            File.WriteAllText(caminhoMatriculas, jsonMatriculas);
        }
    }

    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public Aluno(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Email: {Email}";
        }
    }

    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }

        public Curso(int id, string nome, int cargaHoraria)
        {
            Id = id;
            Nome = nome;
            CargaHoraria = cargaHoraria;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Carga Horária: {CargaHoraria} horas";
        }
    }

    public class Matricula
    {
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }

        public Matricula(Aluno aluno, Curso curso)
        {
            Aluno = aluno;
            Curso = curso;
        }

        public override string ToString()
        {
            return $"Aluno: {Aluno.Nome} - Curso: {Curso.Nome}";
        }
    }
}

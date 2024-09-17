namespace Curso_C_
{
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
            return $"{Id} - {Nome} ({Email})";
        }
    }
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Creditos { get; set; }

        public Curso(int id, string nome, int creditos)
        {
            Id = id;
            Nome = nome;
            Creditos = creditos;
        }

        public override string ToString()
        {
            return $"{Id} - {Nome} ({Creditos} créditos)";
        }
    }
    public class Matricula
    {
        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }
        public DateTime DataMatricula { get; set; }

        public Matricula(Aluno aluno, Curso curso, DateTime dataMatricula)
        {
            Aluno = aluno;
            Curso = curso;
            DataMatricula = dataMatricula;
        }

        public override string ToString()
        {
            return $"{Aluno.Nome} matriculado em {Curso.Nome} em {DataMatricula.ToShortDateString()}";
        }
    }
}

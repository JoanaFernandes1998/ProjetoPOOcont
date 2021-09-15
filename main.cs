using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass
{
    private static NAluno naluno = new NAluno();
    private static NMatricula nmatricula = new NMatricula();
    private static NCurso ncurso = new NCurso();
    public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    int op = 0;
    Console.WriteLine ("----- Aplicativo de Escolar ------");
    do {
            try
            {
                op = Menu();
                switch (op)
                {
                    case 01: AlunoListar(); break;
                    case 02: AlunoInserir(); break;
                    case 03: AlunoAtualizar(); break;
                    case 04: AlunoExcluir(); break;
                    case 05: MatriculaListar(); break;
                    case 06: MatriculaInserir(); break;
                    case 07: MatriculaAtualizar(); break;
                    case 08: MatriculaExcluir(); break;
                    case 09: CursoListar(); break;
                    case 10: CursoInserir(); break;
                    case 11: CursoAtualizar(); break;
                    case 12: CursoExcluir(); break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                op = 100;
            }
        } while (op != 0);
        Console.WriteLine("Bye.....");
    }
    public static int Menu()
    {
        Console.WriteLine();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("01 - Aluno - Listar");
        Console.WriteLine("02 - Aluno - Inserir");
        Console.WriteLine("03 - Aluno - Atualizar");
        Console.WriteLine("04 - Aluno - Excluir");
        Console.WriteLine("05 - Matricula - Listar");
        Console.WriteLine("06 - Matricula - Inserir");
        Console.WriteLine("07 - Matricula - Atualizar");
        Console.WriteLine("08 - Matricula - Excluir");
        Console.WriteLine("09 - Curso - Listar");
        Console.WriteLine("10 - Curso - Inserir");
        Console.WriteLine("11 - Curso - Atualizar");
        Console.WriteLine("12 - Curso - Excluir");
        Console.WriteLine("0 - Fim");
        Console.Write("Informe uma opção: ");
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return op;
    }
    public static void AlunoListar()
    {
        Console.WriteLine("----- Lista de Alunos -----");
        Aluno[] cs = naluno.Listar();
        if (cs.Length == 0)
        {
            Console.WriteLine("Nenhum aluno cadastrado");
            return;
        }
        foreach (Aluno c in cs) Console.WriteLine(c);
        Console.WriteLine();
    }

    public static void AlunoInserir()
    {
        Console.WriteLine("----- Inserção de Alunos -----");
        Console.Write("Informe um código para aluno: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descrição para o aluno: ");
        string descricao = Console.ReadLine();
        Console.Write("Informe o nome: ");
        string nome = Console.ReadLine();
        Console.Write("Informe o endereço: ");
        string endereco = Console.ReadLine();
        Console.Write("Informe o telefone: ");
        int telefone = int.Parse(Console.ReadLine());
        // Instanciar a classe de aluno
        Aluno c = new Aluno(id, descricao, nome, endereco, telefone);
        // Inserção de aluno
        naluno.Inserir(c);
    }

    public static void AlunoAtualizar()
    {
        Console.WriteLine("----- Atualização de Alunos -----");
      AlunoListar();
        Console.Write("Informe um código de aluno para alterar: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descrição de aluno: ");
        string descricao = Console.ReadLine();
        // Instanciar a classe de Aluno
        Aluno c = new Aluno(id, descricao);
        // Inserção de Aluno
        naluno.Atualizar(c);

    }

    public static void AlunoExcluir()
    {
        Console.WriteLine("----- Exclusão de Alunos -----");
      AlunoListar();
        Console.Write("Informe um código de aluno para excluir: ");
        int id = int.Parse(Console.ReadLine());
        // Procurar o aluno com esse id
        Aluno c = naluno.Listar(id);
        // Exclui o aluno do cadastrado
        naluno.Excluir(c);

    }


    public static void MatriculaListar()
    {
        Console.WriteLine("----- Lista de Matriculas -----");
        Matricula[] ps = nmatricula.Listar();
        if (ps.Length == 0)
        {
            Console.WriteLine("Nenhuma matricula cadastrada");
            return;
        }
        foreach (Matricula p in ps) Console.WriteLine(p);
        Console.WriteLine();
    }
    public static void MatriculaInserir()
    {
        Console.WriteLine("----- Inserção de matriculas -----");
        Console.Write("Informe um código para a matricula: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descrição: ");
        string descricao = Console.ReadLine();

        AlunoListar();
        Console.Write("Informe o código do aluno com a matricula: ");
        int idaluno = int.Parse(Console.ReadLine());
        // Seleciona a categoria a partir do id
        Aluno c = naluno.Listar(idaluno);
        // Instanciar a classe de Produto
        Matricula p = new Matricula(id, descricao, c);
        // Inserção da produto
        nmatricula.Inserir(p);
    }

    public static void MatriculaAtualizar()
    {
       Console.WriteLine("----- Atualização de matriculas -----");
       MatriculaListar();
        Console.Write("Informe um código para a matricula: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descrição: ");
        string descricao = Console.ReadLine();

        AlunoListar();
        Console.Write("Informe o código do aluno para a matricula: ");
        int idaluno = int.Parse(Console.ReadLine());
        // Seleciona o aluno a partir do id
        Aluno c = naluno.Listar(idaluno);
        // Instanciar a classe de Matricula
        Matricula p = new Matricula(id, descricao, c);
        // Atualização de matricula
        nmatricula.Atualizar(p);

    }

    public static void MatriculaExcluir()
    {
      Console.WriteLine("----- Exclusão de Matriculas -----");
      MatriculaListar();
        Console.Write("Informe um código de matricula para excluir: ");
        int id = int.Parse(Console.ReadLine());
        // Procurar a matricula com esse id
        Matricula p = nmatricula.Listar(id);
        // Exclui a matricula do cadastrado
        nmatricula.Excluir(p);

    }

    public static void CursoListar() {
    Console.WriteLine("----- Lista de Cursos -----");
    // Lista os cursos
    List<Curso> cs = ncurso.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhum curso cadastrado");
      return;
    }
    foreach(Curso c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }

  public static void CursoInserir() {
    Console.WriteLine("----- Inserção de Cursos -----");
        Console.Write("Informe um código para curso: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Informe uma descrição para o curso: ");
        string descricao = Console.ReadLine();
        Console.Write("Informe a duração do curso: ");
        string duracao = Console.ReadLine();
        Console.Write("Informe o turno: ");
        string turno = Console.ReadLine();
        Console.Write("Informe o valor da mensalidade: ");
        double valormensalidade = double.Parse(Console.ReadLine());
        Console.Write("Informe o valor da matricula: ");
        double valormatricula = double.Parse(Console.ReadLine());
        // Instanciar a classe de Curso
        Curso c = new Curso { Id = id, Descricao = descricao, Duracao = duracao, Turno = turno, ValorMensalidade = valormensalidade, ValorMatricula = valormatricula };
        // Inserção de Curso
        ncurso.Inserir(c);
  }

  public static void CursoAtualizar() {
    Console.WriteLine("----- Atualização de Cursos -----");
    AlunoListar();
    Console.Write("Informe o código do curso a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição para o curso: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a duração do curso: ");
    string duracao = Console.ReadLine();
    Console.Write("Informe o turno: ");
    string turno = Console.ReadLine();
    Console.Write("Informe o valor da mensalidade: ");
    double valormensalidade = double.Parse(Console.ReadLine());
    Console.Write("Informe o valor da matricula: ");
    double valormatricula = double.Parse(Console.ReadLine());
    // Instanciar a classe de Curso
    Curso c = new Curso { Id = id, Descricao = descricao, Duracao = duracao, Turno = turno, ValorMensalidade = valormensalidade, ValorMatricula = valormatricula };
    // Inserção de Curso
    ncurso.Inserir(c);
  }

  public static void CursoExcluir() {
    Console.WriteLine("----- Exclusão de Cursos -----");
    AlunoListar();
    Console.Write("Informe o código do curso a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o curso com esse id
    Curso c = ncurso.Listar(id);
    // Exclui o curso do cadastro
    ncurso.Excluir(c);
  }
}

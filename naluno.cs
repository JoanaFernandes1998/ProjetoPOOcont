using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class NAluno
{
    private Aluno[] alunos = new Aluno[10];
    private int nc;

    public Aluno[] Listar()
    {
        Aluno[] c = new Aluno[nc];
        Array.Copy(alunos, c, nc);
        return c;
    }

    public Aluno Listar(int id)
    {
        for (int i = 0; i < nc; i++)
            if (alunos[i].GetId() == id) return alunos[i];
        return null;
    }

    public void Inserir(Aluno c)
    {
        if (nc == alunos.Length)
        {
            Array.Resize(ref alunos, 2 * alunos.Length);
        }
        alunos[nc] = c;
        nc++;
    }

    public void Atualizar(Aluno c)
    {
        //Localizar no vetor o aluno que possui o id informado no parametro aluno
        Aluno c_atual = Listar(c.GetId());
        if (c_atual == null) return;
        // Aterar os dados do aluno
        c_atual.SetDescricao(c.GetDescricao());
    }

    private int Indice(Aluno c)
    {
        for (int i = 0; i < nc; i++)
            if (alunos[i] == c) return i;
        return -1;
    }

    public void Excluir(Aluno c)
    {
      // Verifica se o aluno está cadastrado
      int n = Indice(c);
      if (n == -1) return;
      for (int i = n; i < nc - 1; i++)
          alunos[i] = alunos[i + 1];
      nc--;
      // Recuperar a lista de matriculas do aluno
      Matricula[] ps = c.MatriculaListar();
      foreach (Matricula p in ps) p.SetAluno(null);

    }

}

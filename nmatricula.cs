using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class NMatricula
{
    private Matricula[] matriculas = new Matricula[10];
    private int np;

    public Matricula[] Listar()
    {
        Matricula[] p = new Matricula[np];
        Array.Copy(matriculas, p, np);
        return p;
    }

    public Matricula Listar(int id)
    {
        for (int i = 0; i < np; i++)
            if (matriculas[i].GetId() == id) return matriculas[i];
        return null;
    }

    public void Inserir(Matricula p)
    {
        if (np == matriculas.Length)
        {
            Array.Resize(ref matriculas, 2 * matriculas.Length);
        }
        matriculas[np] = p;
        np++;
        // Recuperar a categoria da matricula que está sendo inserido
        Aluno c = p.GetAluno();
        // Se a matricula tem um categoria, insere ele nessa categoria
        if (c != null) c.MatriculaInserir(p);
    }

     public void Atualizar(Matricula p) {
    // Localiza no vetor a matricula que possui o id informado no parametro p
    // Se não encontrar a matricula com o Id, retorna sem alterar
    Matricula p_atual = Listar(p.GetId());
    if (p_atual == null) return;
    // Alterar os dados da matricula
    p_atual.SetDescricao(p.GetDescricao());
    // Exclui a matricula do atual aluno
    if (p_atual.GetAluno() != null) 
      p_atual.GetAluno().MatriculaExcluir(p_atual);
    // Atualiza a categoria da matricula
    p_atual.SetAluno(p.GetAluno());
    // Insere a nova matricula do aluno
    if (p_atual.GetAluno() != null)
      p_atual.GetAluno().MatriculaInserir(p_atual);
  }

  private int Indice(Matricula p) {
    // Retorna o índice da matricula no vetor
    for(int i = 0; i < np; i++)
      if (matriculas[i] == p) return i;
    return -1;  
  }

  public void Excluir(Matricula p) {
    // Verifica se a matricula está cadastrado
    int n = Indice(p);
    // Se não encontrar a matricula, retorna sem alterar
    if (n == -1) return;
    // Desloca as matriculas no vetor para substituir o índice da matricula excluído
    // Remove a matricula do vetor
    for (int i = n; i < np - 1; i++)
      matriculas[i] = matriculas[i + 1];
    // Decrementa o contador de matriculas
    np--;
    // Remove a matricula do aluno
    Aluno c = p.GetAluno();
    if (c != null) c.MatriculaExcluir(p);  
  }

}

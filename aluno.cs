using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Aluno
{
    private int id;
    private string descricao;
    private string nome;
    private string endereco;
    private int telefone;
    private Matricula[] matriculas = new Matricula[10];
    private int np;
    public Aluno(int id, string descricao, string nome, string endereco, int telefone)
    {
        this.id = id;
        this.descricao = descricao;
        this.nome = nome;
        this.endereco = endereco;
        this.telefone = telefone;
    }

    public Aluno(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
    }

    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetDescricao(string descricao)
    {
        this.descricao = descricao;
    }
    public void SetNome(string nome)
    {
        this.nome = nome;
    }
    public void SetEndereco(string endereco)
    {
        this.endereco = endereco;
    }
    public void SetTelefone(int telefone)
    {
        this.telefone = telefone;
    }
    public int GetId()
    {
        return id;
    }
    public string GetDescricao()
    {
        return descricao;
    }
    public string GetNome()
    {
        return nome;
    }
    public string GetEndereco()
    {
        return endereco;
    }
    public int GetTelefone()
    {
        return telefone;
    }
    public Matricula[] MatriculaListar()
    {
        Matricula[] c = new Matricula[np];
        Array.Copy(matriculas, c, np);
        return c;
    }
    public void MatriculaInserir(Matricula p)
    {
        if (np == matriculas.Length)
        {
            Array.Resize(ref matriculas, 2 * matriculas.Length);
        }
        matriculas[np] = p;
        np++;
    }
    private int MatriculaIndice(Matricula p){
      // Recupera o indice de uma matricula no vetor
      for (int i = 0; i < np; i++)
        if (matriculas[i] == p) return i;
      return -1;
    }
    public void MatriculaExcluir(Matricula p){
      int n = MatriculaIndice(p);
      if (n == -1) return;
      for (int i = n; i < np - 1; i++)
        matriculas[i] = matriculas[i + 1];
      np--;
    }
    public override string ToString()
    {
        return id + " - " + nome + " - Nº matriculas: " + np;
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class Matricula
{
    private int id;
    private string descricao;
    private Aluno aluno;
    public Matricula(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
    }
    public Matricula(int id, string descricao, Aluno aluno) : this(id, descricao)
    {
        this.aluno = aluno;
    }
    public void SetId(int id)
    {
        this.id = id;
    }
    public void SetDescricao(string descricao)
    {
        this.descricao = descricao;
    }
    public void SetAluno(Aluno aluno)
    {
        this.aluno = aluno;
    }
    public int GetId()
    {
        return id;
    }
    public string GetDescricao()
    {
        return descricao;
    }

    public Aluno GetAluno()
    {
        return aluno;
    }
    public override string ToString()
    {
        if (aluno == null)
            return id + " - " + descricao;
        else
            return id + " - " + descricao + " - " + aluno.GetDescricao();
    }
}

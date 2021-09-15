using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class NCurso {
  private List<Curso> cursos = new List<Curso>();

  public List<Curso> Listar() {
    // Retorna uma listas com os cursos cadastrados
    cursos.Sort();
    return cursos;
  }

  public Curso Listar(int id) {
    // Localiza na lista o curso com o id informado
    for (int i = 0; i < cursos.Count; i++)
      if (cursos[i].Id == id) return cursos[i];
    return null;  
  }

  public void Inserir(Curso c) {
    // Gera o id do curso
    int max = 0;
    foreach(Curso obj in cursos)
      if (obj.Id > max) max = obj.Id;
    c.Id = max + 1;      
    // Insere o curso na lista
    cursos.Add(c);
  } 

  public void Atualizar(Curso c) {
    // Localiza na lista o curso que possui o id informado no parametro c
    Curso c_atual = Listar(c.Id);
    // Se não encontrar o curso com o Id, retorna sem alterar
    if (c_atual == null) return;
    // Altera os dados do curso
    c_atual.Descricao = c.Descricao;
    c_atual.Duracao = c.Duracao;
    c_atual.Turno = c.Turno;
    c_atual.ValorMensalidade = c.ValorMensalidade;
    c_atual.ValorMatricula = c.ValorMatricula;
  } 

  public void Excluir(Curso c) {
    // Remove o curso da lista
    if (c != null) cursos.Remove(c);
  } 
}

class Curso : IComparable<Curso> {
  // Propriedade do Curso
  public int Id { get; set; }
  public string Descricao { get; set; }
  public string Duracao { get; set; }
  public string Turno { get; set; }
  public double ValorMensalidade { get; set; }
  public double ValorMatricula { get; set; }
  public int CompareTo(Curso obj) {
    return this.Descricao.CompareTo(obj.Descricao);
  }
  public override string ToString() {
    return Id + " - " + Descricao + " - " + Duracao + " - " + Turno + " - " + ValorMensalidade + " - " + ValorMatricula;
  }
}

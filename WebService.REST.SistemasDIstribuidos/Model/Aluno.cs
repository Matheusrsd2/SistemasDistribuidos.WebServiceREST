using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.REST.SistemasDIstribuidos.Model
{
    public class Aluno
    {
        public string NomeAluno { get; set; }
        public string Curso { get; set; }
        public string Semestre { get; set; }
        public int RA { get; set; }
        public string CPF { get; set; }
        public string Cidade { get; set; }

        static List<Aluno> alunos = new List<Aluno>();

        public List<Aluno> ListarAlunos()
        {
            return alunos;
        }

        public Aluno ObterAlunoPeloNome(string nome)
        {
            Aluno aluno = alunos.Find(x => x.NomeAluno == nome);
            return aluno;
        }

        public void IncluirAluno(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        public void RemoverAluno(string nome)
        {
            Aluno aluno = alunos.Find(x => x.NomeAluno == nome);
            alunos.Remove(aluno);
        }

        public void EditarAluno(string nome, Aluno model)
        {
            Aluno aluno = alunos.FirstOrDefault(a => a.NomeAluno == nome);
            if (aluno != null)
            {
                aluno.NomeAluno = model.NomeAluno;
                aluno.Curso = model.Curso;
                aluno.Semestre = model.Semestre;
                aluno.RA = model.RA;
                aluno.CPF = model.CPF;
                aluno.Cidade = model.Cidade;
            }
        }       
    }
}


using System;
using System.Collections.Generic;

namespace CursoNetCoreQualyteam.Dominio
{
    public class Receita
    {
        public Receita(string titulo, string descricao, string ingredientes, string preparacao, string urlDaImagem)
        {
            Id = Guid.NewGuid();
            Titulo = titulo;
            Descricao = descricao;
            Ingredientes = ingredientes;
            Preparacao = preparacao;
            UrlDaImagem = urlDaImagem;
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Ingredientes { get; set; }
        public string Preparacao { get; set; }
        public string UrlDaImagem { get; set; }
    }
}
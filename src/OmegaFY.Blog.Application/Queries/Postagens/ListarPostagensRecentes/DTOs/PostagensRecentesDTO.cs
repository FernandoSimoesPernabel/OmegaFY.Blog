﻿using System;

namespace OmegaFY.Blog.Application.Queries.Postagens.ListarPostagensRecentes.DTOs
{

    public class PostagensRecentesDTO
    {

        public Guid Id { get; set; }

        public string Autor { get; set; }

        public string Titulo { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataModificacao { get; set; }

        public PostagensRecentesDTO()
        {

        }

        public PostagensRecentesDTO(Guid id, string autor, string titulo, DateTime dataCriacao, DateTime? dataModificacao)
        {
            Id = id;
            Autor = autor;
            Titulo = titulo;
            DataCriacao = dataCriacao;
            DataModificacao = dataModificacao;
        }

    }

}

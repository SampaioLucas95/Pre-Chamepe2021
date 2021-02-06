namespace CoreAdmChamepe.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Evento
    {
        public Evento()
        {
            this.ParticipanteEventoes = new HashSet<ParticipanteEvento>();
        }

        [Display(Name = "Evento")]
        public int EventoId { get; set; }
        [Display(Name = "Qual o Evento?")]
        public string EventoDescricao { get; set; }
        [Display(Name = "Data do Evento")]
        public System.DateTime EventoData { get; set; }
        [Display(Name = "Data Cadastro")]
        public System.DateTime EventoDataCadastro { get; set; }

        [Display(Name = "Usuário")]
        public string UserId { get; set; }
        [Display(Name = "Limite de Pessoas")]
        public int EventoLimitePessoas { get; set; }

        public virtual ICollection<ParticipanteEvento> ParticipanteEventoes { get; set; }
    }
}

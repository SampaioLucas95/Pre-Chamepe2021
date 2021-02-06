
namespace CoreAdmChamepe.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Igreja
    {
        public Igreja()
        {
            this.ParticipanteEventoes = new HashSet<ParticipanteEvento>();
        }

        [Display(Name = "Igreja")]
        public int IgrejaId { get; set; }
        [Display(Name = "Igreja")]
        public string IgrejaDescricao { get; set; }

        [Display(Name = "Ativa?")]
        public bool IgrejaStatus { get; set; }
        [Display(Name = "Nome Do Pastor")]
        public string IgrejaPastorDescricao { get; set; }
        [Display(Name = "Contato Telefônico")]
        public string IgrejaContrato { get; set; }
        [Display(Name = "Setor 1, 2, 3 ou 4?")]
        public int IgrejaSetor { get; set; }

        [Display(Name = "Data Cadastro")]
        public System.DateTime IgrejaDataCadastro { get; set; }
        [Display(Name = "Usuário")]
        public string UserId { get; set; }

        public virtual ICollection<ParticipanteEvento> ParticipanteEventoes { get; set; }
    }
}
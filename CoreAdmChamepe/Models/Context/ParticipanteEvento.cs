namespace CoreAdmChamepe.Models.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ParticipanteEvento
    {        
        public int ParticipanteEventoId { get; set; }
        [Display(Name ="Nome Completo")]
        [Required(ErrorMessage = "Informe o Nome Completo")]
        [MinLength(length: 10,ErrorMessage = "Informe o nome completo!")]
        public string PartcipanteNomeCompleto { get; set; }
        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]
        [Validation.CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string ParticipanteRg { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string ParticipanteEmail { get; set; }
        [Display(Name = "Nº Telefone")]
        public string ParticipanteTelefone { get; set; }

        [Display(Name = "Idade")]
        public int ParticipanteIdade { get; set; }
        [Display(Name = "Igreja")]
        [Required(ErrorMessage = "Selecione a igreja do participante!")]
        public int IgrejaId { get; set; }
        [Display(Name = "Evento")]
        [Required(ErrorMessage = "Selecione o evento!")]
        public int EventoId { get; set; }
        [Display(Name = "Usuário")]
        public string UserId { get; set; }
        
        public virtual Evento Evento { get; set; }        
        public virtual Igreja Igreja { get; set; }
    }
}

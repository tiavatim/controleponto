using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePonto.Models
{
    [Table("TabFuncionario")]
    public class Funcionario
    {

        [Column("id")]
        [Display(Name = "id")]
        public int id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF")]
        public String CPF { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public String Email { get; set; }


        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public String Telefone { get; set; }


        [Column("Habilitacao")]
        [Display(Name = "Habilitacao")]
        public bool Habilitacao { get; set; }

        [Column("Categoria")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }


        [Column("LinguaEstrangeira")]
        [Display(Name = "Língua Estrangeira")]
        public string LinguaEstrangeira { get; set; }


        [Column("Estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("CEP")]
        [Display(Name = "CEP")]
       

      //  [RegularExpression(@"^\d{5}-\d{3}$",
        // ErrorMessage = "CEP Inválido")]
        public string CEP { get; set; }


        [Column("Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Column("Numero")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }


        [Column("Complemento")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Column("Cargo")]
        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Column("SalarioProposto")]
        [Display(Name = "Salario Proposto")]
        public string SalarioProposto { get; set; }

        [Column("DiadaSemana")]
        [Display(Name = "Dia da Semana")]
        public string DiadaSemana { get; set; }

        [Column("HoraInicio")]
        [Display(Name = "Hora Inicio")]
        public string HoraInicio { get; set; }


        [Column("HoraFim")]
        [Display(Name = "Hora Fim")]
        public string HoraFim { get; set; }

        [Column("TempodeDescanso")]
        [Display(Name = "Tempo de Descanso")]
        public string TempodeDescanso { get; set; }


        [Column("CargaHoraria")]
        [Display(Name = "Carga Horária (h)")]
        public string CargaHoraria { get; set; }

        [Column("CargaHorariaSEmanal")]
        [Display(Name = "Carga Horária Semanal")]
        public string CargaHorariaSEmanal { get; set; }




    

}
}

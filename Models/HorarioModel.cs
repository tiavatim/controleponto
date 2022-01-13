using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePonto.Models
{
    [Table("TabHorario")]
    public class HorarioModel
    {
        [Key]
        [Column("HorarioID")]
        [Display(Name = "HorarioID")]
        public int HorarioID { get; set; }

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
        public int? TempodeDescanso { get; set; }


        [Column("CargaHoraria")]
        [Display(Name = "Carga Horária (h)")]
        public string CargaHoraria { get; set; }

        [Column("CargaHorariaSEmanal")]
        [Display(Name = "Carga Horária Semanal")]
        public string CargaHorariaSEmanal { get; set; }


        [Display(Name = "FuncionarioID")]
        [ForeignKey("FuncionarioID")]
        [Column(Order = 1)]
        public int FuncionarioID { get; set; }

        public virtual Funcionario Funcionario { get; set; }
}




    
}

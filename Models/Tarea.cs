using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace projectTasks1.Models
{
    public class Tarea
    {
        public Guid TareaId {get; set;}
        public Guid CategoriaId {get; set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public Prioridad PrioridadTarea {get; set;}
        public DateTime FechaCreacion {get; set;}
        public virtual Categoria categoria {get; set;}
        public string Resume {get;set;}
    }

    public enum Prioridad {
        baja,
        media,
        alta
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exercicio_17_10_19
{
    using System;
    using System.Collections.Generic;
    
    public partial class Academico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Academico()
        {
            this.Materia = new HashSet<Materia>();
        }
    
        public int Id_Academico { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public Nullable<bool> Excluido { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materia> Materia { get; set; }
    }
}
using System;

namespace CompAndDel
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede retornar la misma imagen o una nueva imagen
    /// creada por él.
    /// </remarks>
    public interface IFilterConditional: IFilter
    {
        /// <summary>
        /// Atributo de si se encuentra lo que se busca
        /// </summary>
        /// <value>Valor bool de si se cumple con el criterio o no</value>
        public bool IsValid {get; set;}
     
    }
}

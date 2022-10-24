using System;

namespace CompAndDel
{
    /// <summary>
    /// Un filtro que recibe, procesa la imagen y carga una propiedad con el resultado del filtro.
    /// creada por él.
    /// </remarks>
    public interface IConditionalFilter: IFilter
    {
        
        public bool RestulFilter{get;}
    }
}

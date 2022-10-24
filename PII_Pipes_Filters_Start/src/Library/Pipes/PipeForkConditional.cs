using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using CompAndDel.Filters;


namespace CompAndDel.Pipes
{
    public class PipeForkConditional : IPipe
    {
        IPipe next2Pipe;
        IPipe nextPipe;

        private FilterConditinalFace filterConditional;

        protected string pathImage {get; set;}

          
        /// <summary>
        /// La cañería recibe una imagen, la clona y envìa la original por una cañeria y la clonada por otra.
        /// </summary>
        /// <param name="tipoFiltro">Tipo de filtro que se debe aplicar sobre la imagen. Se crea un nuevo filtro con los parametros por defecto</param>
        /// <param name="nextPipe">Siguiente cañeria con filtro</param>
        /// <param name="next2Pipe">Siguiente cañeria sin filtro</param>
        public PipeForkConditional(IPipe nextPipe, IPipe next2Pipe, string pathName) 
        {
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe;  
            this.pathImage = pathName;   
            this.filterConditional = new FilterConditinalFace(pathImage);
        }
        
        /// <summary>
        /// La cañería recibe una imagen, construye un duplicado de la misma, 
        /// y envía la original por una cañería y el duplicado por otra.
        /// </summary>
        /// <param name="picture">imagen a filtrar y enviar a las siguientes cañerías</param>
        public IPicture Send(IPicture picture)
        {
            
            IPicture result = filterConditional.Filter(picture); ;
            if(filterConditional.IsValid == true)
            {
                result = nextPipe.Send(picture);
            }
            else
            {
                result = next2Pipe.Send(picture.Clone());
                
            }
            return result;
        }
    }
}

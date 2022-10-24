using System;
using System.Drawing;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y comprueba si hay una foto o no.
    /// </remarks>
    public class ConditionalFilterFace : IConditionalFilter
    {
        /// Valor lógico de si encuentra o no una cara, el hasFace
        /// </summary>
        /// <value>true o false, si encuentra o no una cara</value>
        public bool ResultFilter { get; private set; }

        protected string pathImage {get; set;}

      

        /// Un filtro que retorna el una imagen sin hacerle nada, pero que establece un valor 
        /// bool en base a si hay una cara o no en la foto.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida solo se guarda, y se retorna sin aplicarle ningún cambio.</returns>
        public IPicture Filter(IPicture image)
        {
            CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
            cog.Recognize(@$"../../Imgs/ImagenAPublicar.jpg");
            if (cog.FaceFound)
            {
                this.ResultFilter =  true;
            }
            else
            {
                this.ResultFilter =  false;
            }
            return image;
        }

       
    }
}

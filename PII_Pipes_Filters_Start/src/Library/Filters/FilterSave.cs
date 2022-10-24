using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterSave : IFilter
    {
        private int paso = 0;
        /// Un filtro que retorna el negativo de la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida solo se guarda, y se retorna sin aplicarle ningún cambio.</returns>
        public IPicture Filter(IPicture image)
        {
            this.paso +=1;
            PictureProvider provider = new PictureProvider();
           provider.SavePicture(image,@$"../../Imgs/Imagen paso {this.paso}.jpg");
            return image;
        }
    }
}
